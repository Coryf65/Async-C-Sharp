// See https://aka.ms/new-console-template for more information
Console.WriteLine("------------------ Threads and threading example ------------------");

Console.WriteLine("Strating a thread");

// Here we are not controlling when the threwads are starting and ending
var t = new Thread(new ThreadStart(DoWork));
t.Start();

Console.WriteLine("Done...");

void DoWork()
{
    Console.Write("Sleeping");
    Console.Write(".");
    Console.Write(".");
    Console.Write(".");
    Thread.Sleep(1000);
}