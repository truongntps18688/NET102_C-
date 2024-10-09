using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.IO;

public class LINQtoObjectsClass : MonoBehaviour
{
    void Start()
    {
    }
    public void test1()
    {
        string str = "Chào mừng bạn đến với bình nguyên vô tận";
        // Tách chuỗi thành các từ bằng cách sử dụng phương thức Split()
        string[] words = str.Split(' ');

        // Sử dụng LINQ to Objects để lọc ra các từ có độ dài lớn hơn 3
        var longWords = from word in words
                        where word.Length > 3
                        select word;

        // In ra các từ đã lọc được
        Console.WriteLine("Các từ có độ dài lớn hơn 3:");
        foreach (var word in longWords)
        {
            Debug.Log(word);
        }
    }
    public void test2()
    {
        string[] str = { "T con", "T1", "GenG", 
            "GenG v2", "DK", "HLE", "txt" };

        // Sử dụng LINQ để lọc các phần tử có
        // name bắt đầu bằng "T" (bao gồm cả chữ hoa và chữ thường)
        var namesStartingWithF = from name in str
                                 where name.StartsWith("T", StringComparison.OrdinalIgnoreCase)
                                 select name;

        // In ra các phần tử đã lọc được
        Debug.Log("Các phần tử có name bắt đầu bằng T: ");
        foreach (var name in namesStartingWithF)
        {
            Debug.Log(name);
        }
    }
    public void test3()
    {
        // Khởi tạo mảng số nguyên
        int[] numbers = { 10, 5, 20, 15, 30, 25 };

        // Sử dụng LINQ để lấy ra 3 phần tử có giá trị lớn nhất
        var top3Numbers = numbers.OrderByDescending(n => n).Take(3);

        // In ra 3 phần tử có giá trị lớn nhất
        Debug.Log("3 phần tử có giá trị lớn nhất:");
        foreach (var number in top3Numbers)
        {
            Debug.Log(number);
        }
    }
    public void test4()
    {
        string Path = @"C:\data";

        try
        {
            // Kiểm tra xem thư mục có tồn tại không
            if (Directory.Exists(Path))
            {
                // Lấy danh sách các tệp tin và thư mục trong thư mục
                var directoryContents = from file in Directory.EnumerateFileSystemEntries(Path)
                                        select file;

                // In ra danh sách các tệp tin và thư mục
                Debug.Log("Nội dung của thư mục " + Path);
                foreach (var item in directoryContents)
                {
                    Debug.Log(item);
                }
            }
            else
            {
                Debug.Log("Thư mục không tồn tại.");
            }
        }
        catch (Exception ex)
        {
            Debug.Log("Đã xảy ra lỗi: " + ex.Message);
        }


        /// or
        DirectoryInfo dirInfo = new DirectoryInfo(Path);

        var files = from file in dirInfo.GetFiles()
                    select new { Name = file.Name, Size = (file.Length / 1024) + "KB"};

        Debug.Log("Thư mục " + Path);
        foreach (var file in files)
        {
            Debug.Log(file.Name + " : " + file.Size);
        }
    }
    public void test5()
    {
        List<test5Class> list = new List<test5Class>();
        list.Add(new test5Class("1", "Leesin", 19, 1));
        list.Add(new test5Class("2", "Ashe", 16, 1));
        list.Add(new test5Class("3", "Sone", 17, 2));
        list.Add(new test5Class("4", "Yasuo", 24, 2));

        // xuất thông tin gồm name và một bool, bool = true khi age > 18, và rank = 1
        var result = from item in list
                     where item.rank.Equals(1)
                     select new
                     {
                         name = item.name,
                         boolean = item.age > 18 ? true : false,
                     };
        foreach (var item in result)
        {
            Debug.Log(item.name + " : " + item.boolean);
        }
    }


    public void testSqlClient()
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
        //}
    }
    public void testSqlClient1()
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
        //        string sql = "SELECT Name FROM Player WHERE Id=1"; //To select only 1 user
        //        dbcmd.CommandText = sql;
        //        using (IDataReader reader = dbcmd.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                string NamePlayer = (string)reader["Name"];
        //                string Name = "Name: " + NamePlayer;
        //                Debug.Log(Name); //Display Name in GameObject Console
        //            }
        //        }
        //    }
        //}
    }
    public void testSqlClient2()
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
        //        string sql = "INSERT INTO Player (Name, Username, Password) VALUES ('Ashe', 'bestAshe', 'bestAshe')";
        //        dbcmd.CommandText = sql;
        //        int rowsAffected = dbcmd.ExecuteNonQuery(); // Thực thi lệnh INSERT và trả về số hàng bị ảnh hưởng

        //        if (rowsAffected > 0)
        //        {
        //            Debug.Log("Insert successful! Rows affected: " + rowsAffected); // Hiển thị số dòng đã thêm
        //        }
        //        else
        //        {
        //            Debug.Log("No rows were inserted.");
        //        }
        //    }
        //}
    }
    public void testSqlClient3()
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
        //        string sql = "UPDATE Player SET Name = 'LeeSin sss' WHERE ID = 1";
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
    public void testSqlClient4()
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
    public void testSqlClient5()
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
        //        // Câu lệnh SQL để lấy tên người chơi và các trang thiết bị liên kết
        //        string sql = @"
        //    SELECT 
        //        Player.Name AS PlayerName, 
        //        Equip.Price, 
        //        Equip.Quantity 
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
        //                decimal price = (decimal)reader["Price"];
        //                int quantity = (int)reader["Quantity"];

        //                Debug.Log($"Player: {playerName}, Price: {price}, Quantity: {quantity}");
        //            }
        //        }
        //    }
        //}
    }
}
public class test5Class {
    public string id;
    public string name;
    public int age;
    public int rank;
    public test5Class(string id, string name, int age, int rank)
    {
        this.id = id;
        this.name = name;
        this.age = age;
        this.rank = rank;
    }
}
