using Tabo.DTOs.Games;
using Tabo.DTOs.Words;
using Tabo.Entities;

namespace Tabo.Services.Abstracts
{
    public interface IGameService
    {
        Task<Guid> CreateAsync(GameCreateDto dto);
        Task<WordForGameDto> Start(Guid id);
        Task<WordForGameDto> Skip(Guid id);
        Task<WordForGameDto> Fail(Guid id);
        Task<WordForGameDto> Success(Guid id);
        Task<int> End(Guid id);
    }
}
