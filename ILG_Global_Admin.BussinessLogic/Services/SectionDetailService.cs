using ILG_Global_Admin.BussinessLogic.Abstraction.Repositories;
using ILG_Global_Admin.BussinessLogic.Abstraction.Services;
using ILG_Global_Admin.BussinessLogic.Models;
using ILG_Global_Admin.BussinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILG_Global_Admin.BussinessLogic.Services
{
    public class SectionDetailService : ISectionDetailService
    {
        private readonly ISectionDetailRepository oSectionDetailRepository;

        public SectionDetailService(ISectionDetailRepository oSectionDetailRepository)
        {
            this.oSectionDetailRepository = oSectionDetailRepository;
        }


        public async Task<bool> DeleteByID(int nEntityID)
        {
            try
            {
                await oSectionDetailRepository.DeleteById(nEntityID);
                
                return true;
            }catch(Exception e)
            {
                return false;
            }
        }

        public async Task<bool> Insert(SectionDetailViewModel oEntity)
        {
            try
            {
                SectionDetail oSectionDetail = oConvertToDataModel(oEntity);

                await oSectionDetailRepository.Insert(oSectionDetail);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        
        public async Task<List<SectionDetailViewModel>> SelectAllAsync()
        {
            IEnumerable<SectionDetail> lSectionsDetails  =  await oSectionDetailRepository.SelectAll();
            List<SectionDetailViewModel> lSectionDetailViewModels =   lConvertToVMs(lSectionsDetails);
            return lSectionDetailViewModels;
        }

        public async Task<SectionDetailViewModel> SelectByIdAsync(int nID)
        {
            SectionDetail oSectionDetail = await oSectionDetailRepository.SelectById(nID);
            SectionDetailViewModel oSectionDetailViewModel= oConvertToVM(oSectionDetail);
            return (oSectionDetailViewModel);
        }

        public async Task<bool> Update(SectionDetailViewModel oEntity)
        {
            try
            {
                SectionDetail oSectionDetail = oConvertToDataModel(oEntity);
                await oSectionDetailRepository.UpdateById(oSectionDetail);
                    return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }



        public List<SectionDetailViewModel> lConvertToVMs(IEnumerable<SectionDetail> lSectionsDetails)
        {
            List<SectionDetailViewModel> lSectionDetailViewModels = new List<SectionDetailViewModel>() ;

            foreach (SectionDetail oSectionDetail in lSectionsDetails)
            {
                SectionDetailViewModel oSectionDetailViewModel =  oConvertToVM(oSectionDetail);
                lSectionDetailViewModels.Add(oSectionDetailViewModel);
            }
            return lSectionDetailViewModels;
        }

        public SectionDetail oConvertToDataModel(SectionDetailViewModel oSectionDetailVM)
        {
            SectionDetail oSectionDetail = new SectionDetail
            {
                Title = oSectionDetailVM.Title,
                SectionTitle = oSectionDetailVM.SectionTitle,
                LanguageCode = oSectionDetailVM.LanguageCode,
                Summary = oSectionDetailVM.Summary,
                SectionMasterID =  oSectionDetailVM.SectionMasterID,
            };
            return oSectionDetail;
        }

        public SectionDetailViewModel oConvertToVM(SectionDetail oSectionDetail)
        {
            SectionDetailViewModel oSectionDetailVM = new SectionDetailViewModel
            {
                Title = oSectionDetail.Title,
                SectionTitle = oSectionDetail.SectionTitle,
                LanguageCode = oSectionDetail.LanguageCode,
                Summary = oSectionDetail.Summary,
                SectionMasterID = oSectionDetail.SectionMasterID,
                SectionID = oSectionDetail.ID,    
            };
            return oSectionDetailVM;
        }

    }
}
