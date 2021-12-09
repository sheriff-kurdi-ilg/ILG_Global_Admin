
using ILG_Global.BussinessLogic.Models;
using ILG_Global.BussinessLogic.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ILG_Global.BussinessLogic.Abstraction.Services
{
    public interface ISectionDetailService
    {
        Task<SectionDetailViewModel> SelectByIdAsync(int nID);
        Task<List<SectionDetailViewModel>> SelectAllAsync();
      //  Task<IEnumerable<SectionDetailViewModel>> SelectByCriteriaAsync(OwnerMasterSearchVM oOwnerMasterSearchVM);
        Task<bool> Insert(SectionDetailViewModel oEntity);
        Task<bool> Update(SectionDetailViewModel oEntity);
        Task<bool> DeleteByID(int nEntityID);



        List<SectionDetailViewModel> lConvertToVMs(IEnumerable<SectionDetail> lSectionsDetails);
        SectionDetailViewModel oConvertToVM(SectionDetail oSectionDetail);
        SectionDetail oConvertToDataModel(SectionDetailViewModel oSectionDetailVM);
    }
}
