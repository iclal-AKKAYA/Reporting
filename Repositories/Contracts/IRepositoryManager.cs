using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        IRepositoryReport Report { get; }
        IRepositoryReportFilter ReportFilter { get; }
        IRepositoryDataSource DataSource { get; }
        IRepositoryVisualizationSetting VisualizationSetting { get; }
        IRepositoryConnectionSite ConnectionSite { get; }
        IRepositoryReportSharing ReportSharing { get; }
        IRepositoryReportLog ReportLog { get; }

        void Save();
        Task SaveAsync();
    }
}
