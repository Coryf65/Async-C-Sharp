namespace UtilityLibrary
{
    public static class Utilities
    {
        public static void PrintThreadID()
        {
            Console.WriteLine("Current Thread: {0}", Thread.CurrentThread.ManagedThreadId);
        }

        public static void PrintIsBackgroundThread()
        {
            Console.WriteLine("Is a Background Thread? {0}", Thread.CurrentThread.IsBackground);
        }
    }
}