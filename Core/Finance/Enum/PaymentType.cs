namespace Falcon.App.Core.Finance.Enum
{
    public sealed class PaymentType : TypeSafeEnum
    {
        private readonly int _persistenceLayerId;
        public int PersistenceLayerId { get { return _persistenceLayerId; } }

        private PaymentType(int persistenceLayerId, string name)
            : base(name)
        {
            _persistenceLayerId = persistenceLayerId;
        }

        public static readonly PaymentType Check = new PaymentType(1, "Check");
        public static readonly PaymentType CreditCard = new PaymentType(2, "Credit Card");
        public static readonly PaymentType ElectronicCheck = new PaymentType(7, "eCheck");
        public static readonly PaymentType GiftCertificate = new PaymentType(8, "Gift Certificate");
        public static readonly PaymentType Cash = new PaymentType(4, "Cash");
        public static readonly PaymentType Insurance = new PaymentType(9, "Insurance");

        public const long Onsite_Value = 5000;
        public const string Onsite_Text = "Onsite";
        public const string PayLater_Text = "Pay Later";

        public const long CreditCardOnFile_Value = 5002;
        public const string CreditCardOnFile_Text = "Credit Card on File";

    }
}