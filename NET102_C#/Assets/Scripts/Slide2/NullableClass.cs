using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullableClass : MonoBehaviour
{
    void Start()
    {
        //int? x = null;
        //Debug.Log("x: " + x);

        //int x = null; // các biến tham trị không thể gắn trực tiếp null
        //int y = null;

        // có thể gắn biến tham trị bằng null khi thêm dấu "?" vào sau kiểu dữ liệu
        //int? z = null;

        //// Sử dụng Nullable Types cho kiểu dữ liệu tham trị
        //Nullable<T> x
        //// or
        //T? x
    }
    public void testNonNullable()
    {
        // Dùng toán tử ?? thực hiện gán Nullable Type cho Non-Nullable Type
        Nullable<int> test = null;
        int newTest = test ?? 0;
        Debug.Log("newTest: " + newTest);
    }
    public void TestGetValueOrDefault()
    {
        //Dùng phương thức GetValueOrDefault()
        Nullable<int> a_getvalue = null;
        Debug.Log("GetValueOrDefault: " + a_getvalue.GetValueOrDefault());
    }
    public void CheckNullable()
    {
        //Nên kiểm tra giá trị trước khi dùng bằng HasValue
        Nullable<int> test = null;
        if (test.HasValue)
        {
            Debug.Log("test: " + test);
        }
        else
        {
            Debug.Log("test: null");
        }
    }
    public void testNullable3()
    {
        Nullable<int> test = null;
        Debug.Log("test: " + test.Value);
        // lỗi: InvalidOperationException: Nullable object must have a value.
    }
    public void testNullable2()
    {
        //Cần gán giá trị khi khai báo, nếu không sẽ bị error
        Nullable<int> err;
        //Debug.Log("err: " + err); // Use of unassigned local variable 'err'
    }
    public void nullableType()
    {
        Nullable<int> a = 10;
        int? b = 100;
        bool? c = false;
        int?[] arr = new int?[10];
        List<int?> list = new List<int?>(); // tạo 1 list số, phần tử item có thể là null
    }
    public void testNullable1()
    {
        NullableTest nullable1, nullable2;
        nullable1 = new NullableTest(); // gán nullable1 cho một đối tượng
        nullable2 = nullable1; // nullable1 và nullable2 cùng tham chiếu đến một đối tượng
        nullable2.data = "đây là test nullable"; // set data cho nullable2
        nullable1.showData(); // data: đây là test nullable
        nullable2.showData(); // data: đây là test nullable

        nullable1 = null; // gán nullable1 = null => nullable1 không tham chiếu đến đối tượng nào
        nullable1.showData(); // lỗi
        nullable2.showData(); // data: đây là test nullable

        int x = 10; // int là kiểu tham trị, nó có thể gán giá trị cho biễn x = 10;
        //int y = null; //  int là kiểu tham trị, không thế gán null cho một kiểu tham trị
        int? z = null; // có thể gán null cho tham trị khi thêm dấu "?" vào sau kiểu dữ liệu
    }
}
public class NullableTest
{
    public string data = "";
    public void showData()
    {
        Debug.Log("data: " + data);
    }
}

