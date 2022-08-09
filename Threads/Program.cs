// See https://aka.ms/new-console-template for more information
Console.WriteLine("------------------ Threads and threading example ------------------");

// Here we are not controlling when the threads are starting and ending
// this means the can run in any order
// Each thread will end whenever the thread is done with it's work
var t1 = new Thread(new ThreadStart(DoWork));
Console.WriteLine("Strating a thread");
t1.Start();

var t2 = new Thread(new ThreadStart(DoWork));
Console.WriteLine("Strating a thread");
t2.Start();

var t3 = new Thread(new ThreadStart(DoWork));
Console.WriteLine("Strating a thread");
t3.Start();

Console.WriteLine("Done...");

static void DoWork()
{
    int x = 10;
    Console.WriteLine("Doing Work for thread ID: {0} value: {1}", Thread.CurrentThread.ManagedThreadId, x);
}