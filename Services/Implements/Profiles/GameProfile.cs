using AutoMapper;
using Tabo.DTOs.Games;
using Tabo.Entities;

namespace Tabo.Services.Implements.Profiles
{
    public class GameProfile:Profile
    {
        public GameProfile() 
        {
            CreateMap<GameCreateDto, Game>();
        }
    }
}
