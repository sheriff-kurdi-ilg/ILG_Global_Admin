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
    public class ContactUsService : IContactUsService
    {
        private readonly IContactUsMasterRepository contactUsMasterRepository;
        private readonly IContactUsDetailRepository contactUsDetailRepository;

        public ContactUsService(IContactUsMasterRepository contactUsMasterRepository , IContactUsDetailRepository contactUsDetailRepository )
        {
            this.contactUsMasterRepository = contactUsMasterRepository;
            this.contactUsDetailRepository = contactUsDetailRepository;
        }

        public async Task<bool> Delete(ContactUsSectionVM ContactUsSectionVM)
        {
            try
            {
                 contactUsMasterRepository.DeleteByID(ContactUsSectionVM.ContactUsMasterId);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> Insert(ContactUsSectionVM oEntity)
        {
            try
            {
                ContactInformationMaster ContactInformationMaster = await oConvertMasterToDataModel(oEntity);
                await contactUsMasterRepository.Insert(ContactInformationMaster);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<List<ContactUsSectionVM>> SelectAllAsync(string LanguageCode)
        {
            List<ContactInformationDetail> ContactInformationDetails = await contactUsDetailRepository.SelectAllAsync(LanguageCode);

            return await lConvertToVMs(ContactInformationDetails);
        }

        public async Task<ContactUsSectionVM> SelectByIdAsync(int nID)
        {
            ContactInformationMaster ContactInformationDetails = await contactUsMasterRepository.SelectByIdAsync(nID);

            ContactUsSectionVM ContactUsSectionVM = await oConvertMasterToViewModel(ContactInformationDetails);
            return (ContactUsSectionVM);
        }

        public async Task<bool> Update(ContactUsSectionVM oEntity)
        {
            try
            {
                ContactInformationMaster ContactInformationMaster = await oConvertMasterToDataModel(oEntity); 
                await contactUsMasterRepository.Update(ContactInformationMaster);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
        public async Task ToggleSwtich(int id)
        {
            ContactInformationMaster contactInformationMaster = await contactUsMasterRepository.SelectByIdAsync(id);
            switch (contactInformationMaster.IsEnabled)
            {
                case false:
                    contactInformationMaster.IsEnabled = true;
                    break;
                case true:
                    contactInformationMaster.IsEnabled = false;
                    break;
            }
            await contactUsMasterRepository.Update(contactInformationMaster);
        }


        //==========================================================================================================================//


        private async Task<ContactUsSectionVM> oConvertDataModelToViewModel(ContactInformationDetail ContactInformationDetail)
        {
            ContactUsSectionVM ContactUsSectionVM = new ContactUsSectionVM();

            if (ContactInformationDetail.ContactInformationId != 0)
            {
                ContactUsSectionVM.ContactUsMasterId = ContactInformationDetail.ContactInformationId;
            }
            ContactUsSectionVM.IsEnabled = ContactInformationDetail.ContactInformation.IsEnabled;
            ContactUsSectionVM.Text = ContactInformationDetail.Text;

            ContactUsSectionVM = await GlobalizeViewModel(ContactUsSectionVM, ContactInformationDetail);

            return ContactUsSectionVM;
        }

        private async Task<ContactUsSectionVM> GlobalizeViewModel(ContactUsSectionVM ContactUsSectionVM, ContactInformationDetail ContactInformationDetail)
        {
            if (ContactInformationDetail.LanguageCode == "ar")
            {
                ContactUsSectionVM.TextAr = ContactInformationDetail.Text;
                ContactUsSectionVM.LanguageCode = ContactInformationDetail.LanguageCode;

            }
            else
            {
                ContactUsSectionVM.Text = ContactInformationDetail.Text;
                ContactUsSectionVM.LanguageCode = ContactInformationDetail.LanguageCode;
            }
            return ContactUsSectionVM;
        }
        private async Task<ContactInformationDetail> DetailViewModelToEnglishDataModel(ContactUsSectionVM ContactUsSectionVM)
        {
            ContactInformationDetail ContactInformationDetail = new ContactInformationDetail()
            {
                ContactInformationId = ContactUsSectionVM.ContactUsMasterId,
                Text = ContactUsSectionVM.Text,
                LanguageCode = "en",
            };
            return ContactInformationDetail;
        }
        private async Task<ContactInformationDetail> DetailViewModelToArabicDataModel(ContactUsSectionVM ContactUsSectionVM)
        {
            ContactInformationDetail ContactInformationDetail = new ContactInformationDetail()
            {
                ContactInformationId = ContactUsSectionVM.ContactUsMasterId,
                Text = ContactUsSectionVM.TextAr,
                LanguageCode = "ar",
            };


            return ContactInformationDetail;
        }
        private async Task<List<ContactInformationDetail>> GetEnArDetails (ContactUsSectionVM ContactUsSectionVM)
        {
            List<ContactInformationDetail> ContactInformationDetails = new List<ContactInformationDetail>();
            ContactInformationDetail en = await DetailViewModelToEnglishDataModel(ContactUsSectionVM);
            ContactInformationDetail ar = await DetailViewModelToArabicDataModel(ContactUsSectionVM);
            ContactInformationDetails.Add(en);
            ContactInformationDetails.Add(ar);
            return ContactInformationDetails;
        }
        private async Task<ContactUsSectionVM> oConvertMasterToViewModel(ContactInformationMaster ContactInformationMaster)
        {
            ContactUsSectionVM ContactUsSectionVM = new ContactUsSectionVM()
            {
                ContactUsMasterId = ContactInformationMaster.Id,
                IsEnabled = ContactInformationMaster.IsEnabled,
            };
            foreach (var item in ContactInformationMaster.ContactInformationDetails)
            {
                await GlobalizeViewModel(ContactUsSectionVM, item);
            }
            return ContactUsSectionVM;
        }
        private async Task<ContactInformationMaster> oConvertMasterToDataModel(ContactUsSectionVM ContactUsSectionVM)
        {
            List<ContactInformationDetail> ContactInformationDetails = await GetEnArDetails(ContactUsSectionVM);
            ContactInformationMaster ContactInformationMaster = new()
            {
                Id = ContactUsSectionVM.ContactUsMasterId,
                IsEnabled = ContactUsSectionVM.IsEnabled,
                ContactInformationDetails = ContactInformationDetails,
            };
            return ContactInformationMaster;

        }
        private async Task<List<ContactUsSectionVM>> lConvertToVMs(List<ContactInformationDetail> lContactInformationDetails)
        {
            List<ContactUsSectionVM> lOurServiceViewModels = new List<ContactUsSectionVM>();

            foreach (ContactInformationDetail ContactInformationDetail in lContactInformationDetails)
            {
                ContactUsSectionVM oSectionMasterViewModel = await oConvertDataModelToViewModel(ContactInformationDetail);
                lOurServiceViewModels.Add(oSectionMasterViewModel);
            }
            return lOurServiceViewModels;
        }


    }
}
