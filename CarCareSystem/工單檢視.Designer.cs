namespace CarCareSystem
{
    partial class 工單檢視
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(工單檢視));
            Lbl_標題 = new Label();
            RTB_工作單備註 = new RichTextBox();
            Lbl_工作單備註 = new Label();
            Lbl_里程 = new Label();
            Lbl_日期 = new Label();
            Btn_取消 = new Button();
            DGV_工作單零件 = new DataGridView();
            Lbl_車輛年份 = new Label();
            Lbl_廠牌型式 = new Label();
            Lbl_牌照號碼 = new Label();
            Lbl_車主姓名 = new Label();
            Lbl_行動電話 = new Label();
            Lbl_住家電話 = new Label();
            Lbl_備註 = new Label();
            RTB_備註 = new RichTextBox();
            Lbl_地址 = new Label();
            Lbl_總金額 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            PartName = new DataGridViewTextBoxColumn();
            UnitPrice = new DataGridViewTextBoxColumn();
            Quantity = new DataGridViewTextBoxColumn();
            TotalPrice = new DataGridViewTextBoxColumn();
            Remarks = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)DGV_工作單零件).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // Lbl_標題
            // 
            Lbl_標題.AutoSize = true;
            Lbl_標題.BackColor = Color.LightGreen;
            Lbl_標題.Font = new Font("標楷體", 25F);
            Lbl_標題.Location = new Point(197, 9);
            Lbl_標題.Name = "Lbl_標題";
            Lbl_標題.Size = new Size(508, 34);
            Lbl_標題.TabIndex = 25;
            Lbl_標題.Text = "華晟汽車維修廠(原麥力) 工作單\r\n";
            Lbl_標題.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // RTB_工作單備註
            // 
            RTB_工作單備註.Enabled = false;
            RTB_工作單備註.Font = new Font("標楷體", 14.25F);
            RTB_工作單備註.Location = new Point(12, 483);
            RTB_工作單備註.Name = "RTB_工作單備註";
            RTB_工作單備註.Size = new Size(661, 56);
            RTB_工作單備註.TabIndex = 41;
            RTB_工作單備註.Text = "";
            // 
            // Lbl_工作單備註
            // 
            Lbl_工作單備註.AutoSize = true;
            Lbl_工作單備註.BackColor = SystemColors.GradientInactiveCaption;
            Lbl_工作單備註.Font = new Font("標楷體", 14.25F);
            Lbl_工作單備註.Location = new Point(12, 460);
            Lbl_工作單備註.Name = "Lbl_工作單備註";
            Lbl_工作單備註.Size = new Size(129, 19);
            Lbl_工作單備註.TabIndex = 40;
            Lbl_工作單備註.Text = "工作單備註：";
            // 
            // Lbl_里程
            // 
            Lbl_里程.AutoSize = true;
            Lbl_里程.BackColor = Color.LemonChiffon;
            Lbl_里程.Font = new Font("標楷體", 14.25F);
            Lbl_里程.Location = new Point(422, 164);
            Lbl_里程.Name = "Lbl_里程";
            Lbl_里程.Size = new Size(69, 19);
            Lbl_里程.TabIndex = 38;
            Lbl_里程.Text = "里程：";
            // 
            // Lbl_日期
            // 
            Lbl_日期.AutoSize = true;
            Lbl_日期.BackColor = Color.LemonChiffon;
            Lbl_日期.Font = new Font("標楷體", 14.25F);
            Lbl_日期.Location = new Point(422, 133);
            Lbl_日期.Name = "Lbl_日期";
            Lbl_日期.Size = new Size(69, 19);
            Lbl_日期.TabIndex = 36;
            Lbl_日期.Text = "日期：";
            // 
            // Btn_取消
            // 
            Btn_取消.Font = new Font("標楷體", 14.25F);
            Btn_取消.Location = new Point(679, 500);
            Btn_取消.Name = "Btn_取消";
            Btn_取消.Size = new Size(193, 41);
            Btn_取消.TabIndex = 45;
            Btn_取消.Text = "取消";
            Btn_取消.UseVisualStyleBackColor = true;
            Btn_取消.Click += Btn_取消_Click;
            // 
            // DGV_工作單零件
            // 
            DGV_工作單零件.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGV_工作單零件.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_工作單零件.Columns.AddRange(new DataGridViewColumn[] { PartName, UnitPrice, Quantity, TotalPrice, Remarks });
            DGV_工作單零件.Location = new Point(8, 186);
            DGV_工作單零件.Name = "DGV_工作單零件";
            DGV_工作單零件.Size = new Size(864, 271);
            DGV_工作單零件.TabIndex = 47;
            // 
            // Lbl_車輛年份
            // 
            Lbl_車輛年份.AutoSize = true;
            Lbl_車輛年份.BackColor = Color.LemonChiffon;
            Lbl_車輛年份.Font = new Font("標楷體", 14.25F);
            Lbl_車輛年份.Location = new Point(213, 63);
            Lbl_車輛年份.Name = "Lbl_車輛年份";
            Lbl_車輛年份.Size = new Size(109, 19);
            Lbl_車輛年份.TabIndex = 59;
            Lbl_車輛年份.Text = "車輛年份：";
            // 
            // Lbl_廠牌型式
            // 
            Lbl_廠牌型式.AutoSize = true;
            Lbl_廠牌型式.BackColor = Color.LemonChiffon;
            Lbl_廠牌型式.Font = new Font("標楷體", 14.25F);
            Lbl_廠牌型式.Location = new Point(7, 133);
            Lbl_廠牌型式.Name = "Lbl_廠牌型式";
            Lbl_廠牌型式.Size = new Size(109, 19);
            Lbl_廠牌型式.TabIndex = 57;
            Lbl_廠牌型式.Text = "廠牌型式：";
            // 
            // Lbl_牌照號碼
            // 
            Lbl_牌照號碼.AutoSize = true;
            Lbl_牌照號碼.BackColor = Color.LemonChiffon;
            Lbl_牌照號碼.Font = new Font("標楷體", 14.25F);
            Lbl_牌照號碼.Location = new Point(7, 98);
            Lbl_牌照號碼.Name = "Lbl_牌照號碼";
            Lbl_牌照號碼.Size = new Size(109, 19);
            Lbl_牌照號碼.TabIndex = 55;
            Lbl_牌照號碼.Text = "牌照號碼：";
            // 
            // Lbl_車主姓名
            // 
            Lbl_車主姓名.AutoSize = true;
            Lbl_車主姓名.BackColor = Color.LemonChiffon;
            Lbl_車主姓名.Font = new Font("標楷體", 14.25F);
            Lbl_車主姓名.Location = new Point(7, 63);
            Lbl_車主姓名.Name = "Lbl_車主姓名";
            Lbl_車主姓名.Size = new Size(109, 19);
            Lbl_車主姓名.TabIndex = 49;
            Lbl_車主姓名.Text = "車主姓名：";
            // 
            // Lbl_行動電話
            // 
            Lbl_行動電話.AutoSize = true;
            Lbl_行動電話.BackColor = Color.LemonChiffon;
            Lbl_行動電話.Font = new Font("標楷體", 14.25F);
            Lbl_行動電話.Location = new Point(213, 133);
            Lbl_行動電話.Name = "Lbl_行動電話";
            Lbl_行動電話.Size = new Size(109, 19);
            Lbl_行動電話.TabIndex = 62;
            Lbl_行動電話.Text = "行動電話：";
            // 
            // Lbl_住家電話
            // 
            Lbl_住家電話.AutoSize = true;
            Lbl_住家電話.BackColor = Color.LemonChiffon;
            Lbl_住家電話.Font = new Font("標楷體", 14.25F);
            Lbl_住家電話.Location = new Point(213, 98);
            Lbl_住家電話.Name = "Lbl_住家電話";
            Lbl_住家電話.Size = new Size(109, 19);
            Lbl_住家電話.TabIndex = 61;
            Lbl_住家電話.Text = "住家電話：";
            // 
            // Lbl_備註
            // 
            Lbl_備註.AutoSize = true;
            Lbl_備註.BackColor = Color.LemonChiffon;
            Lbl_備註.Font = new Font("標楷體", 14.25F);
            Lbl_備註.Location = new Point(422, 63);
            Lbl_備註.Name = "Lbl_備註";
            Lbl_備註.Size = new Size(109, 19);
            Lbl_備註.TabIndex = 63;
            Lbl_備註.Text = "車主縮寫：";
            // 
            // RTB_備註
            // 
            RTB_備註.Enabled = false;
            RTB_備註.Font = new Font("標楷體", 14.25F);
            RTB_備註.Location = new Point(442, 39);
            RTB_備註.Name = "RTB_備註";
            RTB_備註.Size = new Size(389, 41);
            RTB_備註.TabIndex = 65;
            RTB_備註.Text = "";
            // 
            // Lbl_地址
            // 
            Lbl_地址.AutoSize = true;
            Lbl_地址.BackColor = Color.LemonChiffon;
            Lbl_地址.Font = new Font("標楷體", 14.25F);
            Lbl_地址.Location = new Point(47, 164);
            Lbl_地址.Name = "Lbl_地址";
            Lbl_地址.Size = new Size(69, 19);
            Lbl_地址.TabIndex = 66;
            Lbl_地址.Text = "地址：";
            // 
            // Lbl_總金額
            // 
            Lbl_總金額.AutoSize = true;
            Lbl_總金額.BackColor = SystemColors.GradientInactiveCaption;
            Lbl_總金額.Font = new Font("標楷體", 14.25F);
            Lbl_總金額.Location = new Point(679, 475);
            Lbl_總金額.Name = "Lbl_總金額";
            Lbl_總金額.Size = new Size(119, 19);
            Lbl_總金額.TabIndex = 67;
            Lbl_總金額.Text = "總金額：0元";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.GradientInactiveCaption;
            panel1.Font = new Font("標楷體", 14.25F);
            panel1.Location = new Point(-57, 458);
            panel1.Name = "panel1";
            panel1.Size = new Size(942, 108);
            panel1.TabIndex = 70;
            // 
            // panel2
            // 
            panel2.BackColor = Color.LemonChiffon;
            panel2.Controls.Add(RTB_備註);
            panel2.Location = new Point(-20, 46);
            panel2.Name = "panel2";
            panel2.Size = new Size(961, 413);
            panel2.TabIndex = 71;
            // 
            // panel3
            // 
            panel3.BackColor = Color.LightGreen;
            panel3.Location = new Point(-17, -2);
            panel3.Name = "panel3";
            panel3.Size = new Size(949, 57);
            panel3.TabIndex = 72;
            // 
            // PartName
            // 
            PartName.FillWeight = 300F;
            PartName.HeaderText = "零件名稱";
            PartName.Name = "PartName";
            PartName.ReadOnly = true;
            // 
            // UnitPrice
            // 
            UnitPrice.HeaderText = "單價";
            UnitPrice.Name = "UnitPrice";
            UnitPrice.ReadOnly = true;
            // 
            // Quantity
            // 
            Quantity.HeaderText = "數量";
            Quantity.Name = "Quantity";
            Quantity.ReadOnly = true;
            // 
            // TotalPrice
            // 
            TotalPrice.HeaderText = "總價";
            TotalPrice.Name = "TotalPrice";
            TotalPrice.ReadOnly = true;
            // 
            // Remarks
            // 
            Remarks.HeaderText = "備註";
            Remarks.Name = "Remarks";
            Remarks.ReadOnly = true;
            // 
            // 工單檢視
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 551);
            Controls.Add(Lbl_總金額);
            Controls.Add(Lbl_地址);
            Controls.Add(Lbl_備註);
            Controls.Add(Lbl_行動電話);
            Controls.Add(Lbl_住家電話);
            Controls.Add(Lbl_車輛年份);
            Controls.Add(Lbl_廠牌型式);
            Controls.Add(Lbl_牌照號碼);
            Controls.Add(Lbl_車主姓名);
            Controls.Add(DGV_工作單零件);
            Controls.Add(Btn_取消);
            Controls.Add(RTB_工作單備註);
            Controls.Add(Lbl_工作單備註);
            Controls.Add(Lbl_里程);
            Controls.Add(Lbl_日期);
            Controls.Add(Lbl_標題);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Controls.Add(panel3);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "工單檢視";
            ((System.ComponentModel.ISupportInitialize)DGV_工作單零件).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label Lbl_標題;
        private Label Lbl_車輛檔案編號;
        private RichTextBox RTB_工作單備註;
        private Label Lbl_工作單備註;
        private Label Lbl_里程;
        private Label Lbl_日期;
        private Button Btn_取消;
        private DataGridView DGV_工作單零件;
        private Label Lbl_車輛年份;
        private Label Lbl_廠牌型式;
        private Label Lbl_牌照號碼;
        private Label Lbl_車主姓名;
        private Label Lbl_行動電話;
        private Label Lbl_住家電話;
        private Label Lbl_備註;
        private RichTextBox RTB_備註;
        private Label Lbl_地址;
        private Label Lbl_總金額;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private DataGridViewTextBoxColumn PartName;
        private DataGridViewTextBoxColumn UnitPrice;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridViewTextBoxColumn TotalPrice;
        private DataGridViewTextBoxColumn Remarks;
    }
}