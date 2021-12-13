using ILG_Global_Admin.BussinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG_Global_Admin.BussinessLogic.ViewModels
{
    public class SuccessStoryComponent_x
    {
        public SucessStoryMaster Master { get; set; }
        public SucessStoryDetail DetailEn { get; set; }
        public SucessStoryDetail DetailAr { get; set; }

        public async Task AddtoMaster()
        {
            this.Master.SucessStoryDetails.Add(this.DetailAr);
            this.Master.SucessStoryDetails.Add(this.DetailEn);

        }
    }
}
