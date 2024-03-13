using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class FileStreamClass : MonoBehaviour
{
    void Start()
    {

    }
    public void readFile()
    {
        string path = "data.txt";
        using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            // tạo mảng để lưu dữ liệu
            byte[] datafs = new byte[fs.Length];
            // đọc dữ liệu từ file
            fs.Read(datafs, 0, datafs.Length);
            // chuyển dữ liệu thành chuối 
            string dataStr = Encoding.UTF8.GetString(datafs);

            // log ra màn hình
            Debug.Log(dataStr);
        }
    }
    public void WriteFile()
    {
        string path = "data.txt";
        string data = "hello word!";

        // chuyển chuỗi thành mảng
        byte[] byteData = Encoding.UTF8.GetBytes(data);

        // khởi tạo đối tượng
        using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
        {
            // ghi dữ liệu vào file
            fs.Write(byteData, 0, byteData.Length);
        }
    }
    public void CreateFile()
    {
        string path = "data.txt";
        FileStream F = new FileStream(path, FileMode.Open, FileAccess.Read);
    }

    public void CreateFileStream()
    {
        //FileStream < tên_đối_tượng > = new FileStream(< tên_file >, < FileMode >, < FileAccess >, < FileShare >);
        //< tên_đối_tượng > là tên của đối tượng FileStream mà bạn muốn tạo.
        //< tên_file > là tên của file mà bạn muốn mở.
        //< FileMode > là một giá trị từ enum FileMode, xác định cách mở hoặc tạo file.
        //<FileAccess> là một giá trị từ enum FileAccess, xác định cách truy cập file(đọc, ghi, hoặc cả hai).
        //<FileShare> là một giá trị từ enum FileShare, xác định cách chia sẻ file với các tiến trình khác1
    }
}
