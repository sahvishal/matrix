using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Audit;
using Falcon.App.Core.Audit.ViewModel;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Mongo;
using Falcon.App.Infrastructure.Mongo.Domain;
using MongoDB.Bson;

namespace Falcon.App.Infrastructure.Audit.Impl
{
    [DefaultImplementation]
    public class ActivityLogViewService : IActivityLogViewService
    {
        private readonly IMongoRepository<ActivityLog> _repositoryActivityLog;
        private readonly IActivityLogFactory _activityLogFactory;
        private readonly IMongoRepository<LoggedModel> _repositoryLoggedModel;
        private readonly IMongoRepository<LoggedCollectionModel> _repositoryLoggedCollectionModel;
        //private readonly IActivityDataNotationService _activityDataNotationService;
        //private readonly IActivityLogViewExceptions _activityLogViewExceptions;

       // private IEnumerable<OrderedPair<string, Type>> _domainTypes = null;

        public ActivityLogViewService(IMongoRepository<ActivityLog> repositoryActivityLog, IActivityLogFactory activityLogFactory,
                                      IMongoRepository<LoggedModel> repositoryLoggedModel, IMongoRepository<LoggedCollectionModel> repositoryLoggedCollectionModel)
        {
            _repositoryActivityLog = repositoryActivityLog;
            _activityLogFactory = activityLogFactory;
            _repositoryLoggedModel = repositoryLoggedModel;
            _repositoryLoggedCollectionModel = repositoryLoggedCollectionModel;
        }

        public ActivityLogListModel GetList(ActivityLogListFilter filter, int pageNumber, int pageSize, out int total)
        {
            Expression<Func<ActivityLog, bool>> query = x => x.Timestamp >= filter.StartDate && x.Timestamp <= filter.EndDate;

            if (filter.AccessType != Core.Audit.Enum.Type.All)
            {
                query = x => x.Timestamp >= filter.StartDate && x.Timestamp <= filter.EndDate && x.Action == filter.AccessType.ToString();
            }

            if (filter.AccessedBy > 0)
            {
                if (filter.AccessType != Core.Audit.Enum.Type.All)
                {
                    query = x =>
                            x.Timestamp >= filter.StartDate && x.Timestamp <= filter.EndDate &&
                            x.Action == filter.AccessType.ToString() &&
                            x.AccessById == filter.AccessedBy;
                }
                else
                {
                    query =
                        x =>
                            x.Timestamp >= filter.StartDate && x.Timestamp <= filter.EndDate &&
                            x.AccessById == filter.AccessedBy;
                }
            }

            if (filter.CustomerId > 0)
            {
                if (filter.AccessedBy > 0)
                {
                    if (filter.AccessType != Core.Audit.Enum.Type.All)
                    {
                        query = x =>
                            x.Timestamp >= filter.StartDate && x.Timestamp <= filter.EndDate &&
                            x.Action == filter.AccessType.ToString() &&
                            x.AccessById == filter.AccessedBy &&
                            x.CustomerId == filter.CustomerId;
                    }
                    else
                    {
                        query =
                            x =>
                                x.Timestamp >= filter.StartDate && x.Timestamp <= filter.EndDate &&
                                x.AccessById == filter.AccessedBy &&
                                x.CustomerId == filter.CustomerId;
                    }
                }
                else
                {
                    if (filter.AccessType != Core.Audit.Enum.Type.All)
                    {
                        query = x =>
                            x.Timestamp >= filter.StartDate && x.Timestamp <= filter.EndDate &&
                            x.Action == filter.AccessType.ToString() &&
                            x.CustomerId == filter.CustomerId;
                    }
                    else
                    {
                        query =
                            x =>
                                x.Timestamp >= filter.StartDate && x.Timestamp <= filter.EndDate &&
                                x.CustomerId == filter.CustomerId;
                    }
                }
            }

            var result = _repositoryActivityLog.Find(query, pageNumber, pageSize, out total).ToList();

            return new ActivityLogListModel { Filter = filter, Collection = result.Select(x => _activityLogFactory.CreateViewModel(x)).ToList() };

        }

        public ActivityLoggedModelDetailsViewModel GetModelDetails(string logId)
        {
            var id = new ObjectId(logId);
            var result = new ActivityLoggedModelDetailsViewModel();

            var activityLog = _repositoryActivityLog.Find(x => x.Id == id).First();
            if (ProcessExceptionModel(activityLog, result))
                return result;

            FillLoggedModel(activityLog, result);

            FillLoggedCollectionModel(id, result);

            result.ActivityLog = _activityLogFactory.CreateViewModel(activityLog);
            return result;
        }

        private void FillLoggedModel(ActivityLog log, ActivityLoggedModelDetailsViewModel result)
        {
            var loggedModels = _repositoryLoggedModel.Find(x => x.LogId == log.Id).ToList();
            foreach (var model in loggedModels)
            {
                result.ModelDetails = CreateActivityViewModel(model.Model, log.ModelName);
            }
        }

        private void FillLoggedCollectionModel(ObjectId logId, ActivityLoggedModelDetailsViewModel result)
        {
            var loggedModels = _repositoryLoggedCollectionModel.Find(x => x.LogId == logId).ToList();

            var collectionModels = new List<ActivityLoggedModelViewModel>();
            foreach (var model in loggedModels)
            {
                var item = CreateActivityViewModel(model.Model, model.ModelName);
                collectionModels.Add(item);
            }

            result.Collections = collectionModels;
        }

        private ActivityLoggedModelViewModel CreateActivityViewModel(BsonDocument doc, string modelName)
        {
            var model = new ActivityLoggedModelViewModel
            {
                Simple = ProcessBsonDocumentForSimpleElement(doc, modelName),
                Complex = ProcessBsonDocumentForComplex(doc, modelName)
            };

            if(doc.Elements.Any(x=>x.Value.IsBsonArray)) model = ProcessBsonDocumentForCollections(model, doc);

            return model;
        }


        private IEnumerable<KeyValuePair<string, string>> ProcessBsonDocumentForSimpleElement(BsonDocument doc, string modelName)
        {
            var simpleElements = new List<KeyValuePair<string, string>>();
            foreach (var element in doc.Elements.Where(x => !x.Value.IsBsonDocument && !x.Value.IsBsonArray).ToList())
            {
                //if (_activityLogViewExceptions.IsIgnored(modelName, element.Name))
                //    continue;

                if ((!element.Name.ToLower().Equals("id") && !element.Name.EndsWith("Id") && !element.Name.EndsWith("ID")) || element.Name.ToLower().Equals("customerid") || element.Name.ToLower().Equals("eventid"))
                {
                    var name = Regex.Replace(element.Name, "(\\B[A-Z])", " $1");
                    var item = GetSimpleElement(name,
                        element.Value.IsBsonNull ? string.Empty : element.Value.ToString(), modelName);
                    /*simpleElements.Add(new KeyValuePair<string, string>(element.Name, element.Value.IsBsonNull ? string.Empty : element.Value.ToString()));*/
                    simpleElements.Add(item);
                }
            }
            return simpleElements;
        }

        private KeyValuePair<string, string> GetSimpleElement(string key, string value, string modelName)
        {
            //if (_activityDataNotationService.IsDataNotationAvailable(key) && !string.IsNullOrEmpty(value))
            //{
            //    long lookupId;
            //    if (long.TryParse(value, out lookupId))
            //    {
            //        var val = long.Parse(value);

            //        if (val > 0) value = _activityDataNotationService.GetLookupValue(val);
            //    }

            //}
            //else if (!string.IsNullOrEmpty(value))
            //{
            //    value = _activityDataNotationService.GetKeyStringValue(key, value);
            //}

            //if (!string.IsNullOrEmpty(modelName))
            //    _activityLogViewExceptions.IncludeExceptions(modelName, ref key, ref value);

            key = GetLabel(key);

            var number = 0;
            var result = Int32.TryParse(value, out number);

            //if ((key.ToLower().EndsWith("id") || key.ToLower().EndsWith("type")) && key.Length >= 2 && value != "None" && result)
            //{
            //    if (_domainTypes == null) _domainTypes = EntityDataHelper.GetAllDomainTypes();

            //    dynamic entity = null;

            //    if (key.ToLower().EndsWith("typeid") || (key.ToLower().EndsWith("type")))
            //    {
            //        entity = EntityDataHelper.GetData("lookupid", number, _domainTypes);
            //    }
            //    else
            //    {
            //        entity = EntityDataHelper.GetData(key, number, _domainTypes);

            //    }

            //    if (entity != null)
            //    {
            //       // var name = EntityDataMapper.GetLabel(entity);

            //        //if (name != string.Empty)
            //        //{
            //        //    value = name;

            //            if(key.ToLower().EndsWith("id"))
            //            {
            //                var keyName = key.Substring(0, key.LastIndexOf("Id"));
            //                key = keyName;
            //            }
            //       // }
            //    }
            //}

            return new KeyValuePair<string, string>(key, value);
        }

        private IEnumerable<KeyValuePair<string, ActivityLoggedModelViewModel>> ProcessBsonDocumentForComplex(BsonDocument doc, string modelName)
        {
            var result = new List<KeyValuePair<string, ActivityLoggedModelViewModel>>();
            foreach (var element in doc.Elements.Where(x => x.Value.IsBsonDocument).ToList())
            {
                //if (_activityLogViewExceptions.IsIgnored(modelName, element.Name))
                //    continue;
                var key = GetLabel(element.Name);
                key = Regex.Replace(key, "(\\B[A-Z])", " $1");
                var complexElement = RecursiveCallToCreateComplextType(key, element.Value, modelName);
                result.Add(complexElement);
            }

            return result;
        }

        private ActivityLoggedModelViewModel ProcessBsonDocumentForCollections(ActivityLoggedModelViewModel result, BsonDocument doc)
        {
            var collections = new List<ActivityLoggedModelViewModel>();
            foreach (var element in doc.Elements.Where(x => x.Value.IsBsonArray).ToList())
            {
                foreach (var ite in element.Value.AsBsonArray.ToList())
                {
                    var item = CreateActivityViewModel(ite.ToBsonDocument(), element.Name);
                    collections.Add(item);
                }
                
            }

            result.Collections = collections;
            return result;
        }

        private KeyValuePair<string, ActivityLoggedModelViewModel> RecursiveCallToCreateComplextType(string key, BsonValue value, string modelName)
        {

            var complexModelList = new List<KeyValuePair<string, ActivityLoggedModelViewModel>>();
            var simpleModelList = new List<KeyValuePair<string, string>>();
            if (!value.IsBsonArray && !value.IsBsonDocument)
            {
                if (!key.ToLower().Equals("id"))
                {
                    key = Regex.Replace(key, "(\\B[A-Z])", " $1");
                    return new KeyValuePair<string, ActivityLoggedModelViewModel>(key,
                        new ActivityLoggedModelViewModel
                        {
                            Simple = new List<KeyValuePair<string, string>>
                            {
                                GetSimpleElement(key, (!value.IsBsonNull ? value.ToString() : string.Empty), modelName)
                            }

                        });
                }
            }
            if (value.IsBsonDocument)
            {
                var doc = (BsonDocument)value;
                foreach (var element in doc.Elements)
                {
                    if (element.Value.IsBsonDocument)
                    {
                        complexModelList.Add(RecursiveCallToCreateComplextType(element.Name, element.Value, modelName));
                    }
                    else if (!element.Value.IsBsonDocument && !element.Value.IsBsonArray)
                    {
                        if (!element.Value.IsBsonNull)
                        {
                            if (!key.ToLower().Equals("id"))
                            {
                                var item = GetSimpleElement(element.Name, element.Value.ToString(), modelName);
                                simpleModelList.Add(item);
                            }
                        }

                    }

                }
            }


            return new KeyValuePair<string, ActivityLoggedModelViewModel>(key,
                new ActivityLoggedModelViewModel { Simple = simpleModelList, Complex = complexModelList });
        }

        private static string GetLabel(string key)
        {
            var aliases = new List<KeyValuePair<string, string>>()
            {
                //new KeyValuePair<string,string>("StateId","State"),
                //new KeyValuePair<string,string>("CountryId","Country"),
                //new KeyValuePair<string,string>("TimeZoneId","TimeZone"),
                //new KeyValuePair<string,string>("SecurityQuestionId","SecurityQuestion"),
                //new KeyValuePair<string,string>("AccountId","Account"),
                //new KeyValuePair<string,string>("LoggedInClinicianId","LoggedInClinician"),
                new KeyValuePair<string,string>("AddressViewModel","Address")
                
            };

            return aliases.Exists(x => x.Key == key)
                 ? aliases.Find(x => x.Key == key).Value
                 : key;


        }

        private bool ProcessExceptionModel(ActivityLog activityLog, ActivityLoggedModelDetailsViewModel result)
        {
            var isProcessed = false;
            switch (activityLog.ModelName)
            {
                case "AdminEditModel":
                    {
                        isProcessed = true;
                        ProcessAdminEditModel(activityLog, result);
                        break;
                    }
            }
            return isProcessed;
        }

        private void ProcessAdminEditModel(ActivityLog activityLog, ActivityLoggedModelDetailsViewModel result)
        {
            var modelName = "AdminEditModel";
            var adminEditModelDoc = _repositoryLoggedModel.Find(x => x.LogId == activityLog.Id).First();
            var newDoc = new BsonDocument();
            var user = adminEditModelDoc.Model["User"];

            if (user != null && user.IsBsonDocument)
            {

                var doc = (BsonDocument)user;
                var personDetails = (BsonDocument)doc["PersonEditModel"];
                newDoc.Add(personDetails.Elements);
                var userLoginDetails = (BsonDocument)doc["UserLogin"];
                newDoc.Add(userLoginDetails.Elements);
            }
            newDoc.Add(new BsonElement("IsAccountAdmin", adminEditModelDoc.Model["IsAccountAdmin"]));
            newDoc.Add(new BsonElement("AccountId", adminEditModelDoc.Model["AccountId"]));


            result.ModelDetails = CreateActivityViewModel(newDoc, modelName);

        }

    }
}
