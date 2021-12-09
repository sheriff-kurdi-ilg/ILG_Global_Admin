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
    public class SuccessStoryService : ISuccessStoryService
    {
        private readonly ISucessStoryMasterRepository sucessStoryMasterRepository;
        private readonly ISucessStoryDetailRepository oISucessStoryDetailRepository;

        public SuccessStoryService(ISucessStoryMasterRepository sucessStoryMasterRepository, ISucessStoryDetailRepository oSucessStoryDetailRepository)
        {
            this.sucessStoryMasterRepository = sucessStoryMasterRepository;
            this.oISucessStoryDetailRepository = oSucessStoryDetailRepository;
        }

        public async Task<bool> Delete(SuccessStoriesVM successStoriesVM)
        {
            try
            {
                 sucessStoryMasterRepository.DeleteById(successStoriesVM.SuccessStoryId);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public async Task<bool> Insert(SuccessStoriesVM oEntity)
        {
            try
            {
                    SucessStoryMaster sucessStoryMaster = await oConvertMasterToDataModel(oEntity);
                    SucessStoryDetail sucessStoryDetailAr = await oConvertDetailToDataArabicModel(oEntity, sucessStoryMaster);
                    SucessStoryDetail sucessStoryDetailEn = await oConvertDetailToDataEnglishModel(oEntity, sucessStoryMaster);
                    await sucessStoryMasterRepository.Insert(sucessStoryMaster);
                    await oISucessStoryDetailRepository.Insert(sucessStoryDetailEn);
                    await oISucessStoryDetailRepository.Insert(sucessStoryDetailAr);
                
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<List<SuccessStoriesVM>> SelectAllAsync(string LanguageCode)
        {
            List<SucessStoryDetail> lSucessStoryDetails = await oISucessStoryDetailRepository.SelectAllAsync(LanguageCode);

            return await lConvertToVMs(lSucessStoryDetails);
        }
        public async Task<SuccessStoriesVM> SelectByIdAsync(int nID)
        {
            SucessStoryMaster sucessStoryMaster = await sucessStoryMasterRepository.SelectByIdAsync(nID);
            SuccessStoriesVM successStoriesVM = await oConvertMasterToViewModel(sucessStoryMaster);
            return (successStoriesVM);
        }
        public async Task<bool> Update(SuccessStoriesVM oEntity)
        {
            try
            {
                SuccessStoryComponent successStoryComponent = await oConvertToDataModel(oEntity);
                await successStoryComponent.AddtoMaster();
                await sucessStoryMasterRepository.Update(successStoryComponent.Master);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public async Task ToggleSwtich(int id)
        {
            SucessStoryMaster sucessStoryMaster = await sucessStoryMasterRepository.SelectByIdAsync(id);
            switch (sucessStoryMaster.IsEnabled)
            {
                case false:
                    sucessStoryMaster.IsEnabled = true;
                    break;
                case true:
                    sucessStoryMaster.IsEnabled = false;
                    break;
            }
            await sucessStoryMasterRepository.Update(sucessStoryMaster);
        }

        //==========================================================================================================================//

        private async Task<SuccessStoryComponent> oConvertToDataModel(SuccessStoriesVM oSectionDetailVM)
        {
            SucessStoryMaster sucessStoryMasterNew = await oConvertMasterToDataModel(oSectionDetailVM);
            return new SuccessStoryComponent()
            {
                Master = sucessStoryMasterNew,
                DetailAr = await oConvertDetailToDataArabicModel(oSectionDetailVM, sucessStoryMasterNew),
                DetailEn = await oConvertDetailToDataEnglishModel(oSectionDetailVM, sucessStoryMasterNew)
            };
        
        }
        private async Task<SucessStoryDetail> oConvertDetailToDataEnglishModel(SuccessStoriesVM oSuccessStoriesDetailVM, SucessStoryMaster SucessStoryMaster)
        {
            SucessStoryDetail sucessStoryEn = new SucessStoryDetail()
            {
                SucessStoryId = oSuccessStoriesDetailVM.SuccessStoryId,
                Title = oSuccessStoriesDetailVM.Title,
                Summary = oSuccessStoriesDetailVM.Summary,
                LanguageCode = "en",

            };
            if (SucessStoryMaster != null)
            {
                sucessStoryEn.SucessStory = SucessStoryMaster;
            }

            return sucessStoryEn;
        }

        private async Task<SucessStoryDetail> oConvertDetailToDataArabicModel(SuccessStoriesVM oSuccessStoriesDetailVM, SucessStoryMaster SucessStoryMaster)
        {
            SucessStoryDetail sucessStoryAr = new SucessStoryDetail()
            {
                SucessStoryId = oSuccessStoriesDetailVM.SuccessStoryId,
                Title = oSuccessStoriesDetailVM.TitleAr,
                Summary = oSuccessStoriesDetailVM.SummaryAr,
                LanguageCode = "ar",
            };
            if (SucessStoryMaster != null)
            {
                sucessStoryAr.SucessStory = SucessStoryMaster;
            }

            return sucessStoryAr;
        }
        private async Task<SuccessStoriesVM> GlobalizeViewModel(SuccessStoriesVM successStoriesVM, SucessStoryDetail oSucessStoryDetail)
        {
            if (oSucessStoryDetail.LanguageCode == "ar")
            {
                successStoriesVM.TitleAr = oSucessStoryDetail.Title;
                successStoriesVM.SummaryAr = oSucessStoryDetail.Summary;
                successStoriesVM.LanguageCode = oSucessStoryDetail.LanguageCode;

            }
            else
            {
                successStoriesVM.Title = oSucessStoryDetail.Title;
                successStoriesVM.Summary = oSucessStoryDetail.Summary;
                successStoriesVM.LanguageCode = oSucessStoryDetail.LanguageCode;

            }
            return successStoriesVM;
        }

        private async Task<List<SuccessStoriesVM>> lConvertToVMs(List<SucessStoryDetail> lSucessStoryDetails)
        {
            List<SuccessStoriesVM> lSuccessStoriesViewModels = new List<SuccessStoriesVM>();

            foreach (SucessStoryDetail oSuccessStoryDetail in lSucessStoryDetails)
            {
                SuccessStoriesVM oSectionMasterViewModel = await oConvertDataModelToViewModel(oSuccessStoryDetail);
                lSuccessStoriesViewModels.Add(oSectionMasterViewModel);
            }
            return lSuccessStoriesViewModels;
        }
        private async Task<SucessStoryMaster> oConvertMasterToDataModel(SuccessStoriesVM oSuccessStoriesDetailVM)
        {
            SucessStoryMaster sucessStoryMaster = new()
            {
                Id = oSuccessStoriesDetailVM.SuccessStoryId,
                IsEnabled = oSuccessStoriesDetailVM.IsEnabled,
                PhoneNumber = oSuccessStoriesDetailVM.PhoneNumber,
                PdfFileName = oSuccessStoriesDetailVM.PdfFileName,
                
            };
            return sucessStoryMaster;
        }
        private async Task<SuccessStoriesVM> oConvertDataModelToViewModel(SucessStoryDetail oSucessStoryDetail)
        {
            SuccessStoriesVM successStoriesVM = new SuccessStoriesVM();

            if (oSucessStoryDetail.SucessStoryId != 0)
            {
                successStoriesVM.SuccessStoryId = oSucessStoryDetail.SucessStoryId;
            }
            successStoriesVM.ImageName = oSucessStoryDetail.SucessStory.ImageName;
            successStoriesVM.IsEnabled = oSucessStoryDetail.SucessStory.IsEnabled;
            successStoriesVM.PdfFileName = oSucessStoryDetail.SucessStory.PdfFileName;
            successStoriesVM.PhoneNumber = oSucessStoryDetail.SucessStory.PhoneNumber;

            successStoriesVM = await GlobalizeViewModel(successStoriesVM, oSucessStoryDetail);

            return successStoriesVM;
        }
        private async Task<SuccessStoriesVM> oConvertMasterToViewModel(SucessStoryMaster sucessStoryMaster)
        {
            SuccessStoriesVM successStoriesVM = new SuccessStoriesVM()
            {
                SuccessStoryId = sucessStoryMaster.Id,
                IsEnabled = sucessStoryMaster.IsEnabled,
                ImageName = sucessStoryMaster.ImageName,
                PdfFileName = sucessStoryMaster.PdfFileName,
                PhoneNumber = sucessStoryMaster.PhoneNumber,
            };
            foreach (var item in sucessStoryMaster.SucessStoryDetails)
            {
                await GlobalizeViewModel(successStoriesVM, item);
            }
            return successStoriesVM;
        }


    }
}
