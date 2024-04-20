using DawnBL;
using DawnModel;
using System.Xml.Linq;

namespace AnimeUI;

internal class AniUI
{
    public static void ShowHistory(Anime anim)
    {
        Console.WriteLine("Anime");
        Console.WriteLine(anim.aniname);
        Console.WriteLine(anim.anigenre);
        Console.WriteLine(anim.anipublisher);
        Console.WriteLine("_____________________");

    }
    static void Main(String [] args)
    {

        AnimeService aniserve = new AnimeService();
        List<Anime> AniRep = aniserve.GetAnimes();
        {


            Console.WriteLine("Welcome to Dawn's Anime Library");
            Console.WriteLine("Please Choose a Number Corresponding to the Actions Below:");
            Console.WriteLine("1.View Anime Library");
            Console.WriteLine("2.Contribute to Dawn's Anime Library");
            Console.WriteLine("3.Delete from Dawn's Anime Library");


            int opps = Convert.ToInt32(Console.ReadLine());

            switch (opps)

            {
                case 1:


                    Console.WriteLine("Please Select an Anime from Dawn's Library");
                    Console.WriteLine("1. The Eminence in Shadow");
                    Console.WriteLine("2. Chainsaw Man");
                    Console.WriteLine("3. Overlord");
                    Console.WriteLine("4. Hell's Paradise");
                    Console.WriteLine("5. Shangri-La Frontier");
                    Console.WriteLine("_____________________");

                    int aniopps = Convert.ToInt32(Console.ReadLine());
                    switch (aniopps)
                    {
                        case 1:
                            ShowHistory(AniRep[0]);
                            break;
                        case 2:
                            ShowHistory(AniRep[1]);
                            break;
                        case 3:
                            ShowHistory(AniRep[2]);
                            break;
                        case 4:
                            ShowHistory(AniRep[3]);
                            break;
                        case 5:
                            ShowHistory(AniRep[4]);
                            break;
                        default:
                            Console.WriteLine("wrong input");
                            break;
                    }
                    break;
                case 2:
                    Anime contri = new Anime();

                    Console.WriteLine("Enter Anime Title");
                    contri.aniname = Console.ReadLine();
                    Console.WriteLine("Enter Genre");
                    contri.anigenre = Console.ReadLine();
                    Console.WriteLine("Enter Publisher");
                    contri.anipublisher = Console.ReadLine();
                    ShowHistory(AniRep[0]);
                    ShowHistory(AniRep[1]);
                    ShowHistory(AniRep[2]);
                    ShowHistory(AniRep[3]);
                    ShowHistory(AniRep[4]);
                    Console.WriteLine("Here's your contributed anime\n");
                    ShowHistory(contri);

                    break;
                case 3:
                    Console.WriteLine("Choose Anime to Delete from Library");
                    Console.WriteLine("1. The Eminence in Shadow");
                    Console.WriteLine("2. Chainsaw Man");
                    Console.WriteLine("3. Overlord");
                    Console.WriteLine("4. Hell's Paradise");
                    Console.WriteLine("5. Shangri-La Frontier");
                    Console.WriteLine("_____________________");
                    int del = Convert.ToInt32(Console.ReadLine());

                    switch (del)
                    {

                        case 1:
                            aniserve.DeleteAnime(AniRep[0]);
                            Console.WriteLine("The anime has been deleted");
                            break;
                        case 2:
                            aniserve.DeleteAnime(AniRep[1]);
                            Console.WriteLine("The anime has been deleted");
                            break;
                        case 3:
                            aniserve.DeleteAnime(AniRep[2]);
                            Console.WriteLine("The anime has been deleted");
                            break;
                        case 4:
                            aniserve.DeleteAnime(AniRep[3]);
                            Console.WriteLine("The anime has been deleted");
                            break;
                        case 5:
                            aniserve.DeleteAnime(AniRep[4]);
                            Console.WriteLine("The anime has been deleted");
                            break;
                        default:
                            Console.WriteLine("wrong input");
                            break;
                    }
                    break;

                default:
                    Console.WriteLine("wrong input");
                    break;


            }
        }
    }
}
