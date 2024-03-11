using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Lab4 : MonoBehaviour
{
    void Start()
    {
        bai1();
        bai2();
        bai3();
        bai4();
    }
    public void bai1()
    {
        List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };
        var newList = list.FindAll(item => item % 2 == 0);
        foreach (var item in newList)
        {
            Debug.Log(item);
        }
    }
    public void bai2()
    {
        List<userDataLab4> list = new List<userDataLab4>();
        list.Add(new userDataLab4("GTA 5", 10));
        list.Add(new userDataLab4("Genshin impact", 15));
        list.Add(new userDataLab4("Gunny", 5));
        list.Add(new userDataLab4("Liên minh huyền thoại", 100));

        var selectedData = list.Select(u => new { u.name, u.level });
        foreach (var item in selectedData)
        {
            Debug.Log("Name: " + item.name + " |level: " + item.level);
        }
        var sortedData = list.OrderByDescending(u => u.level);
        foreach (var item in sortedData)
        {
            Debug.Log("Name: " + item.name + " |level: " + item.level);
        }
    }
    public void bai3()
    {
        List<studentLab4> list = new List<studentLab4>();
        list.Add(new studentLab4("1","Bảo Trâm", 13));
        list.Add(new studentLab4("2","Quốc Trung", 12));
        list.Add(new studentLab4("3", "Huyền Trang", 15));
        list.Add(new studentLab4("4", "Gia Lâm", 20));
        list.Add(new studentLab4("5", "Vân Anh", 16));

        //LINQ Query Syntax:
        var filteredStudentsQuery = from s in list
                                    where s.age > 12 && s.age < 20
                                    select s;
        // LINQ Method Syntax:
        var filteredStudentsMethod = list.Where(s => s.age > 12 && s.age < 20);
    }
    public void bai4()
    {
        List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        var MethodSyntax = (from num in list
                            where num > 5
                            select num).Sum();
        Debug.Log("sum is: " + MethodSyntax);
    }
}
[SerializeField] 
public class userDataLab4
{
    public string name;
    public int level;
    public userDataLab4(string _name, int lv)
    {
        name = _name;
        level = lv;
    }
}
[SerializeField]
public class studentLab4
{
    public string id;
    public string name;
    public int age;
    public studentLab4(string _id, string _name, int _age)
    {
        id = _id;
        name = _name;
        age = _age;
    }
}