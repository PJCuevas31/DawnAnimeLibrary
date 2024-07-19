using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using DawnModel; 
using DawnBL;   

namespace Dawn.API.Controllers
{
    [ApiController]
    [Route("api/anime")]
    public class AnimeController : ControllerBase
    {
        private readonly DawnGetService _animeGetServices;
        private readonly DawnTransactionService _animeTransactionServices;

        public AnimeController(DawnGetService animeGetServices, DawnTransactionService animeTransactionServices)
        {
            _animeGetServices = animeGetServices;
            _animeTransactionServices = animeTransactionServices;
        }

        [HttpGet]
        public ActionResult GetAnimes()
        {
            var animes = _animeGetServices.GetAllAnime(); 

            var animeList = animes.Select(item => new Anime
            {
                AniName = item.AniName,
                AniReleaseDate = item.AniReleaseDate,
                AniStudio = item.AniStudio,
                AniGenre = item.AniGenre
            }).ToList();

            return Ok(animeList);
        }

        [HttpPost]
        public IActionResult AddAnime([FromBody] Anime anime)
        {
            if (anime == null)
            {
                return BadRequest("Invalid anime data.");
            }

            if (_animeTransactionServices.AddAnime(anime) > 0)
            {
                return CreatedAtAction(nameof(GetAnimes), new { name = anime.AniName }, anime);
            }
            else
            {
                return StatusCode(500, "A problem occurred while handling your request.");
            }
        }

        [HttpPatch("{AniName}")]
        public IActionResult UpdateAnime(string AniName, [FromBody] Anime anime)
        {
            if (anime == null || AniName != anime.AniName)
            {
                return BadRequest("Invalid anime data.");
            }

            var result = _animeTransactionServices.UpdateAnime(anime);

            if (result > 0)
            {
                return Ok(anime);
            }
            else
            {
                return StatusCode(500, "A problem occurred while handling your request.");
            }
        }

        [HttpDelete("{AniName}")]
        public IActionResult DeleteAnime(string AniName)
        {
            var result = _animeTransactionServices.DeleteAnime(AniName);

            if (result > 0)
            {
                return NoContent();
            }
            else
            {
                return NotFound($"Anime with name '{AniName}' not found.");
            }
        }
    }
}
