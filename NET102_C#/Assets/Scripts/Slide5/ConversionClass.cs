using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class ConversionClass : MonoBehaviour
{
    void Start()
    {
        
    }
    public void testToList()
    {
        string[] arr = { "Liên Minh", "CSO", "GTA 5", "Genshin impact", "PUPG", "Gunny" };

        List<string> listStr = arr.ToList();

        foreach (var item in listStr)
        {
            Debug.Log(item);
        }
    }
    public void testToArray()
    {
        string[] arr = { "Liên Minh", "CSO", "GTA 5", "Genshin impact", "PUPG", "Gunny" };

        string[] newArr = arr.ToArray();

        foreach (var item in newArr)
        {
            Debug.Log(item);
        }
    }
    public void testToLookup()
    {
        // toLookup
        List<EnemyConversion> listEnemy = new List<EnemyConversion>();
        listEnemy.Add(new EnemyConversion("Chó", "thú"));
        listEnemy.Add(new EnemyConversion("Mèo", "thú"));
        listEnemy.Add(new EnemyConversion("Chào Mào", "chim"));
        listEnemy.Add(new EnemyConversion("Cò", "Chim"));
        listEnemy.Add(new EnemyConversion("Cá Con", "cá"));
        listEnemy.Add(new EnemyConversion("Cá Mập", "cá"));

        var newListEnemy = listEnemy.ToLookup(item => item.enemyType);
        foreach (var item in newListEnemy)
        {
            Debug.Log("key: " + item.Key + " |Count: " + item.Count());
            foreach (var enemy in item)
            {
                Debug.Log("name: " + enemy.name + " |type: " + enemy.enemyType);
            }
            Debug.Log("----------------");
        }
    }
    public void testCast()
    {
        // ép kiểu 
        ArrayList list = new ArrayList { 10, 20, 30 };

        IEnumerable<int> result = list.Cast<int>();

        foreach (var item in result)
        {
            Debug.Log(item);
        }
    }
    public void testCast1()
    {
        // ép kiểu không hợp lệ
        var mixedList = new List<object>() { 1, "two", 3, "four", 5 };

        try
        {
            var intList = mixedList.Cast<int>().ToList();
        }
        catch (Exception ex)
        {
            Debug.Log("Exception: " + ex);
        }
    }
    public void testOfTypeToList()
    {
        // OfType
        var mixedListOfType = new List<object>() { 1, "two", 3, "four", 5, true, false };

        var intListOfType = mixedListOfType.OfType<int>().ToList();
        var stringList = mixedListOfType.OfType<string>().ToList();

        Debug.Log("Integer values:");
        foreach (var i in intListOfType)
        {
            Debug.Log(i);
        }

        Debug.Log("String values:");
        foreach (var str in stringList)
        {
            Debug.Log(str);
        }
    }
    public void testAsEnumerable()
    {
        //AsEnumerable
        // tạo 1 list Enumerable.Range(a, b); tạo list số từ a đến (a + b -1) 
        var numbers = Enumerable.Range(3, 10);
        var asEnumerableNumbers = numbers.AsEnumerable();

        foreach (var number in asEnumerableNumbers)
        {
            Debug.Log(number);
        }
    }
    public void testToDictionary()
    {
        //LINQ ToDictionary

        List<EnemyConversion> listEnemyDir = new List<EnemyConversion>();
        listEnemyDir.Add(new EnemyConversion("Chó", "thú"));
        listEnemyDir.Add(new EnemyConversion("Mèo", "thú"));
        listEnemyDir.Add(new EnemyConversion("Chào Mào", "chim"));
        listEnemyDir.Add(new EnemyConversion("Cò", "Chim"));
        listEnemyDir.Add(new EnemyConversion("Cá Con", "cá"));
        listEnemyDir.Add(new EnemyConversion("Cá Mập", "cá"));

        var newlistEnemyDir = listEnemyDir.ToDictionary(item => item.enemyType);
        foreach (var item in newlistEnemyDir)
        {
            Debug.Log("key: " + item.Key + " |value: " + item.Value);
        }
    }
}

public class EnemyConversion
{
    public string name;
    public string enemyType;
    public EnemyConversion(string _name, string type)
    {
        name = _name;
        enemyType = type;
    }
}