using ILG_Global_Admin.BussinessLogic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG_Global_Admin.DataAccess
{
    public class HtmlContentMasterRepository
    {
        private readonly ILG_GlobalContext _context;

        public HtmlContentMasterRepository(ILG_GlobalContext context)
        {
            this._context = context;
        }

        public async Task<List<HtmlContentDetail>> SelectAllAsync()
        {
            List<HtmlContentDetail> lHtmlContentdetails = new List<HtmlContentDetail>();

            try
            {
                lHtmlContentdetails = await _context.HtmlContentDetails.ToListAsync();
            }
            catch (Exception)
            {

            }

            return lHtmlContentdetails;
        }    
        
        public async Task<List<HtmlContentMaster>> SelectAllMasterAsync()
        {
            List<HtmlContentMaster> lHtmlContentMasters = new List<HtmlContentMaster>();

            try
            {
                lHtmlContentMasters = await _context.HtmlContentMasters.ToListAsync();
            }
            catch (Exception)
            {

            }

            return lHtmlContentMasters;
        }

        public async Task<HtmlContentMaster> SelectByIdAsync(int nID)
        {
            HtmlContentMaster oHtmlContentMaster = new HtmlContentMaster();

            try
            {
                oHtmlContentMaster = await _context.HtmlContentMasters.Include(m=>m.HtmlContentDetails).FirstOrDefaultAsync(m => m.Id == nID);
            }
            catch (Exception oException)
            {

            }

            return oHtmlContentMaster;
        }

        public async Task<bool> Insert(HtmlContentMaster oHtmlContentMaster)
        {
            try
            {
                _context.HtmlContentMasters.Add(oHtmlContentMaster);
                _context.SaveChanges();
                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Update(HtmlContentMaster oHtmlContentMaster)
        {
            try
            {
                _context.Entry(oHtmlContentMaster).State = EntityState.Modified;
                if(oHtmlContentMaster.HtmlContentDetails != null)
                {
                    foreach (HtmlContentDetail oHtmlContentDetail in oHtmlContentMaster.HtmlContentDetails)
                    {
                        _context.Entry(oHtmlContentDetail).State = EntityState.Modified;

                    }
                }

                _context.SaveChanges();
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
                HtmlContentMaster oHtmlContentMaster = _context.HtmlContentMasters.Include(m => m.HtmlContentDetails).FirstOrDefault(m=> m.Id == nID);

                foreach (HtmlContentDetail detail in oHtmlContentMaster.HtmlContentDetails)
                {
                    _context.HtmlContentDetails.Remove(detail);
                }

                _context.HtmlContentMasters.Remove(oHtmlContentMaster);
                _context.SaveChanges();

                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return await Task.FromResult(false);
            }
        }
    }
}
