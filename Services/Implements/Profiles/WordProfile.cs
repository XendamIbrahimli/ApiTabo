using AutoMapper;
using Tabo.DTOs.Words;
using Tabo.Entities;

namespace Tabo.Services.Implements.Profiles
{
    public class WordProfile : Profile
    {
        public WordProfile() 
        {
            CreateMap<WordCreateDto, Word>()
                .ForMember(w=>w.LanguageCode,wcd=>wcd.MapFrom(x=>x.LangCode));
            CreateMap<Word, WordGetDto>();
        }
    }
}
