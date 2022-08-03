using System.Net;

/// <summary>
/// BEGIN END Pattern
/// </summary>
public class Test_Download
{
    string url = "https://www.twitch.tv";

    // Sync way of downloading the webpage
    [Fact]
    public void Test_Download_MySite()
    {
        // Arrange
        var httpRequestInfo = HttpWebRequest.CreateHttp(url);
        // init round trip to server
        var httpResponse = httpRequestInfo.GetResponse();

        // download page contents
        var responseStream = httpResponse.GetResponseStream();

        using (var sr = new StreamReader(responseStream))
        {
            var webPage = sr.ReadToEnd();
            Console.WriteLine(webPage);
        }
    }

    [Fact]
    public void Test_Download_MySite_async()
    {
        // Arrange
        var httpRequestInfo = HttpWebRequest.CreateHttp(url);
        // init round trip to server
        var callback = new AsyncCallback(HttpResponseAvailable);
        var ar = httpRequestInfo.BeginGetResponse(callback, httpRequestInfo);

        ar.AsyncWaitHandle.WaitOne();
    }

    // callback method
    private static void HttpResponseAvailable(IAsyncResult ar)
    {
        var httpRequestInfo = ar.AsyncState as HttpWebRequest;
        var httpResponseInfo = httpRequestInfo.EndGetResponse(ar) as HttpWebResponse;

        var responseStream = httpResponseInfo.GetResponseStream();
        using (var sr = new StreamReader(responseStream))
        {
            string webPage = sr.ReadToEnd();
        }
    }
}