using ILG_Global.BussinessLogic.ViewModels;
using ILG_Global_Admin.BussinessLogic.Models;
using ILG_Global_Admin.BussinessLogic.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ILG_Global.BussinessLogic.Abstraction.Services
{
    public interface IHtmlContentService
    {
        
        Task<List<HtmlContentVM>> SelectAllAsync(string LanguageCode);
           Task<HtmlContentVM> SelectByIdAsync(int nID);
           Task<bool> Insert(HtmlContentVM oEntity);
           Task<bool> Update(HtmlContentVM oEntity);
           Task<bool> Delete(HtmlContentVM oEntity);
           Task ToggleSwtich(int id);
    }
}
