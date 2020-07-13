using System.Collections.Generic;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Marketing
{
    public interface ITestimonialRepository
    {
        Testimonial SaveTestimonial(Testimonial testimonial);
        Testimonial GetTestimonial(long testimonialId);
        List<Testimonial> GetTestimonials(bool? isAccepted, int pageNumber, int pageSize);
        int CountTestimonials(bool? isAccepted);
        int CountAcceptedTestimonials(bool? isAccepted, string gender);
        List<Testimonial> GetAcceptedTestimonials(bool? isAccepted, string gender, int pageNumber, int pageSize);
    }
}
