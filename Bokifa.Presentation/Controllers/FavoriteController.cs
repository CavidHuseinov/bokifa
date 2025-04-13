using Bokifa.Application.IServices;
using Bokifa.Domain.DTOs.Favorite;
using Bookifa.Presentation.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Bokifa.Presentation.Controllers
{
    public class FavoriteController : ApiController
    {
        private readonly IFavoriteService _service;
        private readonly IHttpContextAccessor _http;
        public FavoriteController(IFavoriteService service, IHttpContextAccessor http)
        {
            _service = service;
            _http = http;
        }
        [HttpPost("add-favorite")]
        [Authorize] 
        public async Task<IActionResult> AddToFavorites([FromBody] CreateFavoriteDto dto)
        {
            await _service.AddToFavoritesAsync(dto);
            return Ok(new { message = "Book added to favorites successfully" });
        }
    }
}
