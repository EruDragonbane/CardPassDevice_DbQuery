namespace DbDateQuery.QueryDate
{
    partial class QueryDate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.GetQueryButton = new System.Windows.Forms.Button();
            this.FirstDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.LastDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.Location = new System.Drawing.Point(50, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "İlk Tarih:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label2.Location = new System.Drawing.Point(50, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Son Tarih:";
            // 
            // GetQueryButton
            // 
            this.GetQueryButton.Location = new System.Drawing.Point(50, 160);
            this.GetQueryButton.Name = "GetQueryButton";
            this.GetQueryButton.Size = new System.Drawing.Size(230, 27);
            this.GetQueryButton.TabIndex = 3;
            this.GetQueryButton.Text = "Sorguyu Çıkart";
            this.GetQueryButton.UseVisualStyleBackColor = true;
            this.GetQueryButton.Click += new System.EventHandler(this.GetQueryButton_Click);
            // 
            // FirstDateTimePicker
            // 
            this.FirstDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.FirstDateTimePicker.Location = new System.Drawing.Point(50, 55);
            this.FirstDateTimePicker.Name = "FirstDateTimePicker";
            this.FirstDateTimePicker.Size = new System.Drawing.Size(230, 24);
            this.FirstDateTimePicker.TabIndex = 1;
            this.FirstDateTimePicker.ValueChanged += new System.EventHandler(this.FirstDateTimePicker_ValueChanged);
            // 
            // LastDateTimePicker
            // 
            this.LastDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.LastDateTimePicker.Location = new System.Drawing.Point(50, 115);
            this.LastDateTimePicker.Name = "LastDateTimePicker";
            this.LastDateTimePicker.Size = new System.Drawing.Size(230, 24);
            this.LastDateTimePicker.TabIndex = 2;
            // 
            // QueryDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 223);
            this.Controls.Add(this.LastDateTimePicker);
            this.Controls.Add(this.FirstDateTimePicker);
            this.Controls.Add(this.GetQueryButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "QueryDate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giriş Çıkış Sorgusu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QueryDate_FormClosing);
            this.Load += new System.EventHandler(this.QueryDate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button GetQueryButton;
        private System.Windows.Forms.DateTimePicker FirstDateTimePicker;
        private System.Windows.Forms.DateTimePicker LastDateTimePicker;
    }
}