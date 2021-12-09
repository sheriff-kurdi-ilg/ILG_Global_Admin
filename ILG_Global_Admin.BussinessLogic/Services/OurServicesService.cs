using ILG_Global.BussinessLogic.Abstraction.Services;
using ILG_Global.BussinessLogic.ViewModels;
using ILG_Global_Admin.BussinessLogic.Abstraction.Repositories;
using ILG_Global_Admin.BussinessLogic.Models;
using ILG_Global_Admin.BussinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILG_Global.Web.Services
{
    public class OurServicesService : IOurServicesService
    {
        private readonly IOurServiceMasterRepository OurServiceMasterRepository;
        private readonly IOurServiceDetailRepository oIOurServiceDetailRepository;

        public OurServicesService(IOurServiceMasterRepository OurServiceMasterRepository, IOurServiceDetailRepository oIOurServiceDetailRepository)
        {
            this.OurServiceMasterRepository = OurServiceMasterRepository;
            this.oIOurServiceDetailRepository = oIOurServiceDetailRepository;
        }

        public async Task<bool> Delete(OurServiceVM OurServiceVM)
        {
            try
            {
                 OurServiceMasterRepository.DeleteByID(OurServiceVM.OurServiceID);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> Insert(OurServiceVM oEntity)
        {
            try
            {
                OurServiceMaster OurServiceMaster = await oConvertMasterToDataModel(oEntity);
                await OurServiceMasterRepository.Insert(OurServiceMaster);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<List<OurServiceVM>> SelectAllAsync(string LanguageCode)
        {
            List<OurServiceDetail> ourServiceDetails = await oIOurServiceDetailRepository.SelectAllAsync(LanguageCode);

            return await lConvertToVMs(ourServiceDetails);
        }

        public async Task<OurServiceVM> SelectByIdAsync(int nID)
        {
            OurServiceMaster ourServiceDetails = await OurServiceMasterRepository.SelectByIdAsync(nID);

            OurServiceVM ourServiceVM = await oConvertMasterToViewModel(ourServiceDetails);
            return (ourServiceVM);
        }

        public async Task<bool> Update(OurServiceVM oEntity)
        {
            try
            {
                OurServiceMaster ourServiceMaster = await oConvertMasterToDataModel(oEntity); 
                await OurServiceMasterRepository.Update(ourServiceMaster);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public async Task ToggleSwtich(int id)
        {
            OurServiceMaster ourServiceMaster = await OurServiceMasterRepository.SelectByIdAsync(id);
            switch (ourServiceMaster.IsEnabled)
            {
                case false:
                    ourServiceMaster.IsEnabled = true;
                    break;
                case true:
                    ourServiceMaster.IsEnabled = false;
                    break;
            }
            await OurServiceMasterRepository.Update(ourServiceMaster);
        }

        //==========================================================================================================================//


        private async Task<OurServiceVM> oConvertDataModelToViewModel(OurServiceDetail ourServiceDetail)
        {
            OurServiceVM OurServiceVM = new OurServiceVM();

            if (ourServiceDetail.OurServiceId != 0)
            {
                OurServiceVM.OurServiceID = ourServiceDetail.OurServiceId;
            }
            OurServiceVM.ImageMastersId = ourServiceDetail.OurService.ImageMastersId;
            OurServiceVM.IsEnabled = ourServiceDetail.OurService.IsEnabled;
            OurServiceVM.Description = ourServiceDetail.Description;

            OurServiceVM = await GlobalizeViewModel(OurServiceVM, ourServiceDetail);

            return OurServiceVM;
        }
        private async Task<OurServiceVM> GlobalizeViewModel(OurServiceVM OurServiceVM, OurServiceDetail ourServiceDetail)
        {
            if (ourServiceDetail.LanguageCode == "ar")
            {
                OurServiceVM.TitleAr = ourServiceDetail.Title;
                OurServiceVM.SummaryAr = ourServiceDetail.Summary;
                OurServiceVM.SubTitleAr = ourServiceDetail.SubTitle;
                OurServiceVM.LanguageCode = ourServiceDetail.LanguageCode;

            }
            else
            {
                OurServiceVM.Title = ourServiceDetail.Title;
                OurServiceVM.Summary = ourServiceDetail.Summary;
                OurServiceVM.SubTitle = ourServiceDetail.SubTitle;
                OurServiceVM.LanguageCode = ourServiceDetail.LanguageCode;
            }
            return OurServiceVM;
        }
        private async Task<OurServiceDetail> DetailViewModelToEnglishDataModel(OurServiceVM ourServiceVM)
        {
            OurServiceDetail ourServiceDetail = new OurServiceDetail()
            {
                OurServiceId = ourServiceVM.OurServiceID,
                Title = ourServiceVM.Title,
                Summary = ourServiceVM.Summary,
                SubTitle = ourServiceVM.SubTitle,
                LanguageCode = "en",
            };
            return ourServiceDetail;
        }
        private async Task<OurServiceDetail> DetailViewModelToArabicDataModel(OurServiceVM ourServiceVM)
        {
            OurServiceDetail ourServiceDetail = new OurServiceDetail()
            {
                OurServiceId = ourServiceVM.OurServiceID,
                Title = ourServiceVM.TitleAr,
                Summary = ourServiceVM.SummaryAr,
                SubTitle = ourServiceVM.SubTitleAr,
                LanguageCode = "ar",
            };


            return ourServiceDetail;
        }
        private async Task<List<OurServiceDetail>> GetEnArDetails (OurServiceVM ourServiceVM)
        {
            List<OurServiceDetail> ourServiceDetails = new List<OurServiceDetail>();
            OurServiceDetail en = await DetailViewModelToEnglishDataModel(ourServiceVM);
            OurServiceDetail ar = await DetailViewModelToArabicDataModel(ourServiceVM);
            ourServiceDetails.Add(en);
            ourServiceDetails.Add(ar);
            return ourServiceDetails;
        }
        private async Task<OurServiceVM> oConvertMasterToViewModel(OurServiceMaster ourServiceMaster)
        {
            OurServiceVM ourServiceVM = new OurServiceVM()
            {
                OurServiceID = ourServiceMaster.Id,
                IsEnabled = ourServiceMaster.IsEnabled,
                ImageMastersId = ourServiceMaster.ImageMastersId,

            };
            foreach (var item in ourServiceMaster.OurServiceDetails)
            {
                await GlobalizeViewModel(ourServiceVM, item);
            }
            return ourServiceVM;
        }
        private async Task<OurServiceMaster> oConvertMasterToDataModel(OurServiceVM ourServiceVM)
        {
            List<OurServiceDetail> ourServiceDetails = await GetEnArDetails(ourServiceVM);
            OurServiceMaster OurServiceMaster = new()
            {
                Id = ourServiceVM.OurServiceID,
                IsEnabled = ourServiceVM.IsEnabled,
                ImageMastersId = ourServiceVM.ImageMastersId,
                OurServiceDetails = ourServiceDetails,
            };
            return OurServiceMaster;

        }
        private async Task<List<OurServiceVM>> lConvertToVMs(List<OurServiceDetail> lOurServiceDetails)
        {
            List<OurServiceVM> lOurServiceViewModels = new List<OurServiceVM>();

            foreach (OurServiceDetail ourServiceDetail in lOurServiceDetails)
            {
                OurServiceVM oSectionMasterViewModel = await oConvertDataModelToViewModel(ourServiceDetail);
                lOurServiceViewModels.Add(oSectionMasterViewModel);
            }
            return lOurServiceViewModels;
        }
    }
}
