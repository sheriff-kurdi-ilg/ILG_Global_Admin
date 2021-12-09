
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
    public class ImageMasterRepository:IImageMasterRepository
    {
        private readonly ILG_GlobalContext _context;
        private  DbSet<ImageMaster> ImageMasterEntity;

        public ImageMasterRepository(ILG_GlobalContext context)
        {
            _context = context;
            ImageMasterEntity = context.Set<ImageMaster>();
        }
        public async Task Insert(ImageMaster entity)
        {
            await _context.ImageMasters.AddAsync(entity);
        }

        public async Task<IEnumerable<ImageMaster>> SelectAll()
        {
            return await _context.ImageMasters.ToListAsync();
        }

        public async Task<ImageMaster> SelectById(int Id)
        {
            return await _context.ImageMasters.FirstOrDefaultAsync(ow => ow.Id == Id);
        }

        public async Task DeleteById(int Id)
        {
            ImageMaster ImageMaster = await _context.ImageMasters.FindAsync(Id);
            _context.ImageMasters.Remove(ImageMaster);
        }



        public async Task SaveImageMaster(ImageMaster entity)
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateById(ImageMaster entity)
        {
            ImageMasterEntity.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
