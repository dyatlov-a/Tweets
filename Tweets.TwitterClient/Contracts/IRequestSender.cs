using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using Tweets.TwitterClient.Common;

namespace Tweets.TwitterClient.Contracts
{
    public interface IRequestSender
    {
        Task<JObject> SendAsync(string urlString,
            string method,
            string authorization,
            string requestBody = null,
            string contentType = TwitterClientConsts.DefaultContentType);
    }
}
