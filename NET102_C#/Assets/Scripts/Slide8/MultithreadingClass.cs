using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using System;
using System.Linq;
using ThreadPriority = System.Threading.ThreadPriority;

public class MultithreadingClass : MonoBehaviour
{
    void Start()
    {

        testDeadlock();

    }
    public void testStart()
    {
        // Tạo một đối tượng Thread và truyền phương thức được thực thi vào trong constructor
        Thread childThread = new Thread(ChildThreadFunction);

        // Bắt đầu sự thực thi của thread con bằng cách gọi phương thức Start()
        childThread.Start();

        // Khi thread con được bắt đầu, thread chính (main thread) vẫn tiếp tục thực thi
        for (int i = 0; i < 5; i++)
        {
            Debug.Log("Main thread is running...");
            Thread.Sleep(1000); // Giả lập việc thực thi công việc trong main thread
        }
    }
    // Phương thức được thực thi trong thread con
    static void ChildThreadFunction()
    {
        for (int i = 0; i < 5; i++)
        {
            Debug.Log("Child thread is running...");
            Thread.Sleep(1000); // Giả lập việc thực thi công việc trong child thread
        }
    }
    //--------------------------------------------------
    public void testAB()
    {
        // tạo và start Thread A
        Thread test1 = new Thread(testA);
        test1.Start();

        // chạy test B
        testB();
    }

    static void testA()
    {
        for (int i = 0; i < 5; i++)
        {
            Debug.Log("A: " + i);
        }
    }
    static void testB()
    {
        for (int i = 0; i < 5; i++)
        {
            Debug.Log("B: " + i);
        }
    }
    //--------------------------------------------------
    public void testSleep()
    {
        Thread myThread = new Thread(MyThreadFunction);

        // Bắt đầu sự thực thi của thread bằng cách gọi phương thức Start()
        myThread.Start();

        // In ra màn hình thông điệp để chỉ ra rằng main thread đang thực thi
        Debug.Log("Main thread is running...");

        // Main thread sẽ ngủ trong 3 giây
        Thread.Sleep(3000);

        // Sau khi ngủ 3 giây, main thread tiếp tục thực thi và kết thúc chương trình
        Debug.Log("Main thread has finished.");
    }

    static void MyThreadFunction()
    {
        // In ra màn hình thông điệp để chỉ ra rằng thread đang thực thi
        Debug.Log("My thread is running...");

        // Thread sẽ ngủ trong 5 giây
        Thread.Sleep(5000);

        // Sau khi ngủ 5 giây, thread tiếp tục thực thi và kết thúc
        Debug.Log("My thread has finished.");
    }
    //--------------------------------------------------

    public void testAbort()
    {
        // Tạo một đối tượng Thread và truyền phương thức được thực thi vào trong constructor
        Thread myThread = new Thread(MyThreadFunctionAbort);

        // Bắt đầu sự thực thi của thread bằng cách gọi phương thức Start()
        myThread.Start();

        // Chờ một khoảng thời gian trước khi ngắt thread
        Thread.Sleep(5000);

        // Ngắt thread bằng phương thức Abort()
        myThread.Abort();

        Debug.Log("Main thread has aborted the child thread.");
    }

    // Phương thức được thực thi trong thread
    static void MyThreadFunctionAbort()
    {
        try
        {
            while (true)
            {
                Debug.Log("Child thread is running...");
                Thread.Sleep(1000);
            }
        }
        catch (ThreadAbortException)
        {
            // Xử lý khi thread bị ngắt
            Debug.Log("Child thread has been aborted.");
        }
    }
    //--------------------------------------------------

    public void testThreadClass()
    {
        userDataSlide8 data = new userDataSlide8("2024", "Thread");
        Thread test = new Thread(FuncTestClass);
        test.Start(data);
    }
    static void FuncTestClass(System.Object data)
    {
        // Ép kiểu tham số về kiểu dữ liệu mong muốn
        userDataSlide8 thread_Data = (userDataSlide8)data;

        // In ra thông điệp được truyền từ main thread
        Debug.Log("id: " + thread_Data.id + " |name: " + thread_Data.name);
    }
    //--------------------------------------------------
    public void testThreadLambdaExpression()
    {
        Thread test = new Thread((obj) =>
        {
            userDataSlide8 data = (userDataSlide8)obj;
            Debug.Log("id: " + data.id + " |name: " + data.name);
        });
        test.Start(new userDataSlide8("2024", "Thread"));
    }
    //--------------------------------------------------

    public void testForegroundThread()
    {
        Thread test = new Thread(() =>
        {
            Thread.Sleep(1000);
            Debug.Log("Thread test start");
        });
        test.IsBackground = true; // IsBackground
        test.Start();
        Debug.Log("Main thread ending....");
    }
    //--------------------------------------------------
    public void testThreadPooling()
    {
        // Thêm các tác vụ vào Thread Pool bằng phương thức QueueUserWorkItem()
        for (int i = 0; i < 5; i++)
        {
            int taskNumber = i + 1;
            ThreadPool.QueueUserWorkItem(FuncThreadPooling, taskNumber);
            Debug.Log($"Task {taskNumber} has been queued.");
        }
        // Đợi một lát để xem Thread Pool hoạt động
        Thread.Sleep(2000);
    }

    // Phương thức được thực thi trong Thread Pool
    static void FuncThreadPooling(object state)
    {
        int taskNumber = (int)state;
        Debug.Log($"Task {taskNumber} is being executed.");
        Thread.Sleep(1000); // Giả lập việc thực hiện một công việc mất thời gian
        Debug.Log($"Task {taskNumber} has been completed.");
    }
    //--------------------------------------------------
    public void testThreadName()
    {
        // Tạo và bắt đầu thực thi của hai luồng
        Thread thread1 = new Thread(FuncName);
        thread1.Name = "FirstThread";
        thread1.Start();

        Thread thread2 = new Thread(FuncName);
        thread2.Name = "SecondThread";
        thread2.Start();

        // Đợi một chút để đảm bảo cả hai luồng đã kết thúc
        Thread.Sleep(2000);
    }

    static void FuncName()
    {
        // Lấy tên của luồng đang thực thi và in ra màn hình
        string currentThreadName = Thread.CurrentThread.Name;
        Debug.Log("Thread name: " + currentThreadName);

        // Mô phỏng việc thực hiện một số công việc trong luồng
        for (int i = 1; i <= 3; i++)
        {
            Debug.Log($"Thread {currentThreadName} thực thi... ({i}/3)");
            Thread.Sleep(1000);
        }

        Debug.Log($"Thread {currentThreadName} hoàn thành");
    }
    //--------------------------------------------------

    public void testPriority()
    {
        DateTime time = DateTime.Now;
        Debug.Log(time);

        Thread thread1 = new Thread(FuncPriority);
        thread1.Name = "Thread1";
        thread1.Priority = ThreadPriority.Highest;
        thread1.Start();

        Thread thread2 = new Thread(FuncPriority);
        thread2.Name = "Thread2";
        thread2.Priority = ThreadPriority.Lowest;
        thread2.Start();
    }

    public void FuncPriority()
    {
        string currentThreadName = Thread.CurrentThread.Name;
        for (int i = 1; i <= 100000; i++)
        {
            Debug.Log($"Thread {currentThreadName}: Line {i}");
        }
        Debug.Log("Thread " + currentThreadName + " end time " + DateTime.Now);

    }
    //--------------------------------------------------

    static object lock1 = new object();
    static object lock2 = new object();

    static void Thread1Function()
    {
        lock (lock1)
        {
            Debug.Log("Thread 1 locked lock1");

            // Sleep để tạo ra một tình huống deadlock
            Thread.Sleep(100);

            Debug.Log("Thread 1 is waiting for lock2");

            lock (lock2)
            {
                Debug.Log("Thread 1 locked lock2");
            }
        }
    }

    static void Thread2Function()
    {
        lock (lock2)
        {
            Debug.Log("Thread 2 locked lock2");

            // Sleep để tạo ra một tình huống deadlock
            Thread.Sleep(100);

            Debug.Log("Thread 2 is waiting for lock1");

            lock (lock1)
            {
                Debug.Log("Thread 2 locked lock1");
            }
        }
    }
    public void testDeadlock()
    {
        Thread thread1 = new Thread(Thread1FunctionNew);
        Thread thread2 = new Thread(Thread2FunctionNew);

        thread1.Start();
        thread2.Start();
        thread1.Join();
        thread2.Join();
        Debug.Log("end start");
    }
    static void Thread2FunctionNew()
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
    static void Thread1FunctionNew()
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
public class userDataSlide8
{
    public string id;
    public string name;
    public userDataSlide8(string id, string name)
    {
        this.id = id;
        this.name = name;
    }
}

