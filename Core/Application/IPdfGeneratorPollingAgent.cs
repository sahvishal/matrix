namespace Falcon.App.Core.Application
{
    public interface IPdfGeneratorPollingAgent
    {
        void PollForPdfGenerating();
        void PollForPdfFromHtmlStream();
    }
}
