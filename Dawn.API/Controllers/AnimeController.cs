using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Dawn.API.Controllers
{
    [ApiController]
    [Route("api/anime")]
    public class AnimeController : ControllerBase
    {
        private readonly AnimeGetServices _animeGetServices;
        private readonly AnimeTransactionServices _animeTransactionServices;

        public AnimeController(AnimeGetServices animeGetServices, AnimeTransactionServices animeTransactionServices)
        {
            _animeGetServices = animeGetServices;
            _animeTransactionServices = animeTransactionServices;
        }

        [HttpGet]
        public ActionResult GetAnimes()
        {
            var animes = _animeGetServices.GetAnimes();

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

            if (_animeGetServices.AddAnime(anime))
            {
                return CreatedAtAction(nameof(GetAnimes), new { name = request.AniName }, request);
            }
            else
            {
                return StatusCode(500, "A problem occurred while handling your request.");
            }
        }

        [HttpPatch("{AniName}")]
        public IActionResult UpdateAnime([FromBody] Anime anime)
        {
            if (anime == null || AniName != AniName)
            {
                return BadRequest("Invalid anime data.");
            }

            var result = _animeTransactionServices.UpdateAnime(request.AniName, request.AniReleaseDate, request.AniStudio, request.AniGenre);

            if (_animeGetServices.UpdateAnime(anime)
            {
                return Ok(anime);
            }
            else
            {
                return StatusCode(500, "A problem occurred while handling your request.");
            }
        }

        [HttpDelete("{AniName}")]
        public IActionResult DeleteAnime(Anime anime)
        {
            var result = _animeTransactionServices.DeleteAnime(AniName);

            if (_animeGetServices(anime))
            {
                return NoContent();
            }
            else
            {
                return NotFound($"Anime with name '{anime}' not found.");
            }
        }
    }
}
