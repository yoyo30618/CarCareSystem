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
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace CarCareSystem
{
    public partial class 所有工單查詢 : Form
    {
        private const string ConnectionString = "Data Source=vehicles.db;Version=3;";

        public 所有工單查詢()
        {
            InitializeComponent();
            DTP_起始時間.Value = new DateTime(DateTime.Now.Year, 1, 1);
            DTP_結束時間.Value = DateTime.Today; // 50年前
            DTP_起始時間.Format = DateTimePickerFormat.Custom;
            DTP_起始時間.CustomFormat = string.Format("{0}/MM/dd", DTP_起始時間.Value.AddYears(-1911).Year.ToString("00"));
            DTP_結束時間.Format = DateTimePickerFormat.Custom;
            DTP_結束時間.CustomFormat = string.Format("{0}/MM/dd", DTP_結束時間.Value.AddYears(-1911).Year.ToString("00"));
            CountTotalMoney();
        }

        private void DTP_起始時間_ValueChanged(object sender, EventArgs e)
        {
            DTP_起始時間.Format = DateTimePickerFormat.Custom;
            DTP_起始時間.CustomFormat = string.Format("{0}/MM/dd", DTP_起始時間.Value.AddYears(-1911).Year.ToString("00"));
            DTP_結束時間.Format = DateTimePickerFormat.Custom;
            DTP_結束時間.CustomFormat = string.Format("{0}/MM/dd", DTP_結束時間.Value.AddYears(-1911).Year.ToString("00"));
            CountTotalMoney();
        }

        private void DTP_結束時間_ValueChanged(object sender, EventArgs e)
        {
            DTP_起始時間.Format = DateTimePickerFormat.Custom;
            DTP_起始時間.CustomFormat = string.Format("{0}/MM/dd", DTP_起始時間.Value.AddYears(-1911).Year.ToString("00"));
            DTP_結束時間.Format = DateTimePickerFormat.Custom;
            DTP_結束時間.CustomFormat = string.Format("{0}/MM/dd", DTP_結束時間.Value.AddYears(-1911).Year.ToString("00"));
            CountTotalMoney();
        }
        private void CountTotalMoney()
        {
            string query = @"
                SELECT SUM(WorkOrderTotalPrice) AS WorkOrderTotalPrice
                FROM WorkOrders 
                WHERE Timestamp >= @StartDate AND Timestamp < DATE(@EndDate, '+1 day');
            ";
            DateTime startDate = DTP_起始時間.Value;
            DateTime endDate = DTP_結束時間.Value;
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(query, connection))
                {
                    // 傳遞日期參數
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // 讀取金額，處理 NULL 的情況
                            decimal totalPrice = reader["WorkOrderTotalPrice"] != DBNull.Value
                                ? Convert.ToDecimal(reader["WorkOrderTotalPrice"])
                                : 0;

                            // 更新 Label
                            Lbl_總金額.Text = $"總金額：{totalPrice:C}元"; // 自動格式化為貨幣格式
                        }
                        else
                        {
                            Lbl_總金額.Text = "總金額：0元";
                        }
                    }
                }
            }
        }

        private void Tbx_關鍵字_TextChanged(object sender, EventArgs e)
        {
            DGV_工作單零件.Rows.Clear();

            // 查詢車主、工單與零件資訊
            string query = @"
        SELECT v.Id,v.OwnerName, v.LicensePlate, v.HomePhone, v.MobilePhone, 
               w.WorkOrderID, w.Timestamp, w.Mileage, w.WorkOrderTotalPrice, w.Remark,
               wd.PartName, wd.Quantity, wd.UnitPrice, wd.TotalPrice,wd.Remarks
        FROM Vehicles v
        LEFT JOIN WorkOrders w ON v.Id = w.PlateID
        LEFT JOIN WorkOrderDetails wd ON w.WorkOrderID = wd.WorkOrderID
        WHERE UPPER(v.OwnerName) LIKE @KeyWord
           OR UPPER(v.LicensePlate) LIKE @KeyWord
           OR UPPER(v.HomePhone) LIKE @KeyWord
           OR UPPER(v.MobilePhone) LIKE @KeyWord
           OR UPPER(v.Notes) LIKE @KeyWord
        ORDER BY v.OwnerName ASC , w.Timestamp ASC 
    ";

            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@KeyWord", "%" + Tbx_關鍵字.Text.ToUpper() + "%");

                    using (var reader = command.ExecuteReader())
                    {
                        int currentOwnerID = -1;
                        int rowIndex = -1;
                        int currentWorkOrderID = -1;

                        while (reader.Read())
                        {
                            string ownerName = reader["OwnerName"].ToString();

                            // 新的車主資訊時，新增一行
                            if (int.Parse(reader["Id"].ToString()) != currentOwnerID)
                            {
                                if (currentOwnerID != -1)
                                {
                                    rowIndex = DGV_工作單零件.Rows.Add(
                                        "",
                                        "",
                                        "", ""
                                    );
                                    DGV_工作單零件.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Red;
                                }
                                currentOwnerID = int.Parse(reader["Id"].ToString());
                                currentWorkOrderID = -1;

                                rowIndex = DGV_工作單零件.Rows.Add(
                                     ownerName,
                                    reader["LicensePlate"].ToString(),
                                    reader["HomePhone"].ToString(),
                                     reader["MobilePhone"].ToString()
                                );

                                // 設定車主行的背景色
                                DGV_工作單零件.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightBlue;
                            }

                            // 如果有對應工單，新增一行
                            if (!reader.IsDBNull(reader.GetOrdinal("Timestamp")))
                            {
                                int workOrderID = Convert.ToInt32(reader["WorkOrderID"]);
                                if (currentWorkOrderID != workOrderID)
                                {
                                    currentWorkOrderID = workOrderID;

                                    rowIndex = DGV_工作單零件.Rows.Add(
                                        "工單日期：" + (int.Parse(reader["Timestamp"].ToString().Split('/')[0]) - 1911).ToString() + '/' + (reader["Timestamp"].ToString().Split('/')[1]).ToString() + '/' + (reader["Timestamp"].ToString().Split('/')[2]).ToString().Split(' ')[0],
                                        "當時里程：" + reader["Mileage"].ToString(),
                                        "",""
                                    );
                                    // 設定工單行的背景色
                                    DGV_工作單零件.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Orange;
                                    rowIndex = DGV_工作單零件.Rows.Add(
                                        "備註：" + reader["Remark"].ToString(),
                                        "總金額：" + reader["WorkOrderTotalPrice"].ToString(),
                                        "",
                                        ""
                                    );
                                    // 設定工單行的背景色
                                    DGV_工作單零件.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                                }
                                // 如果該工單有零件資訊，新增一行
                                if (!reader.IsDBNull(reader.GetOrdinal("PartName")))
                                {
                                    rowIndex = DGV_工作單零件.Rows.Add(
                                        reader["PartName"].ToString(),
                                         reader["Quantity"].ToString(),
                                         reader["UnitPrice"].ToString(),
                                        reader["TotalPrice"].ToString()
                                    );

                                    // 設定零件行的背景色
                                    DGV_工作單零件.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightYellow;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void Btn_取消_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
