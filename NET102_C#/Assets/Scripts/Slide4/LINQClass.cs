using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LINQClass : MonoBehaviour
{
    void Start()
    {
        string[] name = { "CSO", "PUPG", "Genshin impact", 
            "Liên minh", "Gunny", "GTA 5", "liên quân" };

        var myLinqQuery = name.Where(item => item.Contains('n'));

        foreach (var item in myLinqQuery)
        {
            Debug.Log(item);
        }

        // Tạo một collection chuỗi
        IList<string> stringList = new List<string>() { 
            "C# Tutorials", 
            "VB.NET Tutorials", 
            "Learn C++", 
            "MVC Tutorials", 
            "Java" 
        };

        // Sử dụng LINQ Query Syntax để tìm các chuỗi chứa từ "Tutorials"
        var result = from s in stringList
                     where s.Contains("Tutorials")
                     select s;

        foreach (var item in result)
        {
            Debug.Log(item);
        }

        //

        // Tạo một collection số nguyên
        IList<int> numberList = new List<int>() { 1, 2, 3, 4, 5 };

        // Sử dụng LINQ Query Syntax để tìm các số lớn hơn 2
        var result1 = from num in numberList
                     where num > 2
                     select num;
        foreach (var item in result1)
        {
            Debug.Log(item);
        }


        // Tạo một danh sách số nguyên
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        // Sử dụng lambda expression để lọc ra các số chẵn
        IEnumerable<int> evenNumbers = numbers.Where(n => n % 2 == 0);

        // Hiển thị kết quả
        foreach (int number in evenNumbers)
        {
            Debug.Log(number);
        }


        // Tạo một danh sách số nguyên
        List<int> numbers1 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        // Sử dụng LINQ Mixed Syntax để lọc ra các số lớn hơn 5 và tính tổng
        int sum = (from num in numbers1
                   where num > 5
                   select num).Sum();

        Debug.Log("Tổng các số lớn hơn 5 là: " + sum);
    }

}
