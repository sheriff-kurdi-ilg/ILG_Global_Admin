
using ILG_Global_Admin.BussinessLogic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using ILG_Global_Admin.BussinessLogic.Abstraction.Repositories;

namespace ILG_Global_Admin.DataAccess
{
    public class ContactUsDetailRepository : IContactUsDetailRepository
    {
        private readonly ILG_GlobalContext applicationDbContext;

        public ContactUsDetailRepository(ILG_GlobalContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<List<ContactInformationDetail>> SelectAllAsync(string sLanguageCode)
        {
            List<ContactInformationDetail> lContactInformationDetails = new List<ContactInformationDetail>();

            try
            {
                lContactInformationDetails = await applicationDbContext.ContactInformationDetails.Include(m=>m.ContactInformation).Where(m=>m.LanguageCode == sLanguageCode).ToListAsync();
            }
            catch (Exception oException)
            {

            }

            return lContactInformationDetails;
        }

        public async Task<ContactInformationDetail> SelectByIdAsync(int nID,string sLanguageCode="en")
        {
            ContactInformationDetail oContactInformationDetail = new ContactInformationDetail();

            try
            {
                oContactInformationDetail = await applicationDbContext.ContactInformationDetails.FirstOrDefaultAsync(m => m.ContactInformationId == nID && m.LanguageCode == sLanguageCode);
            }
            catch (Exception oException)
            {

            }

            return oContactInformationDetail;
        }

        public async Task<bool> Insert(ContactInformationDetail oContactInformationDetail)
        {
            try
            {
                applicationDbContext.ContactInformationDetails.Add(oContactInformationDetail);
                applicationDbContext.SaveChanges();
                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Update(ContactInformationDetail oContactInformationDetail)
        {
            try
            {
                applicationDbContext.Entry(oContactInformationDetail).State = EntityState.Modified;
                applicationDbContext.SaveChanges();
                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> DeleteByID(int nID)
        {
            try
            {
                ContactInformationDetail oContactInformationDetail = applicationDbContext.ContactInformationDetails.Find(nID);

                applicationDbContext.ContactInformationDetails.Remove(oContactInformationDetail);
                applicationDbContext.SaveChanges();

                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return await Task.FromResult(false);
            }
        }
    }
}
