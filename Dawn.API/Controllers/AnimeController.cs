using Microsoft.AspNetCore.Mvc;

namespace Dawn.API.Controllers
{
    [ApiController]
    [Route("api/anime")]
    public class AnimeController : Controller
    {
        AnimeGetServices _animeGetServices;
        AnimeTransactionServices _animeTransactionServices;

        public AnimeController()
        {
            _animeGetServices = new AnimeGetServices();
            _animeTransactionServices = new AnimeTransactionServices();
        }

        [HttpGet]
        public IEnumerable<AnimeManagement.API.Anime> GetAnimes()
        {
            var animes = _animeGetServices.GetAnimes();

            List<AnimeManagement.API.Anime> animeList = new List<Anime>();

            foreach (var item in animes)
            {
                animeList.Add(new API.Anime { AniName = item.AniName, AniReleaseDate = item.AniReleaseDate, AniStudio = item.AniStudio, AniGenre = item.AniGenre });
            }

            return animeList;
        }

        [HttpPost]
        public JsonResult AddAnime(Anime request)
        {
            var result = _animeTransactionServices.CreateAnime(request.AniName, request.AniReleaseDate, request.AniStudio, request.AniGenre);

            return new JsonResult(result);
        }

        [HttpPatch]
        public JsonResult UpdateAnime(Anime request)
        {
            var result = _animeTransactionServices.UpdateAnime(request.AniName, request.AniReleaseDate, request.AniStudio, request.AniGenre);

            return new JsonResult(result);
        }
    }
}
