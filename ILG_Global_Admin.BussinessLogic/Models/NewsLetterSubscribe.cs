using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ILG_Global_Admin.BussinessLogic.Models
{
    public partial class NewsLetterSubscribe
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        public string PreferredLanguage { get; set; }
        public string Email { get; set; }
        public bool? IsEnabled { get; set; }
    }
}
