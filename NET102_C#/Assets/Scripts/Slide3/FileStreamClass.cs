using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class FileStreamClass : MonoBehaviour
{
    void Start()
    {
        string path = "data.txt";
        FileStream F = new FileStream(path, FileMode.Open, FileAccess.Read);

        // ghi file
        string data = "hello word!";

        // chuyển chuỗi thành mảng
        byte[] byteData = Encoding.UTF8.GetBytes(data);

        // khởi tạo đối tượng
        using(FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
        {
            // ghi dữ liệu vào file
            fs.Write(byteData, 0, byteData.Length);
        }

        // đọc file 
        using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            // tạo mảng để lưu dữ liệu
            byte[] datafs = new byte[F.Length];
            // đọc dữ liệu từ file
            F.Read(datafs, 0, datafs.Length);
            // chuyển dữ liệu thành chuối 
            string dataStr = Encoding.UTF8.GetString(datafs);

            // log ra màn hình
            Debug.Log(dataStr);
        }

    }

}
