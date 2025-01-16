namespace CarCareSystem
{
    partial class 工單查詢
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(工單查詢));
            Lbl_查詢關鍵字 = new Label();
            Tbx_關鍵字 = new TextBox();
            DGV_工單列表 = new DataGridView();
            Lbl_標題 = new Label();
            DTP_起始時間 = new DateTimePicker();
            DTP_結束時間 = new DateTimePicker();
            Lbl_波浪符號 = new Label();
            panel2 = new Panel();
            panel3 = new Panel();
            ((System.ComponentModel.ISupportInitialize)DGV_工單列表).BeginInit();
            SuspendLayout();
            // 
            // Lbl_查詢關鍵字
            // 
            Lbl_查詢關鍵字.AutoSize = true;
            Lbl_查詢關鍵字.BackColor = Color.LemonChiffon;
            Lbl_查詢關鍵字.Font = new Font("標楷體", 16F);
            Lbl_查詢關鍵字.Location = new Point(12, 154);
            Lbl_查詢關鍵字.Name = "Lbl_查詢關鍵字";
            Lbl_查詢關鍵字.Size = new Size(142, 22);
            Lbl_查詢關鍵字.TabIndex = 0;
            Lbl_查詢關鍵字.Text = "查詢關鍵字：";
            // 
            // Tbx_關鍵字
            // 
            Tbx_關鍵字.Font = new Font("標楷體", 16F);
            Tbx_關鍵字.Location = new Point(148, 143);
            Tbx_關鍵字.Name = "Tbx_關鍵字";
            Tbx_關鍵字.Size = new Size(724, 33);
            Tbx_關鍵字.TabIndex = 2;
            Tbx_關鍵字.TextChanged += Tbx_關鍵字_TextChanged;
            // 
            // DGV_工單列表
            // 
            DGV_工單列表.AllowUserToAddRows = false;
            DGV_工單列表.AllowUserToDeleteRows = false;
            DGV_工單列表.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGV_工單列表.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_工單列表.Location = new Point(12, 182);
            DGV_工單列表.Name = "DGV_工單列表";
            DGV_工單列表.Size = new Size(860, 357);
            DGV_工單列表.TabIndex = 3;
            DGV_工單列表.CellClick += DGV_工單列表_CellClick;
            DGV_工單列表.CellContentClick += DGV_工單列表_CellContentClick;
            DGV_工單列表.CellPainting += DGV_工單列表_CellPainting;
            // 
            // Lbl_標題
            // 
            Lbl_標題.AutoSize = true;
            Lbl_標題.BackColor = Color.LightGreen;
            Lbl_標題.Font = new Font("標楷體", 30F, FontStyle.Bold);
            Lbl_標題.Location = new Point(238, 9);
            Lbl_標題.Name = "Lbl_標題";
            Lbl_標題.Size = new Size(469, 80);
            Lbl_標題.TabIndex = 26;
            Lbl_標題.Text = "華晟汽車維修廠(原麥力)\r\n工作單查詢\r\n";
            Lbl_標題.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // DTP_起始時間
            // 
            DTP_起始時間.Font = new Font("標楷體", 16F);
            DTP_起始時間.Format = DateTimePickerFormat.Custom;
            DTP_起始時間.Location = new Point(258, 104);
            DTP_起始時間.Name = "DTP_起始時間";
            DTP_起始時間.Size = new Size(200, 33);
            DTP_起始時間.TabIndex = 27;
            DTP_起始時間.ValueChanged += DTP_日期_ValueChanged;
            // 
            // DTP_結束時間
            // 
            DTP_結束時間.Font = new Font("標楷體", 16F);
            DTP_結束時間.Format = DateTimePickerFormat.Custom;
            DTP_結束時間.Location = new Point(491, 104);
            DTP_結束時間.Name = "DTP_結束時間";
            DTP_結束時間.Size = new Size(200, 33);
            DTP_結束時間.TabIndex = 28;
            DTP_結束時間.ValueChanged += DTP_日期_ValueChanged;
            // 
            // Lbl_波浪符號
            // 
            Lbl_波浪符號.AutoSize = true;
            Lbl_波浪符號.Font = new Font("標楷體", 16F);
            Lbl_波浪符號.Location = new Point(464, 112);
            Lbl_波浪符號.Name = "Lbl_波浪符號";
            Lbl_波浪符號.Size = new Size(21, 22);
            Lbl_波浪符號.TabIndex = 29;
            Lbl_波浪符號.Text = "~";
            // 
            // panel2
            // 
            panel2.BackColor = Color.LemonChiffon;
            panel2.Location = new Point(-38, 98);
            panel2.Name = "panel2";
            panel2.Size = new Size(961, 504);
            panel2.TabIndex = 73;
            // 
            // panel3
            // 
            panel3.BackColor = Color.LightGreen;
            panel3.Location = new Point(-35, -16);
            panel3.Name = "panel3";
            panel3.Size = new Size(949, 123);
            panel3.TabIndex = 74;
            // 
            // 工單查詢
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 551);
            Controls.Add(Lbl_波浪符號);
            Controls.Add(DTP_結束時間);
            Controls.Add(DTP_起始時間);
            Controls.Add(Lbl_標題);
            Controls.Add(DGV_工單列表);
            Controls.Add(Tbx_關鍵字);
            Controls.Add(Lbl_查詢關鍵字);
            Controls.Add(panel2);
            Controls.Add(panel3);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "工單查詢";
            Text = "工單查詢";
            ((System.ComponentModel.ISupportInitialize)DGV_工單列表).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Lbl_查詢關鍵字;
        private TextBox Tbx_關鍵字;
        private DataGridView DGV_工單列表;
        private Label Lbl_標題;
        private DateTimePicker DTP_起始時間;
        private DateTimePicker DTP_結束時間;
        private Label Lbl_波浪符號;
        private Panel panel2;
        private Panel panel3;
    }
}