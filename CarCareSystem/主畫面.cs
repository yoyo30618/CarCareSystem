namespace CarCareSystem
{
    public partial class �D�e�� : Form
    {
        public �D�e��()
        {
            InitializeComponent();
        }

        private void Btn_�����n��_Click(object sender, EventArgs e)
        {
            var �����n�� = new �����n��();
            �����n��.ShowDialog();
        }

        private void Btn_�s��n��_Click(object sender, EventArgs e)
        {
            var �s��n�� = new �s��n��();
            �s��n��.ShowDialog();
        }

        private void Btn_�����u��_Click(object sender, EventArgs e)
        {
            var �����u�� = new �����u��();
            �����u��.ShowDialog();
        }

        private void Btn_�����d��_Click(object sender, EventArgs e)
        {
            var �u��d�� = new �u��d��();
            �u��d��.ShowDialog();
        }

        private void Btn_�Ҧ��u��d��_Click(object sender, EventArgs e)
        {
            var �Ҧ��u��d�� = new �Ҧ��u��d��();
            �Ҧ��u��d��.ShowDialog();
        }

        private void Btn_�ƥ���ƨ�ୱ_Click(object sender, EventArgs e)
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
                    MessageBox.Show($"�ɮפw���\�ƥ���ୱ�G{targetFileName}", "���\", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"�����ӷ��ɮסG{sourceFileName}", "���~", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // �B�z����ҥ~
                MessageBox.Show($"�ƥ��L�{���o�Ϳ��~�G{ex.Message}", "���~", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
