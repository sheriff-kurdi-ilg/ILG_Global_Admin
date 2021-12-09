
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
    public class ImageDetailRepository:IImageDetailRepository
    {
        private readonly ILG_GlobalContext _context;
        private  DbSet<ImageDetail> ImageDetailEntity;

        public ImageDetailRepository(ILG_GlobalContext context)
        {
            _context = context;
            ImageDetailEntity = context.Set<ImageDetail>();
        }
        public async Task Insert(ImageDetail entity)
        {
            await _context.ImageDetails.AddAsync(entity);
        }

        public async Task<List<ImageDetail>> SelectAll(string languageCode)
        {
            return await _context.ImageDetails.Include(c=>c.Image).Include(c=>c.LanguageCodeNavigation).ToListAsync();
        }

        public async Task<ImageDetail> SelectById(string languageCode, int imageMasterId)
        {
            return await _context.ImageDetails.Include(c => c.Image).Include(c => c.LanguageCodeNavigation).FirstOrDefaultAsync(ow => ow.LanguageCode == languageCode && ow.ImageId == imageMasterId);
        }

        public async Task DeleteById(int Id)
        {
            ImageDetail ImageDetail = await _context.ImageDetails.FindAsync(Id);
            _context.ImageDetails.Remove(ImageDetail);
        }

        public async Task SaveImageDetail(ImageDetail entity)
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateById(ImageDetail entity)
        {
            ImageDetailEntity.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }


    }
}
