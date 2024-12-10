using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarCareSystem
{
    public partial class 工單查詢 : Form
    {
        private const string ConnectionString = "Data Source=vehicles.db;Version=3;";
        public 工單查詢()
        {
            InitializeComponent();
            InitializeDataGridView();
            string keyword = Tbx_關鍵字.Text.Trim();
            LoadWorkOrders(keyword);

            DTP_起始時間.Value = DateTime.Today.AddYears(-50); // 50年前
            DTP_結束時間.Value = DateTime.Today.AddYears(1); // 50年前
        }

        private void Tbx_關鍵字_TextChanged(object sender, EventArgs e)
        {
            string keyword = Tbx_關鍵字.Text.Trim();
            LoadWorkOrders(keyword);
        }
        private void InitializeDataGridView()
        {
            DataGridViewButtonColumn DelbtnColumn = new DataGridViewButtonColumn();
            DelbtnColumn.Name = "DelDetailsButton";
            DelbtnColumn.HeaderText = "操作";
            DelbtnColumn.Text = "刪除工單";
            DelbtnColumn.UseColumnTextForButtonValue = true;  // 設置按鈕的顯示文字

            DGV_工單列表.ColumnHeadersDefaultCellStyle.Font = new Font("標楷體", 16); // 設定標題的字體和大小
            DGV_工單列表.Columns.Add(DelbtnColumn);
            DGV_工單列表.Columns.Add("WorkOrderID", "工單ID");
            DGV_工單列表.Columns.Add("Timestamp", "時間");
            DGV_工單列表.Columns.Add("PlateID", "車牌號碼");
            DGV_工單列表.Columns.Add("WorkOrderTotalPrice", "總金額");
            // 禁用所有欄位的編輯
            foreach (DataGridViewColumn column in DGV_工單列表.Columns)
            {
                column.ReadOnly = true;
            }
            DGV_工單列表.Columns["DelDetailsButton"].ReadOnly = false;
            DataGridViewButtonColumn EditbtnColumn = new DataGridViewButtonColumn();
            EditbtnColumn.Name = "ShowDetailsButton";
            EditbtnColumn.HeaderText = "操作";
            EditbtnColumn.Text = "顯示工單";
            EditbtnColumn.UseColumnTextForButtonValue = true;  // 設置按鈕的顯示文字
            DGV_工單列表.Columns.Add(EditbtnColumn);
            DGV_工單列表.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void LoadWorkOrders(string keyword)
        {

            DGV_工單列表.Rows.Clear();

            string query = @"
               SELECT DISTINCT w.WorkOrderID, v.LicensePlate, w.Timestamp, w.WorkOrderTotalPrice
                FROM WorkOrders w
                LEFT JOIN WorkOrderDetails wd ON w.WorkOrderID = wd.WorkOrderID
                LEFT JOIN Parts P ON wd.PartName = P.Name
                LEFT JOIN Vehicles v ON w.PlateID = v.Id   -- 假設 PlateID 與 Vehicles 的 LicensePlate 欄位對應
                WHERE (UPPER(w.PlateID) LIKE @keyword                           -- 搜尋 WorkOrders 表格的 PlateID
                OR UPPER(wd.PartName) LIKE @keyword                            -- 搜尋 WorkOrderDetails 的 PartName
                OR UPPER(wd.Remarks) LIKE @keyword                             -- 搜尋 WorkOrderDetails 的 Remarks
                OR UPPER(v.OwnerName) LIKE @keyword                           -- 搜尋 Vehicles 的 OwnerName
                OR UPPER(v.LicensePlate) LIKE @keyword                        -- 搜尋 Vehicles 的 LicensePlate
                OR UPPER(v.HomePhone) LIKE @keyword                           -- 搜尋 Vehicles 的 HomePhone
                OR UPPER(v.MobilePhone) LIKE @keyword                         -- 搜尋 Vehicles 的 MobilePhone
                OR UPPER(v.Model) LIKE @keyword                               -- 搜尋 Vehicles 的 Model
                OR UPPER(v.VehicleYear) LIKE @keyword                         -- 搜尋 Vehicles 的 VehicleYear
                OR UPPER(v.Address) LIKE @keyword                             -- 搜尋 Vehicles 的 Address
                OR UPPER(v.Notes) LIKE @keyword                               -- 搜尋 Vehicles 的 Notes
                OR UPPER(P.Name) LIKE @keyword                               -- 搜尋 Parts 的 Name
                OR UPPER(P.Abbreviation) LIKE @keyword                               -- 搜尋 Parts 的 Abbreviation
                )AND w.Timestamp BETWEEN @startDate AND @endDate
                ORDER BY w.Timestamp ASC;
            ";

            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@keyword", "%" + keyword.ToUpper() + "%"); // 這樣將關鍵字轉為大寫再傳入查詢

                    command.Parameters.AddWithValue("@startDate", DTP_起始時間.Value.Date);
                    command.Parameters.AddWithValue("@endDate", DTP_結束時間.Value.Date.AddDays(1).AddSeconds(-1)); // 包含結束日期的整天

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // 從查詢結果填充到DataGridView
                            DGV_工單列表.Rows.Add(
                                "",
                                reader["WorkOrderID"].ToString(),
                                reader["Timestamp"].ToString(),
                                reader["LicensePlate"].ToString(),
                                Convert.ToDecimal(reader["WorkOrderTotalPrice"]).ToString("C")
                            );
                        }
                    }
                }
            }
        }

        private void DGV_工單列表_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == DGV_工單列表.Columns["ShowDetailsButton"].Index && e.RowIndex >= 0)
            {
                // 取得選中的工單ID
                int selectedWorkOrderID = int.Parse(DGV_工單列表.Rows[e.RowIndex].Cells["WorkOrderID"].Value.ToString());
                // 顯示該工單的詳細資訊
                ShowWorkOrderDetails(selectedWorkOrderID);
            }
        }
        private void ShowWorkOrderDetails(int workOrderID)
        {
            // 打開舊工單
            var 工單檢視 = new 工單檢視();
            工單檢視.WorkOrderID = workOrderID;  // 設定已存在的工單ID
            工單檢視.LoadWorkOrderData();
            工單檢視.ShowDialog();

        }

        private void DGV_工單列表_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && DGV_工單列表.Columns[e.ColumnIndex].Name == "DelDetailsButton" && e.RowIndex >= 0)
            {

                using (Brush brush = new SolidBrush(Color.Red))
                {
                    e.Graphics.FillRectangle(brush, e.CellBounds);
                }

                TextRenderer.DrawText(e.Graphics, "刪除工單", e.CellStyle.Font, e.CellBounds, Color.White,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                e.Handled = true;
            }
        }

        private void DGV_工單列表_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string columnName = DGV_工單列表.Columns[e.ColumnIndex].Name;
                int workOrderID = Convert.ToInt32(DGV_工單列表.Rows[e.RowIndex].Cells["WorkOrderID"].Value);

                if (columnName == "DelDetailsButton")
                {
                    // 確認刪除
                    var result = MessageBox.Show("刪除後無法復原，確定要刪除該工單嗎？", "確認刪除", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        DeleteWorkOrder(workOrderID);
                    }
                }
            }
        }
        private void DeleteWorkOrder(int workOrderID)
        {
            string deleteDetailsSQL = "DELETE FROM WorkOrderDetails WHERE WorkOrderID = @workOrderID";
            string deleteWorkOrderSQL = "DELETE FROM WorkOrders WHERE WorkOrderID = @workOrderID";

            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // 刪除明細
                        using (var command = new SQLiteCommand(deleteDetailsSQL, connection))
                        {
                            command.Parameters.AddWithValue("@workOrderID", workOrderID);
                            command.ExecuteNonQuery();
                        }

                        // 刪除工單
                        using (var command = new SQLiteCommand(deleteWorkOrderSQL, connection))
                        {
                            command.Parameters.AddWithValue("@workOrderID", workOrderID);
                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        MessageBox.Show("工單已成功刪除！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        transaction.Rollback();
                        MessageBox.Show("刪除工單時發生錯誤！", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            // 從 DataGridView 移除該行
            foreach (DataGridViewRow row in DGV_工單列表.Rows)
            {
                if (Convert.ToInt32(row.Cells["WorkOrderID"].Value) == workOrderID)
                {
                    DGV_工單列表.Rows.Remove(row);
                    break;
                }
            }
        }

        private void DTP_日期_ValueChanged(object sender, EventArgs e)
        {
            if (DTP_起始時間.Value > DTP_結束時間.Value)
            {
                MessageBox.Show("起始時間不能晚於結束時間！", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (sender == DTP_起始時間)
                {
                    DTP_起始時間.Value = DTP_結束時間.Value.AddDays(-1);
                }
                else if (sender == DTP_結束時間)
                {
                    DTP_結束時間.Value = DTP_起始時間.Value.AddDays(1);
                }
            }
            string keyword = Tbx_關鍵字.Text.Trim();
            LoadWorkOrders(keyword);
        }
    }
}
