using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab2 : MonoBehaviour
{
    dynamic x = 10;
    void Start()
    {
        // bài 1
        //Debug.Log(x);
        // 1b
        getDetail(10);
        getDetail("games");
        getDetail(true);
        getDetail(9.5);

        // 1c
        userDataLab2 data = new userDataLab2("2024", "Hide on bush", 100);
        data.getInfo();


        // bài 2:
        var userInfp = new
        {
            id = "2024",
            name = "faker",
            isplaying = false,
            bag = new
            {
                skins = 0,
                cups = 20,
            }
        };
        Debug.Log("id: " + userInfp.id);
        Debug.Log("name: " + userInfp.name);
        Debug.Log("isplaying: " + userInfp.isplaying);
        Debug.Log("bag skins: " + userInfp.bag.skins);
        Debug.Log("bag cups: " + userInfp.bag.cups);

        // 2b
        int y = 10;
        Action<int> AnonymousMethod = delegate (int x)
        {
            int sum = x + y;
            int sub = x - y;
            Debug.Log("sum: " + sum);
            Debug.Log("sub: " + sub);
        };
        AnonymousMethod(5);

        // bài 3
        List<float> datafloat = new List<float>() { 10, 9, 8, 7.5f, 2, 1.4f };
        userDataLab2Bai3 userDataLab2Bai3 = new userDataLab2Bai3("bài 3_2", "bài 3_2");
        foreach (var item in datafloat)
        {
            userDataLab2Bai3.scores.Add(item);
        }
        // or
        //userDataLab2Bai3.scores.AddRange(datafloat);

    }
    public void getDetail(dynamic a)
    {
        //Debug.Log(a);
    }
}
[SerializeField]
public class userDataLab2
{
    public string ID;
    public string userName;
    public int level;
    public userDataLab2(string _ID, string _userName, int _level)
    {
        ID = _ID;
        userName = _userName;
        level = _level;
    }
    public void getInfo()
    {
        Debug.Log("ID: " + ID + " |userName: " + userName + " |level: " + level);
    }
}

[SerializeField]
public class userDataLab2Bai3
{
    public string id;
    public string userName;
    public List<float> scores = new List<float>();
    public userDataLab2Bai3(string _id, string _userName)
    {
        id = _id;
        userName = _userName;
    }
}
