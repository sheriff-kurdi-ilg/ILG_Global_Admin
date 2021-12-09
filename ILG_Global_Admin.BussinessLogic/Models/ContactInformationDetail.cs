using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ILG_Global_Admin.BussinessLogic.Models
{
    [Index(nameof(LanguageCode), Name = "IX_ContactInformationDetails_LanguageCode")]
    public partial class ContactInformationDetail
    {
        [Key]
        [Column("ContactInformationID")]
        public int ContactInformationId { get; set; }
        [Key]
        public string LanguageCode { get; set; }
        public string Text { get; set; }

        [ForeignKey(nameof(ContactInformationId))]
        [InverseProperty(nameof(ContactInformationMaster.ContactInformationDetails))]
        public virtual ContactInformationMaster ContactInformation { get; set; }


        [ForeignKey(nameof(LanguageCode))]
        [InverseProperty(nameof(Language.ContactInformationDetails))]
        public virtual Language LanguageCodeNavigation { get; set; }
    }
}
