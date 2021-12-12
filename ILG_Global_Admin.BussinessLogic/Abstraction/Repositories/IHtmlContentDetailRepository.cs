using ILG_Global_Admin.BussinessLogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ILG_Global_Admin.BussinessLogic.Abstraction.Repositories
{
    public interface IHtmlContentDetailRepository
    {
        Task<bool> DeleteByID(int nID);
        Task<bool> Insert(HtmlContentDetail oHtmlContentDetail);
        Task<List<HtmlContentDetail>> SelectAllAsync(string sLanguageCode);
        Task<HtmlContentDetail> SelectByIdAsync(int nID, string sLanguageCode);
        Task<bool> Update(HtmlContentDetail oHtmlContentDetail);
    }
}