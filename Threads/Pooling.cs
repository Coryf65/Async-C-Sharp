using UtilityLibrary;

namespace Threads
{
    public class Pooling
    {
        // Easy Pools
        // learning about pools and threads
        // 
        public Pooling()
        {
            Console.WriteLine("------------------ Pooling Example ------------------");

            // QueueUserWorkItem
            Utilities.PrintThreadID();

            // callback to a delegate
            // This is used for a brief work not long running
            ThreadPool.QueueUserWorkItem(new WaitCallback(DoWork));

            Utilities.PrintIsBackgroundThread();
        }

        void DoWork(object state)
        {
            Utilities.PrintThreadID();
            Utilities.PrintIsBackgroundThread();
        }
    }
}