using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarCareSystem
{
    public partial class 工單檢視 : Form
    {
        private const string ConnectionString = "Data Source=vehicles.db;Version=3;";
        private int Id = 0;
        private decimal OrderTotalPrice = 0;

        public int? WorkOrderID { get; set; }  // 用來儲存傳入的工單ID
        public 工單檢視()
        {
            InitializeComponent();
        }
        private void Btn_取消_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void LoadWorkOrderData()
        {
            if (WorkOrderID.HasValue)
            {
                string query = @"SELECT * FROM WorkOrders WHERE WorkOrderID = @workOrderID";
                using (var connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@workOrderID", WorkOrderID.Value);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {

                                Lbl_日期.Text = "日期：" + reader["Timestamp"].ToString();
                                Lbl_里程.Text = "里程：" + reader["Mileage"].ToString();
                                Lbl_總金額.Text = "總金額：" + reader["WorkOrderTotalPrice"].ToString();
                                
                                RTB_工作單備註.Text = reader["Remark"].ToString();
                                string plateID = reader["PlateID"].ToString(); // 取得 PlateID
                                LoadVehicleData(plateID); // 呼叫載入車輛資料的方法
                                LoadWorkOrderDetails();
                            }
                        }
                    }
                }
            }
        }
        public void LoadVehicleData(string plateID)
        {
            string query = @"SELECT * FROM Vehicles WHERE Id = @plateID";
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@plateID", plateID);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Lbl_車主姓名.Text = "車主姓名：" + reader["OwnerName"].ToString();
                            Lbl_牌照號碼.Text = "牌照號碼：" + reader["LicensePlate"].ToString();
                            Lbl_住家電話.Text = "住家電話：" + reader["HomePhone"].ToString();
                            Lbl_行動電話.Text = "行動電話：" + reader["MobilePhone"].ToString();
                            Lbl_廠牌型式.Text = "廠牌型式：" + reader["Model"].ToString();
                            Lbl_車輛年份.Text = "車輛年份：" + reader["VehicleYear"].ToString();
                            Lbl_地址.Text = "地址：" + reader["Address"].ToString();
                            RTB_備註.Text = reader["Notes"].ToString();
                        }
                    }
                }
            }
        }
        public void LoadWorkOrderDetails()
        {
            if (WorkOrderID.HasValue)
            {
                string query = @"
                    SELECT DetailID, PartName, Quantity, UnitPrice, TotalPrice, Remarks
                    FROM WorkOrderDetails wd
                    WHERE WorkOrderID = @workOrderID
                ";

                using (var connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@workOrderID", WorkOrderID.Value);
                        using (var reader = command.ExecuteReader())
                        {
                            DGV_工作單零件.Rows.Clear();
                            while (reader.Read())
                            {
                                int rowIndex = DGV_工作單零件.Rows.Add();
                                DGV_工作單零件.Rows[rowIndex].Cells["PartName"].Value = reader["PartName"];
                                DGV_工作單零件.Rows[rowIndex].Cells["UnitPrice"].Value = reader["UnitPrice"];
                                DGV_工作單零件.Rows[rowIndex].Cells["Quantity"].Value = reader["Quantity"];
                                DGV_工作單零件.Rows[rowIndex].Cells["TotalPrice"].Value = reader["TotalPrice"];
                                DGV_工作單零件.Rows[rowIndex].Cells["Remarks"].Value = reader["Remarks"];
                            }
                        }
                    }
                }
            }
        }
    }
}
