using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImplicitlyClass : MonoBehaviour
{
    //var a = 10; 
    // báo lỗi CS0825 khi biến "var" khai báo ngoài cục bộ
    void Start()
    {
        var local = 10;
        Debug.Log(local.GetType());


        var localint = 10;
        var localstring = "welcome to FPT FPOLY";
        var localbool = false;
        var localdouble = 10.5f;
        Debug.Log(localint.GetType());
        Debug.Log(localstring.GetType());
        Debug.Log(localbool.GetType());
        Debug.Log(localdouble.GetType());

        //// hạn chế
        //var x; // Lỗi, không có câu lệnh khởi tạo
        //var y = { 1, 2, 3 }; // Lỗi, câu lệnh khởi tạo không được phép là một tập hợp
        //var z = null; // Lỗi, không được phép là kiểu null
        //var u = x => x + 1; // Lỗi, biểu thức lambda không có kiểu
        //var v = v++; // Lỗi, câu lệnh khởi tạo không được phép tham chiếu lại biến đang được khai báo

        //var b = 100;
        //b = "b"; // lỗi, khi biến được gán lại thì phải cùng kiểu dữ liệu


        // cho biết kết quả
        //var x = 10; //(1);
        //var y; y = 10; //(2)
        //var z = null;//(3)
        //var x = 10, y = 20, y = 30;//(4)
        //var y = 20;//(5)
        //var z = 30;//(6)
        //void getDetailVar(var x)
        //{
        //    Debug.Log(x);
        //}
        //getDetailVar(4);//(7)

        //int x = (x = 20);//(8)
        //var y = (y = 20);//(9)

        //var x = new List<int> { 1, 2, 3 };//(10)
    }

}
