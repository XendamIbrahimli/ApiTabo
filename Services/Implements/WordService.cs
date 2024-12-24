using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Tabo.DAL;
using Tabo.DTOs.Words;
using Tabo.Entities;
using Tabo.Exceptions.Languages;
using Tabo.Exceptions.Words;
using Tabo.Services.Abstracts;

namespace Tabo.Services.Implements
{
    public class WordService:IWordService
    {
        readonly TaboDbContext _context;
        readonly IMapper _mapper;
        public WordService(TaboDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper=mapper;
        }
        public async Task<int> CreateWordAsync(WordCreateDto dto)
        {
            Word word = new()
            {
                LanguageCode = dto.LangCode,
                BannedWords = dto.BannedWords.Select(x => new BannedWord
                {
                    Text = x
                }).ToList(),
                Text= dto.Text
            };
            await _context.Words.AddAsync(word);
            await _context.SaveChangesAsync();
            return word.Id;
        }

        public async Task<IEnumerable<WordGetDto>> GetWordsByLanguageCode(string code)
        {
            var datas=await _context.Words.Where(x=>x.LanguageCode==code).ToListAsync();
            return _mapper.Map<IEnumerable<WordGetDto>>(datas);
        }

        public async Task<WordGetDto> GetWordById(int Id)
        {
            var data=await _context.Words.FirstOrDefaultAsync(x=>x.Id==Id);
            return _mapper.Map<WordGetDto>(data);
        }

        public async Task UpdateWord(WordUpdateDto dto,int id)
        {
            var data = await _context.Words.FirstOrDefaultAsync(x=>x.Id==id);

            data.Text=dto.Text;
            data.LanguageCode=dto.LanguageCode;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteWord(int id)
        {
            if (await _context.BannedWords.AnyAsync(x => x.WordId == id))
                throw new WordReferencedException();
            else
            {
                var data = await _context.Words.FindAsync(id);
                _context.Words.Remove(data);
                await _context.SaveChangesAsync();
            }
        }
    }
}
