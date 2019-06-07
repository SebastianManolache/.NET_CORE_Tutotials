using AutoMapper;
using WebApplication1.Models;
using WebApplication1.Models.Dtos.Club;
using WebApplication1.Models.Dtos.Player;
using WebApplication1.Models.Dtos.PlayerProfile;

namespace WebApplication1.Profiles
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<Club, ClubPost>();
            CreateMap<Club, ClubGet>();
            CreateMap<Club, ClubPut>();
            CreateMap<Club, ClubGetName>();

            CreateMap<Player, PlayerPost>();
            CreateMap<Player, PlayerGet>();
            CreateMap<Player, PlayerGetName>();
            CreateMap<Player, PlayerPut>();

            CreateMap<PlayerProfile, PlayerProfilePost>();
            CreateMap<PlayerProfile, PlayerProfileGet>();
            CreateMap<PlayerProfile, PlayerProfileGetName>();
            CreateMap<PlayerProfile, PlayerProfilePut>();
        }
    }
}
