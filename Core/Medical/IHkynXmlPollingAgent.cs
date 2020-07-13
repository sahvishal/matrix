namespace Falcon.App.Core.Medical
{
    public interface IHkynXmlPollingAgent
    {
        void PollForEventsforHkynXml();
    }

    public interface IMyBioChekAssesmentPollingAgent
    {
        void PollForEventsforMyBioChekAssesmentJson();
    }
}