namespace Falcon.App.Core.Sales
{
    public interface IActivityTemplateRepository
    {
        bool ActiveDeActiveTemplate(long activityTemplateId,bool activeStatus);        
    }
}
