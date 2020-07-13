using System;
using System.Web.UI;
using Falcon.App.Core.Application;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.DependencyResolution;

namespace Falcon.App.UI.App.UCCommon
{
    public partial class PreQualificationQuestion : UserControl
    {
        public string GuId
        {
            get
            {
                return string.IsNullOrEmpty(Request.QueryString["guid"]) ? "" : Request.QueryString["guid"];
            }
        }

        private RegistrationFlowModel RegistrationFlow
        {
            get
            {
                if (!string.IsNullOrEmpty(GuId))
                {
                    return Session[GuId] as RegistrationFlowModel;
                }
                return null;
            }
        }

        public short RegistrationMode { get; set; }


        protected EventType EventType { get; set; }

        protected long CustomerId
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.CustomerId : 0;
            }
        }

        protected long Age { get; set; }

        protected bool AllowPrequalifiedTestOnly { get; set; }

        protected bool RecommendPackage { get; set; }
        protected bool AskPreQualifierQuestion { get; set; }
        protected long CallId
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.CallId : 0;
            }
        }
        protected long EventId
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.EventId : 0;
            }
        }

        protected long PreQualificationResultId
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.PreQualificationResultId : 0;
            }
        }

        protected bool AgreedWithPrequalificationQuestion { get; set; }

        protected bool SkipPreQualificationQuestion { get; set; }
        protected string Dob { get; set; }
        protected long Gender { get; set; }

        protected ISettings Settings { get { return IoC.Resolve<ISettings>(); } }
        protected PreQualificationResult ObjPqr { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (EventId > 0)
            {
                var eventRepository = IoC.Resolve<IEventRepository>();
                var theEvent = eventRepository.GetById(EventId);

                if (theEvent != null)
                {
                    RecommendPackage = theEvent.RecommendPackage;
                    AskPreQualifierQuestion = theEvent.AskPreQualifierQuestion;
                }

                var preQualificationRepository = IoC.Resolve<IPreQualificationResultRepository>();

                var rs = preQualificationRepository.GetById(PreQualificationResultId);

                if (rs != null)
                {
                    SkipPreQualificationQuestion = rs.SkipPreQualificationQuestion;
                    AgreedWithPrequalificationQuestion = rs.AgreedWithPrequalificationQuestion;
                    ObjPqr = rs;
                }

                var prospectCustomerRepository = IoC.Resolve<IProspectCustomerRepository>();
                var prospectCustomer = prospectCustomerRepository.GetProspectCustomerByCustomerId(CustomerId);

                if (prospectCustomer != null)
                {
                    Gender = (long)prospectCustomer.Gender;
                    if (prospectCustomer.BirthDate.HasValue)
                        Dob = Convert.ToDateTime(prospectCustomer.BirthDate).ToString("MM/dd/yyyy");
                }
            }
        }
    }
}