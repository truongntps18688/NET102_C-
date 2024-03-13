using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class BinaryWriterClass : MonoBehaviour
{
    void Start()
    {
        
    }
    public void testWrite()
    {
        string path = "data";
        using (BinaryWriter bw = new BinaryWriter(File.Open(path, FileMode.Create)))
        {
            // ghi một số dữ liệu nguyên thủy vào tệp
            bw.Write(1.2f);
            bw.Write(@"hello");
            bw.Write(10);
            bw.Write(true);
        };
    }
    public void testRead()
    {
        string path = "data";
        using (BinaryReader br = new BinaryReader(File.Open(path, FileMode.Open)))
        {
            // đọc dữ liệu
            float number = br.ReadSingle();
            string txt = br.ReadString();
            int integer = br.ReadInt32();
            bool boolean = br.ReadBoolean();

            // in dữ liệu
            Debug.Log("number: " + number);
            Debug.Log("txt: " + txt);
            Debug.Log("integer: " + integer);
            Debug.Log("boolean: " + boolean);
        };
    }
}
