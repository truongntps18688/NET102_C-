using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Lab6 : MonoBehaviour
{
    void Start()
    {
        //bai1();
        //bai2();
        bai3();
    }
    public void bai1()
    {
        List<int> listInt = new List<int>() { 2, 4, 5, 6, 7, 8, 9 };
        List<string> listStr = new List<string>() { null, "T1", "T2", "T3", null };
        List<string> listNull = new List<string>();

        //a / Tìm số chẵn đầu tiên và lớn hơn 5 trong listInt
        var a1 = listInt.FirstOrDefault(item => item % 2 == 0 && item > 5);
        var a2 = listInt.First(item => item % 2 == 0 && item > 5);

        //b / Tìm phần tử cuối cùng trong listInt có giá trị > 200
        var a = listInt.LastOrDefault(item => item > 200);

        //c / Tìm phần tử đầu tiên trong listStr có giá trị bắt đầu bằng ký tự “T”
        var c = listStr.FirstOrDefault(item => item?.StartsWith("T") == true);

        //d / Tính tổng các trị tại vị trí index lẻ và số đó chia hết cho 2 trong listInt
        var d = listInt.Where((value, index) => index % 2 != 0 && value % 2 == 0).Sum();
    }
    public void bai2()
    {
        List<ShopLab6> listShop = new List<ShopLab6>();
        listShop.Add(new ShopLab6(1, "HCM", "Quận 12"));
        listShop.Add(new ShopLab6(2, "Hà Nội", "Quận Nam từ liên"));
        listShop.Add(new ShopLab6(3, "Đà nắng", "Quận Hải châu"));

        List<PhoneLab6> listPhone = new List<PhoneLab6>();
        listPhone.Add(new PhoneLab6(1, 1,"IP 15", 100, "độc lạ bình dương"));
        listPhone.Add(new PhoneLab6(2, 2,"IP 16", 1000, "độc lạ bình dương"));
        listPhone.Add(new PhoneLab6(3, 3,"IP 17", 10000, "độc lạ bình dương"));
        listPhone.Add(new PhoneLab6(4, 1,"IP 18", 100000, "độc lạ bình dương"));

        //a
        var result = listShop.Join(listPhone,
                                    num1 => num1.id,
                                    num2 => num2.id,
                                    (item1, item2) => new
                                    {
                                        ShopName = item1.name,
                                        PhoneName = item2.name,
                                    }
            );
        foreach (var item in result)
        {
            Debug.Log(item.ShopName + " : " + item.PhoneName);
        }
        //b
        var resultb = listShop.GroupJoin(listPhone,
                                        shop => shop.id,
                                        phone => phone.shop_id,
                                        (shop, phones) => new
                                        {
                                            ShopId = shop.id,
                                            ShopName = shop.name,
                                            ShopAddress = shop.address,
                                            Phones = phones.Select(phone => new
                                            {
                                                PhoneId = phone.id,
                                                PhoneName = phone.name,
                                                PhonePrice = phone.price,
                                                PhoneDescription = phone.des
                                            })
                                        }
        );
        foreach (var item in resultb)
        {
            Debug.Log("-------------");
            Debug.Log("shop name: " + item.ShopName);
            foreach (var phone in item.Phones)
            {
                Debug.Log("phoneName: " + phone.PhoneName + " : " + "phonePrice: " + phone.PhonePrice); 
            }

        }

    }
    public void bai3()
    {
        List<int> list1 = new List<int>() { 1, 2, 3, 4, 5 };
        List<int> list2 = new List<int>() { 5, 6, 7, 8, 1 };

        // a
        var newList = list1.Union(list2).OrderByDescending(x => x);
        // b
        var b = list1.Intersect(list2);
        //c
        var c = list1.Concat(list2).OrderBy(x => x);
        //d
        var d = list1.Except(list2);
    }
}
public class PhoneLab6
{
    public int id;
    public int shop_id;
    public string name;
    public int price;
    public string des;
    public PhoneLab6(int id, int shop_id, string name,int price, string des)
    {
        this.id = id;
        this.shop_id = shop_id;
        this.name = name;
        this.price = price;
        this.des = des;
    }
}
public class ShopLab6
{
    public int id;
    public string name;
    public string address;
    public ShopLab6(int _id, string _name, string _address)
    {
        id = _id;
        name = _name;
        address = _address;
    }
}
