using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Extension;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallCenter.Enum;
using Falcon.App.Core.Enum;

namespace Falcon.App.Infrastructure.CallCenter.Impl
{
    [DefaultImplementation]
    public class CallUploadHelper : ICallUploadHelper
    {
        public const string CustomerId = "Customer ID";
        public const string OutreachType = "Outreach Type";
        public const string OutreachDate = "Outreach Date";
        public const string OutreachTime = "Outreach Time";
        public const string Outcome = "Outcome";
        public const string Disposition = "Disposition";
        public const string EventId = "Event ID";
        private const string IsInvalidAddress = "Is Invalid Address";

        public const string Email = "Email";
        public const string UserName = "UserName";
        public const string Notes = "Notes";
        public const string Reason = "Refusal Reason";

        public const string CampaignName = "Campaign Name";
        public const string DirectMailType = "Direct Mail Type";

        public const string OutboundOutReachType = "outbound";
        public const string DirectMailOutReachType = "directmail";


        public static string GetRowValue(DataRow row, string fieldName)
        {
            if (row == null || row[fieldName] == null || row[fieldName] == DBNull.Value) return string.Empty;
            return row[fieldName].ToString().Trim();
        }

        private DateTime? ConvertToDateTime(string dateString, string timeString)
        {
            if (string.IsNullOrEmpty(dateString)) return null;

            if (!string.IsNullOrEmpty(timeString))
            {
                dateString = dateString + " " + timeString;
            }

            DateTime date;

            if (DateTime.TryParse(dateString, out date))
                return date;

            return null;
        }

        private long ConvertToLong(string customerIdString)
        {
            long customerId;
            long.TryParse(customerIdString, out customerId);

            return customerId;

        }

        public CallUploadLog GetUploadLog(DataRow row, long callUploadId)
        {
            var callUploadLog = new CallUploadLog
            {
                CustomerId = ConvertToLong(GetRowValue(row, CustomerId)),
                CustomerIdForCsv = GetRowValue(row, CustomerId),
                EventIdForCsv = GetRowValue(row, EventId),
                OutreachType = GetRowValue(row, OutreachType),
                OutreachDate = GetRowValue(row, OutreachDate),
                OutreachTime = GetRowValue(row, OutreachTime),
                IsInvalidAddress= GetRowValue(row,IsInvalidAddress),
                Outcome = GetRowValue(row, Outcome),
                Disposition = GetRowValue(row, Disposition),
                Reason = GetRowValue(row, Reason),
                EventId = ConvertToLong(GetRowValue(row, EventId)),

                CampaignName = GetRowValue(row, CampaignName),
                DirectMailType = GetRowValue(row, DirectMailType),

                Email = GetRowValue(row, Email),
                UserName = GetRowValue(row, UserName),
                Notes = GetRowValue(row, Notes),

                IsSuccessfull = true,
                CallUploadId = callUploadId
            };


            if (callUploadLog.CustomerId <= 0 || string.IsNullOrEmpty(callUploadLog.OutreachType) || string.IsNullOrEmpty(callUploadLog.OutreachDate) ||
                (string.IsNullOrEmpty(callUploadLog.Email) && string.IsNullOrEmpty(callUploadLog.UserName)))
            {
                callUploadLog.IsSuccessfull = false;

            }

            if (!callUploadLog.IsSuccessfull)
            {
                callUploadLog.ErrorMessage = GetErrorMessageForRequiredField(callUploadLog);
            }

            callUploadLog = CheckIsOutReachTypeIsValid(callUploadLog);

            if (callUploadLog.IsSuccessfull)
            {
                callUploadLog = CheckIsOutReachDateTimeIsValid(callUploadLog);
            }

            if (callUploadLog.IsDirectMail)
            {
                callUploadLog = CheckIfCampaignNameProvided(callUploadLog);
               // callUploadLog = CheckIfDirectMailTypeProvided(callUploadLog);
            }
            else
            {
                callUploadLog = CheckIsCallLogHasValidOutcome(callUploadLog);

                callUploadLog = CheckIsCallLogHasValidDisposition(callUploadLog);
                callUploadLog = CheckIsCallLogHasValidReason(callUploadLog);

                if (callUploadLog.IsSuccessfull)
                {
                    callUploadLog = CheckIsDispositionRequired(callUploadLog);
                }

                //if (callUploadLog.IsSuccessfull)
                //{
                //    callUploadLog = EventIdValidation(callUploadLog);
                //}
            }

            return callUploadLog;
        }

        private CallUploadLog CheckIfCampaignNameProvided(CallUploadLog callUploadLog)
        {
            var error = string.Empty;
            if (!string.IsNullOrEmpty(callUploadLog.ErrorMessage))
                error = callUploadLog.ErrorMessage;

            if (string.IsNullOrEmpty(callUploadLog.CampaignName))
            {
                callUploadLog.IsSuccessfull = false;
                callUploadLog.ErrorMessage = error + " Campaign name is mandatory field.";
            }

            return callUploadLog;
        }

        //private CallUploadLog CheckIfDirectMailTypeProvided(CallUploadLog callUploadLog)
        //{
        //    var error = string.Empty;
        //    if (string.IsNullOrEmpty(callUploadLog.ErrorMessage))
        //        error = callUploadLog.ErrorMessage;

        //    if (string.IsNullOrEmpty(callUploadLog.DirectMailType))
        //    {
        //        callUploadLog.IsSuccessfull = false;
        //        callUploadLog.ErrorMessage = error + " Direct Mail Type is mandatory field.";
        //    }

        //    return callUploadLog;
        //}

        private CallUploadLog CheckIsOutReachTypeIsValid(CallUploadLog callUploadLog)
        {
            if (string.IsNullOrEmpty(callUploadLog.OutreachType) || callUploadLog.OutreachType.ToLower() == OutboundOutReachType
                || callUploadLog.OutreachType.ToLower() == DirectMailOutReachType)
            {
                if (callUploadLog.OutreachType.ToLower() == DirectMailOutReachType)
                    callUploadLog.IsDirectMail = true;

                return callUploadLog;
            }

            var error = string.Empty;
            if (!string.IsNullOrEmpty(callUploadLog.ErrorMessage))
                error = callUploadLog.ErrorMessage;

            callUploadLog.IsSuccessfull = false;
            callUploadLog.ErrorMessage = error + " Please provide a valid entry for Outreach Type.";


            return callUploadLog;
        }

        private CallUploadLog CheckIsOutReachDateTimeIsValid(CallUploadLog callUploadLog)
        {
            var outReachDateTime = ConvertToDateTime(callUploadLog.OutreachDate, callUploadLog.OutreachTime);

            if (outReachDateTime == null || (!callUploadLog.IsDirectMail && outReachDateTime.Value > DateTime.Now))
            {
                var error = string.Empty;
                if (!string.IsNullOrEmpty(callUploadLog.ErrorMessage))
                    error = callUploadLog.ErrorMessage;

                DateTime date;

                if (!DateTime.TryParse(callUploadLog.OutreachDate, out date))
                {
                    callUploadLog.IsSuccessfull = false;
                    callUploadLog.ErrorMessage = error + " Please provide a valid entry for Outreach Date. Correct Date format is MM/DD/YYYY";
                }
                else if (!string.IsNullOrEmpty(callUploadLog.OutreachTime) && outReachDateTime == null)
                {
                    callUploadLog.IsSuccessfull = false;
                    callUploadLog.ErrorMessage = error + " Please provide a valid entry for Outreach Date and Time. Correct Date format is MM/DD/YYYY";
                }
                else if (outReachDateTime != null && (!callUploadLog.IsDirectMail && outReachDateTime.Value > DateTime.Now))
                {
                    callUploadLog.IsSuccessfull = false;
                    callUploadLog.ErrorMessage = error + " Future date can not be provided.";
                }

            }
            else
            {
                callUploadLog.OutreachDateTime = outReachDateTime;
            }

            return callUploadLog;
        }

        private CallUploadLog CheckIsDispositionRequired(CallUploadLog callUploadLog)
        {
            var callStatusEnumPair = (CallStatus.Attended).GetNameValuePairs();

            var callStatusPair = callStatusEnumPair.FirstOrDefault(csep => csep.SecondValue.ToLower() == callUploadLog.Outcome.ToLower());
            var callStatus = callStatusPair != null ? callStatusPair.FirstValue : (long?)null;

            var dispositionEnumPair = (ProspectCustomerTag.HomeVisitRequested).GetNameValuePairs();

            var dispositionOrderedPair = dispositionEnumPair.FirstOrDefault(dep => dep.SecondValue.ToLower() == callUploadLog.Disposition.ToLower());

            var disposition = dispositionOrderedPair != null ? dispositionOrderedPair.FirstValue : (long?)null;

            if ((callStatus.HasValue && callStatus.Value == (long)CallStatus.Attended) && (string.IsNullOrEmpty(callUploadLog.Disposition) || (disposition == null)))
            {
                callUploadLog.IsSuccessfull = false;
                callUploadLog.ErrorMessage = callUploadLog.ErrorMessage + " Please provide valid disposition.";
            }

            return callUploadLog;
        }

        //private CallUploadLog EventIdValidation(CallUploadLog callUploadLog)
        //{
        //    var outcome = callUploadLog.OutcomeEnum;
        //    var disposition = callUploadLog.DispositionEnum;

        //    if (outcome.HasValue && outcome.Value == (long)CallStatus.Attended && disposition.HasValue && disposition.Value == (long)ProspectCustomerTag.BookedAppointment && callUploadLog.EventId <= 0)
        //    {
        //        callUploadLog.IsSuccessfull = false;
        //        callUploadLog.ErrorMessage = callUploadLog.ErrorMessage + " Event Id is required field in case of booked appointment.";
        //    }

        //    return callUploadLog;
        //}

        private CallUploadLog CheckIsCallLogHasValidOutcome(CallUploadLog callUploadLog)
        {
            if (string.IsNullOrEmpty(callUploadLog.Outcome))
            {
                callUploadLog.IsSuccessfull = false;
                var errorMessage = callUploadLog.ErrorMessage;
                callUploadLog.ErrorMessage = errorMessage + " Outcome is mandatory Field.";
                return callUploadLog;
            }

            var orderedPairs = (CallStatus.Attended).GetNameValuePairs();

            if (orderedPairs == null || !orderedPairs.Any())
            {
                callUploadLog.IsSuccessfull = false;
                var errorMessage = callUploadLog.ErrorMessage;
                callUploadLog.ErrorMessage = errorMessage + " Provide a valid Outcome " + callUploadLog.Outcome + " is not valid.";
                return callUploadLog;
            }

            var enumPair = orderedPairs.FirstOrDefault(x => x.SecondValue.ToLower() == callUploadLog.Outcome.ToLower());
            if (enumPair == null)
            {
                callUploadLog.IsSuccessfull = false;
                var errorMessage = callUploadLog.ErrorMessage;
                callUploadLog.ErrorMessage = errorMessage + " Provide a valid Outcome " + callUploadLog.Outcome + " is not valid.";
                return callUploadLog;
            }

            var callStatus = (CallStatus)enumPair.FirstValue;

            var isDefined = Enum.IsDefined(typeof(CallStatus), callStatus);

            if (!isDefined)
            {
                callUploadLog.IsSuccessfull = false;
                var errorMessage = callUploadLog.ErrorMessage;
                callUploadLog.ErrorMessage = errorMessage + " Provide a valid Outcome " + callUploadLog.Outcome + " is not valid.";

                return callUploadLog;
            }

            callUploadLog.OutcomeEnum = (long)callStatus;

            return callUploadLog;
        }

        private CallUploadLog CheckIsCallLogHasValidDisposition(CallUploadLog callUploadLog)
        {
            if (string.IsNullOrEmpty(callUploadLog.Disposition)) return callUploadLog;

            var orderedPairs = (ProspectCustomerTag.HomeVisitRequested).GetNameValuePairs();

            if (orderedPairs == null || !orderedPairs.Any())
            {
                callUploadLog.IsSuccessfull = false;
                var errorMessage = callUploadLog.ErrorMessage;
                callUploadLog.ErrorMessage = errorMessage + " Provide a valid Disposition " + callUploadLog.Disposition + " is not valid.";
                return callUploadLog;
            }

            var enumPair = orderedPairs.FirstOrDefault(x => x.SecondValue.ToLower() == callUploadLog.Disposition.ToLower());

            if (enumPair == null)
            {
                callUploadLog.IsSuccessfull = false;
                var errorMessage = callUploadLog.ErrorMessage;
                callUploadLog.ErrorMessage = errorMessage + " Provide a valid Disposition " + callUploadLog.Disposition + " is not valid.";
                return callUploadLog;
            }

            var disposition = (ProspectCustomerTag)enumPair.FirstValue;

            var isDefined = Enum.IsDefined(typeof(ProspectCustomerTag), disposition);

            if (!isDefined)
            {
                callUploadLog.IsSuccessfull = false;
                var errorMessage = callUploadLog.ErrorMessage;
                callUploadLog.ErrorMessage = errorMessage + " Provide a valid Disposition " + callUploadLog.Disposition + " is not valid.";
                return callUploadLog;
            }

            callUploadLog.DispositionEnum = (long)disposition;

            return callUploadLog;
        }

        private CallUploadLog CheckIsCallLogHasValidReason(CallUploadLog callUploadLog)
        {
            if (string.IsNullOrEmpty(callUploadLog.Reason)) return callUploadLog;

            var orderedPairs = (NotInterestedReason.CustomerRefused).GetNameValuePairs();

            if (orderedPairs == null || !orderedPairs.Any())
            {
                callUploadLog.IsSuccessfull = false;
                var errorMessage = callUploadLog.ErrorMessage;
                callUploadLog.ErrorMessage = errorMessage + " Provide a valid Reason. " + callUploadLog.Reason + " is not valid.";
                return callUploadLog;
            }

            var enumPair = orderedPairs.FirstOrDefault(x => x.SecondValue.ToLower() == callUploadLog.Reason.ToLower());

            if (enumPair == null)
            {
                callUploadLog.IsSuccessfull = false;
                var errorMessage = callUploadLog.ErrorMessage;
                callUploadLog.ErrorMessage = errorMessage + " Provide a valid Refusal Reason. " + callUploadLog.Reason + " is not valid.";
                return callUploadLog;
            }

            var reason = (NotInterestedReason)enumPair.FirstValue;

            var isDefined = Enum.IsDefined(typeof(NotInterestedReason), reason);

            if (!isDefined)
            {
                callUploadLog.IsSuccessfull = false;
                var errorMessage = callUploadLog.ErrorMessage;
                callUploadLog.ErrorMessage = errorMessage + " Provide a valid Refusal Reason. " + callUploadLog.Reason + " is not valid.";
                return callUploadLog;
            }

            callUploadLog.ReasonEnum = (long)reason;

            return callUploadLog;
        }

        private string GetErrorMessageForRequiredField(CallUploadLog callUploadLog)
        {
            var sb = new StringBuilder();

            if (callUploadLog.CustomerId <= 0)
            {
                sb.Append("Customer Id does not contain valid value.");
            }

            if (string.IsNullOrEmpty(callUploadLog.OutreachType))
            {
                sb.Append("Outreach Type is mandatory Field.");
            }

            if (string.IsNullOrEmpty(callUploadLog.OutreachDate))
            {
                sb.Append("OutreachDate is mandatory Field.");
            }

            if (string.IsNullOrEmpty(callUploadLog.Email) && string.IsNullOrEmpty(callUploadLog.UserName))
            {
                sb.Append("Either provide Email or User Name.");
            }

            return sb.ToString();
        }

        public string CheckForColumns(DataRow row)
        {
            var sb = new List<string>();

            try
            {
                GetRowValue(row, CustomerId);
            }
            catch (Exception)
            {
                sb.Add(CustomerId);
            }

            try
            {
                GetRowValue(row, OutreachType);
            }
            catch (Exception)
            {
                sb.Add(OutreachType);
            }

            try
            {
                GetRowValue(row, OutreachDate);
            }
            catch (Exception)
            {
                sb.Add(OutreachDate);
            }

            try
            {
                GetRowValue(row, OutreachTime);
            }
            catch (Exception)
            {
                sb.Add(OutreachTime);
            }

            try
            {
                GetRowValue(row, Outcome);
            }
            catch (Exception)
            {
                sb.Add(Outcome);
            }

            try
            {
                GetRowValue(row, Disposition);
            }
            catch (Exception)
            {
                sb.Add(Disposition);
            }

            try
            {
                GetRowValue(row, EventId);
            }
            catch (Exception)
            {
                sb.Add(EventId);
            }

            try
            {
                GetRowValue(row, IsInvalidAddress);
            }
            catch (Exception)
            {
                sb.Add(IsInvalidAddress);
            }

            try
            {
                GetRowValue(row, Reason);
            }
            catch (Exception)
            {
                sb.Add(Reason);
            }

            try
            {
                GetRowValue(row, CampaignName);
            }
            catch (Exception)
            {
                sb.Add(CampaignName);
            }

            try
            {
                GetRowValue(row, DirectMailType);
            }
            catch (Exception)
            {
                sb.Add(DirectMailType);
            }

            try
            {
                GetRowValue(row, Email);
            }
            catch (Exception)
            {
                sb.Add(Email);
            }

            try
            {
                GetRowValue(row, UserName);
            }
            catch (Exception)
            {
                sb.Add(UserName);
            }

            try
            {
                GetRowValue(row, Notes);
            }
            catch (Exception)
            {
                sb.Add(Notes);
            }

            var missingHeaders = string.Empty;

            if (sb.Any())
                missingHeaders = string.Join(",", sb);

            return missingHeaders;

        }

        public long GetOrganizationRoleId(CallUploadLog callUploadLog, IEnumerable<OrderedPair<long, string>> organizationRoleUserEmail, IEnumerable<OrderedPair<long, string>> organizationRoleUserUserName)
        {
            long orgRoleId = 0;

            if (!string.IsNullOrEmpty(callUploadLog.Email))
            {
                var orgRole = organizationRoleUserEmail.FirstOrDefault(x => x.SecondValue.ToLower() == callUploadLog.Email.ToLower());
                orgRoleId = orgRole != null ? orgRole.FirstValue : 0;
            }

            if (orgRoleId <= 0)
            {
                var orgRole = organizationRoleUserUserName.FirstOrDefault(x => x.SecondValue.ToLower() == callUploadLog.UserName.ToLower());
                orgRoleId = orgRole != null ? orgRole.FirstValue : 0;
            }

            return orgRoleId;
        }
    }
}
