using Tabo.DTOs.Games;
using Tabo.DTOs.Words;
using Tabo.Entities;

namespace Tabo.Services.Abstracts
{
    public interface IGameService
    {
        Task<Guid> CreateAsync(GameCreateDto dto);
        Task<WordForGameDto> Start(Guid id);
        Task Fail(Guid id);
        Task Success(Guid id);
        Task<WordForGameDto> Skip(Guid id);
        Task End(Guid id);
    }
}
