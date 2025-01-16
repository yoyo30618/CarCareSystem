namespace CarCareSystem
{
    partial class 紀錄工單
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(紀錄工單));
            label1 = new Label();
            Cbx_車輛選擇 = new ComboBox();
            Lbl_標題 = new Label();
            RTB_工作單備註 = new RichTextBox();
            Lbl_工作單備註 = new Label();
            Lbl_里程 = new Label();
            Lbl_日期 = new Label();
            Tbx_里程 = new TextBox();
            Btn_取消 = new Button();
            Btn_儲存 = new Button();
            DGV_工作單零件 = new DataGridView();
            Tbx_車輛選擇 = new TextBox();
            Lbl_車輛年份 = new Label();
            Lbl_廠牌型式 = new Label();
            Lbl_牌照號碼 = new Label();
            Lbl_車主姓名 = new Label();
            Btn_建立新車輛 = new Button();
            Lbl_行動電話 = new Label();
            Lbl_住家電話 = new Label();
            Lbl_備註 = new Label();
            DTP_日期 = new DateTimePicker();
            RTB_備註 = new RichTextBox();
            Lbl_地址 = new Label();
            Lbl_總金額 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            Btn_建立新零件 = new Button();
            panel3 = new Panel();
            PartSelection = new DataGridViewComboBoxColumn();
            PartName = new DataGridViewTextBoxColumn();
            Quantity = new DataGridViewTextBoxColumn();
            UnitPrice = new DataGridViewTextBoxColumn();
            TotalPrice = new DataGridViewTextBoxColumn();
            刪除 = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)DGV_工作單零件).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.LemonChiffon;
            label1.Font = new Font("標楷體", 14.25F);
            label1.Location = new Point(7, 66);
            label1.Name = "label1";
            label1.Size = new Size(109, 19);
            label1.TabIndex = 0;
            label1.Text = "車輛選擇：";
            // 
            // Cbx_車輛選擇
            // 
            Cbx_車輛選擇.DropDownStyle = ComboBoxStyle.DropDownList;
            Cbx_車輛選擇.Font = new Font("標楷體", 14.25F);
            Cbx_車輛選擇.FormattingEnabled = true;
            Cbx_車輛選擇.Location = new Point(310, 58);
            Cbx_車輛選擇.Name = "Cbx_車輛選擇";
            Cbx_車輛選擇.Size = new Size(233, 27);
            Cbx_車輛選擇.TabIndex = 1;
            Cbx_車輛選擇.SelectedIndexChanged += Cbx_車輛選擇_SelectedIndexChanged;
            // 
            // Lbl_標題
            // 
            Lbl_標題.AutoSize = true;
            Lbl_標題.BackColor = Color.LightGreen;
            Lbl_標題.Font = new Font("標楷體", 25F);
            Lbl_標題.Location = new Point(213, 9);
            Lbl_標題.Name = "Lbl_標題";
            Lbl_標題.Size = new Size(508, 34);
            Lbl_標題.TabIndex = 25;
            Lbl_標題.Text = "華晟汽車維修廠(原麥力) 工作單\r\n";
            Lbl_標題.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // RTB_工作單備註
            // 
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
            Lbl_里程.Location = new Point(669, 187);
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
            Lbl_日期.Location = new Point(422, 176);
            Lbl_日期.Name = "Lbl_日期";
            Lbl_日期.Size = new Size(69, 19);
            Lbl_日期.TabIndex = 36;
            Lbl_日期.Text = "日期：";
            // 
            // Tbx_里程
            // 
            Tbx_里程.Font = new Font("標楷體", 14.25F);
            Tbx_里程.Location = new Point(751, 176);
            Tbx_里程.Name = "Tbx_里程";
            Tbx_里程.Size = new Size(121, 30);
            Tbx_里程.TabIndex = 39;
            Tbx_里程.KeyPress += Tbx_里程_KeyPress;
            // 
            // Btn_取消
            // 
            Btn_取消.Font = new Font("標楷體", 14.25F);
            Btn_取消.Location = new Point(779, 499);
            Btn_取消.Name = "Btn_取消";
            Btn_取消.Size = new Size(101, 41);
            Btn_取消.TabIndex = 45;
            Btn_取消.Text = "取消";
            Btn_取消.UseVisualStyleBackColor = true;
            Btn_取消.Click += Btn_取消_Click;
            // 
            // Btn_儲存
            // 
            Btn_儲存.Font = new Font("標楷體", 14.25F);
            Btn_儲存.Location = new Point(677, 499);
            Btn_儲存.Name = "Btn_儲存";
            Btn_儲存.Size = new Size(101, 41);
            Btn_儲存.TabIndex = 44;
            Btn_儲存.Text = "儲存";
            Btn_儲存.UseVisualStyleBackColor = true;
            Btn_儲存.Click += Btn_儲存_Click;
            // 
            // DGV_工作單零件
            // 
            DGV_工作單零件.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGV_工作單零件.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_工作單零件.Columns.AddRange(new DataGridViewColumn[] { PartSelection, PartName, Quantity, UnitPrice, TotalPrice, 刪除 });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("標楷體", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 136);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            DGV_工作單零件.DefaultCellStyle = dataGridViewCellStyle4;
            DGV_工作單零件.Location = new Point(8, 229);
            DGV_工作單零件.Name = "DGV_工作單零件";
            DGV_工作單零件.Size = new Size(872, 228);
            DGV_工作單零件.TabIndex = 47;
            DGV_工作單零件.CellContentClick += DGV_工作單零件_CellContentClick;
            DGV_工作單零件.CellLeave += DGV_工作單零件_CellLeave;
            DGV_工作單零件.CellValidating += DGV_工作單零件_CellValidating;
            DGV_工作單零件.CellValueChanged += DGV_工作單零件_CellValueChanged;
            DGV_工作單零件.DefaultValuesNeeded += DGV_工作單零件_DefaultValuesNeeded;
            DGV_工作單零件.EditingControlShowing += DGV_工作單零件_EditingControlShowing;
            DGV_工作單零件.RowsAdded += DGV_工作單零件_RowsAdded;
            DGV_工作單零件.KeyDown += DGV_工作單零件_KeyDown;
            DGV_工作單零件.PreviewKeyDown += DGV_工作單零件_PreviewKeyDown;
            // 
            // Tbx_車輛選擇
            // 
            Tbx_車輛選擇.Font = new Font("標楷體", 14.25F);
            Tbx_車輛選擇.Location = new Point(122, 54);
            Tbx_車輛選擇.Name = "Tbx_車輛選擇";
            Tbx_車輛選擇.Size = new Size(168, 30);
            Tbx_車輛選擇.TabIndex = 48;
            Tbx_車輛選擇.TextChanged += Tbx_車輛選擇_TextChanged;
            // 
            // Lbl_車輛年份
            // 
            Lbl_車輛年份.AutoSize = true;
            Lbl_車輛年份.BackColor = Color.LemonChiffon;
            Lbl_車輛年份.Font = new Font("標楷體", 14.25F);
            Lbl_車輛年份.Location = new Point(213, 106);
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
            Lbl_廠牌型式.Location = new Point(7, 176);
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
            Lbl_牌照號碼.Location = new Point(7, 141);
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
            Lbl_車主姓名.Location = new Point(7, 106);
            Lbl_車主姓名.Name = "Lbl_車主姓名";
            Lbl_車主姓名.Size = new Size(109, 19);
            Lbl_車主姓名.TabIndex = 49;
            Lbl_車主姓名.Text = "車主姓名：";
            // 
            // Btn_建立新車輛
            // 
            Btn_建立新車輛.Font = new Font("標楷體", 14.25F);
            Btn_建立新車輛.Location = new Point(575, 9);
            Btn_建立新車輛.Name = "Btn_建立新車輛";
            Btn_建立新車輛.Size = new Size(127, 47);
            Btn_建立新車輛.TabIndex = 60;
            Btn_建立新車輛.Text = "建立新車輛";
            Btn_建立新車輛.UseVisualStyleBackColor = true;
            Btn_建立新車輛.Click += Btn_建立新車輛_Click;
            // 
            // Lbl_行動電話
            // 
            Lbl_行動電話.AutoSize = true;
            Lbl_行動電話.BackColor = Color.LemonChiffon;
            Lbl_行動電話.Font = new Font("標楷體", 14.25F);
            Lbl_行動電話.Location = new Point(213, 176);
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
            Lbl_住家電話.Location = new Point(213, 141);
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
            Lbl_備註.Location = new Point(422, 106);
            Lbl_備註.Name = "Lbl_備註";
            Lbl_備註.Size = new Size(109, 19);
            Lbl_備註.TabIndex = 63;
            Lbl_備註.Text = "車主縮寫：";
            // 
            // DTP_日期
            // 
            DTP_日期.Font = new Font("標楷體", 14.25F);
            DTP_日期.Location = new Point(483, 176);
            DTP_日期.Name = "DTP_日期";
            DTP_日期.Size = new Size(169, 30);
            DTP_日期.TabIndex = 64;
            DTP_日期.ValueChanged += DTP_日期_ValueChanged;
            // 
            // RTB_備註
            // 
            RTB_備註.Enabled = false;
            RTB_備註.Font = new Font("標楷體", 14.25F);
            RTB_備註.Location = new Point(429, 85);
            RTB_備註.Name = "RTB_備註";
            RTB_備註.Size = new Size(389, 32);
            RTB_備註.TabIndex = 65;
            RTB_備註.Text = "";
            // 
            // Lbl_地址
            // 
            Lbl_地址.AutoSize = true;
            Lbl_地址.BackColor = Color.LemonChiffon;
            Lbl_地址.Font = new Font("標楷體", 14.25F);
            Lbl_地址.Location = new Point(47, 207);
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
            Lbl_總金額.Location = new Point(679, 474);
            Lbl_總金額.Name = "Lbl_總金額";
            Lbl_總金額.Size = new Size(119, 19);
            Lbl_總金額.TabIndex = 67;
            Lbl_總金額.Text = "總金額：0元";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.GradientInactiveCaption;
            panel1.Location = new Point(-44, 455);
            panel1.Name = "panel1";
            panel1.Size = new Size(942, 160);
            panel1.TabIndex = 68;
            // 
            // panel2
            // 
            panel2.BackColor = Color.LemonChiffon;
            panel2.Controls.Add(Btn_建立新零件);
            panel2.Controls.Add(RTB_備註);
            panel2.Controls.Add(Btn_建立新車輛);
            panel2.Location = new Point(-7, 43);
            panel2.Name = "panel2";
            panel2.Size = new Size(961, 414);
            panel2.TabIndex = 69;
            // 
            // Btn_建立新零件
            // 
            Btn_建立新零件.Font = new Font("標楷體", 14.25F);
            Btn_建立新零件.Location = new Point(737, 11);
            Btn_建立新零件.Name = "Btn_建立新零件";
            Btn_建立新零件.Size = new Size(127, 45);
            Btn_建立新零件.TabIndex = 70;
            Btn_建立新零件.Text = "建立新零件";
            Btn_建立新零件.UseVisualStyleBackColor = true;
            Btn_建立新零件.Click += Btn_建立新零件_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.LightGreen;
            panel3.Location = new Point(-7, -14);
            panel3.Name = "panel3";
            panel3.Size = new Size(920, 62);
            panel3.TabIndex = 1;
            // 
            // PartSelection
            // 
            PartSelection.HeaderText = "零件選擇";
            PartSelection.Name = "PartSelection";
            // 
            // PartName
            // 
            PartName.HeaderText = "零件名稱";
            PartName.Name = "PartName";
            // 
            // Quantity
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleRight;
            Quantity.DefaultCellStyle = dataGridViewCellStyle1;
            Quantity.FillWeight = 15F;
            Quantity.HeaderText = "數量";
            Quantity.Name = "Quantity";
            // 
            // UnitPrice
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
            UnitPrice.DefaultCellStyle = dataGridViewCellStyle2;
            UnitPrice.FillWeight = 30F;
            UnitPrice.HeaderText = "單價";
            UnitPrice.Name = "UnitPrice";
            // 
            // TotalPrice
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleRight;
            TotalPrice.DefaultCellStyle = dataGridViewCellStyle3;
            TotalPrice.FillWeight = 50F;
            TotalPrice.HeaderText = "總價";
            TotalPrice.Name = "TotalPrice";
            TotalPrice.ReadOnly = true;
            // 
            // 刪除
            // 
            刪除.FillWeight = 20F;
            刪除.HeaderText = "刪除";
            刪除.Name = "刪除";
            刪除.Text = "刪除";
            刪除.UseColumnTextForButtonValue = true;
            // 
            // 紀錄工單
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 551);
            Controls.Add(Lbl_總金額);
            Controls.Add(Lbl_地址);
            Controls.Add(DTP_日期);
            Controls.Add(Lbl_備註);
            Controls.Add(Lbl_行動電話);
            Controls.Add(Lbl_住家電話);
            Controls.Add(Lbl_車輛年份);
            Controls.Add(Lbl_廠牌型式);
            Controls.Add(Lbl_牌照號碼);
            Controls.Add(Lbl_車主姓名);
            Controls.Add(Tbx_車輛選擇);
            Controls.Add(DGV_工作單零件);
            Controls.Add(Btn_取消);
            Controls.Add(Btn_儲存);
            Controls.Add(RTB_工作單備註);
            Controls.Add(Lbl_工作單備註);
            Controls.Add(Tbx_里程);
            Controls.Add(Lbl_里程);
            Controls.Add(Lbl_日期);
            Controls.Add(Lbl_標題);
            Controls.Add(Cbx_車輛選擇);
            Controls.Add(label1);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Controls.Add(panel3);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "紀錄工單";
            ((System.ComponentModel.ISupportInitialize)DGV_工作單零件).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox Cbx_車輛選擇;
        private Label Lbl_標題;
        private Label Lbl_車輛檔案編號;
        private RichTextBox RTB_工作單備註;
        private Label Lbl_工作單備註;
        private Label Lbl_里程;
        private Label Lbl_日期;
        private TextBox Tbx_里程;
        private Button Btn_取消;
        private Button Btn_儲存;
        private DataGridView DGV_工作單零件;
        private TextBox Tbx_車輛選擇;
        private Label Lbl_車輛年份;
        private Label Lbl_廠牌型式;
        private Label Lbl_牌照號碼;
        private Label Lbl_車主姓名;
        private Button Btn_建立新車輛;
        private Label Lbl_行動電話;
        private Label Lbl_住家電話;
        private Label Lbl_備註;
        private DateTimePicker DTP_日期;
        private RichTextBox RTB_備註;
        private Label Lbl_地址;
        private Label Lbl_總金額;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Button Btn_建立新零件;
        private DataGridViewComboBoxColumn PartSelection;
        private DataGridViewTextBoxColumn PartName;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridViewTextBoxColumn UnitPrice;
        private DataGridViewTextBoxColumn TotalPrice;
        private DataGridViewButtonColumn 刪除;
    }
}