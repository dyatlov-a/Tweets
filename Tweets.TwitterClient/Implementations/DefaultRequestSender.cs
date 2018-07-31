using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Tweets.TwitterClient.Common;
using Tweets.TwitterClient.Contracts;

namespace Tweets.TwitterClient.Implementations
{
    public class DefaultRequestSender : IRequestSender
    {
        public Task<JObject> SendAsync(string urlString,
            string method,
            string authorization,
            string requestBody = null,
            string contentType = TwitterClientConsts.DefaultContentType)
        {
            if (String.IsNullOrWhiteSpace(urlString))
                throw new ArgumentNullException(nameof(urlString));
            if (String.IsNullOrWhiteSpace(method))
                throw new ArgumentNullException(nameof(method));
            if (String.IsNullOrWhiteSpace(authorization))
                throw new ArgumentNullException(nameof(authorization));
            if (String.IsNullOrWhiteSpace(contentType))
                throw new ArgumentNullException(nameof(contentType));

            return SendAsyncAction(urlString, method, authorization, requestBody, contentType);
        }

        private async Task<JObject> SendAsyncAction(string urlString, 
            string method, 
            string authorization,
            string requestBody,
            string contentType)
        {
            var request = WebRequest.Create(urlString);
            request.Headers.Add("Authorization", authorization);
            request.Method = method;
            request.ContentType = contentType;

            if (!String.IsNullOrWhiteSpace(requestBody))
            {
                var bytearrayRequestContent = Encoding.UTF8.GetBytes(requestBody);
                using (var requestStream = request.GetRequestStream())
                {
                    requestStream.Write(bytearrayRequestContent, 0, bytearrayRequestContent.Length);
                }
            }

            // TODO необходимо добавить токен отмены
            var response = await request.GetResponseAsync();
            if (!(response is HttpWebResponse webResponse) || webResponse.StatusCode != HttpStatusCode.OK)
            {
                throw new ApplicationException($"Request fail, url {urlString}");
            }

            var responseStream = response.GetResponseStream();
            var responseJson = new StreamReader(responseStream).ReadToEnd();
            var jobjectResponse = JObject.Parse(responseJson);

            return jobjectResponse;
        }
    }
}
