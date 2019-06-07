using System;
using System.Collections.Generic;
using WebApplication1.Models;
using WebApplication1.Models.Dtos.Club;

namespace WebApplication1.TestingService.FakeData
{
    public class ClubData : Club
    {
        public List<Club> FakeClubs()
        {
            return new List<Club>()
            {
                new Club
                {
                    Id = 2,
                    Name = "AAA",
                    Coach = "BBB",
                    FoundationData = DateTime.UtcNow,
                    Players = null
                    },
                new Club
                {
                    Id = 4,
                    Name = "CCC",
                    Coach = "DDD",
                    FoundationData = DateTime.UtcNow,
                    Players = null
                }
            };
        }

        public Club FakeCLub()
        {
            return new Club
            {
                Id = 2,
                Name = "AAA",
                Coach = "BBB",
                FoundationData = DateTime.UtcNow,
                Players = null
            };
        }

        public List<Club> FakeEmptyClubs()
        {
            var clubs = new List<Club>();

            return clubs;
        }

        public List<ClubGet> FakeClubGets()
        {
            return new List<ClubGet>()
            {
                new ClubGet
                {
                    Id = 2,
                    Name = "AAA",
                    Coach = "BBB",
                    FoundationData = DateTime.UtcNow,
                    Players = null
                    },
                new ClubGet
                {
                    Id = 4,
                    Name = "CCC",
                    Coach = "DDD",
                    FoundationData = DateTime.UtcNow,
                    Players = null
                }
            };
        }
        public List<ClubGet> FakeEmptyClubGets()
        {
            return new List<ClubGet>()
            {
                new ClubGet
                {
                    Id = 2,
                    Name = "AAA",
                    Coach = "BBB",
                    FoundationData = DateTime.UtcNow,
                    Players = null
                    },
                new ClubGet
                {
                    Id = 4,
                    Name = "CCC",
                    Coach = "DDD",
                    FoundationData = DateTime.UtcNow,
                    Players = null
                }
            };
        }
        public Club FakeClub()
        {
            return new Club()
            {
                Id = 1,
                Name = "Club1",
                Coach = "Coach1",
                FoundationData = DateTime.UtcNow,
                Players = null
            };
        }

        public ClubPost FakeClubPost()
        {
            return new ClubPost()
            {
                Name = "Club1",
                Coach = "Coach1",
                FoundationData = DateTime.UtcNow,
            };
        }
        public int FakeGuids() { return 2; }


    }
}
