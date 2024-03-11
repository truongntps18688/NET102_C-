using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class staticClass : MonoBehaviour
{
    void Start()
    {
        //sử dụng
        Player player1 = new Player();
        player1.playerName = "Yasuo";
        Debug.Log(player1.playerName);
        Player player2 = new Player();
        player2.playerName = "Leesin";
        Debug.Log(player2.playerName);

        // sử dụng
        Calculaotr cale = new Calculaotr();
        int result = cale.Sum(5, 3);
        Debug.Log("result: " + result);

        // sử dụng
        Character character = new Character("2024", "Leesin quyền thái", DateTime.Now);
        character.showCharacter();

        // sử dụng
        userData.UserDataLog("Hide on bush", 100, 10000);
        userData.UserDataLog("Cưởng 7 núi", 99, 5000);

        //sử dụng
        PlayerData playerData = new PlayerData(10);
        Debug.Log(playerData.PlayerAction("Leesin", 100));

        // sử dụng
        StaticUserData.detail();
        Debug.Log("userID: " + StaticUserData.userID);
        Debug.Log("userName: " + StaticUserData.userName);

        // sử dụng partial
        ProductGaming product = new ProductGaming("FPOLY");
        product.getDetailProductGaming();

        //sử dụng hash set
        HashSet<string> Games = new HashSet<string>();
        Games.Add("Liên minh huyền thoại");
        Games.Add("Genshin impact");
        Games.Add("CSO");
        Games.Add("GTA 5");
        Games.Add("GTA 5"); // phần tử này sẽ không được thêm vào hashset vì nó đã tồn tại

        foreach (string item in Games)
        {
            Debug.Log("Games item: " + item);
        }
        Debug.Log("tổng phần tử trong Games: " + Games.Count);

        HashSet<string> GamingS = new HashSet<string>() { "CSO", "GTA 5", "PUPG", "C#" };
        foreach (string item in GamingS)
        {
            Debug.Log("GamingS item: " + item);
        }
        Debug.Log("tổng phần tử trong GamingS: " + GamingS.Count);

        // sử dụng LinkedList
        LinkedList<string> linkedList = new LinkedList<string>();
        linkedList.AddLast("Liên minh huyền thoại");
        linkedList.AddLast("Genshin impact");
        linkedList.AddLast("CSO");
        linkedList.AddLast("GTA 5");
        linkedList.AddLast("Gunny");

        ShowLogLinkedList(linkedList);

        // xóa phần tử đầu tiên
        linkedList.Remove(linkedList.First);
        ShowLogLinkedList(linkedList);

        // xóa phần tử có tên là Gunny
        linkedList.Remove("Gunny");
        ShowLogLinkedList(linkedList);

        // xóa phần tử đầu tiên
        linkedList.RemoveFirst();
        ShowLogLinkedList(linkedList);

        // xóa toàn bộ phần tử 
        linkedList.Clear();
        ShowLogLinkedList(linkedList);

        // sử dụng list
        List<string> listTxt = new List<string>();
        listTxt.Add("Liên minh huyền thoại");
        listTxt.Add("Genshin impact");
        listTxt.Add("CSO");
        listTxt.Add("GTA 5");
        listTxt.Add("GTA 5");

        Debug.Log(listTxt.Contains("CSO")); // true or false
    }
    public void ShowLogLinkedList(LinkedList<string> list)
    {
        foreach (string item in list)
        {
            Debug.Log("item: " + item);
        }
        Debug.Log("tổng số phần tử của list: " + list.Count);
    }
}
[SerializeField]
public class Player
{
    public string playerName;
}
[SerializeField]
public class Calculaotr
{
    public int Sum(int a, int b)
    {
        return a + b;
    }
}
[SerializeField]
public class Character
{
    public string ID;
    public string Name;
    public DateTime OwershipDate;
    public static string Ower = "Riot games";

    public Character(string _ID, string _Name, DateTime time)
    {
        ID = _ID;
        Name = _Name;
        OwershipDate = time;
    }
    public void showCharacter()
    {
        string txt = "ID: " + ID + " |Character Name: " + Name + " |ngày sở hữu: " + OwershipDate + " |người sở hữu: " + Ower;
        Debug.Log(txt);
    }
}
[SerializeField]
public class userData
{
    public static void UserDataLog(string Name, int lv, float gold)
    {
        string txt = "Name: " + Name + " |Level user: " + lv + " |userGold: " + gold;
        Debug.Log(txt);
    }
}
[SerializeField]
public class PlayerData
{
    static int HP = 0;
    static PlayerData()
    {
        Debug.Log("khởi tạo PlayerDat");
    }
    public PlayerData(int _HP)
    {
        HP = _HP;
        Debug.Log("truyền data HP: " + HP);
    }
    public string PlayerAction(string name, int point)
    {
        return "userName: " + name + " |Point: " + point + " |HP: " + HP;
    }
}
[Serializable]
public class StaticUserData
{
    public static string userName = "Hide on bush";
    public static string userID = "0195";
    public static bool playing = false;
    public static void detail()
    {
        Debug.Log("userName: " + userName + " |userID: " + userID + " |playing: " + playing);
    }
}