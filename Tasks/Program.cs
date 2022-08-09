// See https://aka.ms/new-console-template for more information
Console.WriteLine("------------------ Tasks example ------------------");
// using and learning tasks

Task t1 = new Task(() => { Console.WriteLine("Task one"); });

// you can run a task right after another one
Task t2 = t1.ContinueWith((taskcon) => { Console.WriteLine("Task Continued..."); });

t1.Start();

// or Task.Start();

// same as, t1.Wait(); t2.Wait();
Task.WaitAll(t1, t2);

// Could also use a TaskFactory, now we can use a scheduler
TaskFactory taskFactory = new();

taskFactory.StartNew();