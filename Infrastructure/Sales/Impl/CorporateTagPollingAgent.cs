using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Interfaces;
using System;

namespace Falcon.App.Infrastructure.Sales.Impl
{
    [DefaultImplementation]
    public class CorporateTagPollingAgent : ICorporateTagPollingAgent
    {
        private readonly ICorporateTagRepository _corporateTagRepository;
        private readonly ILogger _logger;

        public CorporateTagPollingAgent(ICorporateTagRepository corporateTagRepository,ILogManager logManager)
        {
            _logger = logManager.GetLogger("CorporateTagPollingAgent"); 
            _corporateTagRepository = corporateTagRepository;
        }
        public void PollForExpiredCorporateTagData()
        {
            try
            {
                _logger.Info("Disabling Custom Tag Started ...");
                _corporateTagRepository.DisableCustomTagAfterExpiryDate();
                _logger.Info("Disabling Custom Tag Completed.");
            }
            catch (Exception ex)
            {
                _logger.Info("CorporateTag Disable Process. Message: " + ex.Message + ".\n\t" + ex.StackTrace);
            }
            
        }
    }
}
