﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tabo.DTOs.Languages;
using Tabo.Services.Abstracts;

namespace Tabo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController(ILanguageService _service): ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get(string? code)
        {
            if(code != null)
            {
                return Ok(await _service.GetByCodeAsync(code)); 
            }
            
            
            return Ok(await _service.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create(LanguageCreateDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(string code, LanguageUpdateDto dto)
        {
            await _service.UpdateAsync(dto, code);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(string code)
        {
            await _service.DeleteAsync(code);
            return Ok();
        }
    }
}