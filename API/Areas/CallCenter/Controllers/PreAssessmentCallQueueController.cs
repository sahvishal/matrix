using API.Areas.Application.Controllers;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Areas.CallCenter.Controllers
{
    [AllowAnonymous]
    public class PreAssessmentCallQueueController : ApiController
    {
        


        //private readonly IPreAssessmentCallQueueService _preAssessmentCallQueueService;
        //private readonly ILogger _logger;
        //public PreAssessmentCallQueueController(IPreAssessmentCallQueueService preAssessmentCallQueueService, ILogManager logManager)
        //{
        //    _preAssessmentCallQueueService = preAssessmentCallQueueService;
        //    _logger = logManager.GetLogger<PreAssessmentCallQueueController>();
        //}
        public void Get()
        {

        }




        public string Post([FromBody] PreAssessmentCallQueueModel preAssessmentCallQueueModel)
        {
            //try
            //{
            //    _logger.Info("Entery in Pre-Assessment Call Queue API");

            //    _preAssessmentCallQueueService.GetDataFromAPI(preAssessmentCallQueueModel);

            //    _logger.Info("Exit from Pre-Assessment Call Queue API");

            //    return "Data Uploaded Successful";
            //}
            //catch (Exception ex)
            //{
            //    _logger.Error(string.Format("While Featch Data From API of Pre-Assessment CallQueue Message:{0} \\n Stack Trace:{01} ", ex.Message, ex.StackTrace));

            //    return ex.ToString();
            //}

            return string.Empty;
        }


    }


}
