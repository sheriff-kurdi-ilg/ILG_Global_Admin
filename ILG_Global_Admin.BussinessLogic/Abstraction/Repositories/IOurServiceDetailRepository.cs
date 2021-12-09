using ILG_Global_Admin.BussinessLogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ILG_Global_Admin.BussinessLogic.Abstraction.Repositories
{
    public interface IOurServiceDetailRepository
    {
        Task<bool> DeleteByID(int nID);
        Task<bool> Insert(OurServiceDetail oOurServiceDetail);
        Task<List<OurServiceDetail>> SelectAllAsync(string sLanguageCode);
        Task<List<OurServiceDetail>> SelectByIdAsync(int nID);
        Task<bool> Update(OurServiceDetail oOurServiceDetail);
    }
}