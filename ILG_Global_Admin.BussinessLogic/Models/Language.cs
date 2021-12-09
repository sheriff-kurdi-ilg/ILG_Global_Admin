using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ILG_Global_Admin.BussinessLogic.Models
{
    [Table("Language")]
    public partial class Language
    {
        public Language()
        {
            ContactInformationDetails = new HashSet<ContactInformationDetail>();
            HtmlContentDetails = new HashSet<HtmlContentDetail>();
            ImageDetails = new HashSet<ImageDetail>();
            OurServiceDetails = new HashSet<OurServiceDetail>();
            SucessStoryDetails = new HashSet<SucessStoryDetail>();
        }

        [Key]
        public string Code { get; set; }
        public string Title { get; set; }

        [InverseProperty(nameof(ContactInformationDetail.LanguageCodeNavigation))]
        public virtual ICollection<ContactInformationDetail> ContactInformationDetails { get; set; }
        [InverseProperty(nameof(HtmlContentDetail.LanguageCodeNavigation))]
        public virtual ICollection<HtmlContentDetail> HtmlContentDetails { get; set; }
        [InverseProperty(nameof(ImageDetail.LanguageCodeNavigation))]
        public virtual ICollection<ImageDetail> ImageDetails { get; set; }
        [InverseProperty(nameof(OurServiceDetail.LanguageCodeNavigation))]
        public virtual ICollection<OurServiceDetail> OurServiceDetails { get; set; }
        [InverseProperty(nameof(SucessStoryDetail.LanguageCodeNavigation))]
        public virtual ICollection<SucessStoryDetail> SucessStoryDetails { get; set; }
    }
}
