using System;
using System.Web.Script.Services;
using System.Web.Services;
using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.Enum;
using Falcon.App.Core.Marketing.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Infrastructure.Marketing.Repositories;
using Falcon.App.Infrastructure.Repositories.Users;
using System.Web;


/// <summary>
    /// Summary description for ProspectCustomerController
    /// </summary>
    [WebService(Namespace = "http://ProspectCustomerController.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ScriptService]
    public class ProspectCustomerController : WebService, IProspectCustomerController
    {
        private readonly IUniqueItemRepository<ProspectCustomer> _uniqueItemRepository;
    private readonly IProspectCustomerRepository _prospectCustomerRepository;

        public ProspectCustomerController()
        : this(new ProspectCustomerRepository(), new ProspectCustomerRepository())
        { }

        public ProspectCustomerController(IUniqueItemRepository<ProspectCustomer> uniqueItemRepository, IProspectCustomerRepository prospectCustomerRepository)
        {
            _uniqueItemRepository = uniqueItemRepository;
            _prospectCustomerRepository = prospectCustomerRepository;
        }

        [WebMethod (EnableSession = true)]
        public ProspectCustomer SaveProspectCustomer(ProspectCustomer prospectCustomer)
        {
            long prospectCustomerId = prospectCustomer.Id;
            if (prospectCustomer.Id > 0 && prospectCustomer.CreatedOn == DateTime.MinValue)
                prospectCustomer.CreatedOn = DateTime.Now;
            prospectCustomer= _uniqueItemRepository.Save(prospectCustomer);
           
            // If this is a new prospect customer, track this conversion.)
            if (prospectCustomerId == 0)
            {
                long clickId = 0;

                HttpCookie clickIdCookie = Context.Request.Cookies["advertiserClick"];
                if (clickIdCookie != null)
                {
                    long.TryParse(clickIdCookie.Value, out clickId);
                }

                // if there's a click ID, save which click caused the conversion to a prospective customer, and their prospect ID
                if (clickId > 0)
                {
                    IClickConversionRepository clickConversionRepository = new ClickConversionRepository();
                    clickConversionRepository.SaveProspectConversion(clickId, prospectCustomer.Id);
                }
            }
            return prospectCustomer;
        }

        [WebMethod (EnableSession = true)]
        public ProspectCustomer GetById(long prospectCustomerId)
        {
            return _uniqueItemRepository.GetById(prospectCustomerId);
        }

        [WebMethod (EnableSession = true)]
        public ProspectCustomer GetByCustomerId(long customerId)
        {
            return _prospectCustomerRepository.GetProspectCustomerByCustomerId(customerId);
        }

    }

