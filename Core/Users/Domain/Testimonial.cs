using System;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Users.Domain
{
    public class Testimonial : DomainObjectBase
    {
        public long CustomerId { get; set; }
        public string TestimonialText { get; set; }
        public File TestimonialVideo { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public bool? IsAccepted { get; set; }
        public short? Rank { get; set; }
        public long? ReviewedBy { get; set; }
        public DateTime? ReviewedOn { get; set; }


        public Testimonial()
        { }

        public Testimonial(long testimonialId)
            : base(testimonialId)
        { }
    }
}
