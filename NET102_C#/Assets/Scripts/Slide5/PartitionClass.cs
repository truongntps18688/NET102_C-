using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PartitionClass : MonoBehaviour
{
    void Start()
    {
        var nums = new[] { 1, 2, 3, 4 ,5, 6, 7, 8, 9, 3};

        // take
        var results = nums.Take(3); // lấy ra 3 phần tử
        foreach (var item in results)
        {
            //Debug.Log(item);
        }
        // take while
        var resultsWhile = nums.TakeWhile(num => num > 5);
        foreach (var item in resultsWhile)
        {
            //Debug.Log(item);
        }

        // skip
        // bỏ qua phần tử = 2 đầu tiên
        var scores = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 3, 2 };
        var ressultSkip = scores.Skip(2);
        foreach (var item in ressultSkip)
        {
            Debug.Log(item);
        }

        // skip while
        var scoresWhile = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 3, 2 };

        var ressultSkipWhile = scoresWhile.SkipWhile(x => x > 5);

        foreach (var item in ressultSkipWhile)
        {
            Debug.Log(item);
        }

    }

}
