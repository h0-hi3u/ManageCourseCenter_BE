﻿using MCC.DAL.Dto.AcademicTranscriptDto;
using MCC.DAL.Dto.CartDto;
using MCC.DAL.Service.Implements;
using MCC.DAL.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MCC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost("create-cart")]
        public async Task<IActionResult> CreateCartAsync(CartCreateDto cartCreateDto)
        {
            var result = await _cartService.CreateCartAsync(cartCreateDto);
            return Ok(result);
        }

        [HttpPut("update-cart-status")]
        public async Task<IActionResult> UpdateStatusCartAsync(UpdateStatusCartDto updateStatusCartDto)
        {
            var result = await _cartService.UpdateStatusCartAsync(updateStatusCartDto);

            return Ok(result);
        }
    }
}
