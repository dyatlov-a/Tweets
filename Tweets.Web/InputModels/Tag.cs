using System.ComponentModel.DataAnnotations;

namespace Tweets.Web.InputModels
{
    public class Tag
    {
        [Required]
        public string Value { get; set; }
    }
}
