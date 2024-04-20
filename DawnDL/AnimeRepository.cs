using DawnModel;
using System.Xml.Linq;
namespace DawnDL;

public class AnimeRepository
{
    List<Anime> AniRep = new List<Anime>();

    public AnimeRepository()
    {
        AniList();
    }
    public void AniList()
    {
        Anime one = new Anime
        {
            aniname = "The Eminence in Shadow",
            anigenre = "Action",
            anipublisher = "NEXUS",
        };
        AniRep.Add(one);

        Anime two = new Anime
        {
            aniname = "Chainsaw Man",
            anigenre = "Action",
            anipublisher = "MAPPA",
        };

        AniRep.Add(two);
        Anime three = new Anime
        {
            aniname = "Overlord",
            anigenre = "Action",
            anipublisher = "MadHouse",
        };

        AniRep.Add(three);
        Anime four = new Anime
        {
            aniname = "Hell's Paradise",
            anigenre = "Action",
            anipublisher = "MAPPA",
        };

        AniRep.Add(four);
        Anime five = new Anime
        {
            aniname = "Shangri-La Frontier",
            anigenre = "Action",
            anipublisher = "C2C",
        };
        AniRep.Add(five);
    }

    public List<Anime> GetAnimes()
    {
        return AniRep;
    }

}

