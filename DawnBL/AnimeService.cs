using DawnDL;
using DawnModel;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace DawnBL;

public class AnimeService
{

    public List<Anime> AniRep = new List<Anime>();
    public List<Anime> GetAnimes()
    {
        AnimeRepository data = new AnimeRepository();
        return data.GetAnimes();
    }
    public void AddAnime(Anime anime)
    {
        AniRep.Add(anime);
    }
    public void DeleteAnime(Anime anime)
    {
        AniRep.Remove(animex);
    }
}
