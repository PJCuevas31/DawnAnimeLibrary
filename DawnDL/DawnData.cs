using DawnModel;
using System.Collections.Generic;

namespace DawnDL
{
    public class DawnData
    {
        List<Anime> animeList;
        DawnSql sqlData;

        public DawnData()
        {
            animeList = new List<Anime>();
            sqlData = new DawnSql();
        }

        public List<Anime> GetAnime()
        {
            animeList = sqlData.GetAnimes();
            return animeList;
        }

        public int AddAnime(Anime anime)
        {
            return sqlData.AddAnime(anime.AniName, anime.AniReleaseDate, anime.AniStudio, anime.AniGenre);
        }

        public int UpdateAnime(Anime anime)
        {
            return sqlData.UpdateAnime(anime.AniName, anime.AniReleaseDate, anime.AniStudio, anime.AniGenre);
        }

        public int DeleteAnime(Anime anime)
        {
            return sqlData.DeleteAnime(anime.AniName);
        }
    }
}
