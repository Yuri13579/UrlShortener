using Microsoft.AspNetCore.Mvc;
using UrlShortener.Data.Context;
using UrlShortener.Domain.Url;
using UrlShortener.WebApplication.Service;

namespace UrlShortener.WebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UrlController : ControllerBase
    {
        private readonly IShortAliasGenerator _shortAliasGenerator;
        private readonly ApplicationDbContext _dbContext;

        public UrlController(ApplicationDbContext dbContext, IShortAliasGenerator shortAliasGenerator)
        {
            _dbContext = dbContext;
            _shortAliasGenerator = shortAliasGenerator;
        }

        [HttpPost]
        public IActionResult CreateShortUrl([FromBody] string longUrl)
        {
            // Generate a unique short alias (e.g., using a hash algorithm or base62 encoding)
            string shortAlias = _shortAliasGenerator.GenerateShortAlias();

            // Save the shortened URL to the in-memory database
            var urlEntry = new UrlEntry
            {
                OriginalUrl = longUrl,
                ShortAlias = shortAlias,
                CreatedOn = DateTime.UtcNow
            };
            _dbContext.UrlEntries.Add(urlEntry);
            _dbContext.SaveChanges();

            // Return the shortened URL to the client
            string shortUrl = $"https://your-domain.com/{shortAlias}";
            return Ok(shortUrl);
        }

        [HttpGet("{shortAlias}")]
        public IActionResult RedirectToOriginalUrl(string shortAlias)
        {
            // Find the URL entry with the given short alias in the in-memory database
            var urlEntry = _dbContext.UrlEntries.FirstOrDefault(u => u.ShortAlias == shortAlias);

            if (urlEntry == null)
            {
                return NotFound();
            }

            // Redirect the user to the original URL
            return Redirect(urlEntry.OriginalUrl);
        }

    }
}
