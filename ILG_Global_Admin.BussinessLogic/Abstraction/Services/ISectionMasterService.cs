
using ILG_Global.BussinessLogic.Models;
using ILG_Global.BussinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG_Global.BussinessLogic.Abstraction.Services
{
    public interface ISectionMasterService
    {
        Task<SectionMasterViewModel> SelectByIdAsync(int nID);
        Task<List<SectionMasterViewModel>> SelectAllAsync();
      //  Task<IEnumerable<SectionMasterViewModel>> SelectByCriteriaAsync(OwnerMasterSearchVM oOwnerMasterSearchVM);
        Task<bool> Insert(SectionMasterViewModel oEntity);
        Task<bool> Update(SectionMasterViewModel oEntity);
        Task<bool> DeleteByID(int nEntityID);



        List<SectionMasterViewModel> lConvertToVMs(IEnumerable<SectionMaster> lSectionsMasters);
        SectionMasterViewModel oConvertToVM(SectionMaster oSectionMaster);
        SectionMaster oConvertToDataModel(SectionMasterViewModel oSectionMasterVM);
    }
}
