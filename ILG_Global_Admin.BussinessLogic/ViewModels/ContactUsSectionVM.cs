using ILG_Global_Admin.BussinessLogic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG_Global.BussinessLogic.ViewModels
{
    public class ContactUsSectionVM
    {
        //public HtmlContentDetail ContactUsSectionHeaderContent { get; set; }

        //public IEnumerable<ContactInformationDetail> ContactInformationDetails { get; set; }

        [Required]
        public int ContactUsMasterId { get; set; }
        [Required]
        public bool IsEnabled { get; set; }
        [Required]
        public string LanguageCode { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        [Display(Name = "Text")]
        public string TextAr { get; set; }


    }


}
