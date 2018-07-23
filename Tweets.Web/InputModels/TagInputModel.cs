using System.ComponentModel.DataAnnotations;

namespace Tweets.Web.InputModels
{
    public class TagInputModel
    {
        [Required]
        public string Value { get; set; }
    }
}
