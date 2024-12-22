using AutoMapper;
using Tabo.DTOs.Languages;
using Tabo.Entities;

namespace Tabo.Services.Implements.Profiles
{
    public class LanguageProfile:Profile
    {
        public LanguageProfile()
        {
            CreateMap<LanguageCreateDto, Language>(); //Create
            CreateMap<Language, LanguageGetDto>(); //Get
        }
    }
}
