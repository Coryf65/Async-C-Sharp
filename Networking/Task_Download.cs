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
            var callback = new AsyncCallback(HttpResponseAvailable); // callbacks run on a background thrad
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

        [Fact]
        public void Download_TaskAsync()
        {
            var httpRequestInfo = HttpWebRequest.CreateHttp(url);
            Task<WebResponse> taskWebResponse = httpRequestInfo.GetResponseAsync();
            Task taskContinuation = taskWebResponse.ContinueWith(
                    HttpResponseContinuation
                    ,TaskContinuationOptions.OnlyOnRanToCompletion);
            
            Task.WaitAll(taskWebResponse, taskContinuation);
        }

        private static void HttpResponseContinuation(Task<WebResponse> taskResponse)
        {
            var httpResponseInfo = taskResponse.Result as HttpWebResponse;
            var responseStream = httpResponseInfo.GetResponseStream();

            using (var sr = new StreamReader(responseStream))
            {
                string webPage = sr.ReadToEnd();
            }
        }
    }
}
