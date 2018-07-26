using AutoMapper;
using System.Linq;
using Tweets.Domain.Models.Tweets;
using Tweets.Queries.Dtos;

namespace Tweets.Web.Infrastructure.Profiles
{
    public class TweetsProfile : Profile
    {
        public TweetsProfile()
        {
            CreateMap<Picture, PictureDto>();
            CreateMap<Tweet, TweetDto>();
            CreateMap<TweetsCollection, TweetsCollectionDto>()
                .ForMember(tc => tc.Tweets, tc => tc.MapFrom(e => e.Tweets.OrderByDescending(t => t.CreatedAt)));
        }
    }
}
