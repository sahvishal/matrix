using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Enum;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.Interfaces;
using StackExchange.Redis;

namespace Falcon.App.Infrastructure.CallCenter.Impl
{
    
    [DefaultImplementation]
    public class CallQueueCustomerPollingAgent : ICallQueueCustomerPollingAgent
    {
        private readonly ICallQueueCustomerRepository _callQueueCustomerRepository;

        private IDatabase _db;
        private ConnectionMultiplexer _redis;
        private readonly string _host;
        private readonly int _redisDatabaseKey;
        private readonly ILogger _loggerForCustomerLogger;
        private readonly ILogger _loggerForCustomerAppointmentLogger;
        private readonly ILogger _loggerForAppointmentCancellationLogger;
        private ConnectionMultiplexer ConnectionMultiplexer
        {
            get
            {
                if (_redis == null || !_redis.IsConnected)
                {
                    var config = ConfigurationOptions.Parse(_host);
                    config.ConnectTimeout = 5000;
                    _redis = ConnectionMultiplexer.Connect(config);
                }
                return _redis;
            }
        }

        public CallQueueCustomerPollingAgent(ILogManager logManager, ISettings settings, ICallQueueCustomerRepository callQueueCustomerRepository)
        {
            _callQueueCustomerRepository = callQueueCustomerRepository;
            _host = settings.RedisServerHost;
            _redisDatabaseKey = settings.RedisDatabaseKey;
            _loggerForCustomerLogger = logManager.GetLogger("UpdateCustomerLogger");
            _loggerForCustomerAppointmentLogger = logManager.GetLogger("UpdateCustomerAppointmentLogger");
            _loggerForAppointmentCancellationLogger = logManager.GetLogger("AppointmentCancellationLogger");
        }

        public void PollForUpdateCustomerFlag()
        {
            _loggerForCustomerLogger.Info("Update Call Queue Customer Flag Started");
            _loggerForCustomerLogger.Info(string.Format("Subscriber: Channel-{0}, Queue-{1}", RequestSubcriberChannelNames.CallQueueCustomerUpdateCustomerFlagChannel, RequestSubcriberChannelNames.CallQueueCustomerUpdateCustomerFlagQueue));
            try
            {
                var redis = ConnectionMultiplexer;

                var sub = redis.GetSubscriber();
                sub.Unsubscribe(RequestSubcriberChannelNames.CallQueueCustomerUpdateCustomerFlagChannel);

                _db = redis.GetDatabase(_redisDatabaseKey);
                _db.KeyDelete(RequestSubcriberChannelNames.CallQueueCustomerUpdateCustomerFlagQueue);

                sub.Subscribe(RequestSubcriberChannelNames.CallQueueCustomerUpdateCustomerFlagChannel, delegate
                {
                    string item = _db.ListRightPop(RequestSubcriberChannelNames.CallQueueCustomerUpdateCustomerFlagQueue);
                    while (item != null)
                    {
                        var request = Newtonsoft.Json.JsonConvert.DeserializeObject<CallQueueCustomerPubViewModel>(item);
                        try
                        {
                            _loggerForCustomerLogger.Info(string.Format("Updating Customer Details for customerId : {0}", request.CustomerId));
                            UpdateCallQueueCustomer(request);
                            _loggerForCustomerLogger.Info(string.Format("Updated Customer Details for customerId : {0}", request.CustomerId));
                         
                        }
                        catch (Exception ex)
                        {
                            _loggerForCustomerLogger.Error("Update Call Queue Customer Flag Failed. Message: " + ex.Message + ".\n\t" + ex.StackTrace);
                        }
                        item = _db.ListRightPop(RequestSubcriberChannelNames.CallQueueCustomerUpdateCustomerFlagQueue);
                    }
                });
            }
            catch (Exception ex)
            {
                _loggerForCustomerLogger.Error("Update Call Queue Customer Flag Failed. Message: " + ex.Message + ".\n\t" + ex.StackTrace);
            }
        }

        public void PollForUpdateAppointmentFlag()
        {
            _loggerForCustomerAppointmentLogger.Info("Update Call Queue Appointment Flag Started");
            _loggerForCustomerAppointmentLogger.Info(string.Format("Subscriber: Channel-{0}, Queue-{1}", RequestSubcriberChannelNames.CallQueueCustomerUpdateAppointmentFlagChannel, RequestSubcriberChannelNames.CallQueueCustomerUpdateAppointmentFlagQueue));
            try
            {
                var redis = ConnectionMultiplexer;

                var sub = redis.GetSubscriber();
                sub.Unsubscribe(RequestSubcriberChannelNames.CallQueueCustomerUpdateAppointmentFlagChannel);

                _db = redis.GetDatabase(_redisDatabaseKey);
                _db.KeyDelete(RequestSubcriberChannelNames.CallQueueCustomerUpdateAppointmentFlagQueue);

                sub.Subscribe(RequestSubcriberChannelNames.CallQueueCustomerUpdateAppointmentFlagChannel, delegate
                {
                    string item = _db.ListRightPop(RequestSubcriberChannelNames.CallQueueCustomerUpdateAppointmentFlagQueue);
                    while (item != null)
                    {
                        var request = Newtonsoft.Json.JsonConvert.DeserializeObject<FutureAppointmentFlagViewModel>(item);
                        try
                        {
                            _loggerForCustomerAppointmentLogger.Info(string.Format("Updating customers Appointment Info customerId: {0} and Appointment Time: {1} ", request.CustomerId, request.FutureAppointmentDate));
                            UpdateAppointmentFlag(request);
                            _loggerForCustomerAppointmentLogger.Info(string.Format("Updated customers Appointment Info customerId: {0} and Appointment Time: {1} ", request.CustomerId, request.FutureAppointmentDate));
                        }
                        catch (Exception ex)
                        {
                          //  _db.StringSet(request.Guid, "Failed");
                            _loggerForCustomerAppointmentLogger.Error("Appointment Failed. Message: " + ex.Message + ".\n\t" + ex.StackTrace);
                        }
                        item = _db.ListRightPop(RequestSubcriberChannelNames.CallQueueCustomerUpdateAppointmentFlagQueue);
                    }
                });
            }
            catch (Exception ex)
            {
                _loggerForCustomerAppointmentLogger.Error("Update Call Queue Customer Flag Failed. Message: " + ex.Message + ".\n\t" + ex.StackTrace);
            }
        }

        public void PollForUpdateCancellationFlag()
        {
            _loggerForAppointmentCancellationLogger.Info("Update Call Queue Customer Flag Started");
            _loggerForAppointmentCancellationLogger.Info(string.Format("Subscriber: Channel-{0}, Queue-{1}", RequestSubcriberChannelNames.CallQueueCustomerUpdateCancellationFlagChannel, RequestSubcriberChannelNames.CallQueueCustomerUpdateCancellationFlagQueue));
            try
            {
                var redis = ConnectionMultiplexer;

                var sub = redis.GetSubscriber();
                sub.Unsubscribe(RequestSubcriberChannelNames.CallQueueCustomerUpdateCancellationFlagChannel);

                _db = redis.GetDatabase(_redisDatabaseKey);
                _db.KeyDelete(RequestSubcriberChannelNames.CallQueueCustomerUpdateCancellationFlagQueue);

                sub.Subscribe(RequestSubcriberChannelNames.CallQueueCustomerUpdateCancellationFlagChannel, delegate
                {
                    string item = _db.ListRightPop(RequestSubcriberChannelNames.CallQueueCustomerUpdateCancellationFlagQueue);
                    while (item != null)
                    {
                        var request = Newtonsoft.Json.JsonConvert.DeserializeObject<CancelAppointmentFlagViewModel>(item);
                        try
                        {
                            _loggerForAppointmentCancellationLogger.Info(string.Format("Updating customers Appointment Cancellation Info customerId: {0} and Cancellation Time: {1} ", request.CustomerId, request.CancelAppoinemtDate));
                            UpdateCancellationFlag(request);
                            _loggerForAppointmentCancellationLogger.Info(string.Format("Updated customers Appointment Cancellation Info customerId: {0} and Cancellation Time: {1} ", request.CustomerId, request.CancelAppoinemtDate));
                        }
                        catch (Exception ex)
                        {
                          _loggerForAppointmentCancellationLogger.Error("Update Call Queue Customer Flag Failed. Message: " + ex.Message + ".\n\t" + ex.StackTrace);
                        }
                        item = _db.ListRightPop(RequestSubcriberChannelNames.CallQueueCustomerUpdateCancellationFlagQueue);
                    }
                });
            }
            catch (Exception ex)
            {
                _loggerForAppointmentCancellationLogger.Error("Update Call Queue Customer Flag Failed. Message: " + ex.Message + ".\n\t" + ex.StackTrace);
            }
        }

        private void UpdateCallQueueCustomer(CallQueueCustomerPubViewModel customer)
        {
            _callQueueCustomerRepository.UpdateCustomerField(customer);
        }

        private void UpdateAppointmentFlag(FutureAppointmentFlagViewModel customer)
        {
            _callQueueCustomerRepository.UpdateFutureAppointment(customer);
        }

        private void UpdateCancellationFlag(CancelAppointmentFlagViewModel customer)
        {
            _callQueueCustomerRepository.UpdateCancelAppointment(customer);
        }

    }
    
}
