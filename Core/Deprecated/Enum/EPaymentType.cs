namespace Falcon.App.Core.Enum
{
    /// <summary>
    /// This enum will store all the 
    /// Payment Type.
    /// </summary>
    public enum EPaymentType
    {
        /// <summary>
        /// Payment made through Credit Card/ Debit Card
        /// </summary>
        CreditCardPayment = 0,
        /// <summary>
        /// Payment made through Cheque
        /// </summary>
        ChequePayment = 1,
        /// <summary>
        /// Payment made through the 
        /// Demand Drafts
        /// </summary>
        DemandDraftPayment = 2,
        /// <summary>
        /// Payment made through the
        /// Money Orders
        /// </summary>
        MoneyOrderPayment = 3,
        /// <summary>
        /// Payment made through Cash
        /// </summary>
        CashPayment = 4
    }
}