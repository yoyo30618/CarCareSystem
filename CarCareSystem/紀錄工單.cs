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
        
        public int? WorkOrderID { get; set; }  // 用來儲存傳入的工單ID
        public 紀錄工單()
        {
            InitializeComponent();
            LoadVehicles(Tbx_車輛選擇.Text);
            Cbx_車輛選擇.SelectedIndex = 0;
            SetupDataGridView();
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
        private void AddPartToGrid()
        {
            DGV_工作單零件.Rows.Add(); // 新增空白行
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





        private void SetupDataGridView()
        {
            DGV_工作單零件.DefaultCellStyle.Font = new Font("標楷體", 16); // 設定資料列的字體和大小

            // 預設保持一列空白
            DGV_工作單零件.AllowUserToAddRows = true;
            // 零件選擇 (下拉式選單)
            DataGridViewComboBoxColumn partSelectionColumn = new DataGridViewComboBoxColumn();
            partSelectionColumn.HeaderText = "零件選擇";
            partSelectionColumn.Name = "PartSelection";
            partSelectionColumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            LoadPartsIntoComboBox(partSelectionColumn);

            // 零件分類 (下拉式選單)
            DataGridViewComboBoxColumn partCategoryColumn = new DataGridViewComboBoxColumn();
            partCategoryColumn.HeaderText = "零件分類";
            partCategoryColumn.Name = "PartCategory";
            partCategoryColumn.Items.AddRange("耗材", "零件");

            // 其他欄位
            DGV_工作單零件.Columns.Add(partSelectionColumn);
            DGV_工作單零件.Columns.Add(partCategoryColumn);
            DGV_工作單零件.Columns.Add("PartName", "零件名稱");
            DGV_工作單零件.Columns.Add("UnitPrice", "零件單價");
            DGV_工作單零件.Columns.Add("Quantity", "數量");
            DGV_工作單零件.Columns.Add("TotalPrice", "總價");
            DGV_工作單零件.Columns.Add("Remarks", "備註");

            // 設置總價欄位為只讀
            DGV_工作單零件.Columns["TotalPrice"].ReadOnly = true;
            // 刪除按鈕欄位
            DataGridViewButtonColumn deleteColumn = new DataGridViewButtonColumn();
            deleteColumn.HeaderText = "刪除";
            deleteColumn.Text = "刪除";
            deleteColumn.UseColumnTextForButtonValue = true;
            DGV_工作單零件.Columns.Add(deleteColumn);

        }

        private void LoadPartsIntoComboBox(DataGridViewComboBoxColumn column)
        {
            try
            {
                column.Items.Clear(); // 清除原有項目

                // 加入"新零件"選項
                column.Items.Add("新零件");
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
                                column.Items.Add(reader["Name"].ToString());
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

        private void DGV_工作單零件_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (isUpdatingPartName)
            {
                DGV_工作單零件.Rows[e.RowIndex].Cells["PartName"].Value = UpdatingPartName;
                isUpdatingPartName = false; // 重置標誌
                return;
            }

            //// 零件名稱輸入時，查詢並更新相關資訊
            //if (e.ColumnIndex == DGV_工作單零件.Columns["PartName"].Index)
            //{
            //    string partName = DGV_工作單零件.Rows[e.RowIndex].Cells["PartName"].Value?.ToString();
            //    UpdatePartDetails(e.RowIndex, partName);
            //}


            // 計算總價
            if ((e.ColumnIndex == DGV_工作單零件.Columns["UnitPrice"].Index ||
                 e.ColumnIndex == DGV_工作單零件.Columns["Quantity"].Index) &&
                 DGV_工作單零件.Rows[e.RowIndex].Cells["UnitPrice"].Value != null &&
                 DGV_工作單零件.Rows[e.RowIndex].Cells["Quantity"].Value != null)
            {
                CalculateTotalPrice(e.RowIndex);
            }
        }
        private void UpdatePartDetails(int rowIndex, string partName)
        {
            try
            {

                string SQL = @"SELECT * FROM Parts Where Name like @關鍵字 or Abbreviation like @關鍵字";
                using (var connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();
                    using (var command = new SQLiteCommand(SQL, connection))
                    {
                        command.Parameters.AddWithValue("@關鍵字", $"%{partName}%");
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (partName == reader["Name"].ToString())
                                {
                                    //DGV_工作單零件.Rows[rowIndex].Cells["PartSelection"].Value = reader["Name"].ToString();
                                    DGV_工作單零件.Rows[rowIndex].Cells["UnitPrice"].Value = reader["Price"];
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"查詢零件詳情時發生錯誤: {ex.Message}");
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
                e.Row.Cells["PartSelection"].Value = "新零件"; // 明確設定為"新零件"
            }
            // 零件分類欄位
            var partCategoryColumn = DGV_工作單零件.Columns["PartCategory"] as DataGridViewComboBoxColumn;
            if (partCategoryColumn != null && partCategoryColumn.Items.Count > 0)
            {
                e.Row.Cells["PartCategory"].Value = "耗材"; // 預設為"耗材"
            }
            //e.Row.Cells["Quantity"].Value = 0;
            //e.Row.Cells["UnitPrice"].Value = 0;
            //e.Row.Cells["TotalPrice"].Value = 0;
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
        private void ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // 取得選擇的零件名稱
            var comboBox = sender as ComboBox;
            if (comboBox != null)
            {
                int rowIndex = DGV_工作單零件.CurrentRow.Index;
                // 更新其他欄位資料
                DGV_工作單零件.Rows[rowIndex].Cells["PartName"].Value = "";
                DGV_工作單零件.Rows[rowIndex].Cells["PartCategory"].Value = "耗材";
                DGV_工作單零件.Rows[rowIndex].Cells["UnitPrice"].Value = 0;
                DGV_工作單零件.Rows[rowIndex].Cells["TotalPrice"].Value = 0;
                string selectedPart = comboBox.SelectedItem.ToString();

                // 確保選擇的零件不是"新零件"或空白
                if (!string.IsNullOrEmpty(selectedPart) && selectedPart != "新零件")
                {
                    // 查詢資料庫，根據選擇的零件名稱取得相關資訊
                    string SQL = @"SELECT Name, Category, Price FROM Parts WHERE Name = @partName";
                    using (var connection = new SQLiteConnection(ConnectionString))
                    {
                        connection.Open();
                        using (var command = new SQLiteCommand(SQL, connection))
                        {
                            command.Parameters.AddWithValue("@partName", selectedPart);
                            using (var reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    string category = reader["Category"].ToString();
                                    string Name = reader["Name"].ToString();
                                    decimal price = Convert.ToDecimal(reader["Price"]);
                                    DGV_工作單零件.Rows[rowIndex].Cells["PartName"].Value = Name;
                                    DGV_工作單零件.Rows[rowIndex].Cells["PartCategory"].Value = category;
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
                //var partSelectionValue = DGV_工作單零件.CurrentRow.Cells["PartSelection"].Value?.ToString();
                //if (!string.IsNullOrEmpty(partSelectionValue) && partSelectionValue != partName)
                //{
                //    if (DGV_工作單零件.IsCurrentCellDirty)
                //    {
                //        DGV_工作單零件.EndEdit(); // 結束編輯狀態
                //    }
                //    DGV_工作單零件.BeginEdit(true);
                //}
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
            string SQL = @"SELECT * FROM Parts WHERE Name = @partName";
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(SQL, connection))
                {
                    command.Parameters.AddWithValue("@partName", partName);
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
            string SQL = @"SELECT Name,Abbreviation FROM Parts WHERE Name LIKE @filter or Abbreviation LIKE @filter";
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(SQL, connection))
                {
                    command.Parameters.AddWithValue("@filter", "%" + filter + "%");
                    bool Find = false;
                    using (var reader = command.ExecuteReader())
                    {
                        List<string> filteredItems = new List<string>();
                        while (reader.Read())
                        {
                            filteredItems.Add(reader["Name"].ToString());
                            if (
                                (string.IsNullOrEmpty(reader["Name"].ToString()) && reader["Name"].ToString() == filter) ||
                                (!string.IsNullOrEmpty(reader["Abbreviation"].ToString()) && reader["Abbreviation"].ToString() == filter)
                                )
                                Find = true;
                        }
                        if (!Find)
                        {
                            if (string.IsNullOrEmpty(filter))
                                comboBoxCell.Items.Add("新零件");
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

                            using (var command = new SQLiteCommand(insertWorkOrderSQL, connection))
                            {
                                command.Parameters.AddWithValue("@workOrderTotalPrice", OrderTotalPrice);
                                command.Parameters.AddWithValue("@plateID", Id);
                                command.Parameters.AddWithValue("@Timestamp", DTP_日期.Value);
                                command.Parameters.AddWithValue("@Mileage", Tbx_里程.Text.ToString());
                                command.Parameters.AddWithValue("@Remark", RTB_工作單備註.Text.ToString());
                                int workOrderID = Convert.ToInt32(command.ExecuteScalar());  // 取得新插入的 WorkOrderID
                                foreach (DataGridViewRow row in DGV_工作單零件.Rows)
                                {
                                    string partName = row.Cells["PartName"].Value?.ToString() ?? "";  // 如果沒填寫，將其設為空字串
                                    int quantity = Convert.ToInt32(row.Cells["Quantity"].Value ?? 0);
                                    decimal unitPrice = Convert.ToDecimal(row.Cells["UnitPrice"].Value ?? 0);
                                    decimal totalPrice = Convert.ToDecimal(row.Cells["TotalPrice"].Value ?? 0);
                                    string remarks = row.Cells["Remarks"].Value?.ToString() ?? "";  // 如果沒填寫，將其設為空字串;

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
            if (WorkOrderID.HasValue)
            {
                string query = @"SELECT PlateID FROM WorkOrders WHERE WorkOrderID = @workOrderID";
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
                                // 取得 PlateID
                                string plateID = reader["PlateID"].ToString();
                                // 呼叫載入車輛資料的方法
                                LoadVehicleData(plateID);
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
                    UpdatingPartName= partSelectionCell.Value.ToString();
                 //   partNameCell.Value = partSelectionCell.Value.ToString();
                    
                }
            }
        }

    }
}
