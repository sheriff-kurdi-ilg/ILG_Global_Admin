
using ILG_Global_Admin.BussinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG_Global_Admin.BussinessLogic.Abstraction.Services
{
    public interface IImageDetailService
    {
        Task<ImageDetailViewModel> SelectByIdAsync(int nID);
        Task<List<ImageDetailViewModel>> SelectAllAsync();
      //  Task<IEnumerable<ImageDetailViewModel>> SelectByCriteriaAsync(OwnerMasterSearchVM oOwnerMasterSearchVM);
        Task<bool> Insert(ImageDetailViewModel oEntity);
        Task<bool> Update(ImageDetailViewModel oEntity);
        Task<bool> DeleteByID(int nEntityID);



        List<ImageDetailViewModel> lConvertToVMs(IEnumerable<ImageDetail> lSectionsDetails);
        ImageDetailViewModel oConvertToVM(ImageDetail oImageDetail);
        ImageDetail oConvertToDataModel(ImageDetailViewModel oImageDetailVM);
    }
}
