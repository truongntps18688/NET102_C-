using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dynamicClass : MonoBehaviour
{
    void Start()
    {
        dynamic x = 10;
        dynamic y = true;
        dynamic z = "C#";

        dynamic localint = 10;
        dynamic localstring = "welcome to FPT FPOLY";
        dynamic localbool = false;
        dynamic localdouble = 10.5f;
        //Debug.Log(localint.GetType());
        //Debug.Log(localstring.GetType());
        //Debug.Log(localbool.GetType());
        //Debug.Log(localdouble.GetType());

        sum(5, 7);
        sum(10, 1);

        // gán đối tượng
        string name = "Hide on bush";
        float point = 9.5f;

        dynamic dynamicName = name; // gán biến name và dynamicName, nhưng kiểu dữ liệu vẫn chưa được xác nhận
        //Debug.Log("player name: " + dynamicName + " : point: " + point);

    }
    public void sum(dynamic a, dynamic b)
    {
        //Debug.Log("sum a + b: " + (a + b));
    }
}

