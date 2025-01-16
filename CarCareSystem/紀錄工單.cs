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
    public partial class 紀錄工單 : Form
    {
        private const string ConnectionString = "Data Source=vehicles.db;Version=3;";
        private int Id = 0;
        private decimal OrderTotalPrice = 0;
        private bool isProcessing = false;
        private bool isUpdatingPartName = false;
        private string UpdatingPartName = string.Empty;

        public int? OrgWorkOrderID { get; set; }  // 用來儲存傳入的工單ID
        public 紀錄工單()
        {
            InitializeComponent();
            LoadVehicles(Tbx_車輛選擇.Text);
            Cbx_車輛選擇.SelectedIndex = 0;
            //SetupDataGridView();
            DTP_日期.Format = DateTimePickerFormat.Custom;
            DTP_日期.CustomFormat = string.Format("{0}/MM/dd", DTP_日期.Value.AddYears(-1911).Year.ToString("00"));
            if (OrgWorkOrderID.HasValue)//讀取舊單
            {
                LoadWorkOrderData();
            }
            UpdateRowsData(0, 1); // 更新資料
        }
        private void LoadVehicles(string 關鍵字, bool ByID = false)
        {
            try
            {
                Cbx_車輛選擇.Items.Clear();
                if (string.IsNullOrEmpty(關鍵字))
                    Cbx_車輛選擇.Items.Add(new VehicleItem(0, "新車主", ""));
                string SQL = @"SELECT Id,OwnerName || ' ： ' || LicensePlate AS DisplayText,LicensePlate FROM Vehicles
                        WHERE UPPER(OwnerName) like @關鍵字 
                        OR UPPER(LicensePlate) like @關鍵字 
                        OR UPPER(HomePhone) like @關鍵字 
                        OR UPPER(MobilePhone) like @關鍵字 
                        OR UPPER(Model) like @關鍵字 
                        OR UPPER(Address) like @關鍵字 
                        OR UPPER(Notes) like @關鍵字 
                    ";
                if (ByID)
                {
                    SQL = @"SELECT Id,OwnerName || ' ： ' || LicensePlate AS DisplayText,LicensePlate FROM Vehicles
                        WHERE Id = @關鍵字 
                    ";
                }
                using (var connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();
                    using (var command = new SQLiteCommand(SQL, connection))
                    {
                        if (ByID)
                            command.Parameters.AddWithValue("@關鍵字", 關鍵字);
                        else
                            command.Parameters.AddWithValue("@關鍵字", "%" + 關鍵字.ToUpper() + "%");
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = Convert.ToInt32(reader["Id"]);
                                string displayText = reader["DisplayText"].ToString();
                                string LicensePlate = reader["LicensePlate"].ToString();
                                var vehicleItem = new VehicleItem(id, displayText, LicensePlate);
                                Cbx_車輛選擇.Items.Add(vehicleItem);
                            }
                        }
                    }
                }
                if (Cbx_車輛選擇.Items.Count == 0)
                    Cbx_車輛選擇.Items.Add(new VehicleItem(0, "新車主", ""));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"讀取車輛資料時發生錯誤: {ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Tbx_車輛選擇_TextChanged(object sender, EventArgs e)
        {
            Id = 0;
            LoadVehicles(Tbx_車輛選擇.Text);
            Cbx_車輛選擇.SelectedIndex = 0;
            ReloadVehicleData();
        }
        private void ReloadVehicleData()
        {

            if (Cbx_車輛選擇.SelectedItem is VehicleItem selectedVehicle)
            {
                Id = selectedVehicle.Id;
                if (Id != 0)
                {
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
                else
                {
                    Lbl_車主姓名.Text = "車主姓名：";
                    Lbl_牌照號碼.Text = "牌照號碼：";
                    Lbl_住家電話.Text = "住家電話：";
                    Lbl_行動電話.Text = "行動電話：";
                    Lbl_廠牌型式.Text = "廠牌型式：";
                    Lbl_車輛年份.Text = "車輛年份：";
                    Lbl_地址.Text = "地址：";
                    RTB_備註.Text = "";
                }
            }

        }
        private void Btn_建立新車輛_Click(object sender, EventArgs e)
        {
            var 車輛登錄 = new 車輛登錄();
            車輛登錄.ShowDialog();
            LoadVehicles(Tbx_車輛選擇.Text);

            Cbx_車輛選擇.SelectedIndex = 0;
        }

        private void Cbx_車輛選擇_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cbx_車輛選擇.SelectedItem is VehicleItem selectedVehicle)
            {
                if (Id != selectedVehicle.Id)
                {
                    Id = selectedVehicle.Id;
                    ReloadVehicleData();
                }
            }
        }

        private void Tbx_里程_KeyPress(object sender, KeyPressEventArgs e)
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

        private void DGV_工作單零件_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (isUpdatingPartName)
            {
                 DGV_工作單零件.Rows[e.RowIndex].Cells["PartName"].Value = UpdatingPartName;
                UpdatingPartName=string.Empty;
                isUpdatingPartName = false; // 重置標誌
                return;
            }

            // 計算總價
            if (e.RowIndex > -1 && (e.ColumnIndex == DGV_工作單零件.Columns["UnitPrice"].Index ||
                 e.ColumnIndex == DGV_工作單零件.Columns["Quantity"].Index) &&
                 DGV_工作單零件.Rows[e.RowIndex].Cells["UnitPrice"].Value != null &&
                 DGV_工作單零件.Rows[e.RowIndex].Cells["Quantity"].Value != null)
            {
                CalculateTotalPrice(e.RowIndex);
            }
        }
        private void DGV_工作單零件_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;  // 確保完全阻止 Enter 的預設行為
                MoveToNextCell();
            }
        }

        private void MoveToNextCell()
        {
            var currentCell = DGV_工作單零件.CurrentCell;
            if (currentCell == null) return;

            int nextColumnIndex = currentCell.ColumnIndex + 1;
            int currentRowIndex = currentCell.RowIndex;

            // 如果到達或超過最後一列
            if (nextColumnIndex >= DGV_工作單零件.Columns.Count)
            {
                nextColumnIndex = 0;
                currentRowIndex++;
            }

            // 如果是最後一行的最後一格，新增一行
            if (currentRowIndex >= DGV_工作單零件.Rows.Count - 1 &&
                nextColumnIndex >= DGV_工作單零件.Columns.Count - 1)
            {
                DGV_工作單零件.Rows.Add();  // 新增一行
                currentRowIndex++;  // 移到新行
                nextColumnIndex = 0;  // 從第一列開始
            }

            // 尋找下一個可編輯的欄位
            while (nextColumnIndex < DGV_工作單零件.Columns.Count)
            {
                var nextCell = DGV_工作單零件.Rows[currentRowIndex].Cells[nextColumnIndex];
                if (!DGV_工作單零件.Columns[nextColumnIndex].ReadOnly &&
                    DGV_工作單零件.Columns[nextColumnIndex].Visible)
                {
                    DGV_工作單零件.CurrentCell = nextCell;
                    return;
                }
                nextColumnIndex++;
            }
        }


        private void CalculateTotalPrice(int rowIndex)
        {
            decimal unitPrice, quantity;
            if (decimal.TryParse(DGV_工作單零件.Rows[rowIndex].Cells["UnitPrice"].Value?.ToString(), out unitPrice) &&
                decimal.TryParse(DGV_工作單零件.Rows[rowIndex].Cells["Quantity"].Value?.ToString(), out quantity))
            {
                decimal totalPrice = unitPrice * quantity;
                DGV_工作單零件.Rows[rowIndex].Cells["TotalPrice"].Value = totalPrice;
            }
            CalculateGrandTotal();
        }
        private void CalculateGrandTotal()
        {
            OrderTotalPrice = 0;

            foreach (DataGridViewRow row in DGV_工作單零件.Rows)
            {
                if (row.IsNewRow) continue; // 跳過新行
                if (decimal.TryParse(row.Cells["TotalPrice"].Value?.ToString(), out decimal totalPrice))
                {
                    OrderTotalPrice += totalPrice;
                }
            }
            Lbl_總金額.Text = "總金額：" + OrderTotalPrice.ToString() + "元";
        }

        private void DGV_工作單零件_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DGV_工作單零件.Columns.Count - 1 && e.RowIndex >= 0)
            {
                if (!DGV_工作單零件.Rows[e.RowIndex].IsNewRow)
                {
                    DGV_工作單零件.Rows.RemoveAt(e.RowIndex);
                    CalculateGrandTotal();
                }
                else
                {
                    MessageBox.Show("無法刪除空行！");
                }
            }
        }


        private void DGV_工作單零件_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            var partSelectionColumn = DGV_工作單零件.Columns["PartSelection"] as DataGridViewComboBoxColumn;
            if (partSelectionColumn != null && partSelectionColumn.Items.Count > 0)
            {
                e.Row.Cells["PartSelection"].Value = "";
            }
        }

        private void DGV_工作單零件_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // 確保數量欄位只能輸入整數
            if (DGV_工作單零件.Columns[e.ColumnIndex].Name == "Quantity")
            {
                if (!int.TryParse(e.FormattedValue.ToString(), out _) && e.FormattedValue.ToString() != "")
                {
                    MessageBox.Show("請輸入有效的整數數量！", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;  // 取消編輯
                }
            }

            // 確保零件單價欄位只能輸入浮點數
            if (DGV_工作單零件.Columns[e.ColumnIndex].Name == "UnitPrice")
            {
                if (!decimal.TryParse(e.FormattedValue.ToString(), out _) && e.FormattedValue.ToString() != "")
                {
                    MessageBox.Show("請輸入有效的浮點數零件單價！", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;  // 取消編輯
                }
            }
        }
        private void DGV_工作單零件_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox textBox = e.Control as TextBox;
            if (textBox != null)
            {
                // 先完全移除所有可能的事件處理器
                textBox.KeyPress -= TextBox_KeyPress;
                textBox.TextChanged -= TextBox_TextChanged;

                // 然後重新添加
                textBox.KeyPress += TextBox_KeyPress;
                // 先移除之前的事件處理器，以免重複綁定
                textBox.KeyDown -= TextBox_KeyDown;

                // 然後綁定新的事件處理器
                textBox.KeyDown += TextBox_KeyDown;
                if (DGV_工作單零件.CurrentCell.ColumnIndex == DGV_工作單零件.Columns["PartName"].Index)
                {
                    textBox.TextChanged += TextBox_TextChanged;
                }
            }


            if (DGV_工作單零件.CurrentCell.ColumnIndex == DGV_工作單零件.Columns["PartSelection"].Index)
            {
                var comboBox = e.Control as ComboBox;
                if (comboBox != null)
                {
                    // 註冊下拉選單選擇完成事件
                    comboBox.SelectionChangeCommitted -= ComboBox_SelectionChangeCommitted;
                    comboBox.SelectionChangeCommitted += ComboBox_SelectionChangeCommitted;
                }
            }
        }
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                // 強制移動到右邊的單元格
                MoveToNextCell();
            }
        }

        private void ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // 取得選擇的零件名稱
            var comboBox = sender as ComboBox;
            if (comboBox != null)
            {
                int rowIndex = DGV_工作單零件.CurrentRow.Index;
                // 更新其他欄位資料
                DGV_工作單零件.Rows[rowIndex].Cells["PartName"].Value = "";
                //DGV_工作單零件.Rows[rowIndex].Cells["PartCategory"].Value = "耗材";
                //    DGV_工作單零件.Rows[rowIndex].Cells["UnitPrice"].Value = 0;
                //   DGV_工作單零件.Rows[rowIndex].Cells["TotalPrice"].Value = 0;
                string selectedPart = comboBox.SelectedItem.ToString();

                // 確保選擇的零件不是"新零件"或空白
                if (!string.IsNullOrEmpty(selectedPart))
                {
                    // 查詢資料庫，根據選擇的零件名稱取得相關資訊
                    string SQL = @"SELECT Name, Category, Price FROM Parts WHERE UPPER(Name) = @partName";
                    using (var connection = new SQLiteConnection(ConnectionString))
                    {
                        connection.Open();
                        using (var command = new SQLiteCommand(SQL, connection))
                        {
                            command.Parameters.AddWithValue("@partName", selectedPart.ToUpper());
                            using (var reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    string category = reader["Category"].ToString();
                                    string Name = reader["Name"].ToString();
                                    decimal price = Convert.ToDecimal(reader["Price"]);
                                    DGV_工作單零件.Rows[rowIndex].Cells["PartName"].Value = Name;
                                    //DGV_工作單零件.Rows[rowIndex].Cells["PartCategory"].Value = category;
                                    DGV_工作單零件.Rows[rowIndex].Cells["UnitPrice"].Value = price;
                                    var quantityCell = DGV_工作單零件.Rows[rowIndex].Cells["Quantity"];
                                    if (quantityCell.Value != null && decimal.TryParse(quantityCell.Value.ToString(), out decimal quantity))
                                    {
                                        DGV_工作單零件.Rows[rowIndex].Cells["TotalPrice"].Value = price * quantity;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (isUpdatingPartName) return;
            // 確保觸發事件的 TextBox 是 PartName 欄位
            if (DGV_工作單零件.CurrentCell.ColumnIndex == DGV_工作單零件.Columns["PartName"].Index)
            {
                string partName = (sender as TextBox)?.Text ?? string.Empty;
                var comboBoxCell = DGV_工作單零件.CurrentRow.Cells["PartSelection"] as DataGridViewComboBoxCell;
                if (comboBoxCell != null)
                {
                    comboBoxCell.Items.Clear();
                    LoadFilteredParts(partName, comboBoxCell);
                }
                partName = DGV_工作單零件.CurrentRow.Cells["PartSelection"].Value.ToString();
                if (!string.IsNullOrEmpty(partName))
                {
                    SetPartPrice(partName);
                }
            }
        }

        private void SetPartPrice(string partName)
        {
            int rowIndex = DGV_工作單零件.CurrentRow.Index;
            DGV_工作單零件.Rows[rowIndex].Cells["UnitPrice"].Value = 0;
            DGV_工作單零件.Rows[rowIndex].Cells["TotalPrice"].Value = 0; // 清空總價
            string SQL = @"SELECT * FROM Parts WHERE UPPER(Name) = @partName";
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(SQL, connection))
                {
                    command.Parameters.AddWithValue("@partName", partName.ToUpper());
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            decimal price = Convert.ToDecimal(reader["Price"]);
                            DGV_工作單零件.Rows[rowIndex].Cells["UnitPrice"].Value = price;

                            var quantityCell = DGV_工作單零件.Rows[rowIndex].Cells["Quantity"];
                            if (quantityCell.Value != null && decimal.TryParse(quantityCell.Value.ToString(), out decimal quantity))
                            {
                                DGV_工作單零件.Rows[rowIndex].Cells["TotalPrice"].Value = price * quantity;
                            }
                        }
                    }
                }
            }
        }
        private void LoadFilteredParts(string filter, DataGridViewComboBoxCell comboBoxCell)
        {
            // 根據輸入文字過濾零件名稱
            string SQL = @"SELECT Name,Abbreviation FROM Parts WHERE UPPER(Name) LIKE @filter or UPPER(Abbreviation) LIKE @filter";
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(SQL, connection))
                {
                    command.Parameters.AddWithValue("@filter", "%" + filter.ToUpper() + "%");
                    bool Find = false;
                    using (var reader = command.ExecuteReader())
                    {
                        List<string> filteredItems = new List<string>();
                        while (reader.Read())
                        {
                            filteredItems.Add(reader["Name"].ToString());
                            if (
                                (string.IsNullOrEmpty(reader["Name"].ToString().ToUpper()) && reader["Name"].ToString().ToUpper() == filter.ToUpper()) ||
                                (!string.IsNullOrEmpty(reader["Abbreviation"].ToString().ToUpper()) && reader["Abbreviation"].ToString().ToUpper() == filter.ToUpper())
                                )
                                Find = true;
                        }
                        if (!Find)
                        {
                            if (string.IsNullOrEmpty(filter))
                                comboBoxCell.Items.Add("");
                            else
                                comboBoxCell.Items.Add(filter);
                        }
                        comboBoxCell.Items.AddRange(filteredItems.ToArray());
                        if (comboBoxCell.Items.Count > 0)
                        {
                            comboBoxCell.Value = comboBoxCell.Items[0];
                        }
                    }
                }
            }
        }
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (isProcessing) return;
            isProcessing = true;
            try
            {
                var currentCell = DGV_工作單零件.CurrentCell;
                if (currentCell == null)
                    return;
                // 當前編輯的是數量欄位
                if (currentCell.ColumnIndex == DGV_工作單零件.Columns["Quantity"].Index)
                {
                    // 只允許數字和刪除鍵
                    if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                    {
                        e.Handled = true;
                    }
                }
                // 當前編輯的是單價欄位
                if (currentCell.ColumnIndex == DGV_工作單零件.Columns["UnitPrice"].Index)
                {
                    var cellValue = currentCell.Value?.ToString() ?? "";

                    // 只允許數字、小數點、負號和刪除鍵
                    if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != '.' && e.KeyChar != '-')
                    {
                        e.Handled = true;
                    }
                    else
                    {
                        // 處理小數點：如果已經有小數點，則禁止再次輸入
                        if (e.KeyChar == '.' && cellValue.Contains("."))
                        {
                            e.Handled = true;
                        }

                        // 處理負號：只允許負號在第一個位置，且只能出現一次
                        if (e.KeyChar == '-')
                        {
                            // 確保只有在第一個位置才允許負號
                            var editingControl = currentCell.EditedFormattedValue as string;
                            if (editingControl != null && editingControl.Length > 0 && editingControl[0] == '-')
                            {
                                e.Handled = true;
                            }
                        }
                    }
                }
            }
            finally
            {
                isProcessing = false;
            }
        }


        private void Btn_取消_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_儲存_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Tbx_里程.Text))
                MessageBox.Show("必須輸入車輛里程");
            else
            {
                CalculateGrandTotal();
                using (var connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // 插入工作單
                            string insertWorkOrderSQL = @"
                                INSERT INTO WorkOrders (WorkOrderTotalPrice, PlateID,Timestamp,Mileage,Remark)
                                VALUES (@workOrderTotalPrice, @plateID,@Timestamp,@Mileage,@Remark);
                                SELECT last_insert_rowid();
                            ";  // 取得新插入的 WorkOrderID
                            if (OrgWorkOrderID.HasValue)
                            {
                                insertWorkOrderSQL = @"
                                    UPDATE WorkOrders
                                    SET WorkOrderTotalPrice = @workOrderTotalPrice,
                                        PlateID = @plateID,
                                        Timestamp = @Timestamp,
                                        Mileage = @Mileage,
                                        Remark = @Remark
                                    WHERE WorkOrderID = @workOrderID;
                                ";

                            }
                            using (var command = new SQLiteCommand(insertWorkOrderSQL, connection))
                            {
                                command.Parameters.AddWithValue("@workOrderTotalPrice", OrderTotalPrice);
                                command.Parameters.AddWithValue("@plateID", Id);
                                command.Parameters.AddWithValue("@Timestamp", DTP_日期.Value);
                                command.Parameters.AddWithValue("@Mileage", Tbx_里程.Text.ToString());
                                command.Parameters.AddWithValue("@Remark", RTB_工作單備註.Text.ToString());
                                int workOrderID = 0;
                                if (OrgWorkOrderID.HasValue)
                                {
                                    command.Parameters.AddWithValue("@workOrderID", OrgWorkOrderID);
                                    command.ExecuteNonQuery();
                                    workOrderID = (int)OrgWorkOrderID;
                                    string DelDetailsSQL = @"DELETE FROM WorkOrderDetails WHERE WorkOrderID=@workOrderID;";

                                    using (var detailCommand = new SQLiteCommand(DelDetailsSQL, connection))
                                    {
                                        detailCommand.Parameters.AddWithValue("@workOrderID", workOrderID);
                                        detailCommand.ExecuteNonQuery();
                                    }
                                }
                                else
                                {
                                    workOrderID = Convert.ToInt32(command.ExecuteScalar());  // 取得新插入的 WorkOrderID
                                }
                                foreach (DataGridViewRow row in DGV_工作單零件.Rows)
                                {
                                    string partName = row.Cells["PartName"].Value?.ToString() ?? "";  // 如果沒填寫，將其設為空字串
                                    int quantity = Convert.ToInt32(row.Cells["Quantity"].Value ?? 0);
                                    decimal unitPrice = Convert.ToDecimal(row.Cells["UnitPrice"].Value ?? 0);
                                    decimal totalPrice = Convert.ToDecimal(row.Cells["TotalPrice"].Value ?? 0);
                                    string remarks = "";  // 如果沒填寫，將其設為空字串;
                                    if (string.IsNullOrEmpty(partName)) continue;
                                    string insertDetailsSQL = @"
                                        INSERT INTO WorkOrderDetails (WorkOrderID, PartName, Quantity, UnitPrice, TotalPrice, Remarks)
                                        VALUES (@workOrderID, @partName, @quantity, @unitPrice, @totalPrice, @remarks);
                                    ";

                                    using (var detailCommand = new SQLiteCommand(insertDetailsSQL, connection))
                                    {
                                        detailCommand.Parameters.AddWithValue("@workOrderID", workOrderID);
                                        detailCommand.Parameters.AddWithValue("@partName", partName);
                                        detailCommand.Parameters.AddWithValue("@quantity", quantity);
                                        detailCommand.Parameters.AddWithValue("@unitPrice", unitPrice);
                                        detailCommand.Parameters.AddWithValue("@totalPrice", totalPrice);
                                        detailCommand.Parameters.AddWithValue("@remarks", remarks);
                                        detailCommand.ExecuteNonQuery();
                                    }
                                }
                                transaction.Commit();
                                MessageBox.Show($"儲存成功");
                                this.Close();
                            }
                        }
                        catch (Exception ex)
                        {
                            // 發生錯誤時回滾交易
                            transaction.Rollback();
                            MessageBox.Show($"儲存工作單時出錯: {ex.Message}");
                        }
                    }
                }
            }
        }
       
        public void LoadWorkOrderData()
        {
            if (OrgWorkOrderID.HasValue)
            {
                string query = @"SELECT * FROM WorkOrders W LEFT JOIN Vehicles P ON W.PlateID=P.Id WHERE WorkOrderID = @workOrderID";
                using (var connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@workOrderID", OrgWorkOrderID.Value);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {

                                Tbx_車輛選擇.Text = reader["LicensePlate"].ToString();
                                Tbx_里程.Text = reader["Mileage"].ToString();
                                DTP_日期.Text = reader["Timestamp"].ToString();
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
        public void LoadWorkOrderDetails()
        {
            if (OrgWorkOrderID.HasValue)
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
                        command.Parameters.AddWithValue("@workOrderID", OrgWorkOrderID.Value);
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
                                //DGV_工作單零件.Rows[rowIndex].Cells["Remarks"].Value = reader["Remarks"];
                            }
                        }
                    }
                }
                ReLoadPartSelection();
            }
        }
        public void ReLoadPartSelection()
        {
            foreach (DataGridViewRow row in DGV_工作單零件.Rows)
            {
                var comboBoxCell = (DataGridViewComboBoxCell)row.Cells["PartSelection"];
                string TypepartName = row.Cells["PartName"].Value?.ToString() ?? "";  // 如果沒填寫，將其設為空字串
                comboBoxCell.Items.Clear();
                // 加入資料庫中的零件名稱
                string SQL = @"SELECT * FROM Parts";
                bool Add = false;
                using (var connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();
                    using (var command = new SQLiteCommand(SQL, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string partName = reader["Name"].ToString();

                                comboBoxCell.Items.Add(partName);
                                // 如果是目標項目，設定為選中
                                if (partName == TypepartName)
                                {
                                    comboBoxCell.Value = partName;
                                    Add = true;
                                }
                            }
                        }
                    }
                }
                if (Add == false)
                {
                    comboBoxCell.Items.Add(TypepartName);
                    comboBoxCell.Value = TypepartName;
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
        private void SelectVehicleInComboBox(string plateID)
        {
            // 假設 Cbx_車輛選擇 是車輛的下拉選單
            for (int i = 0; i < Cbx_車輛選擇.Items.Count; i++)
            {
                VehicleItem item = Cbx_車輛選擇.Items[i] as VehicleItem; // 假設每個項目是 ComboBoxItem 型別，並包含車輛資料
                if (item != null && item.DisplayText == plateID)
                {
                    // 選擇該車輛項目
                    Cbx_車輛選擇.SelectedIndex = i;
                    break;
                }
            }
        }

        private void DGV_工作單零件_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DGV_工作單零件.Columns["PartName"].Index)
            {
                var currentRow = DGV_工作單零件.Rows[e.RowIndex];
                var partSelectionCell = currentRow.Cells["PartSelection"] as DataGridViewComboBoxCell;
                var partNameCell = currentRow.Cells["PartName"];

                if (partSelectionCell != null && partSelectionCell.Value != null)
                {
                    isUpdatingPartName = true; // 設置標誌，防止重入
                    UpdatingPartName = partSelectionCell.Value.ToString();
                    //   partNameCell.Value = partSelectionCell.Value.ToString();

                }
            }
        }

        private void DTP_日期_ValueChanged(object sender, EventArgs e)
        {

            DTP_日期.Format = DateTimePickerFormat.Custom;
            DTP_日期.CustomFormat = string.Format("{0}/MM/dd", DTP_日期.Value.AddYears(-1911).Year.ToString("00"));
        }

        // 提取共用的邏輯到一個方法
        private void UpdateRowsData(int startIndex, int rowCount)
        {
            try
            {
                UpdatingPartName = string.Empty;
                // 檢查新增的行數量
                for (int i = startIndex; i < startIndex + rowCount; i++)
                {
                    // 找到該行的 ComboBoxCell
                    var comboBoxCell = (DataGridViewComboBoxCell)DGV_工作單零件.Rows[i].Cells["PartSelection"];
                    var buttonCell = (DataGridViewButtonCell)DGV_工作單零件.Rows[i].Cells["刪除"];
                    buttonCell.Value = "刪除";

                    // 清空現有項目
                    comboBoxCell.Items.Clear();

                    // 加入資料庫中的零件名稱
                    string SQL = @"SELECT * FROM Parts";
                    using (var connection = new SQLiteConnection(ConnectionString))
                    {
                        connection.Open();
                        using (var command = new SQLiteCommand(SQL, connection))
                        {
                            using (var reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    // 為每行的 ComboBox 填充資料
                                    comboBoxCell.Items.Add(reader["Name"].ToString());
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"載入零件時發生錯誤: {ex.Message}");
            }
        }

        // RowsAdded 事件處理程式
        private void DGV_工作單零件_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            UpdateRowsData(e.RowIndex, e.RowCount);
        }

        private void DGV_工作單零件_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            // 如果按下的是 Enter 鍵，攔截並防止預設行為
            if (e.KeyCode == Keys.Enter)
            {
                e.IsInputKey = true; // 讓按鍵進入 KeyDown 處理
            }
        }

        private void Btn_建立新零件_Click(object sender, EventArgs e)
        {
            var 零件登錄 = new 零件登錄();
            零件登錄.ShowDialog();
        }
    }
}
