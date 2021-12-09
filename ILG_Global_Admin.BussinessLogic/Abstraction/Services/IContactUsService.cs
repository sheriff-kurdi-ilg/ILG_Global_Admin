using ILG_Global.BussinessLogic.ViewModels;
using ILG_Global_Admin.BussinessLogic.Models;
using ILG_Global_Admin.BussinessLogic.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ILG_Global.BussinessLogic.Abstraction.Services
{
    public interface IContactUsService
    {
           Task<List<ContactUsSectionVM>> SelectAllAsync(string LanguageCode);
           Task<ContactUsSectionVM> SelectByIdAsync(int nID);
           Task<bool> Insert(ContactUsSectionVM oEntity);
           Task<bool> Update(ContactUsSectionVM oEntity);
           Task<bool> Delete(ContactUsSectionVM oEntity);
        Task ToggleSwtich(int id);
    }
}
