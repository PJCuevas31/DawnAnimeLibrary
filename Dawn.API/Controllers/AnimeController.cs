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
        public ActionResult<IEnumerable<Anime>> GetAnimes()
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
        public IActionResult AddAnime([FromBody] Anime request)
        {
            if (request == null || !ModelState.IsValid)
            {
                return BadRequest("Invalid anime data.");
            }

            var result = _animeTransactionServices.CreateAnime(request.AniName, request.AniReleaseDate, request.AniStudio, request.AniGenre);

            if (result > 0)
            {
                return CreatedAtAction(nameof(GetAnimes), new { name = request.AniName }, request);
            }
            else
            {
                return StatusCode(500, "A problem occurred while handling your request.");
            }
        }

        [HttpPatch]
        public IActionResult UpdateAnime([FromBody] Anime request)
        {
            if (request == null || !ModelState.IsValid)
            {
                return BadRequest("Invalid anime data.");
            }

            var result = _animeTransactionServices.UpdateAnime(request.AniName, request.AniReleaseDate, request.AniStudio, request.AniGenre);

            if (result > 0)
            {
                return NoContent();
            }
            else
            {
                return StatusCode(500, "A problem occurred while handling your request.");
            }
        }

        [HttpDelete]
        public IActionResult DeleteAnime(Anime anime)
        {
            if (string.IsNullOrEmpty(anime))
            {
                return BadRequest("Anime name is required.");
            }

            var result = _animeTransactionServices.DeleteAnime(name);

            if (result > 0)
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
