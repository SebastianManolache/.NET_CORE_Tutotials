using AutoMapper;
using WebApplication1.Models;
using WebApplication1.Models.Dtos.Club;

namespace WebApplication1.Profiles
{
    public class ClubProfile:Profile
    {
        public ClubProfile()
        {
            CreateMap<Club, ClubPost>();
            CreateMap<Club, ClubGet>();
            CreateMap<Club, ClubPut>();
        }
    }
}
