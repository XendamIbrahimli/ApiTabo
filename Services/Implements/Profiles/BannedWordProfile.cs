using AutoMapper;
using Tabo.DTOs.BannedWords;
using Tabo.Entities;

namespace Tabo.Services.Implements.Profiles
{
    public class BannedWordProfile:Profile
    {
        public BannedWordProfile()
        {
            CreateMap<BannedWordCreateDto, BannedWord>();
            CreateMap<BannedWord, BannedWordGetDto>();
        }
    }
}
