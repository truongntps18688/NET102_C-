using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AggretgateClass : MonoBehaviour
{
    void Start()
    {
        List<int> list = new List<int>() { 1, 3, 4, 5, 6, -1};
        // min
        int min = list.Min();
        Debug.Log("min value: " + min);
        // total
        int total = list.Sum();
        Debug.Log("total: " + total);

        var nums = new[] { 1, 2, 3, 4 };
        var sum = nums.Aggregate((a, b) => a + b);
        Debug.Log(sum); // output: 10 (1+2+3+4)

        var chars = new[] { "a", "b", "c", "d" };
        var csv = chars.Aggregate((a, b) => a + ',' + b);
        Debug.Log(csv); // Output: a,b,c,d

        var multipliers = new[] { 10, 20, 30, 40 };
        var multiplied = multipliers.Aggregate(5, (a, b) => a * b);
        Debug.Log(multiplied); //Output: 1200000 ((((5*10)*20)*30)*40)
    }

}

