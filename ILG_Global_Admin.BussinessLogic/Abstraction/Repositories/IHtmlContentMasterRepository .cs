using ILG_Global_Admin.BussinessLogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ILG_Global_Admin.BussinessLogic.Abstraction.Repositories
{
    public interface IHtmlContentMasterRepository
    {
        Task<List<HtmlContentDetail>> SelectAllAsync();
        Task<List<HtmlContentMaster>> SelectAllMasterAsync();
        Task<HtmlContentMaster> SelectByIdAsync(int nID);
        Task<bool> Insert(HtmlContentMaster oHtmlContentMaster);
        Task<bool> Update(HtmlContentMaster oHtmlContentMaster);
        Task<bool> DeleteByID(int nID);
    }
}