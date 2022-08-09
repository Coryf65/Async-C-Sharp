using UtilityLibrary;

namespace Threads
{
    internal class Signaling
    {
        private ManualResetEvent resetEvent = new(false);

        public Signaling()
        {
            Console.WriteLine("------------------ Signaling example ------------------");

            // QueueUserWorkItem
            Utilities.PrintThreadID();

            // callback to a delegate
            // This is used for a brief work not long running
            ThreadPool.QueueUserWorkItem(new WaitCallback(DoWork));

            Utilities.PrintIsBackgroundThread();

            // our thread runs up to this point and waits for a signal
            resetEvent.WaitOne();
        }

        void DoWork(object state)
        {
            Utilities.PrintThreadID();
            Utilities.PrintIsBackgroundThread();

            resetEvent.Set();
        }
    }
}
