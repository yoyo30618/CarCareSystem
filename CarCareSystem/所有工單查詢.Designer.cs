namespace CarCareSystem
{
    partial class 所有工單查詢
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            Btn_取消 = new Button();
            DGV_工作單零件 = new DataGridView();
            Lbl_總金額 = new Label();
            Lbl_標題 = new Label();
            Lbl_波浪符號 = new Label();
            DTP_結束時間 = new DateTimePicker();
            DTP_起始時間 = new DateTimePicker();
            Tbx_關鍵字 = new TextBox();
            Lbl_查詢關鍵字 = new Label();
            label1 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            PartName = new DataGridViewTextBoxColumn();
            Quantity = new DataGridViewTextBoxColumn();
            UnitPrice = new DataGridViewTextBoxColumn();
            TotalPrice = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)DGV_工作單零件).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // Btn_取消
            // 
            Btn_取消.Font = new Font("標楷體", 16F);
            Btn_取消.Location = new Point(795, 13);
            Btn_取消.Name = "Btn_取消";
            Btn_取消.Size = new Size(101, 41);
            Btn_取消.TabIndex = 45;
            Btn_取消.Text = "取消";
            Btn_取消.UseVisualStyleBackColor = true;
            Btn_取消.Click += Btn_取消_Click;
            // 
            // DGV_工作單零件
            // 
            DGV_工作單零件.AllowUserToAddRows = false;
            DGV_工作單零件.AllowUserToResizeColumns = false;
            DGV_工作單零件.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGV_工作單零件.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_工作單零件.Columns.AddRange(new DataGridViewColumn[] { PartName, Quantity, UnitPrice, TotalPrice });
            DGV_工作單零件.Location = new Point(36, 38);
            DGV_工作單零件.Name = "DGV_工作單零件";
            DGV_工作單零件.ReadOnly = true;
            DGV_工作單零件.Size = new Size(860, 386);
            DGV_工作單零件.TabIndex = 47;
            // 
            // Lbl_總金額
            // 
            Lbl_總金額.AutoSize = true;
            Lbl_總金額.BackColor = SystemColors.GradientInactiveCaption;
            Lbl_總金額.Font = new Font("標楷體", 16F);
            Lbl_總金額.Location = new Point(475, 32);
            Lbl_總金額.Name = "Lbl_總金額";
            Lbl_總金額.Size = new Size(131, 22);
            Lbl_總金額.TabIndex = 67;
            Lbl_總金額.Text = "總金額：0元";
            // 
            // Lbl_標題
            // 
            Lbl_標題.AutoSize = true;
            Lbl_標題.BackColor = Color.LightGreen;
            Lbl_標題.Font = new Font("標楷體", 25F);
            Lbl_標題.Location = new Point(201, 9);
            Lbl_標題.Name = "Lbl_標題";
            Lbl_標題.Size = new Size(508, 34);
            Lbl_標題.TabIndex = 68;
            Lbl_標題.Text = "華晟汽車維修廠(原麥力) 工作單\r\n";
            Lbl_標題.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Lbl_波浪符號
            // 
            Lbl_波浪符號.AutoSize = true;
            Lbl_波浪符號.BackColor = SystemColors.GradientInactiveCaption;
            Lbl_波浪符號.Font = new Font("標楷體", 16F);
            Lbl_波浪符號.Location = new Point(242, 39);
            Lbl_波浪符號.Name = "Lbl_波浪符號";
            Lbl_波浪符號.Size = new Size(21, 22);
            Lbl_波浪符號.TabIndex = 73;
            Lbl_波浪符號.Text = "~";
            // 
            // DTP_結束時間
            // 
            DTP_結束時間.CalendarFont = new Font("標楷體", 14F);
            DTP_結束時間.Font = new Font("標楷體", 14F);
            DTP_結束時間.Location = new Point(269, 31);
            DTP_結束時間.Name = "DTP_結束時間";
            DTP_結束時間.Size = new Size(200, 30);
            DTP_結束時間.TabIndex = 72;
            DTP_結束時間.ValueChanged += DTP_結束時間_ValueChanged;
            // 
            // DTP_起始時間
            // 
            DTP_起始時間.CalendarFont = new Font("標楷體", 14F);
            DTP_起始時間.Font = new Font("標楷體", 14F);
            DTP_起始時間.Location = new Point(36, 31);
            DTP_起始時間.Name = "DTP_起始時間";
            DTP_起始時間.Size = new Size(200, 30);
            DTP_起始時間.TabIndex = 71;
            DTP_起始時間.ValueChanged += DTP_起始時間_ValueChanged;
            // 
            // Tbx_關鍵字
            // 
            Tbx_關鍵字.Font = new Font("標楷體", 16F);
            Tbx_關鍵字.Location = new Point(148, 55);
            Tbx_關鍵字.Name = "Tbx_關鍵字";
            Tbx_關鍵字.Size = new Size(724, 33);
            Tbx_關鍵字.TabIndex = 70;
            Tbx_關鍵字.TextChanged += Tbx_關鍵字_TextChanged;
            // 
            // Lbl_查詢關鍵字
            // 
            Lbl_查詢關鍵字.AutoSize = true;
            Lbl_查詢關鍵字.BackColor = Color.LemonChiffon;
            Lbl_查詢關鍵字.Font = new Font("標楷體", 16F);
            Lbl_查詢關鍵字.Location = new Point(12, 66);
            Lbl_查詢關鍵字.Name = "Lbl_查詢關鍵字";
            Lbl_查詢關鍵字.Size = new Size(142, 22);
            Lbl_查詢關鍵字.TabIndex = 69;
            Lbl_查詢關鍵字.Text = "查詢關鍵字：";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.GradientInactiveCaption;
            label1.Font = new Font("標楷體", 16F);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(36, 6);
            label1.Name = "label1";
            label1.Size = new Size(186, 22);
            label1.TabIndex = 74;
            label1.Text = "工單累積金額查詢";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.GradientInactiveCaption;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(Lbl_波浪符號);
            panel1.Controls.Add(Btn_取消);
            panel1.Controls.Add(DTP_結束時間);
            panel1.Controls.Add(Lbl_總金額);
            panel1.Controls.Add(DTP_起始時間);
            panel1.Location = new Point(-24, 490);
            panel1.Name = "panel1";
            panel1.Size = new Size(1009, 121);
            panel1.TabIndex = 75;
            // 
            // panel2
            // 
            panel2.BackColor = Color.LemonChiffon;
            panel2.Controls.Add(DGV_工作單零件);
            panel2.Location = new Point(-24, 49);
            panel2.Name = "panel2";
            panel2.Size = new Size(1133, 444);
            panel2.TabIndex = 71;
            // 
            // panel3
            // 
            panel3.BackColor = Color.LightGreen;
            panel3.Location = new Point(-21, -6);
            panel3.Name = "panel3";
            panel3.Size = new Size(959, 69);
            panel3.TabIndex = 70;
            // 
            // PartName
            // 
            dataGridViewCellStyle1.Font = new Font("標楷體", 12F);
            PartName.DefaultCellStyle = dataGridViewCellStyle1;
            PartName.FillWeight = 300F;
            PartName.HeaderText = "零件名稱";
            PartName.Name = "PartName";
            PartName.ReadOnly = true;
            // 
            // Quantity
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Font = new Font("標楷體", 12F);
            Quantity.DefaultCellStyle = dataGridViewCellStyle2;
            Quantity.HeaderText = "數量";
            Quantity.Name = "Quantity";
            Quantity.ReadOnly = true;
            // 
            // UnitPrice
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Font = new Font("標楷體", 12F);
            UnitPrice.DefaultCellStyle = dataGridViewCellStyle3;
            UnitPrice.HeaderText = "零件單價";
            UnitPrice.Name = "UnitPrice";
            UnitPrice.ReadOnly = true;
            // 
            // TotalPrice
            // 
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Font = new Font("標楷體", 12F);
            TotalPrice.DefaultCellStyle = dataGridViewCellStyle4;
            TotalPrice.HeaderText = "總價";
            TotalPrice.Name = "TotalPrice";
            TotalPrice.ReadOnly = true;
            // 
            // 所有工單查詢
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 551);
            Controls.Add(Tbx_關鍵字);
            Controls.Add(Lbl_查詢關鍵字);
            Controls.Add(Lbl_標題);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Controls.Add(panel3);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "所有工單查詢";
            ((System.ComponentModel.ISupportInitialize)DGV_工作單零件).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label Lbl_車輛檔案編號;
        private Button Btn_取消;
        private DataGridView DGV_工作單零件;
        private Label Lbl_總金額;
        private Label Lbl_標題;
        private Label Lbl_波浪符號;
        private DateTimePicker DTP_結束時間;
        private DateTimePicker DTP_起始時間;
        private TextBox Tbx_關鍵字;
        private Label Lbl_查詢關鍵字;
        private Label label1;
        private Panel panel1;
        private Panel panel3;
        private Panel panel2;
        private DataGridViewTextBoxColumn PartName;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridViewTextBoxColumn UnitPrice;
        private DataGridViewTextBoxColumn TotalPrice;
    }
}