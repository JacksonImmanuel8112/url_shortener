using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using urlshortner.Data;
using urlshortner.Helper;
using urlshortner.Models;

namespace urlshortner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlShortenerController : ControllerBase
    {

        public readonly AppContextDb _context;

        public UrlShortenerController(AppContextDb Context)
        {
        _context = Context;
        }

        [HttpPost("shorten")]
        public async Task<IActionResult> Shorten([FromBody] string surl)
        {

            if(!Uri.IsWellFormedUriString(surl, UriKind.Absolute))
            {
                return BadRequest("Invalid Url");
            }
            var shortcode = UrlHelper.Generate();

            var url = new UrlManagement
            {
                Url = surl,
                ShortenUrl = shortcode

            };

            _context.Urls.Add(url);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                shortUrl = $"{Request.Scheme}://{Request.Host}/{shortcode}"
            });
        }

        [HttpGet("/{code}")]
        public async Task<IActionResult> Get(string code)
        {
            var url = await _context.Urls.FirstOrDefaultAsync<UrlManagement>(x => x.ShortenUrl == code);

            if(url == null)
            {
                return NotFound();
            }

            return Redirect(url.Url);
        }
    }
}
