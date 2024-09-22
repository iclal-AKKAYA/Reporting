using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Entities.Models;
using Microsoft.AspNetCore.Identity; // Kendi entity'lerin

namespace Repositories.EFCore
{
    public class RepositoryContext : IdentityDbContext<IdentityUser>
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {
        }

        // Kendi entity'lerini ekle
        public DbSet<Report> Reports { get; set; }
        public DbSet<DataSource> DataSources { get; set; }
        public DbSet<ReportFilter> ReportFilters { get; set; }
        public DbSet<ConnectionSite> ConnectionSites { get; set; }
        public DbSet<ReportLog> ReportLogs { get; set; }
        public DbSet<VisualizationSetting> VisualizationSettings { get; set; }
        public DbSet<ReportSharing> ReportSharings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Identity tablolarını eklemek için

            // ReportFilter ile Report arasında ilişki
            modelBuilder.Entity<ReportFilter>()
                .HasOne(rf => rf.Report)
                .WithMany(r => r.ReportFilters)
                .HasForeignKey(rf => rf.ReportID)
                .OnDelete(DeleteBehavior.Cascade); // Cascade silme ilişkisi

            // ReportSharing ile Report arasında ilişki
            modelBuilder.Entity<ReportSharing>()
                .HasOne(rs => rs.Report)
                .WithMany(r => r.ReportSharings)
                .HasForeignKey(rs => rs.ReportID)
                .OnDelete(DeleteBehavior.Cascade); // Cascade silme ilişkisi

            // Diğer ilişkiler ve konfigürasyonlar
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RepositoryContext).Assembly);
        }
    }
}
