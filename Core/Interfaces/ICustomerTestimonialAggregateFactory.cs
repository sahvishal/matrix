using System.Linq;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;

namespace Falcon.App.Core.Interfaces
{
    public interface ICustomerTestimonialAggregateFactory
    {
        CustomerTestimonialAggregate CreateCustomerTestimonialAggregate(IGrouping<long, Testimonial> testimonialGroup);
    }
}
