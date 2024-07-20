using System.Collections.Generic;
using DawnModel;

namespace DawnDL
{
    public class DawnData
    {
        private DawnSql _dawnSql = new DawnSql();

        public List<Anime> GetAnimes()
        {
            return _dawnSql.GetAnimes();
        }

        public int AddAnime(Anime anime)
        {
            if (anime == null) return 0;
            return _dawnSql.AddAnime(anime.AniName, anime.AniReleaseDate, anime.AniStudio, anime.AniGenre);
        }

        public int UpdateAnime(Anime anime)
        {
            if (anime == null) return 0;
            return _dawnSql.UpdateAnime(anime.AniName, anime.AniReleaseDate, anime.AniStudio, anime.AniGenre);
        }

        public int DeleteAnime(string aniName)
        {
            return _dawnSql.DeleteAnime(aniName);
        }
    }
}
