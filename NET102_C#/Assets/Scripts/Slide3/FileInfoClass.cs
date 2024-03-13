using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileInfoClass : MonoBehaviour
{
    void Start()
    {

    }
    public void testRead()
    {
        string path = @"Assets\newFile\text.txt"; // đường dẫn 
        if (File.Exists(path))
        {
            FileInfo fileInfo = new FileInfo(path);
            using (StreamReader sr = fileInfo.OpenText())
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
    public void testCreate()
    {
        string path = @"Assets\newFile\text.txt"; // đường dẫn 
        if (File.Exists(path))
        {
            File.Delete(path); //Tạo một đối tượng FileInfo
        }
        FileInfo fi = new FileInfo(path);

        Debug.Log("name: " + fi.Name + " |FullName: " + fi.FullName);
        Debug.Log("CreationTime: " + fi.CreationTime + " |LastAccessTime: " + fi.LastAccessTime);

        // Sử dụng phương thức Create để tạo tệp
        using (StreamWriter sw = fi.CreateText())
        {
            // Ghi dữ liệu vào tệp ở đây nếu bạn muốn
            sw.WriteLine("hello");
            sw.WriteLine("Chào mừng bàn đến với bình nguyên vô tận");
        }
        // Tệp text.txt đã được tạo
    }
}

