using System;
using System.Collections.Generic;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Users.ViewModels
{
    public class CustomerTestimonialAggregate
    {
        public Customer Customer{get;set;}
        public List<Testimonial> Testimonials { get; set; }


        public int Age { get { return Customer.DateOfBirth.HasValue ? DateTime.Today.Year - Customer.DateOfBirth.Value.Year : 0; } }
        public string Race
        {
            get { return Customer.Race.ToString(); }
        }
        public string Gender
        {
            get
            {
                return Customer.Gender.ToString();
            }
        }
    }
}
