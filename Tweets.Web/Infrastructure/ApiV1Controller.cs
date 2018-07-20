using Microsoft.AspNetCore.Mvc;

namespace Tweets.Web.Infrastructure
{
    [Route("api/" + ApiVersion + "/[controller]")]
    public abstract class ApiV1Controller : ControllerBase
    {
        public const string ApiVersion = "v1"; 
    }
}
