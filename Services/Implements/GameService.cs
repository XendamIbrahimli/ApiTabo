using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Tabo.DAL;
using Tabo.DTOs.Games;
using Tabo.DTOs.Words;
using Tabo.Entities;
using Tabo.Extensions;
using Tabo.Services.Abstracts;

namespace Tabo.Services.Implements
{
    public class GameService : IGameService
    {
        readonly TaboDbContext _context;
        readonly IMapper _mapper;
        readonly IMemoryCache _cache;

        public GameService(TaboDbContext context, IMapper mapper, IMemoryCache cache)
        {
            _context = context;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<Guid> CreateAsync(GameCreateDto dto)
        {
            var data=_mapper.Map<Game>(dto);
            await _context.Games.AddAsync(data);
            await _context.SaveChangesAsync();
            return data.Id;
        }

        public Task End(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Fail(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<WordForGameDto> Skip(Guid id)
        {
            var status =_getCurrentGame(id);
            if(status.Skip<=status.MaxSkipCount)
            {
                var currentWord =status.Words.Pop();
                status.Skip++;
                _cache.Set(id,status,TimeSpan.FromSeconds(300));
                return currentWord;
            }
            return null;
        }

        public async Task<WordForGameDto> Start(Guid id)
        {
            var game= await _context.Games.FindAsync(id);
            if(game ==null || game.Score != null)
            {
                throw new Exception();
            }
            IQueryable<Word> query =_context.Words.Where(x=>x.LanguageCode==game.LanguageCode);
            var words =await query.Select(x=>new WordForGameDto
            {
                Id=x.Id,
                Word=x.Text,
                BannedWords=x.BannedWords.Select(y=>y.Text)
            }).ToListAsync();

            var randomWords = words
                .Random()
                .Take(20)
                .ToList();

            var wordsStack = new Stack<WordForGameDto>(randomWords);
            WordForGameDto currentWord=wordsStack.Pop();
            GameStatusDto status= new GameStatusDto()
            {
                Fail=0,
                Success=0,
                Skip=0,
                Words=wordsStack,
                MaxSkipCount=game.SkipCount,
                UsedWordIds= randomWords.Select(x=>x.Id)
            };

            _cache.Set(id, status, TimeSpan.FromSeconds(300));
            return currentWord; 
        }

        public Task Success(Guid id)
        {
            throw new NotImplementedException();
        }

        GameStatusDto _getCurrentGame(Guid id)
        {
            var result =_cache.Get<GameStatusDto>(id);
            if(result == null) 
                throw new Exception();

            return result;
        }
    }
}
