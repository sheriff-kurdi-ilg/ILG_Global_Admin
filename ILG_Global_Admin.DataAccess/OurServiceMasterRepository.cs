using ILG_Global_Admin.BussinessLogic.Abstraction.Repositories;
using ILG_Global_Admin.BussinessLogic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG_Global_Admin.DataAccess
{
    public class OurServiceMasterRepository  : IOurServiceMasterRepository
    {
        private readonly ILG_GlobalContext _context;

        public OurServiceMasterRepository(ILG_GlobalContext context)
        {
            this._context = context;
        }

        public async Task<List<OurServiceMaster>> SelectAllAsync()
        {
            List<OurServiceMaster> ourServiceMasters = new List<OurServiceMaster>();

            try
            {
                ourServiceMasters = await _context.OurServiceMasters.ToListAsync();
            }
            catch (Exception)
            {

            }

            return ourServiceMasters;
        }    
        
        public async Task<IEnumerable<OurServiceMaster>> SelectAllMasterAsync()
        {
            List<OurServiceMaster> lHtmlContentMasters = new List<OurServiceMaster>();

            try
            {
                lHtmlContentMasters = await _context.OurServiceMasters.ToListAsync();
            }
            catch (Exception)
            {

            }

            return lHtmlContentMasters;
        }

        public async Task<OurServiceMaster> SelectByIdAsync(int nID)
        {
            OurServiceMaster ourServiceMaster = new OurServiceMaster();

            try
            {
                ourServiceMaster = await _context.OurServiceMasters.Include(m=>m.OurServiceDetails).FirstOrDefaultAsync(m => m.Id == nID);
            }
            catch (Exception oException)
            {

            }

            return ourServiceMaster;
        }

        public async Task<bool> Insert(OurServiceMaster oOurServiceMaster)
        {
            try
            {
                _context.OurServiceMasters.Add(oOurServiceMaster);
                _context.SaveChanges();
                return await Task.FromResult(true);
            }
            catch (Exception oException)
            {
                return false;
            }
        }

        public async Task<bool> Update(OurServiceMaster oOurServiceMaster)
        {
            try
            {
                _context.Entry(oOurServiceMaster).State = EntityState.Modified;
                if (oOurServiceMaster.OurServiceDetails != null)
                {
                    foreach (var oOurServicedetial in oOurServiceMaster.OurServiceDetails)
                    {
                        _context.Entry(oOurServicedetial).State = EntityState.Modified;

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

        public bool DeleteByID(int nID)
        {
            try
            {
                OurServiceMaster oOurServiceMaster = _context.OurServiceMasters.Include(m => m.OurServiceDetails).FirstOrDefault(m=> m.Id == nID);

                foreach (var detail in oOurServiceMaster.OurServiceDetails)
                {
                    _context.OurServiceDetails.Remove(detail);
                }

                _context.OurServiceMasters.Remove(oOurServiceMaster);
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Task<List<OurServiceMaster>> SelectAllAsync(string LanguageCode)
        {
            throw new NotImplementedException();
        }

        public Task<OurServiceMaster> SelectByIdAsync(int ID, string LanguageCode)
        {
            throw new NotImplementedException();
        }
    }
}
