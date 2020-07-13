using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Audit;
using Falcon.App.Core.Audit.ViewModel;
using Falcon.App.Infrastructure.Mongo;
using Falcon.App.Infrastructure.Mongo.Domain;
using MongoDB.Bson;

namespace Falcon.App.Infrastructure.Audit.Impl
{
    [DefaultImplementation]
    public class ActivityLogService : IActivityLogService
    {
        private readonly IMongoRepository<ActivityLog> _repositoryActivityLog;
        private readonly IMongoRepository<LoggedModel> _repositoryLoggedModel;
        private readonly IMongoFactory _mongoFactory;
        private readonly IReflectionFactory _reflectionFactory;
        private readonly IMongoRepository<LoggedCollectionModel> _repositoryLoggedCollectionModel;

        public ActivityLogService(IMongoRepository<ActivityLog> repositoryActivityLog,
                                  IMongoRepository<LoggedModel> repositoryLoggedModel, IMongoFactory mongoFactory, IReflectionFactory reflectionFactory,
                                  IMongoRepository<LoggedCollectionModel> repositoryLoggedCollectionModel
                                 )
        {
            _repositoryActivityLog = repositoryActivityLog;
            _repositoryLoggedModel = repositoryLoggedModel;
            _mongoFactory = mongoFactory;
            _reflectionFactory = reflectionFactory;
            _repositoryLoggedCollectionModel = repositoryLoggedCollectionModel;
        }

        public Task LogViewModel(ActivityLogEditModel activityLogEditModel, dynamic model, bool fromAPI = false)
        {
            return Task.Run(() =>
            {
                if (activityLogEditModel.CustomerId <= 0)
                {
                    var customerId = CheckModifiedCustomerId(model);
                    if (!fromAPI && customerId > 0)
                    {
                        activityLogEditModel.CustomerId = customerId;
                    }
                }

                var activityLogDomain = SaveActivityLogDomain(activityLogEditModel);

                SaveLoggedModel(model, fromAPI, activityLogDomain);
            });

        }

        public Task LogEditModel(ActivityLogEditModel activityLogEditModel, dynamic model, bool fromAPI = false)
        {
            return Task.Run(() =>
            {
                if (activityLogEditModel.CustomerId <= 0)
                {
                    var customerId = CheckModifiedCustomerId(model);
                    if (!fromAPI && customerId > 0)
                    {
                        activityLogEditModel.CustomerId = customerId;
                    }
                }

                var activityLogDomain = SaveActivityLogDomain(activityLogEditModel);
                SaveLoggedModel(model, fromAPI, activityLogDomain);
            });
        }

        public Task LogDeleteActivity(ActivityLogEditModel activityLogEditModel, dynamic model, bool fromAPI = false)
        {
            return Task.Run(() =>
            {
                var activityLogDomain = SaveActivityLogDomain(activityLogEditModel);

                if (model == null)
                    return;

                var type = (Type) model.GetType();
                if ((type.IsGenericType &&
                     (type.GetGenericTypeDefinition() == typeof (IEnumerable<>) ||
                      type.GetGenericTypeDefinition() == typeof (Dictionary<,>) ||
                      type.GetGenericTypeDefinition() == typeof (List<>))) || type.IsArray)
                {
                    var collection = (List<BsonDocument>) _reflectionFactory.ListProperty(model);
                    if (!collection.Any())
                        return;
                    var collectionToBeSaved = collection.Select(x => new LoggedCollectionModel
                    {
                        LogId = activityLogDomain.Id,
                        Model = x
                    }).ToList();

                    _repositoryLoggedCollectionModel.Save(collectionToBeSaved);
                }
                else
                {
                    SaveLoggedModel(model, fromAPI, activityLogDomain);
                }
            });

        }

        public Task LogListModel(ActivityLogEditModel activityLogEditModel, dynamic model, bool fromAPI = false)
        {
            return Task.Run(() =>
            {
                var activityLogDomain = SaveActivityLogDomain(activityLogEditModel);

                SaveListLoggedModel(model, fromAPI, activityLogDomain);
            });
        }

        public Task LogFilterModelPair(ActivityLogEditModel activityLogEditModel, dynamic filter, dynamic model, bool fromAPI = false)
        {
            return Task.Run(() =>
            {
                var activityLogDomain = SaveActivityLogDomain(activityLogEditModel);
                SaveLoggedModel(filter, fromAPI, activityLogDomain);

                SaveListLoggedModel(model, fromAPI, activityLogDomain);
            });
        }

        // Use it from the Aspx to log multiple list against single action
        public Task LogRelatedModel(ActivityLogEditModel activityLogEditModel, dynamic model, bool fromAPI = false)
        {
            return Task.Run(() =>
            {
                var activityLogDomain = SaveActivityLogDomain(activityLogEditModel);

                PropertyInfo[] members = model.GetType().GetProperties();

                foreach (var property in members)
                {
                    var propertyValue = property.GetValue(model);
                    if (property.Name.EndsWith("List"))
                    {
                        SaveListLoggedModel(propertyValue, fromAPI, activityLogDomain);
                    }
                    else
                    {
                        SaveLoggedModel(propertyValue, fromAPI, activityLogDomain);
                    }
                    //try
                    //{

                    //}
                    //catch (NullReferenceException)
                    //{
                    //}
                }
            });
        }

        private long CheckModifiedCustomerId(dynamic model)
        {
            try
            {
                long propertyValue = 0;

                if (model.GetType().Name.Contains("Customer") && model.GetType().Name.Contains("Model"))
                {
                    long idValue = 0;
                    var idProp = model.GetType().GetProperty("Id");

                    if (idProp != null)
                    {
                        idValue = long.Parse(idProp.GetValue(model).ToString());
                    }

                    propertyValue = idValue;
                }

                if (propertyValue <= 0)
                {
                    var idProp = model.GetType().GetProperty("CustomerId");
                    long idValue = 0;

                    if (idProp != null)
                    {
                        idValue = long.Parse(idProp.GetValue(model).ToString());
                    }
                    propertyValue = idValue;

                }

                return propertyValue;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        
        private ActivityLog SaveActivityLogDomain(ActivityLogEditModel activityLogEditModel)
        {
            var activityLogDomain = _mongoFactory.CreateDomain(activityLogEditModel);
            _repositoryActivityLog.Save(activityLogDomain);
            return activityLogDomain;
        }
        
        private void SaveLoggedModel(dynamic model, bool fromAPI, ActivityLog activityLogDomain)
        {
            dynamic bsonModel;

            if (_reflectionFactory.IsPrimitiveType(model.GetType()) || _reflectionFactory.IsNumericType(model.GetType()))
            {
                bsonModel = new BsonDocument("Unknown", model);
            }
            else
            {
                bsonModel = _reflectionFactory.CreateFromEditModel(model, fromAPI);
            }

            var loggedModelDomain = new LoggedModel
            {
                LogId = activityLogDomain.Id,
                Model = bsonModel
            };
            _repositoryLoggedModel.Save(loggedModelDomain);
        }

        private void SaveListLoggedModel(dynamic model, bool fromAPI, ActivityLog activityLogDomain)
        {
            var type = (Type)model.GetType();
            if ((type.IsGenericType &&
                 (type.GetGenericTypeDefinition() == typeof(IEnumerable<>) ||
                  type.GetGenericTypeDefinition() == typeof(List<>))) || type.IsArray)
            {
                var collection = (List<BsonDocument>)_reflectionFactory.ListProperty(model, fromAPI);
                if (!collection.Any())
                    return;
                var collectionToBeSaved = collection.Select(x => new LoggedCollectionModel
                {
                    LogId = activityLogDomain.Id,
                    ModelName = type.Name,
                    Model = x
                }).ToList();

                _repositoryLoggedCollectionModel.Save(collectionToBeSaved);

                return;
            }

            PropertyInfo[] members = model.GetType().GetProperties();
            foreach (var propertyInfo in members)
            {
                if (propertyInfo.GetCustomAttributes(typeof(IgnoreAuditAttribute), false).Any())
                {
                    continue;
                }

                var propertyValue = propertyInfo.GetValue(model);

                if (propertyValue == null)
                    continue;

                if (!string.IsNullOrEmpty(GetSimplePropertyValue(propertyInfo, model)))
                {
                    var elementValue = GetSimplePropertyValue(propertyInfo, model);

                    var loggedModelDomain = new LoggedCollectionModel
                    {
                        LogId = activityLogDomain.Id,
                        Model = new BsonDocument(propertyInfo.Name, elementValue),
                        ModelName = type.Name
                    };
                    _repositoryLoggedCollectionModel.Save(loggedModelDomain);
                }
                else if ((propertyInfo.PropertyType.IsGenericType && (propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(IEnumerable<>) || propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(IList<>) || propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(List<>))) || propertyInfo.PropertyType.IsArray)
                {
                    var collection = (List<BsonDocument>)_reflectionFactory.ListProperty(propertyValue, fromAPI);
                    if (!collection.Any())
                        continue;
                    var collectionToBeSaved = collection.Select(x => new LoggedCollectionModel
                    {
                        LogId = activityLogDomain.Id,
                        ModelName = type.Name,
                        Model = x
                    }).ToList();

                    _repositoryLoggedCollectionModel.Save(collectionToBeSaved);
                }
                else
                {
                    SaveLoggedModel(propertyValue, fromAPI, activityLogDomain);
                    
                }
            }
        }

        private string GetSimplePropertyValue(PropertyInfo propertyInfo, dynamic model)
        {
            if (_reflectionFactory.IsPrimitiveType(propertyInfo.PropertyType) || _reflectionFactory.IsNumericType(propertyInfo.PropertyType))
            {
               return propertyInfo.GetValue(model).ToString();
            }
            if (propertyInfo.PropertyType == typeof (DateTime?) || propertyInfo.PropertyType == typeof (DateTime))
            {
                return ((DateTime)propertyInfo.GetValue(model)).ToString();
            }
            return string.Empty;
        }
    }
}
