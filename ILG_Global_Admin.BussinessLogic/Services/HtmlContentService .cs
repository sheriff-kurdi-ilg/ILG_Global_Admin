using ILG_Global.BussinessLogic.Abstraction.Services;
using ILG_Global.BussinessLogic.ViewModels;
using ILG_Global_Admin.BussinessLogic.Abstraction.Repositories;
using ILG_Global_Admin.BussinessLogic.Models;
using ILG_Global_Admin.BussinessLogic.ViewModels;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILG_Global.Web.Services
{
    public class HtmlContentService : IHtmlContentService
    {
        private readonly IHtmlContentMasterRepository htmlContentMasterRepository;
        private readonly IHtmlContentDetailRepository htmlContentDetailRepository;

        public HtmlContentService(
            IHtmlContentMasterRepository htmlContentMasterRepository,
            IHtmlContentDetailRepository htmlContentDetailRepository)
        {
            this.htmlContentMasterRepository = htmlContentMasterRepository;
            this.htmlContentDetailRepository = htmlContentDetailRepository;
        }

        public async Task<bool> Delete(HtmlContentVM HtmlContentVM)
        {
            try
            {
                 await htmlContentMasterRepository.DeleteByID(HtmlContentVM.HtmlContenID);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        #region Insert


        public async Task<bool> Insert(HtmlContentVM oEntity)
        {
            try
            {
                HtmlContentMaster HtmlContentMaster = await oConvertMasterToDataModel(oEntity);

                await htmlContentMasterRepository.Insert(HtmlContentMaster);
                return true;
            }
            catch (Exception oException)
            {
                return false;
            }
        }

        private async Task<HtmlContentMaster> oConvertMasterToDataModel(HtmlContentVM oHtmlContentVM)
        {
            // List<HtmlContentDetail> HtmlContentDetails = await GetEnArDetails(oHtmlContentVM);

            HtmlContentMaster oHtmlContentMaster = new HtmlContentMaster()
            {
                Id = oHtmlContentVM.HtmlContenID,
                IsEnabled = oHtmlContentVM.IsEnabled,
            };

            HtmlContentDetail oHtmlContentDetail = await oConvertDetailViewModelToEnDataModel(oHtmlContentVM);
            oHtmlContentMaster.HtmlContentDetails.Add(oHtmlContentDetail);

            oHtmlContentDetail = await oConvertDetailViewModelToArDataModel(oHtmlContentVM);
            oHtmlContentMaster.HtmlContentDetails.Add(oHtmlContentDetail);

            return oHtmlContentMaster;

        }

        //private async Task<List<HtmlContentDetail>> GetEnArDetails(HtmlContentVM HtmlContentVM)
        //{
        //    List<HtmlContentDetail> HtmlContentDetails = new List<HtmlContentDetail>();

        //    HtmlContentDetail oHtmlContentDetail = await oConvertDetailViewModelToEnDataModel(HtmlContentVM);
        //    HtmlContentDetails.Add(oHtmlContentDetail);

        //    oHtmlContentDetail = await oConvertDetailViewModelToArDataModel(HtmlContentVM);
        //    HtmlContentDetails.Add(oHtmlContentDetail);

        //    return HtmlContentDetails;
        //}

        private async Task<HtmlContentDetail> oConvertDetailViewModelToEnDataModel(HtmlContentVM HtmlContentVM)
        {
            HtmlContentDetail HtmlContentDetail = new HtmlContentDetail()
            {
                HtmlContentId = HtmlContentVM.HtmlContenID,
                LanguageCode = "en",
                Title = HtmlContentVM.Title,
                SubTitle = HtmlContentVM.SubTitle,
                Summary = HtmlContentVM.Summary
      
            };

            return HtmlContentDetail;
        }

        private async Task<HtmlContentDetail> oConvertDetailViewModelToArDataModel(HtmlContentVM HtmlContentVM)
        {
            HtmlContentDetail HtmlContentDetail = new HtmlContentDetail()
            {
                HtmlContentId = HtmlContentVM.HtmlContenID,
                LanguageCode = "ar",
                Title = HtmlContentVM.TitleAr,
                SubTitle = HtmlContentVM.SubTitleAr,
                Summary = HtmlContentVM.SummaryAr,
            };

            return HtmlContentDetail;
        }

        #endregion



        public async Task<List<HtmlContentVM>> SelectAllAsync(string LanguageCode)
        {
            
            List<HtmlContentDetail> HtmlContentDetails = await htmlContentDetailRepository.SelectAllAsync(LanguageCode);

            return await lConvertToVMs(HtmlContentDetails);
        }

        public async Task<HtmlContentVM> SelectByIdAsync(int nID)
        {
            
            HtmlContentMaster HtmlContentDetails = await htmlContentMasterRepository.SelectByIdAsync(nID);

            HtmlContentVM HtmlContentVM = await oConvertMasterToViewModel(HtmlContentDetails);
            return (HtmlContentVM);
        }

        public async Task<bool> Update(HtmlContentVM oEntity)
        {
            try
            {
                HtmlContentMaster HtmlContentMaster = await oConvertMasterToDataModel(oEntity); 
                await htmlContentMasterRepository.Update(HtmlContentMaster);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public async Task ToggleSwtich(int id)
        {
            HtmlContentMaster HtmlContentMaster = await htmlContentMasterRepository.SelectByIdAsync(id);
            switch (HtmlContentMaster.IsEnabled)
            {
                case false:
                    HtmlContentMaster.IsEnabled = true;
                    break;
                case true:
                    HtmlContentMaster.IsEnabled = false;
                    break;
            }
            await htmlContentMasterRepository.Update(HtmlContentMaster);
        }

        //==========================================================================================================================//


        private async Task<HtmlContentVM> oConvertDataModelToViewModel(HtmlContentDetail HtmlContentDetail)
        {
            HtmlContentVM HtmlContentVM = new HtmlContentVM();

            if (HtmlContentDetail.HtmlContentId != 0)
            {
                HtmlContentVM.HtmlContenID = HtmlContentDetail.HtmlContentId;
            }
            HtmlContentVM.IsEnabled = HtmlContentDetail.HtmlContent.IsEnabled;

            HtmlContentVM = await GlobalizeViewModel(HtmlContentVM, HtmlContentDetail);

            return HtmlContentVM;
        }
        private async Task<HtmlContentVM> GlobalizeViewModel(HtmlContentVM HtmlContentVM, HtmlContentDetail HtmlContentDetail)
        {
            if (HtmlContentDetail.LanguageCode == "ar")
            {
                HtmlContentVM.TitleAr = HtmlContentDetail.Title;
                HtmlContentVM.SummaryAr = HtmlContentDetail.Summary;
                HtmlContentVM.SubTitleAr = HtmlContentDetail.SubTitle;
                HtmlContentVM.LanguageCode = HtmlContentDetail.LanguageCode;

            }
            else
            {
                HtmlContentVM.Title = HtmlContentDetail.Title;
                HtmlContentVM.Summary = HtmlContentDetail.Summary;
                HtmlContentVM.SubTitle = HtmlContentDetail.SubTitle;
                HtmlContentVM.LanguageCode = HtmlContentDetail.LanguageCode;
            }
            return HtmlContentVM;
        }

        private async Task<HtmlContentVM> oConvertMasterToViewModel(HtmlContentMaster HtmlContentMaster)
        {
            HtmlContentVM HtmlContentVM = new HtmlContentVM()
            {
                HtmlContenID = HtmlContentMaster.Id,
                IsEnabled = HtmlContentMaster.IsEnabled,

            };
            foreach (var item in HtmlContentMaster.HtmlContentDetails)
            {
                await GlobalizeViewModel(HtmlContentVM, item);
            }
            return HtmlContentVM;
        }



        private async Task<List<HtmlContentVM>> lConvertToVMs(List<HtmlContentDetail> lHtmlContentDetails)
        {
            List<HtmlContentVM> lOurServiceViewModels = new List<HtmlContentVM>();

            foreach (HtmlContentDetail HtmlContentDetail in lHtmlContentDetails)
            {
                HtmlContentVM oSectionMasterViewModel = await oConvertDataModelToViewModel(HtmlContentDetail);
                lOurServiceViewModels.Add(oSectionMasterViewModel);
            }
            return lOurServiceViewModels;
        }
    }
}
