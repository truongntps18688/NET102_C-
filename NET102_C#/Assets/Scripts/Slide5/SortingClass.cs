using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SortingClass : MonoBehaviour
{
    void Start()
    {

       
    }
    public void testOrderByRank()
    {
        //OrderBy
        List<leaderboard> listleaderboard = new List<leaderboard>();
        listleaderboard.Add(new leaderboard("Tú Bà", 1, 90));
        listleaderboard.Add(new leaderboard("Thúy Kiều", 3, 60));
        listleaderboard.Add(new leaderboard("Thúy Vân", 4, 60));
        listleaderboard.Add(new leaderboard("Trọng Thủy", 2, 75));
        listleaderboard.Add(new leaderboard("Mị Châu", 5, 55.5f));
        listleaderboard.Add(new leaderboard("Báo Hồng", 6, 45));

        // sắp xếp giảm dần theo rank
        var listRank = listleaderboard.OrderBy(e => e.rank);
        foreach (var item in listRank)
        {
            Debug.Log(item.rank);
        }
    }
    public void testOrderByName()
    {
        //OrderBy
        List<leaderboard> listleaderboard = new List<leaderboard>();
        listleaderboard.Add(new leaderboard("Tú Bà", 1, 90));
        listleaderboard.Add(new leaderboard("Thúy Kiều", 3, 60));
        listleaderboard.Add(new leaderboard("Thúy Vân", 4, 60));
        listleaderboard.Add(new leaderboard("Trọng Thủy", 2, 75));
        listleaderboard.Add(new leaderboard("Mị Châu", 5, 55.5f));
        listleaderboard.Add(new leaderboard("Báo Hồng", 6, 45));

        // sắp xếp tăng dần theo tên 
        var listName = listleaderboard.OrderBy(e => e.name);
        foreach (var item in listName)
        {
            Debug.Log(item.name);
        }
    }
    public void testLINQqueries()
    {
        //LINQ OrderBy viết theo cách LINQ queries

        // mảng số
        var listQueries = new[] { 10, 45, 35, 29, 100, 69, 58, 50 };
        var orderedNums = from num in listQueries
                          orderby num
                          select num;
        // mảng chuỗi
        var cities = new[] { "Barcelona", "London", "Paris", "New York",
            "Moscow", "Amsterdam", "Tokyo", "Florence" };
        var orderedCities = from city in cities
                            orderby city
                            select city;
        // sắp xếp theo 1 thuộc tính cụ thể
        var fruits = new ArrayList();
        fruits.Add("mango");
        fruits.Add("apple");
        fruits.Add("lemon");
        IEnumerable<string> query = from fruit in fruits.Cast<string>()
                                    where fruit.StartsWith("m")
                                    orderby fruit
                                    select fruit;
    }
    public void testThenBy()
    {
        // sắp xếp theo nhiều tiêu chí 
        List<GameAll> gameAlls = new List<GameAll>();
        gameAlls.Add(new GameAll("FPS", 70));
        gameAlls.Add(new GameAll("RPG", 30));
        gameAlls.Add(new GameAll("MOBA", 55));
        gameAlls.Add(new GameAll("PC", 90));
        gameAlls.Add(new GameAll("Control", 0));
        var sortedGamesDescending = gameAlls.OrderByDescending(g => g.GameType).ThenByDescending(g => g.rate);
        var sortedGames = gameAlls.OrderBy(g => g.GameType).ThenBy(g => g.rate);
        foreach (var item in sortedGames)
        {
            Debug.Log("GameType: " + item.GameType + " |WinRate: " + item.rate);
        }
    }
}

public class leaderboard
{
    public string name;
    public int rank;
    public float rate;
    public leaderboard(string _name, int _rank, float _rate)
    {
        name = _name;
        rank = _rank;
        rate = _rate;
    }
}
public class GameAll
{
    public string GameType;
    public float rate;
    public GameAll(string _GameType, float _rate)
    {
        GameType = _GameType;
        rate = _rate;
    }
}
