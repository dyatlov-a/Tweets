using System.Threading.Tasks;

namespace Tweets.TwitterClient.Contracts
{
    public interface ITokenProvider
    {
        Task<string> GetToken();
    }
}
