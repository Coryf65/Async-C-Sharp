namespace Tasks
{
    internal class ParallelTasks
    {
        public ParallelTasks()
        {
            Console.WriteLine("------------------ Parallel Tasks Demo ------------------");

            Console.WriteLine("using a 'For' loop");
            // Runs sequential
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("using a 'Parallel.For' Task loop");
            // Runs out of order using background threads
            // can work with collections
            Parallel.For(0, 100, (i) => { Console.WriteLine(i); });

            // populating 1 thru 100
            List<int> ints = Enumerable.Range(1, 100).ToList();

            Console.WriteLine("using a 'Parallel.ForEach' Task loop");
            // could also use 
            Parallel.ForEach(ints, (i) => { Console.WriteLine(i); });
        }
    }
}