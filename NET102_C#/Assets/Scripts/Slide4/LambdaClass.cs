using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LambdaClass : MonoBehaviour
{
    void Start()
    {
        // Dùng Anonymous function
        int[] array = { 1, 2, 3, 4, 5 };

        // Sử dụng anonymous function với phương thức Array.ForEach
        Array.ForEach(array, delegate (int value)
        {
            Debug.Log(value);
        });

        // Sử dụng lambda expression với phương thức Array.ForEach
        Array.ForEach(array, value => Debug.Log(value));

        //(1) có thể bỏ qua kiểu dữ liêu của parameters truyền vào 
        //Action<string> myAction = (string name) => { Debug.Log("name: " + name); };
        //Action<string> myAction = (name) => { Debug.Log("name: " + name); };

        //(2) nếu không có parameters, bỏ dấu ( )
        //Action myAction = () => { Debug.Log("LambdaClass"); };

        //(3) nếu chỉ có 1 parameters, có thể bỏ dấu ( )
        //Action<string> myAction = name => { Debug.Log("LambdaClass: " + name); };

        //(4) nếu có nhiều parameters, ngắn cách bằng dấu phẩy
        //Action<string, string> myAction = (x, y) => { Debug.Log("LambdaClass: "); };


        //(5) nếu anonymous function chỉ có  1 câu lệnh thì có thể bỏ dấu {}
        //Action<string> myAction = name => { Debug.Log("name: " + name); };
        //Action<string> myAction = name => Debug.Log("name: " + name);

        //(5) nếu chỉ có return một giá trị, có thể bỏ qua chữ return
        //Func<int, int> square = x => { return x * x; };
        //Func<int, int> square = x => x * x;

        Func<int, int> myFunc = x =>
        {
            if (x == 1)
            {
                return x + 3;
            }
            return x;
        };

        Func<int, int> test1 = x => x + 3;
        test1(1);
        Func<int, bool> test2 = x => x == 2;
        test2(1);
        Func<int, int, int> test3 = (x,y) => x + y;
        test3(1,2);
        Func<int, int, bool> test4 = (x, y) => x == y;
        test4(1,2);

    }

}
