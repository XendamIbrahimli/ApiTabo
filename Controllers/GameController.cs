using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Tabo.DTOs.Games;
using Tabo.Services.Abstracts;

namespace Tabo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController(IGameService _service, IMemoryCache _cache):ControllerBase
    {
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateAsync(GameCreateDto dto)
        {
            
            return Ok(await _service.CreateAsync(dto));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Get(string key)
        {
            return Ok(_cache.Get(key));
        }

        [HttpGet]
        public async Task<IActionResult> Set(string key, string value)
        {
            _cache.Set<string>(key, value,DateTimeOffset.Now.AddSeconds(20));
            return Ok();
        }
    }
}
