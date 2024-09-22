using Repositories.Contracts;
using Repositories.EFCore;
using System;

namespace Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly Lazy<IRepositoryReport> _repositoryReport;
        private readonly Lazy<IRepositoryReportFilter> _repositoryReportFilter;
        private readonly Lazy<IRepositoryDataSource> _repositoryDataSource;
        private readonly Lazy<IRepositoryVisualizationSetting> _repositoryVisualizationSetting;
        private readonly Lazy<IRepositoryConnectionSite> _repositoryConnectionSite;
        private readonly Lazy<IRepositoryReportSharing> _repositoryReportSharing;
        private readonly Lazy<IRepositoryReportLog> _repositoryReportLog;

        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
            _repositoryReport = new Lazy<IRepositoryReport>(() => new RepositoryReport(_context));
            _repositoryReportFilter = new Lazy<IRepositoryReportFilter>(() => new RepositoryReportFilter(_context));
            _repositoryDataSource = new Lazy<IRepositoryDataSource>(() => new RepositoryDataSource(_context));
            _repositoryVisualizationSetting = new Lazy<IRepositoryVisualizationSetting>(() => new RepositoryVisualizationSetting(_context));
            _repositoryConnectionSite = new Lazy<IRepositoryConnectionSite>(() => new RepositoryConnectionSite(_context));
            _repositoryReportSharing = new Lazy<IRepositoryReportSharing>(() => new RepositoryReportSharing(_context));
            _repositoryReportLog = new Lazy<IRepositoryReportLog>(() => new RepositoryReportLog(_context));
        }

        // Lazy loading kullanarak repository'lere erişim
        public IRepositoryReport Report => _repositoryReport.Value;
        public IRepositoryReportFilter ReportFilter => _repositoryReportFilter.Value;
        public IRepositoryDataSource DataSource => _repositoryDataSource.Value;
        public IRepositoryVisualizationSetting VisualizationSetting => _repositoryVisualizationSetting.Value;
        public IRepositoryConnectionSite ConnectionSite => _repositoryConnectionSite.Value;
        public IRepositoryReportSharing ReportSharing => _repositoryReportSharing.Value;
        public IRepositoryReportLog ReportLog => _repositoryReportLog.Value;

        // Save işlemi
        public void Save()
        {
            _context.SaveChanges();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
