var PostAuditEvaluatoin = function () {
    var postAuditEvaluatoinModel = null;

    var get = function () {
        if (postAuditEvaluatoinModel == null) {
            postAuditEvaluatoinModel = {
                CustomerId: 0,
                EventId: 0,
                TestResultStrings: null,
                DoPostAudit: false,
                DoReque: false,
                OrganizationRoleUserId: 0,
                IsNewResultflow: false,
                IsPennedBack: false,
                IsRevertToCoding: false,
                IsRevertToNp: false,
                IsRevertToPreAudit: false,
                IsHealthPlanEvent: false,
                ShowHraQuestions: false,
                IsEawvTestPurchased : false,
                Message: ''
            };
        }
        var isNewResultflow = $("#IsNewResultFlowInputHidden").val();
        var isPennedBack = false;
        
        if ($("input[id*='MarkAsPennedBackCheckbox']").length) {
            isPennedBack = $("input[id*='MarkAsPennedBackCheckbox']").is(":checked");
        }

        postAuditEvaluatoinModel.IsNewResultflow = isNewResultflow;
        postAuditEvaluatoinModel.IsPennedBack = isPennedBack;
        postAuditEvaluatoinModel.OrganizationRoleUserId = 0;
        //postAuditEvaluatoinModel.OrganizationRoleUserId = '<%= IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId %>';

        return postAuditEvaluatoinModel;
    };
    var setCustomerEventId = function (customerId, eventid, testResult) {
        if (postAuditEvaluatoinModel == null) {
            postAuditEvaluatoinModel = get();
        }
        postAuditEvaluatoinModel.CustomerId = customerId;
        postAuditEvaluatoinModel.EventId = eventid;
        postAuditEvaluatoinModel.TestResultStrings = testResult;
    };

    var isPostAudit = function () {
        if (postAuditEvaluatoinModel == null) {
            postAuditEvaluatoinModel = get();
        }
        postAuditEvaluatoinModel.DoPostAudit = true;
        postAuditEvaluatoinModel.DoReque = false;
        postAuditEvaluatoinModel.IsRevertToCoding = false;
        postAuditEvaluatoinModel.IsRevertToNp = false;
        postAuditEvaluatoinModel.IsRevertToPreAudit = false;
        postAuditEvaluatoinModel.Message = "";
    };
    
    var setDoReque = function () {
        if (postAuditEvaluatoinModel == null) {
            postAuditEvaluatoinModel = get();
        }
        postAuditEvaluatoinModel.DoPostAudit = false;
        postAuditEvaluatoinModel.DoReque = true;
        postAuditEvaluatoinModel.IsRevertToCoding = false;
        postAuditEvaluatoinModel.IsRevertToNp = false;
        postAuditEvaluatoinModel.IsRevertToPreAudit = false;
        postAuditEvaluatoinModel.Message = "";
    };
    
    var setRevertToPreAudit = function () {
        if (postAuditEvaluatoinModel == null) {
            postAuditEvaluatoinModel = get();
        }
        postAuditEvaluatoinModel.DoPostAudit = false;
        postAuditEvaluatoinModel.DoReque = false;
        postAuditEvaluatoinModel.IsRevertToCoding = false;
        postAuditEvaluatoinModel.IsRevertToNp = false;
        postAuditEvaluatoinModel.IsRevertToPreAudit = true;
        postAuditEvaluatoinModel.Message = "";
    };
    
   

    var setRevertForCoding = function () {
        if (postAuditEvaluatoinModel == null) {
            postAuditEvaluatoinModel = get();
        }
        postAuditEvaluatoinModel.DoPostAudit = false;
        postAuditEvaluatoinModel.DoReque = false;
        postAuditEvaluatoinModel.IsRevertToCoding = true;
        postAuditEvaluatoinModel.IsRevertToNp = false;
        postAuditEvaluatoinModel.IsRevertToPreAudit = false;
        postAuditEvaluatoinModel.Message = "";
    };
    
    var setRevertToNpForReview = function () {
        
        if (postAuditEvaluatoinModel == null) {
            postAuditEvaluatoinModel = get();
        }
        
        postAuditEvaluatoinModel.DoPostAudit = false;
        postAuditEvaluatoinModel.DoReque = false;
        postAuditEvaluatoinModel.IsRevertToCoding = false;
        postAuditEvaluatoinModel.IsRevertToNp = true;
        postAuditEvaluatoinModel.IsRevertToPreAudit = false;
        postAuditEvaluatoinModel.Message = "";
    };
    
    var setEventHraStatus = function (isHealthPlanEvent, showHraQuestions, isEawvTestPurchased, isEawvTestNotPerformed) {
        if (postAuditEvaluatoinModel == null) {
            postAuditEvaluatoinModel = get();
        }
        postAuditEvaluatoinModel.IsHealthPlanEvent = isHealthPlanEvent;
        postAuditEvaluatoinModel.ShowHraQuestions = showHraQuestions;
        postAuditEvaluatoinModel.IsEawvTestPurchased = isEawvTestPurchased;
        postAuditEvaluatoinModel.IsEawvTestNotPerformed = isEawvTestNotPerformed;

    };
    var setRevertStatus = function (dopostAudit, isRevertToCoding, isRevertToNp, isRevertToEvaluation, isRevertToPreAudit, message) {
        if (postAuditEvaluatoinModel == null) {
            postAuditEvaluatoinModel = get();
        }
        postAuditEvaluatoinModel.DoPostAudit = dopostAudit;
        postAuditEvaluatoinModel.DoReque = isRevertToEvaluation;
        postAuditEvaluatoinModel.IsRevertToCoding = isRevertToCoding;
        postAuditEvaluatoinModel.IsRevertToNp = isRevertToNp;
        postAuditEvaluatoinModel.IsRevertToPreAudit = isRevertToPreAudit;
        postAuditEvaluatoinModel.Message = message;
    };
    
    return {
        get: get,
        SetCustomerEventId: setCustomerEventId,
        IsPostAudit: isPostAudit,
        SetDoReque: setDoReque,
        
        SetRevertToPreAudit: setRevertToPreAudit,
       
        SetRevertForCoding: setRevertForCoding,
        SetRevertToNpForReview: setRevertToNpForReview,
        SetRevertStatus: setRevertStatus,
        SetEventHraStatus:setEventHraStatus
    };
}();