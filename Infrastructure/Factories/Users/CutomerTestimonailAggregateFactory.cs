using System.Linq;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.Infrastructure.Repositories.Users;

namespace Falcon.App.Infrastructure.Factories.Users
{
    public class CutomerTestimonailAggregateFactory : ICustomerTestimonialAggregateFactory
    {

        public CustomerTestimonialAggregate CreateCustomerTestimonialAggregate(IGrouping<long, Testimonial> testimonialGroup)
        {
            ICustomerRepository customerRepository = new CustomerRepository();
            var customer = customerRepository.GetCustomer(testimonialGroup.Key);

            return new CustomerTestimonialAggregate {Customer = customer, Testimonials = testimonialGroup.ToList()};
        }

    }
}
