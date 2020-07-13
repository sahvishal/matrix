namespace Falcon.App.Core.Application.ViewModels
{
    public abstract class ReportRequestBase
    {
        protected ReportRequestBase()
        {
            Guid = System.Guid.NewGuid().ToString();
        }
        public string Guid { get; set; }
        public string CsvFilePath { get; set; }
    }
}
