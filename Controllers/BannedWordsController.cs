using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tabo.DTOs.BannedWords;
using Tabo.Exceptions;
using Tabo.Services.Abstracts;

namespace Tabo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannedWordsController(IBannedWordService _service) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(BannedWordCreateDto dto)
        {
            await _service.Create(dto);
            return Ok();
        }


        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _service.GetById(id));
        }

        [HttpGet("{wordId}")]
        public async Task<IActionResult> GetByWordId(int wordId)
        {
            return Ok(await _service.GetByWordId(wordId));
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, BannedWordUpdateDto dto)
        {
            await _service.Update(id, dto);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return Ok();
        }

    }
}
