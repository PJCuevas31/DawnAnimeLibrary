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
    public void AddAnime(Anime animex)
    {
        AniRep.Add(animex);
    }
    public void DeleteAnime(Anime animex)
    {
        AniRep.Remove(animex);
    }
}
