using System.Net;

namespace Networking
{
    public class Task_Download
    {
        string url = "https://www.twitch.tv";

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
}
