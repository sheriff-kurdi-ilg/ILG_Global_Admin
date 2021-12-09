
using ILG_Global_Admin.BussinessLogic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using ILG_Global_Admin.BussinessLogic.Abstraction.Repositories;

namespace ILG_Global_Admin.DataAccess
{
    public class ContactUsMasterRepository : IContactUsMasterRepository
    {
        private readonly ILG_GlobalContext applicationDbContext;

        public ContactUsMasterRepository(ILG_GlobalContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<List<ContactInformationMaster>> SelectAllAsync()
        {
            List<ContactInformationMaster> lContactInformationMasters = new List<ContactInformationMaster>();

            try
            {
                lContactInformationMasters = await applicationDbContext.ContactInformationMasters.Include(m=>m.ContactInformationDetails).ToListAsync();
            }
            catch (Exception oException)
            {

            }

            return lContactInformationMasters;
        }

        public async Task<ContactInformationMaster> SelectByIdAsync(int nID)
        {
            ContactInformationMaster oContactInformationMaster = new ContactInformationMaster();

            try
            {
                oContactInformationMaster = await applicationDbContext.ContactInformationMasters.Include(t=>t.ContactInformationDetails).FirstOrDefaultAsync(m => m.Id == nID);
            }
            catch (Exception oException)
            {

            }

            return oContactInformationMaster;
        }

        public async Task<bool> Insert(ContactInformationMaster oContactInformationMaster)
        {
            try
            {
                applicationDbContext.ContactInformationMasters.Add(oContactInformationMaster);
                applicationDbContext.SaveChanges();
                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Update(ContactInformationMaster oContactInformationMaster)
        {
            try
            {
                applicationDbContext.Entry(oContactInformationMaster).State = EntityState.Modified;
                if (oContactInformationMaster.ContactInformationDetails != null)
                {
                    foreach (var oContactInformationDetails in oContactInformationMaster.ContactInformationDetails)
                    {
                        applicationDbContext.Entry(oContactInformationDetails).State = EntityState.Modified;

                    }
                }
                applicationDbContext.SaveChanges();
                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return await Task.FromResult(false);
            }
        }

        public bool DeleteByID(int nID)
        {
            try
            {
                ContactInformationMaster oContactInformationMaster = applicationDbContext.ContactInformationMasters.Find(nID);

                applicationDbContext.ContactInformationMasters.Remove(oContactInformationMaster);
                applicationDbContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
