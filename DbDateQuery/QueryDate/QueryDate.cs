using System;
using System.Windows.Forms;
using System.Data;
using System.Linq;

using OfficeOpenXml;
using System.IO;
using System.Drawing;
using OfficeOpenXml.Style;
using System.Collections.Generic;

namespace DbDateQuery.QueryDate
{
    public partial class QueryDate : Form
    {
        public QueryDate()
        {
            InitializeComponent();
        }

        private void QueryDate_Load(object sender, EventArgs e)
        {
            FirstDateTimePicker.MaxDate = DateTime.Now;
            LastDateTimePicker.MinDate = FirstDateTimePicker.Value;
            LastDateTimePicker.MaxDate = DateTime.Now;

        }

        #region Query Date Form Closing Events
        private void QueryDate_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (LoginFormClosing() == false)
            {
                this.FormClosing -= QueryDate_FormClosing;
                Application.Exit();
            }
            else
                e.Cancel = true;
        }


        private MessageBoxTextForQueryDate StringValuesForMessageBox()
        {
            var messageboxText = new MessageBoxTextForQueryDate
            {
                MessageBox_Message = "Çıkış yapmak istediğinizden emin misiniz?",
                MessageBox_Title = "Çıkış Onayı"
            };

            return messageboxText;
        }

        private bool LoginFormClosing()
        {
            var messageBoxText = StringValuesForMessageBox();

            if (MessageBox.Show(
                messageBoxText.MessageBox_Message, messageBoxText.MessageBox_Title,
                MessageBoxButtons.YesNo)
                == DialogResult.Yes)

                return false;
            else
                return true;
        }
        #endregion

        private void FirstDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            LastDateTimePicker.MinDate = FirstDateTimePicker.Value;
        }

        #region Get User NameSurname and Date  Events

        private void GetQueryButton_Click(object sender, EventArgs e)
        {
            GetDataBetweenTwoDates();
        }

        private void GetDataBetweenTwoDates()
        {
            GetQueryButton.Enabled = false;
 
            using (DbDQ.Entity.DbDQContext cntxt = new DbDQ.Entity.DbDQContext())
            {
                DateTime FirstDate =
                    Convert.ToDateTime(FirstDateTimePicker.Value.ToString("dd-MM-yyyy 00:00:00"));
                DateTime LastDate =
                    Convert.ToDateTime(LastDateTimePicker.Value.ToString("dd-MM-yyyy 23:59:59"));

                var bills = (from sokg in cntxt.Tablo4
                             join sok in cntxt.Tablo3
                             on sokg.Tablo3Id equals sok.Id
                             join so in cntxt.Tablo2
                             on sok.Tablo2Id equals so.Id
                             join s in cntxt.Tablo1
                             on so.Id equals s.Id
                             where
                             sokg.GecisDateTime > FirstDate &&
                             sokg.GecisDateTime < LastDate
                             select new BillList()
                             {
                                 AdSoyad = s.AdSoyad,
                                 GecisDateTime = sokg.GecisDateTime
                             }).OrderBy(o => o.AdSoyad).ThenBy(t => t.GecisDateTime).ToList();

                WriteToExcelFromBillList(bills);
            }
        }
        #endregion

        #region Excel 
        private void WriteToExcelFromBillList(List<BillList> bills)
        {
            #region Directory Path
            string excelPath = @"\Tarih Sorguları";
            string excelName = "-GecislerTablosu.xlsx";
            string strPath = CheckDirectory(excelPath, excelName);

            FileInfo fileInfo = new FileInfo(strPath);
            #endregion

            #region Excel
            using (ExcelPackage xlApp = new ExcelPackage(fileInfo))
            {
                try
                {
                    ExcelWorksheet xlWorkSheet = xlApp.Workbook.Worksheets.Add("Sorgu " + (xlApp.Workbook.Worksheets.Count + 1));

                    #region Excel Title and First Data
                    //Excel Title
                    xlWorkSheet.Cells[1, 1].Value = "Kişiye Göre Geçiş Kayıtları";
                    xlWorkSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    xlWorkSheet.Row(1).Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    xlWorkSheet.Row(1).Style.Font.Size = 12;
                    xlWorkSheet.Row(1).Style.Font.Bold = true;
                    xlWorkSheet.Cells["A1:F2"].Merge = true;

                    xlWorkSheet.Column(1).AutoFit();

                    //Önveri
                    ///"Adı Soyadı" Cell
                    xlWorkSheet.Cells[3, 1].Value = "Adı Soyadı:     " + bills.ElementAt(0).AdSoyad.ToString();
                    xlWorkSheet.Cells[3, 1].Style.Font.Size = 10;
                    xlWorkSheet.Cells[3, 1].Style.Font.Name = "Arial";
                    xlWorkSheet.Cells[3, 1].Style.Font.Bold = true;
                    xlWorkSheet.Cells[3, 1, 3, 6].Merge = true;
                    /// "Tarih" Cell
                    xlWorkSheet.Cells[4, 1].Value = "Tarih";
                    xlWorkSheet.Cells[4, 3].Value = "Geçiş Farkları (saat)";
                    xlWorkSheet.Cells[4, 5].Value = "Cihaz";
                    for (int i = 1; i <= 5; i += 2)
                    {
                        xlWorkSheet.Cells[4, i].Style.Font.Size = 9;
                        xlWorkSheet.Cells[4, i].Style.Font.Name = "Arial";
                        xlWorkSheet.Cells[4, i].Style.Font.Bold = true;
                        xlWorkSheet.Cells[4, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        xlWorkSheet.Cells[4, i].Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                        xlWorkSheet.Cells[4, i, 4, i + 1].Merge = true;
                    }
                    #endregion

                    #region Variables
                    string previousNameSurname = bills.ElementAt(0).AdSoyad.ToString();
                    string nextNameSurname;
                    int cellIndex = 0;
                    int dateIndex = 4;
                    DateTime? previousDateTime = null;
                    DateTime? nextDateTime = null;
                    TimeSpan? extResult = null;
                    bool isFirstDate = false;
                    #endregion

                    while (cellIndex < bills.Count)
                    {
                        nextNameSurname = bills.ElementAt(cellIndex).AdSoyad.ToString();

                        if (previousNameSurname == nextNameSurname)
                        {
                            #region Set Date Times
                            if (cellIndex > 0)
                            {
                                previousDateTime = Convert.ToDateTime(bills.ElementAt(cellIndex - 1).GecisDateTime.ToString());
                                nextDateTime = Convert.ToDateTime(bills.ElementAt(cellIndex).GecisDateTime.ToString());

                                extResult = (nextDateTime - previousDateTime);
                            }

                            xlWorkSheet.Cells[dateIndex + 1, 1].Value = bills.ElementAt(cellIndex).GecisDateTime.ToString();
                            xlWorkSheet.Cells[dateIndex + 1, 3].Value = string.Format($"{extResult:hh\\:mm}");

                            for (int i = 1; i <= 5; i += 2)
                                xlWorkSheet.Cells[dateIndex + 1, i, dateIndex + 1, i + 1].Merge = true;

                            xlWorkSheet.Cells[dateIndex + 1, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                            if (isFirstDate == true)
                            {
                                xlWorkSheet.Cells[dateIndex + 1, 3].Value = null;
                                isFirstDate = false;
                            }

                            cellIndex++;
                            dateIndex++;
                            #endregion
                        }
                        else
                        {
                            #region Set New User // NameSurname
                            /// Last Cell of a Record
                            xlWorkSheet.Cells[dateIndex + 1, 1, dateIndex + 1, 6].Merge = true;
                            xlWorkSheet.Cells[dateIndex + 1, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            xlWorkSheet.Cells[dateIndex + 1, 1].Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                            /// "Adı Soyadı" Cell
                            xlWorkSheet.Cells[dateIndex + 2, 1].Value = "Adı Soyadı:     " + bills.ElementAt(cellIndex).AdSoyad.ToString();
                            xlWorkSheet.Cells[dateIndex + 2, 1].Style.Font.Size = 10;
                            xlWorkSheet.Cells[dateIndex + 2, 1].Style.Font.Name = "Arial";
                            xlWorkSheet.Cells[dateIndex + 2, 1].Style.Font.Bold = true;
                            xlWorkSheet.Cells[dateIndex + 2, 1, dateIndex + 2, 6].Merge = true;
                            /// "Tarih" Cell
                            xlWorkSheet.Cells[dateIndex + 3, 1].Value = "Tarih";
                            xlWorkSheet.Cells[dateIndex + 3, 3].Value = "Geçiş Farkları (saat)";
                            xlWorkSheet.Cells[dateIndex + 3, 5].Value = "Cihaz";
                            for (int i = 1; i <= 5; i += 2)
                            {
                                xlWorkSheet.Cells[dateIndex + 3, i].Style.Font.Size = 9;
                                xlWorkSheet.Cells[dateIndex + 3, i].Style.Font.Name = "Arial";
                                xlWorkSheet.Cells[dateIndex + 3, i].Style.Font.Bold = true;
                                xlWorkSheet.Cells[dateIndex + 3, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                xlWorkSheet.Cells[dateIndex + 3, i].Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                                xlWorkSheet.Cells[dateIndex + 3, i, dateIndex + 3, i + 1].Merge = true;
                            }
                            //xlWorkSheet.Column(dateIndex + 3).AutoFit();
                            xlWorkSheet.Column(cellIndex).Width = 20;

                            dateIndex += 3;
                            isFirstDate = true;
                            #endregion
                        }
                        previousNameSurname = nextNameSurname;
                    }

                    byte[] xlAppBytes = xlApp.GetAsByteArray();
                    WriteAllBytesToFile(xlAppBytes, strPath);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }
            GetQueryButton.Enabled = true;
            #endregion
        }

        private string CheckDirectory(string excelPath, string excelName)
        {
            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory).ToString() +
                excelPath))
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory).ToString() +
                excelPath);

            string strPath =
                    Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory).ToString() +
                    excelPath + @"\" +
                    DateTime.Now.ToString("dd-MM-yyyy(HH;mm;ss)") +
                    excelName;

            return strPath;
        }

        private void WriteAllBytesToFile(byte[] xlApp, string strPath)
        {
            FileStream objFileStream = File.Create(strPath);
            objFileStream.Close();
            File.WriteAllBytes(strPath, xlApp);

            CheckDirectoryAndFileAfterWrite(strPath);
        }
        private void CheckDirectoryAndFileAfterWrite(string strPath)
        {
            if(File.Exists(strPath))
                MessageBox.Show("Sorgu oluşturuldu. \n\nMasaüstünde 'Tarih Sorguları' klasörüne kaydedildi.", "Sorgu", MessageBoxButtons.OK);
            else
                MessageBox.Show("Dosya bulunamadı.", "Hata", MessageBoxButtons.OK);
        }
        #endregion
    }
}

public class BillList
{
    public string AdSoyad { get; set; }
    public DateTime? GecisDateTime { get; set; }
}

public class MessageBoxTextForQueryDate
{
    public string MessageBox_Message { get; set; }
    public string MessageBox_Title { get; set; }
}