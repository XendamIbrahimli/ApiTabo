using System.Collections;
using System.Collections.Generic;
using Tabo.DTOs.Words;

namespace Tabo.Services.Abstracts
{
    public interface IWordService
    {
        Task<int> CreateWordAsync(WordCreateDto dto);
        Task UpdateWord(WordUpdateDto dto, int id);
        Task<IEnumerable<WordGetDto>> GetWordsByLanguageCode(string code);
        Task<WordGetDto> GetWordById(int id);
        Task DeleteWord(int id);
    }
}
