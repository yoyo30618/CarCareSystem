using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CarCareSystem
{
    internal class DatabaseInitializer
    {
        private const string ConnectionString = "Data Source=vehicles.db;Version=3;";
        public static void InitializeDatabase()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                string createVehiclesTable = @"
                    CREATE TABLE IF NOT EXISTS Vehicles (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,          -- 唯一值，自動遞增
                        OwnerName TEXT NOT NULL,                       -- 車主姓名 (不得為空)
                        LicensePlate TEXT NOT NULL,                    -- 牌照號碼 (不得為空)
                        HomePhone TEXT,                                -- 住家電話
                        MobilePhone TEXT,                              -- 行動電話
                        Model TEXT,                                    -- 廠牌型式
                        VehicleYear TEXT,                              -- 車輛年份
                        Address TEXT,                                  -- 地址
                        Notes TEXT,                                    -- 備註
                        CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,  -- 建立時間
                        UNIQUE (OwnerName, LicensePlate, Notes)        -- 複合唯一約束，確保組合不重複
                    );
                ";

                string createPartsTable = @"
                    CREATE TABLE IF NOT EXISTS Parts (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,       -- 唯一值，自動遞增
                        Category TEXT,                              -- 零件分類
                        Name TEXT NOT NULL,                         -- 零件名稱，必填
                        Price REAL DEFAULT 0,                       -- 零件單價，預設值為 0
                        Abbreviation TEXT,                          -- 零件縮寫
                        Notes TEXT,                                 -- 備註
                        UNIQUE (Category, Name, Abbreviation)       -- 複合唯一約束，確保組合不重複
                    );
                ";

                string createWorkOrdersTable = @"
                    CREATE TABLE IF NOT EXISTS WorkOrders(
                        WorkOrderID INTEGER PRIMARY KEY AUTOINCREMENT, --自動遞增主鍵
                        Timestamp DATETIME NOT NULL, --建立時間
                        WorkOrderTotalPrice REAL NOT NULL,
                        Mileage REAL NOT NULL,
                        Remark TEXT NOT NULL,                               --Remark
                        PlateID TEXT NOT NULL                               --車牌 ID
                    );
                ";
                string createWorkOrderDetailsTable = @"
                    CREATE TABLE IF NOT EXISTS WorkOrderDetails (
                        DetailID INTEGER PRIMARY KEY AUTOINCREMENT,
                        WorkOrderID INTEGER NOT NULL,
                        PartName TEXT NOT NULL,
                        Quantity INTEGER NOT NULL,
                        UnitPrice REAL NOT NULL,
                        TotalPrice REAL NOT NULL,
                        Remarks TEXT,
                        FOREIGN KEY (WorkOrderID) REFERENCES WorkOrders (WorkOrderID) 
                            ON DELETE CASCADE
                    );
                ";
                string createTableQuery = createVehiclesTable + createPartsTable + createWorkOrdersTable+ createWorkOrderDetailsTable;

                using (var command = new SQLiteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
