using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Tabo.DAL;
using Tabo.DTOs.Games;
using Tabo.Entities;
using Tabo.Services.Abstracts;

namespace Tabo.Services.Implements
{
    public class GameService : IGameService
    {
        readonly TaboDbContext _context;
        readonly IMapper _mapper;

        public GameService(TaboDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> CreateAsync(GameCreateDto dto)
        {
            var data=_mapper.Map<Game>(dto);
            await _context.Games.AddAsync(data);
            await _context.SaveChangesAsync();
            return data.Id;
        }
        public async Task Start(Guid id)
        {

        }
    }
}
