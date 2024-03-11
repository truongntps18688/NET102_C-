using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class BinaryWriterClass : MonoBehaviour
{
    void Start()
    {
        string path = "data";
        using (BinaryWriter bw = new BinaryWriter(File.Open(path, FileMode.Create)))
        {
            bw.Write(1.2f);
            bw.Write(@"hello");
            bw.Write(10);
            bw.Write(true);
        };

        // đọc file
        using(BinaryReader br = new BinaryReader(File.Open(path, FileMode.Open)))
        {
            float number = br.ReadSingle();
            string txt = br.ReadString();
            int integer = br.ReadInt32();
            bool boolean = br.ReadBoolean();
            Debug.Log("number: " + number);
            Debug.Log("txt: " + txt);
            Debug.Log("integer: " + integer);
            Debug.Log("boolean: " + boolean);
        };
    }

}
