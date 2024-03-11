using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Partial1 : MonoBehaviour
{
    void Start()
    {
        
    }
}
public partial class ProductGaming
{
    public string name;
    public ProductGaming() { }
    public ProductGaming(string _name)
    {
        name = _name;
    }
}
// lab 1 bài 3 
public partial class calculate
{
    private float A;
    private float B;

    public calculate() { }
    public calculate(float _A, float _B)
    {
        A = _A;
        B = _B;
    }
}
