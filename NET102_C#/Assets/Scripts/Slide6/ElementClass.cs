using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class ElementClass : MonoBehaviour
{
    void Start()
    {
        //LINQFirst();
        //LINQFirstOrDefault();
        //LINQLast();
        //LINQLastOrDefault();
        //ElementAt_ElementAtOrDefault();
        //LINQSingle();
        //LINQSingleOrDefault();
        LINQDefaultIfEmpty();
    }
    
    public void LINQFirst()
    {
        //LINQ First()
        List<int> nums = new List<int>() { 1, 2, 3, 4, 5, 7, -1 };
        List<string> strings = new List<string>() { "Liên minh",
            "Liên quân", "CSO", "CSGO", "GTA 5" };
        List<string> stringsNull = new List<string>();

        Debug.Log("First int: " + nums.First());
        Debug.Log("First int âm: " + nums.First(i => i < 0));
        Debug.Log("First str: " + strings.First());
        try
        {
            // báo lỗi InvalidOperationException khi list không có giá trị
            Debug.Log("First str null: " + stringsNull.First());
            // báo lỗi InvalidOperationException khi không có phần tử thõa mãn điều kiện
            Debug.Log("First int âm null: " + nums.First(i => i < -10));
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }
    public void LINQFirstOrDefault()
    {
        //FirstOrDefault
        List<int> numsDef = new List<int>() { 1, 2, 3, 4, 5, 7, -1 };
        List<int> numsDefNull = new List<int>() { };
        List<string> stringsDef = new List<string> { null, "T1", "T2" };


        Debug.Log("First: " + numsDef.FirstOrDefault());
        Debug.Log("First: " + numsDefNull.FirstOrDefault());
        try
        {
            Debug.Log("First: " + numsDefNull.FirstOrDefault().ToString());
            Debug.Log("First str: " + stringsDef.FirstOrDefault(i => i.Contains("T")));
            //cố gắng lấy phần tử đầu tiên của nhưng list không có phần tử nào 
            //thì giá trị sẽ trả về null, mà khi chúng ta cố gắng gọi phương thức
            //cho 1 giá trị null thì sẽ sảy ra Exception
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }
    public void LINQLast()
    {
        // LINQ Last() Method
        List<int> numsLast = new List<int>() { 1, 2, 3, 4, 5, 7, -1 };
        List<string> stringsLast = new List<string>() { "Liên minh",
            "Liên quân", "CSO", "CSGO", "GTA 5" };
        List<string> stringsLastNull = new List<string>();
        Debug.Log("Last int: " + numsLast.Last());
        Debug.Log("Last int âm: " + numsLast.Last(i => i < 0));
        Debug.Log("Last str: " + stringsLast.Last());
        try
        {
            // báo lỗi InvalidOperationException khi list không có giá trị
            Debug.Log("Last str null: " + stringsLastNull.Last());
            // báo lỗi InvalidOperationException khi không có phần tử thõa mãn điều kiện
            Debug.Log("Last int âm null: " + numsLast.Last(i => i < -10));
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }
    public void LINQLastOrDefault()
    {
        //LINQ LastOrDefault
        List<int> numsDef = new List<int>() { 1, 2, 3, 4, 5, 7, -1 };
        List<int> numsDefNull = new List<int>() { };
        List<string> stringsDef = new List<string> { null, "T1", "T2" };

        Debug.Log("Last: " + numsDef.LastOrDefault());
        Debug.Log("Last: " + numsDefNull.LastOrDefault());
        try
        {
            Debug.Log("Last: " + numsDefNull.LastOrDefault().ToString());
            Debug.Log("Last str: " + stringsDef.LastOrDefault(i => i.Contains("T")));
            //cố gắng lấy phần tử cuối cùng của nhưng list không có phần tử nào 
            //thì giá trị sẽ trả về null, mà khi chúng ta cố gắng gọi phương thức
            //cho 1 giá trị null thì sẽ sảy ra Exception
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }
    public void ElementAt_ElementAtOrDefault()
    {
        // ElementAt() và ElementAtOrDefault()
        List<int> nums = new List<int>() { 1, 2, 3, 4, 5, 7, -1 };
        List<string> strings = new List<string>() { "Liên minh",
            "Liên quân", null ,"CSO", "CSGO", "GTA 5" };

        Debug.Log("phần tử nums 1st: " + nums.ElementAt(0));
        Debug.Log("phần tử strings 1st: " + strings.ElementAt(0));
        Debug.Log("phần tử nums 11st: " + nums.ElementAtOrDefault(12));
        Debug.Log("phần tử strings 11st: " + strings.ElementAtOrDefault(12));

        Debug.Log("phần tử nums 11st: " + nums.ElementAt(12)); // exception
        Debug.Log("phần tử strings 3st: " + strings.ElementAtOrDefault(2).ToString()); // exception
    }
    public void LINQSingle()
    {
        List<int> nums = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10 };
        List<int> numsOne = new List<int>() { 1 };
        List<string> strings = new List<string> { null, "T1", "T2" };
        List<string> stringsNull = new List<string>();

        Debug.Log("Single: " + nums.Single(n => n == 5));
        Debug.Log("Single: " + numsOne.Single());
        Debug.Log("Single: " + strings.Single()); // exception
        Debug.Log("Single: " + stringsNull.Single()); // exception
        Debug.Log("Single: " + strings.Single(i => i.Contains("T"))); // exception
        Debug.Log("Single: " + nums.Single(i => i == 10)); // exception
    }
    public void LINQSingleOrDefault()
    {
        List<int> nums = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10 };
        List<int> numsOne = new List<int>() { 1 };
        List<string> strings = new List<string> { null, "T1", "T2" };
        List<string> stringsNull = new List<string>();

        Debug.Log("Single: " + nums.SingleOrDefault(n => n == 5));
        Debug.Log("Single: " + nums.SingleOrDefault(i => i == 10)); // exception
        
        Debug.Log("Single: " + numsOne.SingleOrDefault());


        Debug.Log("Single: " + stringsNull.SingleOrDefault());
        Debug.Log("Single: " + stringsNull.SingleOrDefault().ToString()); // exception

        Debug.Log("Single: " + strings.SingleOrDefault()); // exception
        Debug.Log("Single: " + strings.SingleOrDefault(i => i.Contains("T"))); // exception
    }
    public void LINQDefaultIfEmpty()
    {
        List<int> numbers = new List<int>() { 1, 2, 3, 4, 5 };
        var result = numbers.DefaultIfEmpty();
        Debug.Log("Count: " + result.Count());


        List<string> emptyList = new List<string>();
        var newList = emptyList.DefaultIfEmpty("None");
        // trả về None khi list emptyList không có giá trị nào
        Debug.Log("Count: " + newList.Count());
    }
}
