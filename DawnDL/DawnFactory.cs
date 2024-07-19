using DawnModel;
using System;
using System.Collections.Generic;

namespace DawnDL
{
    public class DawnFactory
    {
        private List<Anime> dummyAnime = new List<Anime>();

        public List<Anime> GetDummyAnime()
        {
            dummyAnime.Add(CreateDummyAnime("Naruto", new DateTime(2002, 10, 3), "Studio Pierrot", "Action"));
            dummyAnime.Add(CreateDummyAnime("One Piece", new DateTime(1999, 10, 20), "Toei Animation", "Adventure"));
            dummyAnime.Add(CreateDummyAnime("Attack on Titan", new DateTime(2013, 4, 7), "Wit Studio", "Dark Fantasy"));
            dummyAnime.Add(CreateDummyAnime("My Hero Academia", new DateTime(2016, 4, 3), "Bones", "Superhero"));

            return dummyAnime;
        }

        private Anime CreateDummyAnime(string aniName, DateTime aniReleaseDate, string aniStudio, string aniGenre)
        {
            Anime anime = new Anime
            {
                AniName = aniName,
                AniReleaseDate = aniReleaseDate,
                AniStudio = aniStudio,
                AniGenre = aniGenre
            };

            return anime;
        }
    }
}
