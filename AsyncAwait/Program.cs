using System.Net;

Console.WriteLine("------------------ Async Await examples ------------------");

string url = "https://twitch.tv";

Download();

async void Download()
{
    var downloader = new WebClient();
    byte[] rawdata = await downloader.DownloadDataTaskAsync(url); // the compiler will do magic to split this up
    Console.WriteLine(rawdata.Length);
}