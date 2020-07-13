using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Impl
{
    [DefaultImplementation]
    public class DataRecorderMetaDataFactory : IDataRecorderMetaDataFactory
    {
        private readonly ICalendar _calendar;

        public DataRecorderMetaDataFactory()
            : this(new DateTimeCalendar())
        {}

        public DataRecorderMetaDataFactory(ICalendar calendar)
        {
            _calendar = calendar;
        }

        public DataRecorderMetaData CreateDataRecorderMetaData(long dataRecorderCreatorId)
        {
            return CreateDataRecorderMetaData(dataRecorderCreatorId, _calendar.Now);
        }

        public DataRecorderMetaData CreateDataRecorderMetaData(long dataRecoderCreatorId, DateTime dateCreated)
        {
            return CreateDataRecorderMetaData(dataRecoderCreatorId, dateCreated, null, null);
        }

        public DataRecorderMetaData CreateDataRecorderMetaData(long dataRecorderCreatorId, DateTime dateCreated,
            long? dataRecorderModifierId, DateTime? dateModified)
        {
            var dataRecorderCreator = new OrganizationRoleUser(dataRecorderCreatorId);
            OrganizationRoleUser dataRecorderModifier = dataRecorderModifierId.HasValue ?
                new OrganizationRoleUser(dataRecorderModifierId.Value) : null;

            return new DataRecorderMetaData
            {
                DataRecorderCreator = dataRecorderCreator,
                DataRecorderModifier = dataRecorderModifier,
                DateCreated = dateCreated,
                DateModified = dateModified
            };
        }
    }
}