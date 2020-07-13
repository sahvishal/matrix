using System.Collections.Generic;
using System.Linq;

namespace Falcon.App.Core.Finance.Domain
{
    public class PhysicianInvoice : PhysicianInvoiceBase
    {
        public PhysicianInvoice()
        {}

        public PhysicianInvoice(long medicalVendorInvoiceId)
            : base(medicalVendorInvoiceId)
        {}

        private List<MedicalVendorInvoiceItem> _medicalVendorInvoiceItems;
        public List<MedicalVendorInvoiceItem> MedicalVendorInvoiceItems
        {
            get
            {
                if (_medicalVendorInvoiceItems == null)
                {
                    _medicalVendorInvoiceItems = new List<MedicalVendorInvoiceItem>();
                }
                return _medicalVendorInvoiceItems;
            }
            set
            {
                _medicalVendorInvoiceItems = value;
            }
        }
        public override decimal InvoiceAmount { get { return MedicalVendorInvoiceItems.Sum(m => m.MedicalVendorAmountEarned); } }
        public override int NumberOfEvaluations { get { return MedicalVendorInvoiceItems.Count; } }
    }    
}