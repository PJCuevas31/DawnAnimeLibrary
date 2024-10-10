using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DawnBL;
using DawnModel;

namespace Dawn.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimeController : ControllerBase
    {
        private readonly DawnGetService _dawnGetService;
        private readonly DawnTransactionService _dawnTransactionService;

        public AnimeController()
        {
            _dawnGetService = new DawnGetService();
            _dawnTransactionService = new DawnTransactionService();
        }

        // GET api/anime
        [HttpGet]
        public ActionResult<List<Anime>> GetAllAnimes()
        {
            try
            {
                var animes = _dawnGetService.GetAnimes();
                return Ok(animes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST api/anime
        [HttpPost]
        public ActionResult AddAnime([FromBody] Anime anime)
        {
            try
            {
                if (anime == null)
                {
                    return BadRequest("Anime object is null");
                }

                int result = _dawnTransactionService.AddAnime(anime);
                if (result > 0)
                {
                    return CreatedAtAction(nameof(GetAllAnimes), new { name = anime.AniName }, anime);
                }
                else
                {
                    return StatusCode(500, "Failed to add anime");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PATCH api/anime/{name}
        [HttpPatch("{name}")]
        public ActionResult UpdateAnime(string name, [FromBody] Anime anime)
        {
            try
            {
                if (anime == null || anime.AniName != name)
                {
                    return BadRequest("Invalid anime object or name mismatch");
                }

                int result = _dawnTransactionService.UpdateAnime(anime);
                if (result > 0)
                {
                    return Ok();
                }
                else
                {
                    return StatusCode(500, $"Failed to update anime with name {name}");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE api/anime/{name}
        [HttpDelete("{name}")]
        public ActionResult DeleteAnime(string name)
        {
            try
            {
                int result = _dawnTransactionService.DeleteAnime(name);
                if (result > 0)
                {
                    return NoContent();
                }
                else
                {
                    return NotFound($"Anime with name {name} not found");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
