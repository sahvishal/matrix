using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Services;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Core.Domain;

namespace Falcon.App.UI.Controllers
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]

    public class FranchiseeUserController : WebService
    {
        private readonly ISalesRepresentativeRepository _salesRepresentativeRepository;

        public FranchiseeUserController()
            : this(new SalesRepresentativeRepository())
        { }

        public FranchiseeUserController(ISalesRepresentativeRepository salesRepresentativeRepository)
        {
            _salesRepresentativeRepository = salesRepresentativeRepository;
        }

        [WebMethod (EnableSession = true)]
        public List<SalesRepresentative> GetSalesRepresentativesForFranchisee(long franchiseeId)
        {
            List<SalesRepresentative> salesRepresentatives = _salesRepresentativeRepository.
                            GetSalesRepresentativesForFranchisee(franchiseeId).OrderBy(sr => sr.Name.FullName).ToList();
            return salesRepresentatives;
        }

        [WebMethod (EnableSession = true)]
        public List<SalesRepresentative> GetAllSalesRepresentatives()
        {
            List<SalesRepresentative> salesRepresentatives = _salesRepresentativeRepository.
                            GetAllSalesRepresentatives().OrderBy(sr => sr.Name.FullName).ToList();
            return salesRepresentatives;
        }
    }
}

