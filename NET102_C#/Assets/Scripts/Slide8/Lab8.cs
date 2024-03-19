using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine;
using System;
using System.Linq;
using ThreadPriority = System.Threading.ThreadPriority;

public class Lab8 : MonoBehaviour
{
    void Start()
    {
        bai1();
    }
    static System.Random random = new System.Random();
    static List<int> list = new List<int>();
    public void bai1()
    {
        // Khởi tạo và bắt đầu thực thi của hai luồng
        Thread thread1 = new Thread(Thread1Function);
        Thread thread2 = new Thread(Thread2Function);

        thread1.Start();
        thread2.Start();
    }
    static void Thread1Function()
    {
        for (int i = 0; i < 100; i++)
        {
            // Sinh số ngẫu nhiên từ 1 đến 20
            int randomNumber = random.Next(1, 11);

            // Hiển thị số ngẫu nhiên ra màn hình
            Debug.Log($"Thread1: Random number generated: {randomNumber}");

            list.Add(randomNumber);
            // Ngủ 2 giây
            Thread.Sleep(2000);
        }
    }

    static void Thread2Function()
    {
        for (int i = 0; i < 100; i++)
        {
            // Đợi 1 giây
            Thread.Sleep(1000);

            // Tính bình phương của số ngẫu nhiên đã được sinh ra bởi Thread1 và hiển thị ra màn hình
            if (list.Count == 0) return;

            int rd = random.Next(0, list.Count - 1);
            int squaredNumber = list[rd] * list[rd];
            Debug.Log($"Thread2: Squared number: {squaredNumber}");
        }
    }

    // bai2
    public void bai2()
    {
        Thread thread1 = new Thread(Thread1FunctionLab8);
        Thread thread2 = new Thread(Thread2FunctionLab8);

        thread1.Start();
        thread2.Start();
        thread1.Join();
        thread2.Join();
        Debug.Log("end start");
    }
    static object lock1 = new object();
    static object lock2 = new object();

    static void Thread1FunctionLab8()
    {
        bool lock1Taken = false;
        bool lock2Taken = false;
        try
        {
            if (Monitor.TryEnter(lock2, TimeSpan.FromMilliseconds(1000)))
            {
                lock2Taken = true;
                Debug.Log("Thread 2 locked lock2");

                Thread.Sleep(100); // Sleep để tạo ra một tình huống deadlock

                Debug.Log("Thread 2 is waiting for lock1");

                if (Monitor.TryEnter(lock1, TimeSpan.FromMilliseconds(1000)))
                {
                    lock1Taken = true;
                    Debug.Log("Thread 2 locked lock1");
                }
                else
                {
                    Debug.Log("Thread 2 couldn't acquire lock1, releasing lock2");
                }
            }
            else
            {
                Debug.Log("Thread 2 couldn't acquire lock2");
            }
        }
        finally
        {
            if (lock1Taken)
                Monitor.Exit(lock1);
            if (lock2Taken)
                Monitor.Exit(lock2);
        }
    }
    static void Thread2FunctionLab8()
    {
        bool lock1Taken = false;
        bool lock2Taken = false;
        try
        {
            if (Monitor.TryEnter(lock1, TimeSpan.FromMilliseconds(1000)))
            {
                lock1Taken = true;
                Debug.Log("Thread 1 locked lock1");

                Thread.Sleep(100); // Sleep để tạo ra một tình huống deadlock

                Debug.Log("Thread 1 is waiting for lock2");

                if (Monitor.TryEnter(lock2, TimeSpan.FromMilliseconds(1000)))
                {
                    lock2Taken = true;
                    Debug.Log("Thread 1 locked lock2");
                }
                else
                {
                    Debug.Log("Thread 1 couldn't acquire lock2, releasing lock1");
                }
            }
            else
            {
                Debug.Log("Thread 1 couldn't acquire lock1");
            }
        }
        finally
        {
            if (lock1Taken)
                Monitor.Exit(lock1);
            if (lock2Taken)
                Monitor.Exit(lock2);
        }
    }
}
