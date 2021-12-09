using ILG_Global.BussinessLogic.ViewModels;
using ILG_Global_Admin.BussinessLogic.Models;
using ILG_Global_Admin.BussinessLogic.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ILG_Global.BussinessLogic.Abstraction.Services
{
    public interface ISuccessStoryService
    {
        Task<List<SuccessStoriesVM>> SelectAllAsync(string LanguageCode);
        Task<SuccessStoriesVM> SelectByIdAsync(int nID);
        Task<bool> Insert(SuccessStoriesVM oEntity);
        Task<bool> Update(SuccessStoriesVM oEntity);
        Task<bool> Delete(SuccessStoriesVM oEntity);
        Task ToggleSwtich(int id);
    }
}
