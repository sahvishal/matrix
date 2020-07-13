namespace Falcon.App.Core.Medical
{
    public interface IHafGenerationService
    {
        void GenerateHafAssessment(long eventId);
    }
}