using DawnDL;
using DawnModel;

namespace DawnBL
{
    public class DawnTransactionService
    {
        private DawnData _dawnData = new DawnData();

        public int AddAnime(Anime anime)
        {
            return _dawnData.AddAnime(anime);
        }

        public int UpdateAnime(Anime anime)
        {
            return _dawnData.UpdateAnime(anime);
        }

        public int DeleteAnime(string aniName)
        {
            return _dawnData.DeleteAnime(aniName);
        }
    }
}
