﻿using Microsoft.AspNetCore.Mvc;
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

        [HttpPost("[action]")]
        public async Task<IActionResult> Start(Guid id)
        {

            return Ok(await _service.Start(id));
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Skip(Guid id)
        {

            return Ok(await _service.Skip(id));
        }

    }
}
