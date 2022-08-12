using System.Collections.Concurrent;
using System.Net;

Console.WriteLine("------------------ Async Await examples ------------------");

Console.WriteLine("Example 1: download from a url");
//Download();

Console.WriteLine("Example 2: Read a text file");
ConcurrentDictionary<string, uint> wordCount = new();
ProcessTextFileAsync();

async void Download()
{
    string url = "https://twitch.tv";
    var downloader = new WebClient();
    byte[] rawdata = await downloader.DownloadDataTaskAsync(url); // the compiler will do magic to split this up
    Console.WriteLine(rawdata.Length);
}

void ProcessTextFileAsync()
{
    string filename = @"X:\Code\Github\Networking\AsyncAwait\exampleFiles\demoFile.txt";
    string[] lines = File.ReadAllLines(filename);

    Parallel.ForEach(lines,
        (string line) => 
        {
            string[] words =  line.Split(' ');
            foreach (string word in words)
            {
                if (string.IsNullOrEmpty(word))
                {
                    continue;
                }

                // count the word once per instance
                wordCount.AddOrUpdate(word, 1, (k, currentCount) => { return currentCount++; });

            }
        });
}