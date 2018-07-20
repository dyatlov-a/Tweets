namespace Tweets.TwitterClient.Common
{
    public class TwitterClientSettings
    {
        public string CultureInfo { get; set; }
        public string DateTimeFormat { get; set; }
        public string TokenUrl { get; set; }
        public string QueryUrlPattern { get; set; }
        public string ConsumerKey { get; set; }
        public string ConsumerSecret { get; set; }
        public string TweetsFieldName { get; set; }
        public string AccessTokenFieldName { get; set; }
    }
}
