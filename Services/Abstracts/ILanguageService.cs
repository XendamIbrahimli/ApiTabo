
using Microsoft.AspNetCore.Mvc;
using Tabo.DTOs.Languages;

namespace Tabo.Services.Abstracts
{
    public interface ILanguageService
    {
        Task CreateAsync(LanguageCreateDto dto);
        Task<LanguageGetDto> GetByCodeAsync(string code);
        Task<IEnumerable<LanguageGetDto>> GetAllAsync();
        Task DeleteAsync(string code);
        Task UpdateAsync(LanguageUpdateDto dto,string code);
    }
}
