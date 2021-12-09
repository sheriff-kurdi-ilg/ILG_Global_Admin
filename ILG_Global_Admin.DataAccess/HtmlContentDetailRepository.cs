
using ILG_Global_Admin.BussinessLogic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using ILG_Global_Admin.BussinessLogic.Abstraction.Repositories;

namespace ILG_Global_Admin.DataAccess
{
    public class HtmlContentDetailRepository : IHtmlContentDetailRepository
    {
        private readonly ILG_GlobalContext applicationDbContext;

        public HtmlContentDetailRepository(ILG_GlobalContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<HtmlContentDetail>> SelectAllAsync(string sLanguageCode)
        {
            List<HtmlContentDetail> lHtmlContentDetails = new List<HtmlContentDetail>();

            try
            {
                lHtmlContentDetails = await applicationDbContext.HtmlContentDetails.Where(m=>m.LanguageCode == sLanguageCode).ToListAsync();
            }
            catch (Exception)
            {

            }

            return lHtmlContentDetails;
        }

        public async Task<HtmlContentDetail> SelectByIdAsync(int nID,string sLanguageCode)
        {
            HtmlContentDetail oHtmlContentDetail = new HtmlContentDetail();

            try
            {
                oHtmlContentDetail = await applicationDbContext.HtmlContentDetails.FirstOrDefaultAsync(m => m.HtmlContentId == nID && m.LanguageCode == sLanguageCode);
            }
            catch (Exception oException)
            {

            }

            return oHtmlContentDetail;
        }

        public async Task<bool> Insert(HtmlContentDetail oHtmlContentDetail)
        {
            try
            {
                applicationDbContext.HtmlContentDetails.Add(oHtmlContentDetail);
                applicationDbContext.SaveChanges();
                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Update(HtmlContentDetail oHtmlContentDetail)
        {
            try
            {
                applicationDbContext.Entry(oHtmlContentDetail).State = EntityState.Modified;
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
                HtmlContentDetail oHtmlContentDetail = applicationDbContext.HtmlContentDetails.Find(nID);

                applicationDbContext.HtmlContentDetails.Remove(oHtmlContentDetail);
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
