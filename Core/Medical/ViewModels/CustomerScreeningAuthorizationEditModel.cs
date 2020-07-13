using System;
using System.Collections.Generic;
using System.ComponentModel;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class CustomerScreeningAuthorizationEditModel
    {
        [DisplayName("Customer Id")]
        public long CustomerId { get; set; }
        
        public string Name { get; set; }

        public DateTime? Dob { get; set; }

        public string Gender { get; set; }

        public Height Height { get; set; }

        public Weight Weight { get; set; }

        public string Ethnicity { get; set; }

        public IEnumerable<Test> EventTests { get; set; }

        public bool IsAuthorized { get; set; }

        public long EventCustomerId { get; set; }
    }
}
