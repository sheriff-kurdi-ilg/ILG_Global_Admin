using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ILG_Global_Admin.BussinessLogic.Models
{
    [Index(nameof(LanguageCode), Name = "IX_OurServiceDetails_LanguageCode")]
    public partial class OurServiceDetail
    {
        [Key]
        [Column("OurServiceID")]
        public int OurServiceId { get; set; }
        [Key]
        public string LanguageCode { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }

        [ForeignKey(nameof(LanguageCode))]
        [InverseProperty(nameof(Language.OurServiceDetails))]
        public virtual Language LanguageCodeNavigation { get; set; }
        [ForeignKey(nameof(OurServiceId))]
        [InverseProperty(nameof(OurServiceMaster.OurServiceDetails))]
        public virtual OurServiceMaster OurService { get; set; }
    }
}
