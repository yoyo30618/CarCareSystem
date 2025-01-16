namespace CarCareSystem
{
    partial class 零件登錄
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(零件登錄));
            Lbl_零件檔案編號 = new Label();
            Lbl_零件登錄編輯搜尋 = new Label();
            Tbx_零件登錄編輯搜尋框 = new TextBox();
            Lbx_舊有零件資訊 = new ListBox();
            Tbx_零件名稱 = new TextBox();
            Lbl_零件名稱 = new Label();
            RTB_備註 = new RichTextBox();
            Btn_取消 = new Button();
            Btn_儲存 = new Button();
            Lbl_零件登錄 = new Label();
            Lbl_備註 = new Label();
            Tbn_刪除 = new Button();
            Tbx_零件單價 = new TextBox();
            Lbl_零件單價 = new Label();
            Tbx_零件縮寫 = new TextBox();
            Lbl_零件縮寫 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // Lbl_零件檔案編號
            // 
            Lbl_零件檔案編號.AutoSize = true;
            Lbl_零件檔案編號.BackColor = Color.LightGreen;
            Lbl_零件檔案編號.Font = new Font("標楷體", 16F);
            Lbl_零件檔案編號.Location = new Point(28, 160);
            Lbl_零件檔案編號.Name = "Lbl_零件檔案編號";
            Lbl_零件檔案編號.Size = new Size(230, 22);
            Lbl_零件檔案編號.TabIndex = 1;
            Lbl_零件檔案編號.Text = "零件檔案編號：新零件";
            // 
            // Lbl_零件登錄編輯搜尋
            // 
            Lbl_零件登錄編輯搜尋.AutoSize = true;
            Lbl_零件登錄編輯搜尋.BackColor = Color.LemonChiffon;
            Lbl_零件登錄編輯搜尋.Font = new Font("標楷體", 16F);
            Lbl_零件登錄編輯搜尋.Location = new Point(591, 17);
            Lbl_零件登錄編輯搜尋.Name = "Lbl_零件登錄編輯搜尋";
            Lbl_零件登錄編輯搜尋.Size = new Size(230, 22);
            Lbl_零件登錄編輯搜尋.TabIndex = 7;
            Lbl_零件登錄編輯搜尋.Text = "選擇已有零件紀錄編輯";
            // 
            // Tbx_零件登錄編輯搜尋框
            // 
            Tbx_零件登錄編輯搜尋框.Font = new Font("標楷體", 16F);
            Tbx_零件登錄編輯搜尋框.Location = new Point(591, 42);
            Tbx_零件登錄編輯搜尋框.Name = "Tbx_零件登錄編輯搜尋框";
            Tbx_零件登錄編輯搜尋框.Size = new Size(278, 33);
            Tbx_零件登錄編輯搜尋框.TabIndex = 13;
            Tbx_零件登錄編輯搜尋框.TextChanged += Tbx_零件登錄編輯搜尋框_TextChanged;
            // 
            // Lbx_舊有零件資訊
            // 
            Lbx_舊有零件資訊.FormattingEnabled = true;
            Lbx_舊有零件資訊.ItemHeight = 15;
            Lbx_舊有零件資訊.Location = new Point(591, 81);
            Lbx_舊有零件資訊.Name = "Lbx_舊有零件資訊";
            Lbx_舊有零件資訊.Size = new Size(278, 364);
            Lbx_舊有零件資訊.TabIndex = 47;
            Lbx_舊有零件資訊.SelectedIndexChanged += Lbx_舊有零件資訊_SelectedIndexChanged;
            // 
            // Tbx_零件名稱
            // 
            Tbx_零件名稱.Font = new Font("標楷體", 16F);
            Tbx_零件名稱.Location = new Point(394, 144);
            Tbx_零件名稱.Name = "Tbx_零件名稱";
            Tbx_零件名稱.Size = new Size(160, 33);
            Tbx_零件名稱.TabIndex = 10;
            // 
            // Lbl_零件名稱
            // 
            Lbl_零件名稱.AutoSize = true;
            Lbl_零件名稱.BackColor = Color.LightGreen;
            Lbl_零件名稱.Font = new Font("標楷體", 16F);
            Lbl_零件名稱.Location = new Point(290, 155);
            Lbl_零件名稱.Name = "Lbl_零件名稱";
            Lbl_零件名稱.Size = new Size(98, 22);
            Lbl_零件名稱.TabIndex = 5;
            Lbl_零件名稱.Text = "零件名稱";
            // 
            // RTB_備註
            // 
            RTB_備註.Location = new Point(113, 287);
            RTB_備註.Name = "RTB_備註";
            RTB_備註.Size = new Size(441, 92);
            RTB_備註.TabIndex = 12;
            RTB_備註.Text = "";
            // 
            // Btn_取消
            // 
            Btn_取消.Font = new Font("標楷體", 16F);
            Btn_取消.Location = new Point(469, 397);
            Btn_取消.Name = "Btn_取消";
            Btn_取消.Size = new Size(101, 41);
            Btn_取消.TabIndex = 16;
            Btn_取消.Text = "取消";
            Btn_取消.UseVisualStyleBackColor = true;
            Btn_取消.Click += Btn_取消_Click;
            // 
            // Btn_儲存
            // 
            Btn_儲存.Font = new Font("標楷體", 16F);
            Btn_儲存.Location = new Point(337, 397);
            Btn_儲存.Name = "Btn_儲存";
            Btn_儲存.Size = new Size(101, 41);
            Btn_儲存.TabIndex = 15;
            Btn_儲存.Text = "儲存";
            Btn_儲存.UseVisualStyleBackColor = true;
            Btn_儲存.Click += Btn_儲存_Click;
            // 
            // Lbl_零件登錄
            // 
            Lbl_零件登錄.AutoSize = true;
            Lbl_零件登錄.BackColor = Color.LightGreen;
            Lbl_零件登錄.Font = new Font("標楷體", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 136);
            Lbl_零件登錄.Location = new Point(60, 100);
            Lbl_零件登錄.Name = "Lbl_零件登錄";
            Lbl_零件登錄.Size = new Size(128, 27);
            Lbl_零件登錄.TabIndex = 0;
            Lbl_零件登錄.Text = "零件登錄";
            // 
            // Lbl_備註
            // 
            Lbl_備註.AutoSize = true;
            Lbl_備註.BackColor = Color.LightGreen;
            Lbl_備註.Font = new Font("標楷體", 16F);
            Lbl_備註.Location = new Point(60, 376);
            Lbl_備註.Name = "Lbl_備註";
            Lbl_備註.Size = new Size(54, 22);
            Lbl_備註.TabIndex = 4;
            Lbl_備註.Text = "備註";
            // 
            // Tbn_刪除
            // 
            Tbn_刪除.BackColor = Color.Red;
            Tbn_刪除.Enabled = false;
            Tbn_刪除.Font = new Font("標楷體", 16F);
            Tbn_刪除.ForeColor = Color.White;
            Tbn_刪除.Location = new Point(12, 404);
            Tbn_刪除.Name = "Tbn_刪除";
            Tbn_刪除.Size = new Size(101, 41);
            Tbn_刪除.TabIndex = 17;
            Tbn_刪除.Text = "刪除";
            Tbn_刪除.UseVisualStyleBackColor = false;
            Tbn_刪除.Click += Tbn_刪除_Click;
            // 
            // Tbx_零件單價
            // 
            Tbx_零件單價.Font = new Font("標楷體", 16F);
            Tbx_零件單價.Location = new Point(113, 220);
            Tbx_零件單價.Name = "Tbx_零件單價";
            Tbx_零件單價.Size = new Size(160, 33);
            Tbx_零件單價.TabIndex = 9;
            Tbx_零件單價.KeyPress += Tbx_零件單價_KeyPress;
            // 
            // Lbl_零件單價
            // 
            Lbl_零件單價.AutoSize = true;
            Lbl_零件單價.BackColor = Color.LightGreen;
            Lbl_零件單價.Font = new Font("標楷體", 16F);
            Lbl_零件單價.Location = new Point(9, 231);
            Lbl_零件單價.Name = "Lbl_零件單價";
            Lbl_零件單價.Size = new Size(98, 22);
            Lbl_零件單價.TabIndex = 3;
            Lbl_零件單價.Text = "零件單價";
            // 
            // Tbx_零件縮寫
            // 
            Tbx_零件縮寫.Font = new Font("標楷體", 16F);
            Tbx_零件縮寫.Location = new Point(394, 220);
            Tbx_零件縮寫.Name = "Tbx_零件縮寫";
            Tbx_零件縮寫.Size = new Size(160, 33);
            Tbx_零件縮寫.TabIndex = 11;
            // 
            // Lbl_零件縮寫
            // 
            Lbl_零件縮寫.AutoSize = true;
            Lbl_零件縮寫.BackColor = Color.LightGreen;
            Lbl_零件縮寫.Font = new Font("標楷體", 16F);
            Lbl_零件縮寫.Location = new Point(290, 231);
            Lbl_零件縮寫.Name = "Lbl_零件縮寫";
            Lbl_零件縮寫.Size = new Size(98, 22);
            Lbl_零件縮寫.TabIndex = 6;
            Lbl_零件縮寫.Text = "零件縮寫";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.GradientInactiveCaption;
            panel1.Location = new Point(-22, 391);
            panel1.Name = "panel1";
            panel1.Size = new Size(609, 95);
            panel1.TabIndex = 49;
            // 
            // panel2
            // 
            panel2.BackColor = Color.LightGreen;
            panel2.Controls.Add(Lbl_備註);
            panel2.Controls.Add(Lbl_零件登錄);
            panel2.Controls.Add(Lbl_零件檔案編號);
            panel2.Location = new Point(-7, -19);
            panel2.Name = "panel2";
            panel2.Size = new Size(594, 411);
            panel2.TabIndex = 48;
            // 
            // panel3
            // 
            panel3.BackColor = Color.LemonChiffon;
            panel3.Location = new Point(578, -22);
            panel3.Name = "panel3";
            panel3.Size = new Size(331, 511);
            panel3.TabIndex = 50;
            // 
            // 零件登錄
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 461);
            Controls.Add(Tbx_零件縮寫);
            Controls.Add(Lbl_零件縮寫);
            Controls.Add(Tbx_零件單價);
            Controls.Add(Lbl_零件單價);
            Controls.Add(Tbn_刪除);
            Controls.Add(Lbl_零件登錄編輯搜尋);
            Controls.Add(Tbx_零件登錄編輯搜尋框);
            Controls.Add(Lbx_舊有零件資訊);
            Controls.Add(Tbx_零件名稱);
            Controls.Add(Lbl_零件名稱);
            Controls.Add(RTB_備註);
            Controls.Add(Btn_取消);
            Controls.Add(Btn_儲存);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Controls.Add(panel3);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "零件登錄";
            Text = "零件登錄";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Lbl_零件檔案編號;
        private Label Lbl_零件登錄編輯搜尋;
        private TextBox Tbx_零件登錄編輯搜尋框;
        private ListBox Lbx_舊有零件資訊;
        private TextBox Tbx_零件名稱;
        private Label Lbl_零件名稱;
        private RichTextBox RTB_備註;
        private Button Btn_取消;
        private Button Btn_儲存;
        private Label Lbl_零件登錄;
        private Label Lbl_備註;
        private Button Tbn_刪除;
        private TextBox Tbx_零件單價;
        private Label Lbl_零件單價;
        private TextBox Tbx_零件縮寫;
        private Label Lbl_零件縮寫;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
    }
}