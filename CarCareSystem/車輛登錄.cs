using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarCareSystem
{
    public partial class 車輛登錄 : Form
    {
        private const string ConnectionString = "Data Source=vehicles.db;Version=3;";
        private int Id = 0;
        public 車輛登錄()
        {
            InitializeComponent();
            LoadVehicles(Tbx_車輛資訊編輯搜尋框.Text);
        }

        private void LoadVehicles(string 關鍵字)
        {
            try
            {
                string SQL = @"SELECT Id,OwnerName || ' ： ' || LicensePlate AS DisplayText,LicensePlate FROM Vehicles
                        WHERE UPPER(OwnerName) like @關鍵字 
                        OR UPPER(LicensePlate) like @關鍵字 
                        OR UPPER(HomePhone) like @關鍵字 
                        OR UPPER(MobilePhone) like @關鍵字 
                        OR UPPER(Model) like @關鍵字 
                        OR UPPER(Address) like @關鍵字 
                        OR UPPER(Notes) like @關鍵字 
                    ";
                Lbx_舊有車輛資訊.Items.Clear();
                Lbx_舊有車輛資訊.Items.Add(new VehicleItem(0, "新建車輛資訊", ""));
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
                                var vehicleItem = new VehicleItem(id, displayText, reader["LicensePlate"].ToString());
                                Lbx_舊有車輛資訊.Items.Add(vehicleItem);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"讀取車輛資料時發生錯誤: {ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                string ownerName = Tbx_車主姓名.Text;
                string licensePlate = Tbx_牌照號碼.Text;
                string homePhone = Tbx_住家電話.Text;
                string mobilePhone = Tbx_行動電話.Text;
                string model = Tbx_廠牌型式.Text;
                string vehicleYear = Tbx_車輛年份.Text;
                string address = Tbx_地址.Text;
                string notes = Tbx_車主縮寫.Text;

                if (string.IsNullOrEmpty(ownerName) || string.IsNullOrEmpty(licensePlate))
                {
                    MessageBox.Show("車主姓名與牌照號碼不能為空！", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string SQL = string.Empty;
                if (Id == 0)
                {//0的時候是新建立
                    SQL = @"
                        INSERT INTO Vehicles (OwnerName, LicensePlate, HomePhone, MobilePhone, Model, VehicleYear, Address, Notes)
                        VALUES (@OwnerName, @LicensePlate, @HomePhone, @MobilePhone, @Model, @VehicleYear, @Address, @Notes);
                    ";
                }
                else
                {
                    SQL = @"
                        UPDATE Vehicles
                        SET 
                            OwnerName = @OwnerName,
                            LicensePlate = @LicensePlate,
                            HomePhone = @HomePhone,
                            MobilePhone = @MobilePhone,
                            Model = @Model,
                            VehicleYear = @VehicleYear,
                            Address = @Address,
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
                        command.Parameters.AddWithValue("@OwnerName", ownerName);
                        command.Parameters.AddWithValue("@LicensePlate", licensePlate);
                        command.Parameters.AddWithValue("@HomePhone", homePhone);
                        command.Parameters.AddWithValue("@MobilePhone", mobilePhone);
                        command.Parameters.AddWithValue("@Model", model);
                        command.Parameters.AddWithValue("@VehicleYear", vehicleYear);
                        command.Parameters.AddWithValue("@Address", address);
                        command.Parameters.AddWithValue("@Notes", notes);
                        command.ExecuteNonQuery();
                        // 獲取剛插入資料的自動生成 Id
                        using (var idCommand = new SQLiteCommand("SELECT last_insert_rowid();", connection))
                        {
                            var insertedId = idCommand.ExecuteScalar();  // 取得自增的 ID
                            MessageBox.Show($"資料已成功儲存！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (Id == 0)
                            {
                                Id = int.Parse(insertedId.ToString());
                            }
                            Lbl_車輛檔案編號.Text = "車輛檔案編號：" + Id;
                        }
                    }
                }
                LoadVehicles(Tbx_車輛資訊編輯搜尋框.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"儲存資料時發生錯誤: {ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Lbx_舊有車輛資訊_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Lbx_舊有車輛資訊.SelectedItem is VehicleItem selectedVehicle)
                {
                    Id = selectedVehicle.Id;
                    if (Id != 0)
                    {
                        Tbn_刪除.Enabled = true;
                        Lbl_車輛檔案編號.Text = "車輛檔案編號：" + Id;
                        string SQL = @"SELECT * FROM Vehicles Where Id = @Id";
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
                                        Tbx_車主姓名.Text = reader["OwnerName"].ToString();
                                        Tbx_牌照號碼.Text = reader["LicensePlate"].ToString();
                                        Tbx_住家電話.Text = reader["HomePhone"].ToString();
                                        Tbx_行動電話.Text = reader["MobilePhone"].ToString();
                                        Tbx_廠牌型式.Text = reader["Model"].ToString();
                                        Tbx_車輛年份.Text = reader["VehicleYear"].ToString();
                                        Tbx_地址.Text = reader["Address"].ToString();
                                        Tbx_車主縮寫.Text = reader["Notes"].ToString();
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Tbn_刪除.Enabled = false;
                        Lbl_車輛檔案編號.Text = "車輛檔案編號：新建檔案";
                        Tbx_車主姓名.Text = "";
                        Tbx_牌照號碼.Text = "";
                        Tbx_住家電話.Text = "";
                        Tbx_行動電話.Text = "";
                        Tbx_廠牌型式.Text = "";
                        Tbx_車輛年份.Text = "";
                        Tbx_地址.Text = "";
                        Tbx_車主縮寫.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"讀取車輛資料時發生錯誤: {ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Tbx_車輛資訊編輯搜尋框_TextChanged(object sender, EventArgs e)
        {
            LoadVehicles(Tbx_車輛資訊編輯搜尋框.Text);
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
                    string SQL = "DELETE FROM Vehicles WHERE Id = @Id";
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

                LoadVehicles(Tbx_車輛資訊編輯搜尋框.Text);
                Id = 0;
                Tbn_刪除.Enabled = false;
                Lbl_車輛檔案編號.Text = "車輛檔案編號：新建檔案";
                Tbx_車主姓名.Text = "";
                Tbx_牌照號碼.Text = "";
                Tbx_住家電話.Text = "";
                Tbx_行動電話.Text = "";
                Tbx_廠牌型式.Text = "";
                Tbx_車輛年份.Text = "";
                Tbx_地址.Text = "";
                Tbx_車主縮寫.Text = "";
            }
        }
    }
    public class VehicleItem
    {
        public int Id { get; set; }
        public string DisplayText { get; set; }
        public string LicensePlate { get; set; }
        public VehicleItem(int id, string displayText, string licensePlate)
        {
            Id = id;
            DisplayText = displayText;
            LicensePlate = licensePlate;
        }
        public override string ToString()
        {
            return DisplayText;
        }
    }
}