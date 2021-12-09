
using ILG_Global_Admin.BussinessLogic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using ILG_Global_Admin.BussinessLogic.Abstraction.Repositories;

namespace ILG_Global_Admin.DataAccess
{
    public class OurServiceDetailRepository : IOurServiceDetailRepository
    {
        private readonly ILG_GlobalContext applicationDbContext;

        public OurServiceDetailRepository(ILG_GlobalContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<List<OurServiceDetail>> SelectAllAsync(string sLanguageCode)
        {
            List<OurServiceDetail> lOurServiceDetails = new List<OurServiceDetail>();
            lOurServiceDetails = await applicationDbContext.OurServiceDetails.Include(m => m.OurService).ThenInclude(m =>m.ImageMasterImageMasters).Include(m => m.OurService.ImageDetails).Where(m => m.LanguageCode == sLanguageCode).ToListAsync();

            try
            {
            }
            catch (Exception)
            {

            }

            return lOurServiceDetails;
        }

        public async Task<List<OurServiceDetail>> SelectByIdAsync(int nID)
        {
            
            List<OurServiceDetail> ourServiceDetails = new List<OurServiceDetail>();

            try
            {
                ourServiceDetails = await applicationDbContext.OurServiceDetails.Where(m => m.OurServiceId == nID).Include(m => m.OurService).ToListAsync();
            }
            catch (Exception oException)
            {

            }

            return ourServiceDetails;
        }

        public async Task<bool> Insert(OurServiceDetail oOurServiceDetail)
        {
            try
            {
                applicationDbContext.OurServiceDetails.Add(oOurServiceDetail);
                applicationDbContext.SaveChanges();
                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Update(OurServiceDetail oOurServiceDetail)
        {
            try
            {
                applicationDbContext.Entry(oOurServiceDetail).State = EntityState.Modified;
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
                OurServiceDetail oOurServiceDetail = applicationDbContext.OurServiceDetails.Find(nID);

                applicationDbContext.OurServiceDetails.Remove(oOurServiceDetail);
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
