using Tabo.DTOs.Games;
using Tabo.Entities;

namespace Tabo.Services.Abstracts
{
    public interface IGameService
    {
        Task<Guid> CreateAsync(GameCreateDto dto);
        Task Start(Guid id);
    }
}
