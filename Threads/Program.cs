// See https://aka.ms/new-console-template for more information
Console.WriteLine("------------------ Threads and threading example ------------------");

Console.WriteLine("Strating a thread");

// Here we are not controlling when the threwads are starting and ending
var t1 = new Thread(new ThreadStart(DoWork));
t1.Start();

var t2 = new Thread(new ThreadStart(DoWork));
t2.Start();

var t3 = new Thread(new ThreadStart(DoWork));
t3.Start();

Console.WriteLine("Done...");

static void DoWork()
{
    int x = 10;
    Console.WriteLine("Doing Work for thread ID: {0} value: {1}", Thread.CurrentThread.ManagedThreadId, x);
}