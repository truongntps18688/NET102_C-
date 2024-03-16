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
    public void bai2()
    {
        //a
        //using (CustomerDBDataContext dataContext = new CustomerDBDataContext())
        //{
        //    try
        //    {
        //        var query = from order in dataContext.Orders
        //                    join customer in dataContext.Customers
        //                    on order.CustomerID equals customer.CustomerID
        //                    select new
        //                    {
        //                        NameOrder = order.Name,
        //                        NameCustomer = customer.Name,
        //                    };
        //        foreach (var result in query)
        //        {
        //            Console.WriteLine($"OrderID: {result.OrderID}, CustomerName: {result.CustomerName}");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}
        //b
        //using (CustomerDBDataContext dataContext = new CustomerDBDataContext())
        //{
        //    try
        //    {
        //        Customer newCustomer = new Customer();
        //        newCustomer.CustomerID = "2024";
        //        newCustomer.CompanyName = "Độ tộc";

        //        dataContext.Customers.InsertOnSubmit(newCustomer);
        //        dataContext.SubmitChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Lỗi: " + ex.Message);
        //    }
        //}
        //c
        //using (CustomerDBDataContext dataContext = new CustomerDBDataContext())
        //{
        //    try
        //    {
        //        Customer newCustomer = dataContext.Customer.Where(item => item.CustomerID == "2024").FirsOrDefault();
        //        newCustomer.CustomerID = "Bộ tộc gaming";
        //        newCustomer.SubmitChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Lỗi: " + ex.Message);
        //    }
        //}
        //d
        //using (CustomerDBDataContext dataContext = new CustomerDBDataContext())
        //{
        //    try
        //    {
        //        Customer newCustomer = dataContext.Customer.Where(item => item.CustomerID == "2024").FirsOrDefault();
        //        newCustomer.Customer.DeleteOnSumbit(newCustomer);
        //        newCustomer.SubmitChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Lỗi: " + ex.Message);
        //    }
        //}
    }
}
