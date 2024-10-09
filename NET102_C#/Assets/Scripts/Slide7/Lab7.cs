using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.IO;

public class Lab7 : MonoBehaviour
{
    void Start()
    {
        bai1();
    }

    public void bai1()
    {
        //1b
        List<int> nums = new List<int>() { 1, 3, 4, 5, 8, 9 };
        var resulta = nums.Where(num => num % 2 == 0 && num > 4).Select(num => num * num);
        foreach (var item in resulta)
        {
            Debug.Log("num: " + item);
        }

        //1b
        string strb = "chao mung den voi binh nguyen vo tan";
        var resultb = strb.Where(Char.IsLetter).GroupBy(str => str)
                            .Select(group => new { Key = group.Key, count = group.Count() });
        foreach (var item in resultb)
        {
            Debug.Log("key: " + item.Key + " |count: " + item.count);
        }

        //1c
        string strc = "CHAO mung DEN Voi binh nguyen vo tan";
        var words = strc.Split(' ');

        var resultc = from word in words
                             where word.Equals(word.ToUpper())
                             select word;

        foreach (var word in resultc)
        {
            Debug.Log(word); // Output: CHAO, DEN
        }
    }
    public void bai2a()
    {
        //Debug.Log("Hello world !!!"); // Show message on the GameObject Console
        //string connectionString =
        //   "Server=TRUONGNT;" + // Your SQLServer use with double slash \\ for path as: MYPC\\SQLEXPRESS
        //   "Database=Player;" + // Your database name
        //   "Integrated Security=True;";
        //IDbConnection dbcon;
        //using (dbcon = new SqlConnection(connectionString))
        //{
        //    dbcon.Open();
        //    Debug.Log("Connection successful !!!");

        //    using (IDbCommand dbcmd = dbcon.CreateCommand())
        //    {
        //        // Câu lệnh SQL để lấy thông tin Name và PlayerID

        //        string sql = @"
        //    SELECT 
        //        Player.Name AS PlayerName, 
        //        Equip.playerId AS PlayerID 
        //    FROM 
        //        Player 
        //    JOIN 
        //        Equip ON Player.ID = Equip.playerId;";

        //        dbcmd.CommandText = sql;

        //        using (IDataReader reader = dbcmd.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                string playerName = (string)reader["PlayerName"];
        //                int playerId = (int)reader["PlayerID"];

        //                // Xuất thông tin ra console
        //                Debug.Log($"Player Name: {playerName}, Player ID: {playerId}");
        //            }
        //        }
        //    }
        //}
    }
    public void bai2b()
    {
        //Debug.Log("Hello world !!!"); // Show message on the GameObject Console
        //string connectionString =
        //   "Server=TRUONGNT;" + //Your SQLServer use with doble slash \\ for path as: MYPC\\SQLEXPRESS
        //   "Database=Player;" + //Your database name
        //   "Integrated Security=True;";
        //IDbConnection dbcon;
        //using (dbcon = new SqlConnection(connectionString))
        //{
        //    dbcon.Open();
        //    Debug.Log("connection successful !!!");

        //    using (IDbCommand dbcmd = dbcon.CreateCommand())
        //    {
        //        // Câu lệnh INSERT để thêm một người chơi mới

        //        string sql = @"
        //        INSERT INTO Player (Name, Username, Password) 
        //        VALUES ('Mixi Gaming', 'Mixigaming', 'Mixigaming@123');";

        //        dbcmd.CommandText = sql;
        //        int rowsAffected = dbcmd.ExecuteNonQuery(); 

        //        if (rowsAffected > 0)
        //        {
        //            Debug.Log("Insert successful! Rows affected: " + rowsAffected);
        //        }
        //        else
        //        {
        //            Debug.Log("No rows were inserted.");
        //        }
        //    }
        //}
    }
    public void bai2c()
    {
        //Debug.Log("Hello world !!!"); // Show message on the GameObject Console
        //string connectionString =
        //   "Server=TRUONGNT;" + //Your SQLServer use with doble slash \\ for path as: MYPC\\SQLEXPRESS
        //   "Database=Player;" + //Your database name
        //   "Integrated Security=True;";
        //IDbConnection dbcon;
        //using (dbcon = new SqlConnection(connectionString))
        //{
        //    dbcon.Open();
        //    Debug.Log("connection successful !!!");

        //    using (IDbCommand dbcmd = dbcon.CreateCommand())
        //    {
        //        string sql = @"
        //            UPDATE Player 
        //            SET Name = 'Bộ tộc gaming' 
        //            WHERE Name = 'Mixi Gaming';";
        //        dbcmd.CommandText = sql;
        //        int rowsAffected = dbcmd.ExecuteNonQuery(); // Thực thi lệnh UPDATE và trả về số hàng bị ảnh hưởng

        //        if (rowsAffected > 0)
        //        {
        //            Debug.Log("Update successful! Rows affected: " + rowsAffected); // Hiển thị số dòng đã cập nhật
        //        }
        //        else
        //        {
        //            Debug.Log("No rows were updated.");
        //        }
        //    }
        //}
    }
    public void bai2d()
    {
        //Debug.Log("Hello world !!!"); // Show message on the GameObject Console
        //string connectionString =
        //   "Server=TRUONGNT;" + //Your SQLServer use with doble slash \\ for path as: MYPC\\SQLEXPRESS
        //   "Database=Player;" + //Your database name
        //   "Integrated Security=True;";
        //IDbConnection dbcon;
        //using (IDbCommand dbcmd = dbcon.CreateCommand())
        //{
        //    // Câu lệnh DELETE để xóa người chơi có ID = 1
        //    string sql = "DELETE FROM Player WHERE ID = 1"; // Thay ID = 1 bằng ID của người chơi cần xóa
        //    dbcmd.CommandText = sql;
        //    int rowsAffected = dbcmd.ExecuteNonQuery(); // Thực thi lệnh DELETE và trả về số hàng bị ảnh hưởng

        //    if (rowsAffected > 0)
        //    {
        //        Debug.Log("Delete successful! Rows affected: " + rowsAffected); // Hiển thị số dòng đã xóa
        //    }
        //    else
        //    {
        //        Debug.Log("No rows were deleted.");
        //    }
        //}
    }
}
