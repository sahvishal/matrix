using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.Services;
using Falcon.App.Core.Application;
using Falcon.App.Core.Marketing;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.Core.ValueTypes;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.App.Infrastructure.Service;
using Falcon.App.Core.Extensions;

namespace Falcon.App.UI.Controllers
{
    /// <summary>
    /// Summary description for CustomerTestimoialController
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class CustomerTestimoialController : WebService
    {
        private readonly ITestimonialRepository _testimonialRepository;

        public CustomerTestimoialController(ITestimonialRepository testimonialRepository)
        {
            _testimonialRepository = testimonialRepository;
        }

        public CustomerTestimoialController()
            : this(new TestimonialRepository())
        { }

        [WebMethod(EnableSession = true)]
        public List<CustomerTestimonialAggregate> GetAllSubmittedTestimonial(int pageNumber, int pageSize)
        {
            var customerService = IoC.Resolve<ICustomerService>();
            return customerService.GetCustomerTestimonials(null, pageNumber, pageSize);
        }

        [WebMethod(EnableSession = true)]
        public int GetAllSubmittedTestimonialCount()
        {
            return _testimonialRepository.CountTestimonials(null);
        }

        [WebMethod(EnableSession = true)]
        public List<CustomerTestimonialAggregate> GetAllAcceptedTestimonial(string gender, int pageNumber, int pageSize)
        {
            var customerService = IoC.Resolve<ICustomerService>();
            var testimonials = customerService.GetAcceptedTestimonials(true, gender, pageNumber, pageSize);
            if (testimonials.IsNullOrEmpty())
                return null;
            return testimonials.ToList();
        }

        [WebMethod(EnableSession = true)]
        public int GetAllAcceptedTestimonialCount(string gender)
        {
            return _testimonialRepository.CountAcceptedTestimonials(true, gender);
        }

        [WebMethod(EnableSession = true)]
        public List<CustomerTestimonialAggregate> GetAllDeclinedTestimonial(int pageNumber, int pageSize)
        {
            var customerService = IoC.Resolve<ICustomerService>();
            return customerService.GetCustomerTestimonials(false, pageNumber, pageSize);
        }

        [WebMethod(EnableSession = true)]
        public int GetAllDeclinedTestimonialCount()
        {
            return _testimonialRepository.CountTestimonials(false);
        }

        [WebMethod(EnableSession = true)]
        public bool ChangeTestimonialStatus(bool isAccepted, long testimonialId)
        {

            var testimonial = _testimonialRepository.GetTestimonial(testimonialId);
            testimonial.IsAccepted = isAccepted;
            testimonial.ReviewedOn = DateTime.Now;
            testimonial.ReviewedBy = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId;

            _testimonialRepository.SaveTestimonial(testimonial);
            return true;
        }

        [WebMethod(EnableSession = true)]
        public bool UpdateTestimonialRank(short rank, long testimonialId)
        {
            var testimonial = _testimonialRepository.GetTestimonial(testimonialId);
            testimonial.Rank = rank;
            testimonial.ReviewedOn = DateTime.Now;
            testimonial.ReviewedBy = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId;

            _testimonialRepository.SaveTestimonial(testimonial);
            return true;
        }

        [WebMethod(EnableSession = true)]
        public string ViewTestimonialText(long testimonialId)
        {
            var testimonial = _testimonialRepository.GetTestimonial(testimonialId);
            return testimonial.TestimonialText.Replace("'", "\'");
        }

        [WebMethod(EnableSession = true)]
        public string ViewTestimonialVideo(long testimonialId)
        {
            var testimonial = _testimonialRepository.GetTestimonial(testimonialId);
            return testimonial.TestimonialVideo.Path.Replace("'", "\'");
        }

        [WebMethod(EnableSession = true)]
        public Customer GetCustomer(long customerId)
        {
            var customerRepository = IoC.Resolve<ICustomerRepository>();
            var customer = customerRepository.GetCustomer(customerId);
            return customer;
        }

        [WebMethod(EnableSession = true)]
        public bool SaveCustomer(long customerId, Gender gender, long heightInFeet, long heightInInch, double weight)
        {
            var customerRepository = IoC.Resolve<ICustomerRepository>();
            var customer = customerRepository.GetCustomer(customerId);

            customer.Gender = gender;
            customer.Height = new Height(heightInFeet, heightInInch);
            customer.Weight = new Weight(weight);

            var customerService = IoC.Resolve<ICustomerService>();
            var currentSession = IoC.Resolve<ISessionContext>().UserSession;
            return customerService.SaveCustomer(customer, currentSession.CurrentOrganizationRole.OrganizationRoleUserId);
        }
    }
}
