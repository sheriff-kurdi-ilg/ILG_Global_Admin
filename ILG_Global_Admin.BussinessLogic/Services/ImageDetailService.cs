using ILG_Global_Admin.BussinessLogic.Abstraction.Repositories;
using ILG_Global_Admin.BussinessLogic.Abstraction.Services;
using ILG_Global_Admin.BussinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ILG_Global_Admin.BussinessLogic.Services
{
    public class ImageDetailService : IImageDetailService
    {
        private readonly IImageDetailRepository oImageDetailRepository;

        public ImageDetailService(IImageDetailRepository oImageDetailRepository)
        {
            this.oImageDetailRepository = oImageDetailRepository;
        }


        public async Task<bool> DeleteByID(int nEntityID)
        {
            try
            {
                await oImageDetailRepository.DeleteById(nEntityID);
                
                return true;
            }catch(Exception e)
            {
                return false;
            }
        }

        public async Task<bool> Insert(ImageDetailViewModel oEntity)
        {
            try
            {
                ImageDetail oImageDetail = oConvertToDataModel(oEntity);

                await oImageDetailRepository.Insert(oImageDetail);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        
        public async Task<List<ImageDetailViewModel>> SelectAllAsync()
        {
            IEnumerable<ImageDetail> lSectionsDetails  =  await oImageDetailRepository.SelectAll();
            List<ImageDetailViewModel> lImageDetailViewModels =   lConvertToVMs(lSectionsDetails);
            return lImageDetailViewModels;
        }

        public async Task<ImageDetailViewModel> SelectByIdAsync(int nID)
        {
            ImageDetail oImageDetail = await oImageDetailRepository.SelectById(nID);
            ImageDetailViewModel oImageDetailViewModel= oConvertToVM(oImageDetail);
            return (oImageDetailViewModel);
        }

        public async Task<bool> Update(ImageDetailViewModel oEntity)
        {
            try
            {
                ImageDetail oImageDetail = oConvertToDataModel(oEntity);
                await oImageDetailRepository.UpdateById(oImageDetail);
                    return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }



        public List<ImageDetailViewModel> lConvertToVMs(IEnumerable<ImageDetail> lSectionsDetails)
        {
            List<ImageDetailViewModel> lImageDetailViewModels = new List<ImageDetailViewModel>() ;

            foreach (ImageDetail oImageDetail in lSectionsDetails)
            {
                ImageDetailViewModel oImageDetailViewModel =  oConvertToVM(oImageDetail);
                lImageDetailViewModels.Add(oImageDetailViewModel);
            }
            return lImageDetailViewModels;
        }

        public ImageDetail oConvertToDataModel(ImageDetailViewModel oImageDetailVM)
        {
            ImageDetail oImageDetail = new ImageDetail
            {
                Title = oImageDetailVM.Title,
                ImageMasterID = oImageDetailVM.ImageMasterID,
                LanguageCode = oImageDetailVM.LanguageCode,
                AlternateText = oImageDetailVM.AlternateText,
                Name =  oImageDetailVM.Name,
            };
            return oImageDetail;
        }

        public ImageDetailViewModel oConvertToVM(ImageDetail oImageDetail)
        {
            ImageDetailViewModel oImageDetailVM = new ImageDetailViewModel
            {
                Title = oImageDetail.Title,
                AlternateText = oImageDetail.AlternateText,
                LanguageCode = oImageDetail.LanguageCode,
                ID = oImageDetail.ID,
                Name = oImageDetail.Name,
                ImageMasterID = oImageDetail.ImageMasterID,    
            };
            return oImageDetailVM;
        }

    }
}
