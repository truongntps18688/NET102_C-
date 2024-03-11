using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab1 : MonoBehaviour
{
    void Start()
    {
        // bài 1
        Debug.Log("ID: " + userDataLab1.ID);
        Debug.Log("UserName: " + userDataLab1.UserName);
        Debug.Log("HP: " + userDataLab1.HP);
        Debug.Log("point: " + userDataLab1.point);

        // bài 2 
        MapsLab1 maps1 = new MapsLab1("2024", "URF");
        Debug.Log(maps1.ShowData());

        MapsLab1 maps2 = new MapsLab1();
        maps2.ID = "2024";
        maps2.Name = "URF";
        Debug.Log(maps2.ShowData());

        // bài 3
        calculate calculate = new calculate(5, 7);
        calculate.Sum();
        calculate.Sub();
        calculate.multiplication();
        calculate.division();
    }
}

// bài 1
static class userDataLab1
{
    public static string ID;
    public static string UserName;
    public static float HP;
    public static int point;

    static userDataLab1()
    {
        ID = "2024";
        UserName = "Hide on bush";
        HP = 100.5f;    
        point = 100;
    }

}
// bài 2
public class MapsLab1 
{
    public string ID;
    public string Name;
    public static string inGame = "Liên minh huyền thoại";
    public MapsLab1() { }
    public MapsLab1(string _ID, string _Name)
    {
        ID = _ID;
        Name = _Name;
    }
    public string ShowData()
    {
        return "ID: " + ID + " |Name: " + Name + " |inGame: " + inGame;
    }
}
