using System.Collections.Generic;
using DawnDL;
using DawnModel;

namespace DawnBL
{
    public class DawnGetService
    {
        private DawnData _dawnData = new DawnData();

        public List<Anime> GetAnimes()
        {
            return _dawnData.GetAnimes();
        }
    }
}
