using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tabo.DAL;
using Tabo.DTOs.Languages;
using Tabo.Entities;
using Tabo.Exceptions.Languages;
using Tabo.Exceptions.Words;
using Tabo.Services.Abstracts;

namespace Tabo.Services.Implements
{
    public class LanguageService:ILanguageService
    {
        readonly TaboDbContext _context;
        readonly IMapper _mapper;

        public LanguageService(TaboDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task CreateAsync(LanguageCreateDto dto)
        {
            if(await _context.Languages.AnyAsync(x=>x.Code==dto.Code))
            {
                throw new LanguageExistException();
            }
            await _context.Languages.AddAsync(_mapper.Map<Language>(dto));
            await _context.SaveChangesAsync();
        }


        public async Task<LanguageGetDto> GetByCodeAsync(string code)
        {
            var data=await _context.Languages.FirstOrDefaultAsync(x=>x.Code==code);

            return _mapper.Map<LanguageGetDto>(data);
            
        }


        public async Task<IEnumerable<LanguageGetDto>> GetAllAsync()
        {
            var datas=await _context.Languages.ToListAsync();
            return _mapper.Map<IEnumerable<LanguageGetDto>>(datas);
        }


        public async Task DeleteAsync(string code)
        {
            var data=await _context.Languages.FindAsync(code);
            if (await _context.Words.AnyAsync(x => x.LanguageCode == data.Code))
                throw new LanguageReferencedException();
            else
            {
                _context.Languages.Remove(data);
                await _context.SaveChangesAsync();
            }
        }


        public async Task UpdateAsync(LanguageUpdateDto dto, string code)
        {
            var data=await _context.Languages.FindAsync(code);

            data.Name=dto.Name;
            data.Icon=dto.Icon;

            await _context.SaveChangesAsync();

        }
    }
}
