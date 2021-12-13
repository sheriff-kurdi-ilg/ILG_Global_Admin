using ILG_Global_Admin.BussinessLogic.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG_Global.BussinessLogic.ViewModels
{
    public  class OurServiceVM
    {
        [Required]
        public int OurServiceID { get; set; }
        [Required]
        public bool IsEnabled { get; set; }
        [Required]
        public string LanguageCode { get; set; }
        [MaxLength(80)]
        [Required]
        public string Title { get; set; }
        [Required]
        [MaxLength(80)]
        public string SubTitle { get; set; }
        [Required]
        [Display(Name = "SubTitle")]
        [MaxLength(80)]
        public string SubTitleAr { get; set; }
        [Required]
        [MaxLength(500)]
        public string Summary { get; set; }
        [Required]

        public string Description { get; set; }
        [Required]

        [Display(Name = "Title")]
        [MaxLength(80)]
        public string TitleAr { get; set; }
        [Required]
        [Display(Name = "Summary")]
        [MaxLength(500)]
        public string SummaryAr { get; set; }

        public int ImageMastersId { get; set; }
        public IFormFile Image { get; set; }
        public string ImageURL { get; set; }
        //public List<ImageDetail> ImageDetails { get; set; }
    }
}
