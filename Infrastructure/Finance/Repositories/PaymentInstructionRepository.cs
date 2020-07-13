using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Core.Finance.Domain;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Infrastructure.Finance.Mappers;

namespace Falcon.App.Infrastructure.Finance.Repositories
{
    public class PaymentInstructionRepository : PersistenceRepository
    {
        IMapper<PaymentInstructions, PaymentInstructionsEntity> _mapper;

        public PaymentInstructionRepository()
        {
            _mapper = new PaymentInstructionMapper();
        }

        public PaymentInstructions Save(PaymentInstructions paymentInstruction)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = _mapper.Map(paymentInstruction);
                if (!myAdapter.SaveEntity(entity, true))
                {
                    throw new PersistenceFailureException();
                }
                paymentInstruction.Id = entity.PaymentInstructionId;
            }
            return paymentInstruction;
        }

        public PaymentInstructions Get(long id)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var entity = linqMetaData.PaymentInstructions.Where(pi => pi.PaymentInstructionId == id).FirstOrDefault();
                return _mapper.Map(entity);
            }
        }

    }
}

