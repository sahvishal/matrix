using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HealthYes.Data.HelperClasses;
using HealthYes.Data.Linq;
using HealthYes.Web.Core;
using HealthYes.Web.Core.Domain.Addresses.Interfaces;
using HealthYes.Web.Core.Exceptions;
using HealthYes.Web.Core.Interfaces;
using HealthYes.Web.Core.ValueTypes;
using HealthYes.Web.Infrastructure.Impl;
using HealthYes.Web.Core.Domain.PrintOrder;
using HealthYes.Data.EntityClasses;
using HealthYes.Web.Infrastructure.Interfaces;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using HealthYes.Web.Core.Domain.PrintOrder.Interfaces;
using HealthYes.Web.Infrastructure.Mappers.PrintOrder;
using HealthYes.Web.Core.Domain.PrintOrder.Enum;

namespace HealthYes.Web.Infrastructure.Repositories.PrintOrder
{
    public class PrintOrderItemShippingStatusRepository : PersistenceRepository, IPrintOrderItemShippingStatusRepository
    {
        private readonly IMapper<PrintOrderItemShippingStatus, PrintOrderItemShippingStatusEntity> _mapper;

        public PrintOrderItemShippingStatusRepository()
            : this(new PrintOrderItemShippingStatusMapper())
        {

        }

        public PrintOrderItemShippingStatusRepository(IMapper<PrintOrderItemShippingStatus, PrintOrderItemShippingStatusEntity> mapper)
        {
            _mapper = mapper;
        }

        public PrintOrderItemShippingStatus GetById(long eventId)
        {
            return null;
        }

        public PrintOrderItemShippingStatus Save(PrintOrderItemShippingStatus printOrderItemShippingStatus)
        {
            var printOrderItemShippingStatusEntity = _mapper.Map(printOrderItemShippingStatus);

            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                if (!adapter.SaveEntity(printOrderItemShippingStatusEntity, false))
                {
                    throw new PersistenceFailureException();
                }
            }
            return _mapper.Map(printOrderItemShippingStatusEntity);
        }



    }
}

