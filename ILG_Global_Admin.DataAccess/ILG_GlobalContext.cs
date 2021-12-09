using System;
using ILG_Global_Admin.BussinessLogic.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ILG_Global_Admin.DataAccess
{
    public partial class ILG_GlobalContext : IdentityDbContext<ApplicationUser>
    {
        public ILG_GlobalContext()
        {
        }

        public ILG_GlobalContext(DbContextOptions<ILG_GlobalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ContactInformationDetail> ContactInformationDetails { get; set; }
        public virtual DbSet<ContactInformationMaster> ContactInformationMasters { get; set; }
        public virtual DbSet<HtmlContentDetail> HtmlContentDetails { get; set; }
        public virtual DbSet<HtmlContentMaster> HtmlContentMasters { get; set; }
        public virtual DbSet<ImageDetail> ImageDetails { get; set; }
        public virtual DbSet<ImageMaster> ImageMasters { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<NewsLetterSubscribe> NewsLetterSubscribes { get; set; }
        public virtual DbSet<OurServiceDetail> OurServiceDetails { get; set; }
        public virtual DbSet<OurServiceMaster> OurServiceMasters { get; set; }
        public virtual DbSet<ShareViaEmailSubscriber> ShareViaEmailSubscribers { get; set; }
        public virtual DbSet<SucessStoryDetail> SucessStoryDetails { get; set; }
        public virtual DbSet<SucessStoryMaster> SucessStoryMasters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ContactInformationDetail>(entity =>
            {
                entity.HasKey(e => new { e.ContactInformationId, e.LanguageCode });
            });

            modelBuilder.Entity<HtmlContentDetail>(entity =>
            {
                entity.HasKey(e => new { e.HtmlContentId, e.LanguageCode });
            });

            modelBuilder.Entity<ImageDetail>(entity =>
            {
                entity.HasKey(e => new { e.ImageId, e.LanguageCode });
            });

            modelBuilder.Entity<OurServiceDetail>(entity =>
            {
                entity.HasKey(e => new { e.OurServiceId, e.LanguageCode });
            });

            modelBuilder.Entity<SucessStoryDetail>(entity =>
            {
                entity.HasKey(e => new { e.SucessStoryId, e.LanguageCode });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
