using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tabo.DAL;
using Tabo.DTOs.BannedWords;
using Tabo.Entities;
using Tabo.Exceptions.BannedWords;
using Tabo.Services.Abstracts;

namespace Tabo.Services.Implements
{
    public class BannedWordService:IBannedWordService
    {
        readonly TaboDbContext _context;
        readonly IMapper _mapper;
        public BannedWordService(TaboDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task Create(BannedWordCreateDto dto)
        {
            if (await _context.Words.AnyAsync(x => x.Id == dto.WordId))
            {
                var data = _mapper.Map<BannedWord>(dto);
                await _context.BannedWords.AddAsync(data);
                await _context.SaveChangesAsync();
            }
            else
                throw new WordDoesnotExistException();

        }

        public async Task<BannedWordGetDto> GetById(int id)
        {
            var data=await _context.BannedWords.FindAsync(id);
            return _mapper.Map<BannedWordGetDto>(data);
        }

        public async Task<ICollection<BannedWordGetDto>> GetByWordId(int wordId)
        {
            var datas = await _context.BannedWords.Where(x => x.WordId == wordId).ToListAsync();
            return _mapper.Map<ICollection<BannedWordGetDto>>(datas);
        }

        public async Task Update(int id, BannedWordUpdateDto dto)
        {
            var data = await _context.BannedWords.FindAsync(id);
            data.Text= dto.Text;
            data.WordId= dto.WordId;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var data= await _context.BannedWords.FindAsync(id);
            _context.BannedWords.Remove(data);
            await _context.SaveChangesAsync();
        }
    }
}
