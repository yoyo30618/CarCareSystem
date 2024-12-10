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
    }
}
