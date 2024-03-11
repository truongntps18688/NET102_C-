using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileInfoClass : MonoBehaviour
{
    void Start()
    {
        string path = @"Assets\newFile\text.txt"; // đường dẫn 

        // Tạo một đối tượng FileInfo
        if (File.Exists(path))
        {
            File.Delete(path);
        }
        FileInfo fi = new FileInfo(path);

        Debug.Log(fi.Name);
        Debug.Log(fi.FullName);
        Debug.Log(fi.CreationTime);
        Debug.Log(fi.LastAccessTime);

        // Sử dụng phương thức Create để tạo tệp
        using (StreamWriter sw = fi.CreateText())
        {
            // Ghi dữ liệu vào tệp ở đây nếu bạn muốn
            sw.WriteLine("hello");
            sw.WriteLine("Chào mừng bàn đến với bình nguyên vô tận");
        }

        // Tệp text.txt đã được tạo

        // đọc file
        if (File.Exists(path))
        {
            FileInfo fileInfo = new FileInfo(path);
            using(StreamReader sr = fileInfo.OpenText())
            {
                string txt;
                // Đọc và log từng dòng
                while ((txt = sr.ReadLine()) != null)
                {
                    Debug.Log(txt);
                }
            }
        }

    }

}
