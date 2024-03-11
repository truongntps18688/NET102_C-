using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Lab5 : MonoBehaviour
{
    void Start()
    {
        List<UserAccountLab5> list = new List<UserAccountLab5>();
        list.Add(new UserAccountLab5("Sơn Tùng", 10, 55.5f, "Ca Nhạc", 50));
        list.Add(new UserAccountLab5("Đen Vâu", 5, 70, "Ca Nhạc", 10));
        list.Add(new UserAccountLab5("Thùy Linh", 15, 45.5f, "Ca Nhạc", 25));
        list.Add(new UserAccountLab5("Độ Mixi", 1, 90, "ALL", 2));
        list.Add(new UserAccountLab5("bà Tuyết Diamond", 3, 60.5f, "Ẩm thực", 10));
        list.Add(new UserAccountLab5("PewPew", 4, 55.5f, "live", 50));
        list.Add(new UserAccountLab5("Liên Minh", 2, 85.5f, "Game", 255));
        list.Add(new UserAccountLab5("Liên Quân", 11, 55.5f, "Game", 200));
        list.Add(new UserAccountLab5("Fifa 4", 7, 55.5f, "Game", 150));
        list.Add(new UserAccountLab5("CSO", 8, 55.5f, "Game", 1000));
        list.Add(new UserAccountLab5("CSGO", 6, 85.5f, "Game", 500));

        // 1
        foreach (var item in list)
        {
            Debug.Log("Name: " + item.name);
        }
        // 2
        //2a
        var newRate50 = list.SkipWhile(item => item.winRate > 50);
        foreach (var item in newRate50)
        {
            Debug.Log("Name: " + item.name);
        }
        //2b
        var newRateMax = list.OrderByDescending(item => item.winRate).First();
        Debug.Log("newRateMax2: " + newRateMax.name);
        //2c
        Debug.Log("tổng số tài khoản: " + list.Count);

        //3
        //3a
        var newRank = list.OrderBy(item => item.rank);
        foreach (var item in newRank)
        {
            Debug.Log(item.rank);
        };

        //3b
        var newNameSKin = list.OrderBy(item => item.name).ThenBy(item => item.skin);
        foreach (var item in newNameSKin)
        {
            Debug.Log("name: " + item.name + " |skin: " + item.skin);
        };
        //3c
        var newNameB = list.Where(item => item.name.StartsWith("L")).ToList();
        foreach (var item in newNameB)
        {
            Debug.Log("name: " + item.name);
        };

        //4
        Debug.Log("000000000");
        var newlistKeyValue = list.ToLookup(item => item.type);
        foreach (var item in newlistKeyValue)
        {
            Debug.Log("key: " + item.Key + " |Count: " + item.Count());
            foreach (var acc in item)
            {
                Debug.Log("name: " + acc.name + " |type: " + acc.type);
            }
            Debug.Log("----------------");
        }
    }

}
public class UserAccountLab5
{
    public string name;
    public int rank;
    public float winRate;
    public string type;
    public int skin;

    public UserAccountLab5(string _name, int _rank, float _winRate, string _type, int _skin)
    {
        name = _name;
        rank = _rank;
        winRate = _winRate;
        type = _type;
        skin = _skin;
    }
}

