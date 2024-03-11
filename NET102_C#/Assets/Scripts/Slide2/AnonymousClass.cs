using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnonymousClass : MonoBehaviour
{
    void Start()
    {
        var obj = new { Name = "Hide on bush", address = "Korea", Age = 25 };

        var data = new
        {
            id = "2024",
            name = "faker",
            isplaying = false,
            games = new
            {
                name = "Liên minh huyền thoại",
                accountName = "Hide on bush",
            }
        };
        Debug.Log("id: " + data.id);
        Debug.Log("name: " + data.name);
        Debug.Log("isplaying: " + data.isplaying);
        Debug.Log("games name: " + data.games.name);
        Debug.Log("games accountName: " + data.games.accountName);

        //Phương thức vô danh 
        Action<int> sumAction = delegate (int x)
        {
            Debug.Log(x + x);
        };
        sumAction(5);




        // Anonymous methods truy cập biến từ bên ngoài

        int count = 10;
        Action<int> sumCount = delegate (int x)
        {
            Debug.Log(x + count);
        };
        sumCount(5);

        // Kết hợp Anonymous methods  và delegate truyền tham số cho hàm
        DisplayMsg(delegate (string msg)
        {
            Debug.Log(msg);
        }, "Hello C#");
    }
    public delegate void ShowMsg(string msg);
    public static void DisplayMsg(ShowMsg showMsg, string msg)
    {
        showMsg(msg);
    }
}
