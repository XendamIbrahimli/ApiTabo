using Microsoft.AspNetCore.Mvc;
using Tabo.DTOs.Words;
using Tabo.Exceptions;
using Tabo.Services.Abstracts;

namespace Tabo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordsController(IWordService _service) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(WordCreateDto dto)
        {

            return Ok(await _service.CreateWordAsync(dto));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateMany(List<WordCreateDto> dto)
        {
            foreach (var item in dto) 
            {
                await _service.CreateWordAsync(item);
            }
            return Ok();
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetWordsByLanguageCode(string? code)
        {
            return Ok(await _service.GetWordsByLanguageCode(code));
        }
        [HttpGet]
        public async Task<IActionResult> GetWordById(int id)
        {
            return Ok(await _service.GetWordById(id));
        }

        [HttpPut]
        public async Task<IActionResult> Update(WordUpdateDto dto, int id)
        {
            await _service.UpdateWord(dto, id);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.DeleteWord(id);
                return Ok();

            }catch (Exception ex)
            {
                if(ex is IBaseException bEx)
                {
                    return StatusCode(bEx.StatusCode, new
                    {
                        StatusCode = bEx.StatusCode,
                        Message = bEx.ErrorMessage
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        ex.Message
                    });
                }
            }
        }

    }
}
