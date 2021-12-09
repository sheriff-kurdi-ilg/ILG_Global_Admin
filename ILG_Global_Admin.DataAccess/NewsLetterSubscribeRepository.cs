
using ILG_Global_Admin.BussinessLogic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using ILG_Global_Admin.BussinessLogic.Abstraction.Repositories;

namespace ILG_Global_Admin.DataAccess
{
    public class NewsLetterSubscribeRepository : INewsLetterSubscribeRepository
    {
        private readonly ILG_GlobalContext applicationDbContext;

        public NewsLetterSubscribeRepository(ILG_GlobalContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<NewsLetterSubscribe>> SelectAllAsync()
        {
            List<NewsLetterSubscribe> lNewsLetterSubscribes = new List<NewsLetterSubscribe>();

            try
            {
                lNewsLetterSubscribes = await applicationDbContext.NewsLetterSubscribes.ToListAsync();
            }
            catch (Exception)
            {

            }

            return lNewsLetterSubscribes;
        }

        public async Task<NewsLetterSubscribe> SelectByIdAsync(int nID)
        {
            NewsLetterSubscribe oNewsLetterSubscribe = new NewsLetterSubscribe();

            try
            {
                oNewsLetterSubscribe = await applicationDbContext.NewsLetterSubscribes.FirstOrDefaultAsync();
            }
            catch (Exception oException)
            {

            }

            return oNewsLetterSubscribe;
        }

        public async Task<bool> Insert(NewsLetterSubscribe oNewsLetterSubscribe)
        {
            try
            {
                applicationDbContext.NewsLetterSubscribes.Add(oNewsLetterSubscribe);
                applicationDbContext.SaveChanges();
                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Update(NewsLetterSubscribe oNewsLetterSubscribe)
        {
            try
            {
                applicationDbContext.Entry(oNewsLetterSubscribe).State = EntityState.Modified;
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
                NewsLetterSubscribe oNewsLetterSubscribe = applicationDbContext.NewsLetterSubscribes.Find(nID);

                applicationDbContext.NewsLetterSubscribes.Remove(oNewsLetterSubscribe);
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
