using ILG_Global.BussinessLogic.ViewModels;
using ILG_Global_Admin.BussinessLogic.Models;
using ILG_Global_Admin.BussinessLogic.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ILG_Global.BussinessLogic.Abstraction.Services
{
    public interface IOurServicesService
    {
        Task<List<OurServiceVM>> SelectAllAsync(string LanguageCode);
           Task<OurServiceVM> SelectByIdAsync(int nID);
           Task<bool> Insert(OurServiceVM oEntity);
           Task<bool> Update(OurServiceVM oEntity);
           Task<bool> Delete(OurServiceVM oEntity);
           Task ToggleSwtich(int id);
    }
}
