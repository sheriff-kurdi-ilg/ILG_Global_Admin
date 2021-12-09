
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
    public class SucessStoryMasterRepository : ISucessStoryMasterRepository
    {

        private readonly ILG_GlobalContext _context;
        private DbSet<SucessStoryMaster> SucessStoryMasterEntity;
        private DbSet<SucessStoryDetail> sucessStoryDetailsEntity;


        public SucessStoryMasterRepository(ILG_GlobalContext context)
        {
            _context = context;
            SucessStoryMasterEntity = context.Set<SucessStoryMaster>();
        }
        public async Task<bool> Insert(SucessStoryMaster entity)
        {
            try
            {
                await _context.SucessStoryMasters.AddAsync(entity);
                await _context.SaveChangesAsync();
                return true;
            }catch(Exception e)
            {
                return false;
            }
        }

        public async Task<IEnumerable<SucessStoryMaster>> SelectAllAsync()
        {
            return await _context.SucessStoryMasters.Include(m=>m.SucessStoryDetails).ToListAsync();
        }

        public async Task<SucessStoryMaster> SelectByIdAsync(int Id)
        {
            return await _context.SucessStoryMasters.Include(m=>m.SucessStoryDetails).FirstOrDefaultAsync(ow => ow.Id == Id);
        }

        public  bool DeleteById(int Id)
        {
            try
            {
                SucessStoryMaster SucessStoryMaster =  _context.SucessStoryMasters.FindAsync(Id).Result;
                _context.SucessStoryMasters.Remove(SucessStoryMaster);
                 _context.SaveChanges();
                return true;
            }catch(Exception e)
            {
                return false;
            }

        }



        public async Task SaveSucessStoryMaster(SucessStoryMaster entity)
        {
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Update(SucessStoryMaster entity)
        {
            try
            {
                //SucessStoryMasterEntity.Attach(entity);
                 _context.Entry(entity).State = EntityState.Modified;
                foreach (var detail in entity.SucessStoryDetails)
                {
                    _context.Entry(detail).State = EntityState.Modified;
                }
                await _context.SaveChangesAsync();
                return await Task.FromResult(true);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }

        }

       

    }
}
