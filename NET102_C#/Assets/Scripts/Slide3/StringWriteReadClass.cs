using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class StringWriteReadClass : MonoBehaviour
{
    void Start()
    {
        string data = "hello word!";

        // lưu dữ liệu vào 1 chuỗi
        StringWriter sw = new StringWriter();
        sw.Write(data);

        // lấy data từ chuỗi StringWriter
        string txt = sw.ToString();


        // đọc data từ bằng StringReader
        StringReader sr = new StringReader(txt);
        string line = sr.ReadLine();

        Debug.Log(line);
    }
}
