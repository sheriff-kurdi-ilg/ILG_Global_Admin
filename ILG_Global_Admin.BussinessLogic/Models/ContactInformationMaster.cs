using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ILG_Global_Admin.BussinessLogic.Models
{
    public partial class ContactInformationMaster
    {
        public ContactInformationMaster()
        {
            ContactInformationDetails = new HashSet<ContactInformationDetail>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        public string FontAwsomeIconCssClass { get; set; }
        public bool IsEnabled { get; set; }

        [InverseProperty(nameof(ContactInformationDetail.ContactInformation))]
        public virtual ICollection<ContactInformationDetail> ContactInformationDetails { get; set; }
    }
}
