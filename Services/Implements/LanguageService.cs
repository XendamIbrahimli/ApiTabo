using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tabo.DAL;
using Tabo.DTOs.Languages;
using Tabo.Services.Abstracts;

namespace Tabo.Services.Implements
{
    public class LanguageService:ILanguageService
    {
        readonly TaboDbContext _context;

        public LanguageService(TaboDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(LanguageCreateDto dto)
        {
            await _context.Languages.AddAsync(new Entities.Language
            {
                Name = dto.Name,
                Icon = dto.Icon,
                Code = dto.Code
            });
            await _context.SaveChangesAsync();
        }

        public async Task<LanguageGetDto?> GetByCodeAsync(string code)
        {
            var data=await _context.Languages.FirstOrDefaultAsync(x=>x.Code==code);

            return new LanguageGetDto
            {
                Name=data.Name,
                Icon=data.Icon,
                Code=data.Code
            };
            
        }

        public async Task<IEnumerable<LanguageGetDto>> GetAllAsync()
        {
            return await _context.Languages.Select(x => new LanguageGetDto
            {
                Name = x.Name,
                Icon = x.Icon,
                Code = x.Code
            }).ToListAsync();
        }

        public async Task DeleteAsync(string code)
        {
            var data=await _context.Languages.FindAsync(code);
            _context.Languages.Remove(data);
            await _context.SaveChangesAsync();
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
