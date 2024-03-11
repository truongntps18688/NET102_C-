using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Partial2 : MonoBehaviour
{
    void Start()
    {
        
    }
}
public partial class ProductGaming
{
    public void getDetailProductGaming()
    {
        Debug.Log("name: " + name);
    }
}
// lab 1 bài 3
public partial class calculate
{
    public void Sum()
    {
        Debug.Log("tổng A + B: " + (A + B));
    }
    public void Sub()
    {
        Debug.Log("hiệu A - B: " + (A - B));
    }
    public void multiplication()
    {
        Debug.Log("tích A * B: " + (A * B));
    }
    public void division()
    {
        Debug.Log("thương A / B: " + (A / B));
    }
}
