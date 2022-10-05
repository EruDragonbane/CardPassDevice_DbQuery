using System;
using System.Drawing;
using System.Windows.Forms;

namespace DbDateQuery.WatermarkTextbox
{
    /// <summary>
    /// Projelerde kullanılmak amacıyla vardır. 
    /// Textboxlar için Watermark
    /// </summary>
    public class WatermarkTextbox : TextBox
    {
        private string stringWatermarkText = "";
        Label lbl = new Label();
        public WatermarkTextbox()
        {
            lbl.Click += new EventHandler(Lbl_click);
            lbl.Location = new Point(2, 1);
            lbl.AutoSize = true;
            lbl.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular);
            lbl.BackColor = Color.Transparent;
            lbl.ForeColor = Color.Gray;
            base.Controls.Add(lbl);
        }
        public Font WatermarkTextFont
        {
            get
            {
                return lbl.Font;
            }
            set
            {
                lbl.Font = value;
            }
        }
        public string WatermarkText
        {
            get
            {
                return stringWatermarkText;
            }
            set
            {
                this.stringWatermarkText = value;
                base.ForeColor = Color.Black;
                lbl.Text = stringWatermarkText;
                if (value != "")
                    base.Controls.Add(lbl);
                lbl.Location = new Point(2, 1);
            }
        }
        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            if (base.Text == "")
                base.Controls.Add(lbl);
        }
        public void Lbl_click(object sender, EventArgs e)
        {
            base.Focus();
        }
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            if (base.Text != "")
                base.Controls.Remove(lbl);
            else
                if (this.WatermarkText != "")
                base.Controls.Add(lbl);
        }
    }
}
