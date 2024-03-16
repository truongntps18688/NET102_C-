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
    public void test6()
    {
        //string dataSource = "your_server_address";
        //string initialCatalog = "your_database_name";
        //bool integratedSecurity = true;

        //string connectionString = $"Data Source={dataSource};Initial Catalog={initialCatalog};Integrated Security={integratedSecurity}";
        //using (CustomerDBDataContext dataContext = new CustomerDBDataContext(connectionString))
        //{
        //    try
        //    {
        //        var customers = dataContext.Customers.ToList();
        //        foreach (var customer in customers)
        //        {
        //            Console.WriteLine($"CompanyName: {customer.CompanyName}");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Lỗi: " + ex.Message);
        //    }
        //}
    }
    public void test7()
    {
        //string dataSource = "your_server_address";
        //string initialCatalog = "your_database_name";
        //bool integratedSecurity = true;

        //string connectionString = $"Data Source={dataSource};Initial Catalog={initialCatalog};Integrated Security={integratedSecurity}";
        //using (CustomerDBDataContext dataContext = new CustomerDBDataContext(connectionString))
        //{
        //    try
        //    {
        //        Customer newCustomer = new Customer();
        //        newCustomer.ID = 1;
        //        newCustomer.Name = "LINQ to SQL";

        //        dataContext.Customers.InsertOnSubmit(newCustomer);
        //        dataContext.SubmitChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Lỗi: " + ex.Message);
        //    }
        //}
    }
    public void test8()
    {
        //string dataSource = "your_server_address";
        //string initialCatalog = "your_database_name";
        //bool integratedSecurity = true;

        //string connectionString = $"Data Source={dataSource};Initial Catalog={initialCatalog};Integrated Security={integratedSecurity}";
        //using (CustomerDBDataContext dataContext = new CustomerDBDataContext(connectionString))
        //{
        //    try
        //    {
        //        Customer newCustomer = dataContext.Customer.Where(item => item.ID == 1).FirsOrDefault();
        //        newCustomer.age = 20;
        //        newCustomer.SubmitChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Lỗi: " + ex.Message);
        //    }
        //}
    }
    public void test9()
    {
        //string dataSource = "your_server_address";
        //string initialCatalog = "your_database_name";
        //bool integratedSecurity = true;

        //string connectionString = $"Data Source={dataSource};Initial Catalog={initialCatalog};Integrated Security={integratedSecurity}";
        //using (CustomerDBDataContext dataContext = new CustomerDBDataContext(connectionString))
        //{
        //    try
        //    {
        //        Customer newCustomer = dataContext.Customer.Where(item => item.ID == 1).FirsOrDefault();
        //        newCustomer.age = 20;

        //        newCustomer.Customer.DeleteOnSumbit(newCustomer);
        //        newCustomer.SubmitChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Lỗi: " + ex.Message);
        //    }
        //}
    }
    public void test10()
    {
        //using (CustomerDBDataContext dataContext = new CustomerDBDataContext())
        //{
        //    try
        //    {
        //        var query = from order in dataContext.Orders
        //                    join customer in dataContext.Customers
        //                    on order.CustomerID equals customer.CustomerID
        //                    select new
        //                    {
        //                        ID = order.ID,
        //                        Name = customer.Name,
        //                        Age = order.Age
        //                    };
        //        foreach (var result in query)
        //        {
        //            Console.WriteLine($"OrderID: {result.OrderID}, CustomerName: {result.CustomerName}, OrderDate: {result.OrderDate}");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
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
