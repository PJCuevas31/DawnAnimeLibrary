using DawnDL;
using DawnModel;
using System.Collections.Generic;

namespace DawnBL
{
    public class DawnGetService
    {
        private List<Anime> GetAllAnime()
        {
            DawnData dawnData = new DawnData();

            return dawnData.GetAnime();
        }

        public List<Anime> GetAnimeByGenre(string genre)
        {
            List<Anime> animeByGenre = new List<Anime>();

            foreach (var anime in GetAllAnime())
            {
                if (anime.AniGenre == genre)
                {
                    animeByGenre.Add(anime);
                }
            }

            return animeByGenre;
        }

        public Anime GetAnime(string aniName)
        {
            Anime foundAnime = null;

            foreach (var anime in GetAllAnime())
            {
                if (anime.AniName == aniName)
                {
                    foundAnime = anime;
                    break;
                }
            }

            return foundAnime;
        }
    }
}
