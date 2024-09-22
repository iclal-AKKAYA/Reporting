using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Reporting.Data // Doğru namespace'i kullandığınızdan emin olun
{
    public class ApplicationDbContext : DbContext
    {
        // Constructor, DbContextOptions parametresi alır ve base sınıfa iletilir
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<Report> Reports { get; set; }
        public DbSet<ReportFilter> ReportFilters { get; set; }
        public DbSet<DataSource> DataSources { get; set; }
        public DbSet<VisualizationSetting> VisualizationSettings { get; set; }
        public DbSet<ConnectionSite> Sites { get; set; }
        public DbSet<ReportSharing> ReportSharings { get; set; }
        public DbSet<ReportLog> ReportLogs { get; set; }

        
    }
}
