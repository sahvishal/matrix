namespace Falcon.App.Core.Medical
{
    public interface IResultPacketGeneratorPollingAgent
    {
        void PollForResultPacketGeneration();
        //void GeneratePremiumPdfZipforpendingEvents();
    }
}