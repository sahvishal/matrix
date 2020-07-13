using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Application.ViewModels;
using FluentValidation;
using Falcon.App.Core.Application.Attributes;
using System.ComponentModel;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class EventCustomersFindingEditModel : ViewModelBase
    {
        public long EventId { get; set; }
        public DateTime EventDate { get; set; }
        public string Host { get; set; }
        public string Pod { get; set; }
        public IEnumerable<Test> EventTests { get; set; }
        public IEnumerable<CustomerTestFindingEditModel> Customers { get; set; }
    }

    public enum Finding
    {
        Unknown = 0,
        [Description("3 - 5 cm")]
        _3_5CM =11,
        Normal =1,
        Mild =2,
        Abnormal =3,
        Critical=4,
        High = 5,
        //MildlyAbnormal = 6, 

        Low=7, 
        [Description("Moderate")]
        ModeratelyAbnormal=8,
        Severe = 9,
        [Description("Very High")]
        VeryHigh=10,

        ReTest = 12,
        [Description("Not Tested")]
        NotTested = 13,
        Borderline = 14 
        
    }

    public class CustomerTestFindingEditModel
    {
        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Phone { get; set; }

        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }
        public IEnumerable<TestFindingEditModel> Tests { get; set; }
    }

    public class TestFindingEditModel
    {
        public TestType TestType { get; set; }
        public Finding Finding { get; set; }
    }



    [DefaultImplementation(Interface = typeof(IValidator<EventCustomersFindingEditModel>))]
    public class EventCustomersFindingEditModelValidator : AbstractValidator<EventCustomersFindingEditModel>
    {
        public EventCustomersFindingEditModelValidator()
        {
            
        }
    }

    [DefaultImplementation(Interface = typeof(IValidator<CustomerTestFindingEditModel>))]
    public class CustomerTestFindingEditModelValidator : AbstractValidator<CustomerTestFindingEditModel>
    {
        public CustomerTestFindingEditModelValidator()
        {
            
        }
    }

    [DefaultImplementation(Interface = typeof(IValidator<TestFindingEditModel>))]
    public class TestFindingEditModelValidator : AbstractValidator<TestFindingEditModel>
    {
        public TestFindingEditModelValidator()
        {
            
        }
    }
}