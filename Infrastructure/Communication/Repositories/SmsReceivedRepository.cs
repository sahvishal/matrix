using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.Communication.Repositories
{
    [DefaultImplementation]
    public class SmsReceivedRepository : PersistenceRepository, ISmsReceivedRepository
    {
        public SmsReceived SaveSmsReceived(SmsReceived smsReceived)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<SmsReceived, SmsReceivedEntity>(smsReceived);
                if (!adapter.SaveEntity(entity, true))
                {
                    throw new PersistenceFailureException();
                }

                return Mapper.Map<SmsReceivedEntity, SmsReceived>(entity);
            }
        }

        public IEnumerable<SmsReceived> GetSmsReceived(long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from sms in linqMetaData.SmsReceived select sms).ToArray();

                return
                    Mapper.Map<IEnumerable<SmsReceivedEntity>, IEnumerable<SmsReceived>>(entities);
            }
        }

        public IEnumerable<SmsReceived> GetSmsReceived(string phoneNumber)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from sms in linqMetaData.SmsReceived where sms.PhoneNumber == phoneNumber select sms).ToArray();

                return Mapper.Map<IEnumerable<SmsReceivedEntity>, IEnumerable<SmsReceived>>(entities);
            }
        }
    }
}
