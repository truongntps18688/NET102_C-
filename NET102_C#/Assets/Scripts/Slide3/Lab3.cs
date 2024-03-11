using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System;

public class Lab3 : MonoBehaviour
{
    void Start()
    {
        //bai1();
        //bai2();
        bai3();
    }
    public void bai1()
    {
        // bài 1 
        string path = "data.txt";
        using (FileStream fs = new FileStream(path, FileMode.Create))
        {
            // Tạo một đối tượng StreamWriter để ghi dữ liệu vào FileStream
            using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
            {
                sw.WriteLine("username: myUsername");
                sw.WriteLine("password: myPassword");
            }
        }

        //// Tạo một đối tượng FileStream để đọc dữ liệu
        using (FileStream fs = new FileStream(path, FileMode.Open))
        {
            // Tạo một đối tượng StreamReader để đọc dữ liệu từ FileStream
            using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Debug.Log(line);
                }
            }
        }
    }
    public void bai2()
    {
        //bài 2
        string username = "myUsername";
        string password = "myPassword";
        string time = DateTime.Now.ToString();

        // Sử dụng StringWriter để lưu tài khoản và mật khẩu
        using (StringWriter sw = new StringWriter())
        {
            sw.WriteLine("username: " + username);
            sw.WriteLine("password: " + password);
            sw.WriteLine("time save: " + time);

            // Lấy chuỗi từ StringWriter
            string content = sw.ToString();

            // Sử dụng StringReader để đọc tài khoản và mật khẩu
            using (StringReader sr = new StringReader(content))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Debug.Log(line);
                }
            }   
        }
    }
    public void bai3()
    {
        string path = @"Assets\data"; // đường dẫn 
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path); // tạo thư mục
        }


        string pathtxt = @"Assets\data\data.txt";
        if (File.Exists(pathtxt))
        {
            File.Delete(pathtxt);
        }
        FileInfo fi = new FileInfo(pathtxt); // tạo file
        using (StreamWriter sw = fi.CreateText())
        {
            sw.WriteLine("mssv: 1000");
            sw.WriteLine("name: bai3");
        }


        string path2 = @"Assets\data2"; // đường dẫn 
        if (!Directory.Exists(path2))
        {
            Directory.CreateDirectory(path2);
        }
        CopyDirectory(path, path2);
    }
    public static void CopyDirectory(string sourceDirectory, string targetDirectory)
    {
        DirectoryInfo diSource = new DirectoryInfo(sourceDirectory);
        DirectoryInfo diTarget = new DirectoryInfo(targetDirectory);

        CopyAll(diSource, diTarget);
    }

    public static void CopyAll(DirectoryInfo source, DirectoryInfo target)
    {
        Directory.CreateDirectory(target.FullName);

        foreach (FileInfo fi in source.GetFiles())
        {
            fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
        }

        foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
        {
            DirectoryInfo nextTargetSubDir =
                target.CreateSubdirectory(diSourceSubDir.Name);
            CopyAll(diSourceSubDir, nextTargetSubDir);
        }
    }
}
