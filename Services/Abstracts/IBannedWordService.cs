using Tabo.DTOs.BannedWords;
using Tabo.Entities;

namespace Tabo.Services.Abstracts
{
    public interface IBannedWordService
    {
        Task Create(BannedWordCreateDto dto);
        Task<BannedWordGetDto> GetById(int id);
        Task<ICollection<BannedWordGetDto>> GetByWordId(int wordId);
        Task Update(int id, BannedWordUpdateDto dto);
        Task Delete(int id);
    }
}
