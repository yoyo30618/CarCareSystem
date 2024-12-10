namespace CarCareSystem
{
    partial class 主畫面
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(主畫面));
            Btn_車輛登錄 = new Button();
            Btn_零件登錄 = new Button();
            Btn_紀錄工單 = new Button();
            Btn_紀錄查詢 = new Button();
            Lbl_標題 = new Label();
            Btn_所有工單查詢 = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            SuspendLayout();
            // 
            // Btn_車輛登錄
            // 
            Btn_車輛登錄.Font = new Font("標楷體", 16F);
            Btn_車輛登錄.Location = new Point(154, 133);
            Btn_車輛登錄.Name = "Btn_車輛登錄";
            Btn_車輛登錄.Size = new Size(237, 41);
            Btn_車輛登錄.TabIndex = 2;
            Btn_車輛登錄.Text = "車輛登錄";
            Btn_車輛登錄.UseVisualStyleBackColor = true;
            Btn_車輛登錄.Click += Btn_車輛登錄_Click;
            // 
            // Btn_零件登錄
            // 
            Btn_零件登錄.Font = new Font("標楷體", 16F);
            Btn_零件登錄.Location = new Point(154, 193);
            Btn_零件登錄.Name = "Btn_零件登錄";
            Btn_零件登錄.Size = new Size(237, 41);
            Btn_零件登錄.TabIndex = 3;
            Btn_零件登錄.Text = "零件登錄";
            Btn_零件登錄.UseVisualStyleBackColor = true;
            Btn_零件登錄.Click += Btn_零件登錄_Click;
            // 
            // Btn_紀錄工單
            // 
            Btn_紀錄工單.Font = new Font("標楷體", 16F);
            Btn_紀錄工單.Location = new Point(154, 253);
            Btn_紀錄工單.Name = "Btn_紀錄工單";
            Btn_紀錄工單.Size = new Size(237, 41);
            Btn_紀錄工單.TabIndex = 4;
            Btn_紀錄工單.Text = "紀錄工單";
            Btn_紀錄工單.UseVisualStyleBackColor = true;
            Btn_紀錄工單.Click += Btn_紀錄工單_Click;
            // 
            // Btn_紀錄查詢
            // 
            Btn_紀錄查詢.Font = new Font("標楷體", 16F);
            Btn_紀錄查詢.Location = new Point(154, 313);
            Btn_紀錄查詢.Name = "Btn_紀錄查詢";
            Btn_紀錄查詢.Size = new Size(237, 41);
            Btn_紀錄查詢.TabIndex = 5;
            Btn_紀錄查詢.Text = "紀錄查詢";
            Btn_紀錄查詢.UseVisualStyleBackColor = true;
            Btn_紀錄查詢.Click += Btn_紀錄查詢_Click;
            // 
            // Lbl_標題
            // 
            Lbl_標題.AutoSize = true;
            Lbl_標題.BackColor = Color.LightGreen;
            Lbl_標題.Font = new Font("標楷體", 30F, FontStyle.Bold);
            Lbl_標題.Location = new Point(47, 24);
            Lbl_標題.Name = "Lbl_標題";
            Lbl_標題.Size = new Size(469, 80);
            Lbl_標題.TabIndex = 1;
            Lbl_標題.Text = "華晟汽車維修廠(原麥力)\r\n愛車帳本";
            Lbl_標題.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Btn_所有工單查詢
            // 
            Btn_所有工單查詢.Font = new Font("標楷體", 16F);
            Btn_所有工單查詢.Location = new Point(154, 373);
            Btn_所有工單查詢.Name = "Btn_所有工單查詢";
            Btn_所有工單查詢.Size = new Size(237, 41);
            Btn_所有工單查詢.TabIndex = 6;
            Btn_所有工單查詢.Text = "所有工單查詢";
            Btn_所有工單查詢.UseVisualStyleBackColor = true;
            Btn_所有工單查詢.Click += Btn_所有工單查詢_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.GradientInactiveCaption;
            panel1.Location = new Point(-284, 300);
            panel1.Name = "panel1";
            panel1.Size = new Size(1009, 230);
            panel1.TabIndex = 78;
            // 
            // panel2
            // 
            panel2.BackColor = Color.LemonChiffon;
            panel2.Location = new Point(-284, 107);
            panel2.Name = "panel2";
            panel2.Size = new Size(1133, 200);
            panel2.TabIndex = 77;
            // 
            // panel3
            // 
            panel3.BackColor = Color.LightGreen;
            panel3.Location = new Point(-281, -89);
            panel3.Name = "panel3";
            panel3.Size = new Size(959, 204);
            panel3.TabIndex = 76;
            // 
            // 主畫面
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(565, 440);
            Controls.Add(Btn_所有工單查詢);
            Controls.Add(Lbl_標題);
            Controls.Add(Btn_紀錄查詢);
            Controls.Add(Btn_紀錄工單);
            Controls.Add(Btn_零件登錄);
            Controls.Add(Btn_車輛登錄);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(panel3);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "主畫面";
            Text = "華晟汽車修護廠 愛車帳本";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Btn_車輛登錄;
        private Button Btn_零件登錄;
        private Button Btn_紀錄工單;
        private Button Btn_紀錄查詢;
        private Label Lbl_標題;
        private Button Btn_所有工單查詢;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
    }
}
