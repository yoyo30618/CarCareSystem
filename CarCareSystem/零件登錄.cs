using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CarCareSystem
{
    public partial class 零件登錄 : Form
    {
        private const string ConnectionString = "Data Source=vehicles.db;Version=3;";
        private int Id = 0;
        public 零件登錄()
        {
            InitializeComponent();
            LoadParts(Tbx_零件登錄編輯搜尋框.Text);
        }

        private void LoadParts(string 關鍵字)
        {
            try
            {
                string SQL = @"SELECT Id, Name AS DisplayText FROM Parts 
                        WHERE  UPPER(Category) like @關鍵字 
                        OR UPPER(Name) like @關鍵字 
                        OR UPPER(Abbreviation) like @關鍵字 
                        OR UPPER(Notes) like @關鍵字 
                    ";

                Lbx_舊有零件資訊.Items.Clear();
                Lbx_舊有零件資訊.Items.Add(new PartItem(0, "新建零件資訊"));
                using (var connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();
                    using (var command = new SQLiteCommand(SQL, connection))
                    {
                        command.Parameters.AddWithValue("@關鍵字", "%" + 關鍵字.ToUpper() + "%");
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = Convert.ToInt32(reader["Id"]);
                                string displayText = reader["DisplayText"].ToString();
                                var PartItem = new PartItem(id, displayText);
                                Lbx_舊有零件資訊.Items.Add(PartItem);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"讀取零件資料時發生錯誤: {ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_取消_Click(object sender, EventArgs e)
        {
            this.Close(); // 關閉當前的表單
        }
        private void Btn_儲存_Click(object sender, EventArgs e)
        {

            try
            {
                string Category = "";
                string Name = Tbx_零件名稱.Text;
                string Price = Tbx_零件單價.Text;
                string Abbreviation = Tbx_零件縮寫.Text;
                string Notes = RTB_備註.Text;

                if (string.IsNullOrEmpty(Name))
                {
                    MessageBox.Show("零件名稱不能為空！", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string SQL = string.Empty;
                if (Id == 0)
                {//0的時候是新建立
                    SQL = @"
                        INSERT INTO Parts (Category, Name, Price, Abbreviation, Notes) 
                        VALUES (@Category, @Name, @Price, @Abbreviation, @Notes);
                    ";
                }
                else
                {
                    SQL = @"
                        UPDATE Parts
                        SET 
                           Category=@Category,
                           Name = @Name,
                           Price = @Price, 
                           Abbreviation = @Abbreviation, 
                           Notes = @Notes 
                        WHERE Id = @Id;
                    ";
                }
                using (var connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();
                    using (var command = new SQLiteCommand(SQL, connection))
                    {
                        command.Parameters.AddWithValue("@Id", Id);
                        command.Parameters.AddWithValue("@Category", Category);
                        command.Parameters.AddWithValue("@Name", Name);
                        command.Parameters.AddWithValue("@Price", Price);
                        command.Parameters.AddWithValue("@Abbreviation", Abbreviation);
                        command.Parameters.AddWithValue("@Notes", Notes);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("資料已成功儲存！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadParts(Tbx_零件登錄編輯搜尋框.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"儲存資料時發生錯誤: {ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Lbx_舊有零件資訊_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Lbx_舊有零件資訊.SelectedItem is PartItem selectedVehicle)
                {
                    Id = selectedVehicle.Id;
                    if (Id != 0)
                    {
                        Tbn_刪除.Enabled = true;
                        Lbl_零件檔案編號.Text = "零件檔案編號：" + Id;
                        string SQL = @"SELECT * FROM Parts Where Id = @Id";
                        using (var connection = new SQLiteConnection(ConnectionString))
                        {
                            connection.Open();
                            using (var command = new SQLiteCommand(SQL, connection))
                            {
                                command.Parameters.AddWithValue("@Id", Id);
                                using (var reader = command.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        Tbx_零件名稱.Text = reader["Name"].ToString();
                                        Tbx_零件單價.Text = reader["Price"].ToString();
                                        Tbx_零件縮寫.Text = reader["Abbreviation"].ToString();
                                        RTB_備註.Text = reader["Notes"].ToString();
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Tbn_刪除.Enabled = false;
                        Lbl_零件檔案編號.Text = "零件檔案編號：新零件";
                        Tbx_零件名稱.Text = "";
                        Tbx_零件單價.Text = "";
                        Tbx_零件縮寫.Text = "";
                        RTB_備註.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"讀取車輛資料時發生錯誤: {ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Tbx_零件登錄編輯搜尋框_TextChanged(object sender, EventArgs e)
        {
            LoadParts(Tbx_零件登錄編輯搜尋框.Text);
        }

        private void Tbn_刪除_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "確定要刪除這筆資料嗎？",
                "刪除確認",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    string SQL = "DELETE FROM Parts WHERE Id = @Id";
                    using (var connection = new SQLiteConnection(ConnectionString))
                    {
                        connection.Open();
                        using (var command = new SQLiteCommand(SQL, connection))
                        {
                            command.Parameters.AddWithValue("@Id", Id);
                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("刪除成功！", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("刪除失敗，找不到指定的資料。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"刪除時發生錯誤: {ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                LoadParts(Tbx_零件登錄編輯搜尋框.Text);
                Id = 0;
                Tbn_刪除.Enabled = false;
                Lbl_零件檔案編號.Text = "車輛檔案編號：新建檔案";
                Lbl_零件檔案編號.Text = "零件檔案編號：新零件";
                Tbx_零件名稱.Text = "";
                Tbx_零件單價.Text = "";
                Tbx_零件縮寫.Text = "";
                RTB_備註.Text = "";
            }
        }

        private void Tbx_零件單價_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 允許數字、小數點、刪除鍵和退格鍵
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // 阻止非數字輸入
            }

            // 只允許一個小數點
            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains("."))
            {
                e.Handled = true; // 阻止重複的小數點輸入
            }
        }
    }
    public class PartItem
    {
        public int Id { get; set; }
        public string DisplayText { get; set; }
        public PartItem(int id, string displayText)
        {
            Id = id;
            DisplayText = displayText;
        }
        public override string ToString()
        {
            return DisplayText;
        }
    }
}
