using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ILG_Global_Admin.BussinessLogic.Models
{
    public partial class SucessStoryMaster
    {
        public SucessStoryMaster()
        {
            SucessStoryDetails = new HashSet<SucessStoryDetail>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        public string ImageName { get; set; }
        public bool IsEnabled { get; set; }
        public string PhoneNumber { get; set; }
        [Column("PDF_FileName")]
        public string PdfFileName { get; set; }

        [InverseProperty(nameof(SucessStoryDetail.SucessStory))]
        public virtual ICollection<SucessStoryDetail> SucessStoryDetails { get; set; }
        public string ImageURL { get; set; }
        public string PdfURL { get; set; }

    }
}
