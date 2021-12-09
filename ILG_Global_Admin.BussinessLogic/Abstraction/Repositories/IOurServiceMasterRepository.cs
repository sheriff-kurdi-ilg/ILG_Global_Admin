using ILG_Global_Admin.BussinessLogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ILG_Global_Admin.BussinessLogic.Abstraction.Repositories
{
    public interface IOurServiceMasterRepository
    {
        bool DeleteByID(int nID);
        Task<bool> Insert(OurServiceMaster OurServiceMaster);
        Task<List<OurServiceMaster>> SelectAllAsync(string LanguageCode);
        Task<OurServiceMaster> SelectByIdAsync(int ID);
        Task<bool> Update(OurServiceMaster OurServiceMaster);
    }
}