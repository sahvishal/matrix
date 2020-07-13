using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Finance.Domain;
using FluentValidation;
using System.ComponentModel.DataAnnotations;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Finance.ViewModels
{
    public class ProductOrderItemEditModel : ViewModelBase
    {
        [UIHint("Hidden")]
        public long EventId { get; set; }
        [UIHint("Hidden")]
        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
        public Order Order { get; set; }
        public IEnumerable<long> ProductOrderDetailIds { get; set; }

        public RefundRequestEditModel RefundRequest { get; set; }
        public PaymentEditModel Payments { get; set; }
    }

    [DefaultImplementation(Interface = typeof(IValidator<ProductOrderItemEditModel>))]
    public class ProductOrderItemEditModelValidator : AbstractValidator<ProductOrderItemEditModel>
    {
        public ProductOrderItemEditModelValidator()
        {

        }
    }
}