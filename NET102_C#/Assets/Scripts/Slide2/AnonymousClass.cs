using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnonymousClass : MonoBehaviour
{
    void Start()
    {
        // Kết hợp Anonymous methods và delegate truyền tham số cho hàm
        DisplayMsg(delegate (string msg)
        {
            Debug.Log(msg);
        }, "Hello C#");
        // => Hello C#
    }
    public delegate void ShowMsg(string msg); // khai báo một delegate

    // tạo một phưogn thức nhận vào một delegate và một tin nhắn
    public static void DisplayMsg(ShowMsg showMsg, string msg)
    {
        showMsg(msg);
    }
    public void test4()
    {
        // Anonymous methods truy cập biến từ bên ngoài
        int count = 10;
        Action<int> sumCount = delegate (int x)
        {
            // truy cập và sử dụng biến bên ngoài
            int result = x + count;
            Debug.Log("result: " + result);
        };
        // gọi phương thức vô danh
        sumCount(5);
        //thay đổi giá trị biến bên ngoài
        count = 20;
        // gọi lại phương thức vô danh
        sumCount(5);
    }
    public void test3()
    {
        //Phương thức vô danh 
        Action<int> sumAction = delegate (int x)
        {
            Debug.Log(x + x);
        };
        // gọi phương thức vô danh
        sumAction(5);
    }
    public void test2()
    {
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
    }
    public void test()
    {
        var obj = new { Name = "Hide on bush", address = "Korea", Age = 25 };
    }
}
