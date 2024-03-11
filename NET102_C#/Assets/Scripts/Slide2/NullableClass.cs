using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullableClass : MonoBehaviour
{
    void Start()
    {
        int? x = null;
        Debug.Log("x: " + x);
        //int y = null;

        // Sử dụng Nullable Types cho kiểu dữ liệu tham trị
        //Nullable<T> x
        //T? x

        Nullable<int> a = 10;
        int? b = 100;
        bool? c = false;
        int?[] arr = new int?[10];
        List<int?> list = new List<int?>(); // tạo 1 list số, phần tử item có thể là null


        //Cần gán giá trị khi khai báo, nếu không sẽ bị error
        //Nullable<int> err;
        //Debug.Log("err: " + err);


        //Nên kiểm tra giá trị trước khi dùng bằng HasValue
        Nullable<int> a_null = null;
        Debug.Log("a_null: " + a_null);
        if (a_null.HasValue)
        {
            Debug.Log("a_null: " + a_null);
        }
        else
        {
            Debug.Log("a_null: null" );
        }


        //Dùng phương thức GetValueOrDefault()
        Nullable<int> a_getvalue = null;
        Debug.Log("GetValueOrDefault: " + a_getvalue.GetValueOrDefault());

        // Dùng toán tử ?? thực hiện gán Nullable Type cho Non-Nullable Type
        Nullable<int> G = null;
        int y = G ?? 0;
        Debug.Log("y: " + y);
    }
}
