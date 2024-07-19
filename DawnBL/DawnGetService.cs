using DawnModel;
using DawnDL;
using System.Collections.Generic;

namespace DawnBL
{
    public class DawnGetService
    {
        private DawnData _dawnData = new DawnData();

        public List<Anime> GetAllAnime()
        {
            return _dawnData.GetAnime();
        }
    }
}
