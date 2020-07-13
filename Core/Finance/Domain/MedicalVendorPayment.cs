using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;

namespace Falcon.App.Core.Finance.Domain
{
    public class MedicalVendorPayment : DomainObjectBase
    {
        private List<PaymentInstrument> _paymentInstruments;
        public List<PaymentInstrument> PaymentInstruments
        {
            get
            {
                if (_paymentInstruments == null)
                {
                    _paymentInstruments = new List<PaymentInstrument>();
                }
                return _paymentInstruments;
            }
            set
            {
                _paymentInstruments = value;
            }
        }
        public PaymentStatus PaymentStatus { get; set; }
        [IgnoreAudit]
        public DataRecorderMetaData DataRecorderMetaData { get; set; }
        public decimal PaymentAmount
        {
            get
            {
                return PaymentInstruments.Sum(p => p.Amount);
            }
        }

        public string ReferenceNumber { get; set; }
        public string Notes { get; set; }

        public MedicalVendorPayment()
        {}

        public MedicalVendorPayment(long medicalVendorPaymentId)
            : base(medicalVendorPaymentId)
        {}
    }
}