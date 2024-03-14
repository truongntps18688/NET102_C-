using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class JoinOperatorsClass : MonoBehaviour
{
    void Start()
    {
        //LINQInnerJoin();
        //LINQLeftJoin();
        LINQunion();
        LINQIntersect();
        LINQDistinct();
    }

    public void LINQInnerJoin()
    {
        // vd 1 
        List<int> list1 = new List<int>() { 1, 2, 3, 4, 5 };
        List<int> list2 = new List<int>() { 3, 4, 5, 6, 7 };

        var innerJoinResult = list1.Join(list2,
                                         num1 => num1,
                                         num2 => num2,
                                         (num1, num2) => num1);
        // trả về 1 ds chứ các phần tử đêu có cả trong list1 vs list2
        foreach (var num in innerJoinResult)
        {
            Debug.Log(num);
        }

        // vd 2
        List<BrandJoin> listBrand = new List<BrandJoin>();
        listBrand.Add(new BrandJoin(1, "IP 15 pro max"));
        listBrand.Add(new BrandJoin(2, "IP 14 pro max"));
        listBrand.Add(new BrandJoin(3, "IP 13 pro max"));
        listBrand.Add(new BrandJoin(4, "IP 12 pro max"));

        List<ProductJoin> listProductJoin = new List<ProductJoin>();
        listProductJoin.Add(new ProductJoin(1, 100, "Giàu Có"));
        listProductJoin.Add(new ProductJoin(2, 90, "Giàu Có"));
        listProductJoin.Add(new ProductJoin(3, 80, "Giàu Có"));
        listProductJoin.Add(new ProductJoin(4, 70, "Giàu Có"));

        var result = listBrand.Join(listProductJoin,
                                    item1 => item1.id,
                                    item2 => item2.id,
                                    (item1, item2) => new
                                    {
                                        item1.id,
                                        item1.name,
                                        item2.price,
                                        item2.des,
                                    }
        );
        foreach (var item in result)
        {
            Debug.Log("ID: " + item.id + " |name: " + item.name);
            Debug.Log("price: " + item.price + " |des: " + item.des);
            Debug.Log("-----------");
        }
    }
    public void LINQLeftJoin()
    {
        List<BrandJoin> listBrand = new List<BrandJoin>();
        listBrand.Add(new BrandJoin(1, "IP 15 pro max"));
        listBrand.Add(new BrandJoin(2, "IP 14 pro max"));
        listBrand.Add(new BrandJoin(3, "IP 13 pro max"));
        listBrand.Add(new BrandJoin(4, "IP 12 pro max"));

        List<ProductJoin> listProductJoin = new List<ProductJoin>();
        listProductJoin.Add(new ProductJoin(1, 100, "Giàu Có"));
        listProductJoin.Add(new ProductJoin(2, 90, "Giàu Có"));
        listProductJoin.Add(new ProductJoin(3, 80, "Giàu Có"));

        var leftJoinResult = from b in listBrand
                             join p in listProductJoin on b.id equals p.id into ps
                             from p in ps.DefaultIfEmpty()
                             select new { id = b.id, name = b.name, price = p?.price, des = p?.des };
        
        foreach (var item in leftJoinResult)
        {
            Debug.Log("ID: " + item.id + " |name: " + item.name);
            Debug.Log("price: " + item.price + " |des: " + item.des);
            Debug.Log("-----------");
        }

        var result = listBrand.GroupJoin(listProductJoin,
                                    item1 => item1.id,
                                    item2 => item2.id,
                                    (item1, item2) => new 
                                    { item1, item2 }).SelectMany(x => x.item2.DefaultIfEmpty(),
                                    (x, item2) => new
                                    {
                                        id = x.item1.id,
                                        name = x.item1.name,
                                        price = item2?.price,
                                        des = item2?.des,
                                    }
        );
        foreach (var item in result)
        {
            Debug.Log("ID: " + item.id + " |name: " + item.name);
            Debug.Log("price: " + item.price + " |des: " + item.des);
            Debug.Log("-----------------");
        }
    }
    public void LINQunion()
    {
        List<int> list1 = new List<int>() { 1, 2, 3, 4, 5 };

        List<int> list2 = new List<int>() { 3, 4, 5, 6, 7 };

        var newList = list1.Union(list2);

        foreach (var item in newList)
        {
            Debug.Log(item);
        }
    }
    public void LINQIntersect()
    {
        List<int> list1 = new List<int>() { 1, 2, 3, 4, 5 };

        List<int> list2 = new List<int>() { 3, 4, 5, 6, 7 };

        var newList = list1.Intersect(list2);

        foreach (var item in newList)
        {
            Debug.Log(item);
        }
    }
    public void LINQDistinct()
    {
        List<int> list = new List<int>() { 1, 1, 2, 3, 4, 5 };

        var newList = list.Distinct();

        foreach (var item in newList)
        {
            Debug.Log(item);
        }
    }
}
public class ProductJoin
{
    public int id;
    public int price;
    public string des;
    public ProductJoin(int id, int price, string des)
    {
        this.id = id;
        this.price = price;
        this.des = des;
    }
}
public class BrandJoin
{
    public int id;
    public string name;
    public BrandJoin(int _id, string _name)
    {
        id = _id;
        name = _name;
    }
}


