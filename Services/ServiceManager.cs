using Repositories.Contracts;
using Services.Contracts;
using System;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IServiceReport> _serviceReport;
        private readonly Lazy<IServiceConnectionSite> _serviceConnectionSite;
        private readonly Lazy<IServiceDataSource> _serviceDataSource;
        private readonly Lazy<IServiceReportFilter> _serviceReportFilter;
        private readonly Lazy<IServiceVisualizationSetting> _serviceVisualizationSetting;
        private readonly Lazy<IServiceReportLog> _serviceReportLog;
        private readonly Lazy<IServiceReportSharing> _serviceReportSharing;

        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _serviceReport = new Lazy<IServiceReport>(() => new ServiceReport(repositoryManager));
            _serviceConnectionSite = new Lazy<IServiceConnectionSite>(() => new ServiceConnectionSite(repositoryManager));
            _serviceDataSource = new Lazy<IServiceDataSource>(() => new ServiceDataSource(repositoryManager));
            _serviceReportFilter = new Lazy<IServiceReportFilter>(() => new ServiceReportFilter(repositoryManager));
            _serviceVisualizationSetting = new Lazy<IServiceVisualizationSetting>(() => new ServiceVisualizationSetting(repositoryManager));
            _serviceReportLog = new Lazy<IServiceReportLog>(() => new ServiceReportLog(repositoryManager));
            _serviceReportSharing = new Lazy<IServiceReportSharing>(() => new ServiceReportSharing(repositoryManager));
        }

        // Tüm servisler için Lazy Loading kullanıyoruz, böylece yalnızca ihtiyaç duyulduğunda yüklenir.
        public IServiceReport ServiceReport => _serviceReport.Value;
        public IServiceConnectionSite ServiceConnectionSite => _serviceConnectionSite.Value;
        public IServiceDataSource ServiceDataSource => _serviceDataSource.Value;
        public IServiceReportFilter ServiceReportFilter => _serviceReportFilter.Value;
        public IServiceVisualizationSetting ServiceVisualizationSetting => _serviceVisualizationSetting.Value;
        public IServiceReportLog ServiceReportLog => _serviceReportLog.Value;
        public IServiceReportSharing ServiceReportSharing => _serviceReportSharing.Value;
    }
}
