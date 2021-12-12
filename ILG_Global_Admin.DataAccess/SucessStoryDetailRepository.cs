
using ILG_Global_Admin.BussinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ILG_Global_Admin.BussinessLogic.Abstraction.Repositories;

namespace ILG_Global_Admin.DataAccess
{
    public class SucessStoryDetailRepository : ISucessStoryDetailRepository
    {
        private readonly ILG_GlobalContext applicationDbContext;

        public SucessStoryDetailRepository(ILG_GlobalContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<List<SucessStoryDetail>> SelectAllAsync(string languageCode)
        {
            List<SucessStoryDetail> lSucessStoryDetails = new List<SucessStoryDetail>();

            try
            {
                lSucessStoryDetails = await applicationDbContext.SucessStoryDetails.Include(m=> m.SucessStory).Where(m=>m.LanguageCode==languageCode).ToListAsync();
            }
            catch (Exception oException)
            {

            }

            return lSucessStoryDetails;
        }

        public async Task<SucessStoryDetail> SelectByIdLanguageCodeAsync(int nID,string sLanguageCode)
        {
            SucessStoryDetail oSucessStoryDetail = new SucessStoryDetail();
   


            try
            {
                oSucessStoryDetail = await applicationDbContext.SucessStoryDetails.Include(m=>m.SucessStory).FirstOrDefaultAsync(m => m.SucessStoryId == nID && m.LanguageCode == sLanguageCode);
            }
            catch (Exception oException)
            {

            }

            return oSucessStoryDetail;
        }

        public async Task<bool> Insert(SucessStoryDetail oSucessStoryDetail)
        {
            try
            {
                applicationDbContext.SucessStoryDetails.Add(oSucessStoryDetail);
                applicationDbContext.SaveChanges();
                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Update(SucessStoryDetail oSucessStoryDetail)
        {
            try
            {
                applicationDbContext.Entry(oSucessStoryDetail).State = EntityState.Modified;
                applicationDbContext.SaveChanges();
                return await Task.FromResult(true);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> Delete(SucessStoryDetail oSucessStoryDetail)
        {
            SucessStoryDetail sucessStoryDetail = applicationDbContext.SucessStoryDetails.Find(oSucessStoryDetail.SucessStoryId);

            try
            {
              //  SucessStoryDetail sucessStoryDetail = applicationDbContext.SucessStoryDetails.Find(oSucessStoryDetail.SucessStoryId);
                
                applicationDbContext.SucessStoryDetails.Remove(sucessStoryDetail);
                applicationDbContext.SaveChanges();

                return await Task.FromResult(true);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<List<SucessStoryDetail>> SelectByIdAsync(int nID)
        {

            List<SucessStoryDetail> oSucessStoryDetail = new List<SucessStoryDetail>();
            try
            {
          
                 oSucessStoryDetail = await applicationDbContext.SucessStoryDetails.Where(m => m.SucessStoryId == nID).Include(m => m.SucessStory).ToListAsync();

            }
            catch (Exception oException)
            {

            }

            return oSucessStoryDetail;
        }

        public async Task<bool> AddRange(List<SucessStoryDetail> sucessStoryDetailsEntity)
        {
            try
            {
                await applicationDbContext.SucessStoryDetails.AddRangeAsync(sucessStoryDetailsEntity);
                await applicationDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public async Task<bool> UpdateRange(List<SucessStoryDetail> sucessStoryDetailsEntity)
        {
            try
            {
                applicationDbContext.SucessStoryDetails.UpdateRange(sucessStoryDetailsEntity);
                await applicationDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

    }
}
