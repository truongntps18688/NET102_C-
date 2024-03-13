using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class TextWriterClass : MonoBehaviour
{
    void Start()
    {
    }
    public void testWrite()
    {
        string path = "data.txt";
        string data = "hello word!";

        // khởi tạo đối tượng
        using (TextWriter tw = new StreamWriter(path))
        {
            // ghi dữ liệu
            tw.WriteLine(data);
        }
    }
    public void testRead()
    {
        string path = "data.txt";

        using (StreamReader tw = new StreamReader(path))
        {
            string datatxt = tw.ReadToEnd(); // đọc tất cả
            Debug.Log(datatxt);
        }
        using (StreamReader tw = new StreamReader(path))
        {
            string datatxt = tw.ReadLine(); // đọc 1 hàng
            Debug.Log(datatxt);
        }
        using (StreamReader tw = new StreamReader(path))
        {
            // đọc 4 chứ đầu tiên
            char[] charData = new char[4];
            tw.Read(charData, 0, 4);
            string datatxt = new string(charData);
            Debug.Log(datatxt);
        }
    }
}
