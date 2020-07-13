using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Interfaces
{
    public interface IDataRecorderMetaDataFactory
    {
        DataRecorderMetaData CreateDataRecorderMetaData(long dataRecorderCreatorId);
        DataRecorderMetaData CreateDataRecorderMetaData(long dataRecoderCreatorId, DateTime dateCreated);
        DataRecorderMetaData CreateDataRecorderMetaData(long dataRecorderCreatorId, DateTime dateCreated,
            long? dataRecorderModifierId, DateTime? dateModified);
    }
}