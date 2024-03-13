using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DirectoryClass : MonoBehaviour
{
    void Start()
    {
        
    }
    public void testCopy()
    {
        string pathDir = @"Assets\newFile"; // đường dẫn 
        string pathDirNew = @"Assets\test1"; // đường dẫn 
        CopyDirectory(pathDir, pathDirNew);
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

        // Sao chép từng tập tin vào thư mục mới.
        foreach (FileInfo fi in source.GetFiles())
        {
            fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
        }

        // Sao chép từng thư mục con bằng cách sử dụng đệ quy.
        foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
        {
            DirectoryInfo nextTargetSubDir =
                target.CreateSubdirectory(diSourceSubDir.Name);
            CopyAll(diSourceSubDir, nextTargetSubDir);
        }
    }
    
    public void testCreateDirectory()
    {
        string path = @"Assets\newFile"; // đường dẫn 
        // kiểm tra thư mục đó đã tồn tại hay là chưa
        if (!Directory.Exists(path))
        {
            // tạo thư mục
            Directory.CreateDirectory(path);
        }
    }
    public void DirectoryInfoTest()
    {
        // Directory info
        string path = @"Assets\newFile"; // đường dẫn 
        DirectoryInfo dir = new DirectoryInfo(path);
        if (dir.Exists)
        {
            // đã có thư mục
            Debug.Log(dir.Name);
            Debug.Log(dir.FullName);
            Debug.Log(dir.CreationTime);
            Debug.Log(dir.LastAccessTime);
        }
        else
        {
            dir.Create(); // tạo thư mục
            Debug.Log(dir.Name);
            Debug.Log(dir.FullName);
            Debug.Log(dir.CreationTime);
            Debug.Log(dir.LastAccessTime);
        }
    }
}
