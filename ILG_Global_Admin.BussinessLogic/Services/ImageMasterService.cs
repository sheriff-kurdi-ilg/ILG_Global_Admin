
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
    public class ImageMasterService : IImageMasterService
    {
        private readonly IImageMasterRepository oImageMasterRepository;

        public ImageMasterService(IImageMasterRepository oImageMasterRepository)
        {
            this.oImageMasterRepository = oImageMasterRepository;
        }


        public async Task<bool> DeleteByID(int nEntityID)
        {
            try
            {
                await oImageMasterRepository.DeleteById(nEntityID);
                
                return true;
            }catch(Exception e)
            {
                return false;
            }
        }

        public async Task<bool> Insert(ImageMasterViewModel oEntity)
        {
            try
            {
                ImageMaster oImageMaster = oConvertToDataModel(oEntity);

                await oImageMasterRepository.Insert(oImageMaster);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        
        public async Task<List<ImageMasterViewModel>> SelectAllAsync()
        {
            IEnumerable<ImageMaster> lSectionsMasters  =  await oImageMasterRepository.SelectAll();
            List<ImageMasterViewModel> lImageMasterViewModels =   lConvertToVMs(lSectionsMasters);
            return lImageMasterViewModels;
        }

        public async Task<ImageMasterViewModel> SelectByIdAsync(int nID)
        {
            ImageMaster oImageMaster = await oImageMasterRepository.SelectById(nID);
            ImageMasterViewModel oImageMasterViewModel= oConvertToVM(oImageMaster);
            return (oImageMasterViewModel);
        }

        public async Task<bool> Update(ImageMasterViewModel oEntity)
        {
            try
            {
                ImageMaster oImageMaster = oConvertToDataModel(oEntity);
                await oImageMasterRepository.UpdateById(oImageMaster);
                    return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }



        public List<ImageMasterViewModel> lConvertToVMs(IEnumerable<ImageMaster> lSectionsMasters)
        {
            List<ImageMasterViewModel> lImageMasterViewModels = new List<ImageMasterViewModel>() ;

            foreach (ImageMaster oImageMaster in lSectionsMasters)
            {
                ImageMasterViewModel oImageMasterViewModel =  oConvertToVM(oImageMaster);
                lImageMasterViewModels.Add(oImageMasterViewModel);
            }
            return lImageMasterViewModels;
        }

        public ImageMaster oConvertToDataModel(ImageMasterViewModel oImageMasterVM)
        {
            ImageMaster oImageMaster = new ImageMaster
            {
                ID = oImageMasterVM.ID,
                IsEnabled = oImageMasterVM.IsEnabled,
                SectionMasterID = oImageMasterVM.SectionMasterID,
                Width = oImageMasterVM.Width,
                Height =  oImageMasterVM.Height,
            };
            return oImageMaster;
        }

        public ImageMasterViewModel oConvertToVM(ImageMaster oImageMaster)
        {
            ImageMasterViewModel oImageMasterVM = new ImageMasterViewModel
            {
                ID = oImageMaster.ID,
                IsEnabled = oImageMaster.IsEnabled,
                SectionMasterID = oImageMaster.SectionMasterID,
                Width = oImageMaster.Width,
                Height = oImageMaster.Height,
            };
            return oImageMasterVM;
        }

    }
}
