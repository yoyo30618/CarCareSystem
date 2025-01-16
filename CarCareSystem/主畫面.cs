namespace CarCareSystem
{
    public partial class 主畫面 : Form
    {
        public 主畫面()
        {
            InitializeComponent();
        }

        private void Btn_車輛登錄_Click(object sender, EventArgs e)
        {
            var 車輛登錄 = new 車輛登錄();
            車輛登錄.ShowDialog();
        }

        private void Btn_零件登錄_Click(object sender, EventArgs e)
        {
            var 零件登錄 = new 零件登錄();
            零件登錄.ShowDialog();
        }

        private void Btn_紀錄工單_Click(object sender, EventArgs e)
        {
            var 紀錄工單 = new 紀錄工單();
            紀錄工單.ShowDialog();
        }

        private void Btn_紀錄查詢_Click(object sender, EventArgs e)
        {
            var 工單查詢 = new 工單查詢();
            工單查詢.ShowDialog();
        }

        private void Btn_所有工單查詢_Click(object sender, EventArgs e)
        {
            var 所有工單查詢 = new 所有工單查詢();
            所有工單查詢.ShowDialog();
        }

        private void Btn_備份資料到桌面_Click(object sender, EventArgs e)
        {
            try
            {
                string exeDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string sourceFileName = "vehicles.db";
                string sourceFilePath = Path.Combine(exeDirectory, sourceFileName);
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string dateTimeSuffix = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string targetFileName = $"vehicles_{dateTimeSuffix}.db";
                string targetFilePath = Path.Combine(desktopPath, targetFileName);
                if (File.Exists(sourceFilePath))
                {
                    File.Copy(sourceFilePath, targetFilePath);
                    MessageBox.Show($"檔案已成功備份到桌面：{targetFileName}", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"未找到來源檔案：{sourceFileName}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // 處理任何例外
                MessageBox.Show($"備份過程中發生錯誤：{ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
