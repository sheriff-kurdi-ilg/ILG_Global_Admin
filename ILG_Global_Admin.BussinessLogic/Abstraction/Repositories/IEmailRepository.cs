using ILG_Global_Admin.BussinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG_Global_Admin.BussinessLogic.Abstraction.Repositories
{
    public interface IEmailRepository
    {
        Task<ShareViaEmailSubscriber> SelectById(int id);
        Task<List<ShareViaEmailSubscriber>> SelectAll();
        Task UpdateById(ShareViaEmailSubscriber entity);
        Task Insert(ShareViaEmailSubscriber entity);
        Task DeleteById(int Id);
    }
}
