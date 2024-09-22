namespace Services.Contracts
{
    public interface IServiceManager
    {
        IServiceReport ServiceReport { get; }
        IServiceConnectionSite ServiceConnectionSite { get; }
        IServiceDataSource ServiceDataSource { get; }
        IServiceReportFilter ServiceReportFilter { get; }
        IServiceVisualizationSetting ServiceVisualizationSetting { get; }
        IServiceReportLog ServiceReportLog { get; }
        IServiceReportSharing ServiceReportSharing { get; }
    }
}
