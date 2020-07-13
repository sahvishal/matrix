using Falcon.App.Core.CallQueues.Enum;
using System;

namespace Falcon.App.Core.CallQueues.ViewModels
{
    public class AccountCallQueueSettingEditModel
    {
        public long AccountId { get; set; }
        public long CallQueueId { get; set; }
        public string CallQueueName { get; set; }
        public long SuppressionTypeId { get; set; }
        public string SuppressionDescription { get; set; }
        public int? NoOfDays { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsActive { get; set; }

        public string ToolTipInfo
        {
            get
            {
                var tooltipInfo = string.Empty;
                switch (SuppressionTypeId)
                {
                    case (long)CallQueueSuppressionType.LeftVoiceMail:
                        tooltipInfo = "&#9656; Left Voice Mail<br />"+
                                      "&#9656; Date/Time Conflict<br />"+
                                      "&#9656; No Answer <br />"+
                                      "&#9656; Appointment Canceled<br />" +
                                      "&#9656; Left Message with Others <br />"+
                                      "&#9656; Language Barrier <br/>" + 
                                      "&#9656; No Show<br />";
                        break;
                    case (long)CallQueueSuppressionType.Others:
                        tooltipInfo = "&#9656; Moved/Relocated<br />&#9656; Will Speak with Physician<br />" +
                                      "&#9656; No Events In Area <br />" +
                                      "&#9656; Invalid Number<br />" +
                                      "&#9656; Declined- Member not mammo available, no events in area<br />";
                        break;
                    case (long)CallQueueSuppressionType.RefuseCustomer:
                        tooltipInfo = "&#9656; Recently Saw Doc or Future Doc Appt<br />&#9656; Not Interested<br />&#9656; Transportation Issue<br />&#9656;  Declined Mobile and Home Visit" +
                            "<br />&#9656; Declined Mammo - Not interested in Mammogram<br />";
                        break;
                    case (long)CallQueueSuppressionType.MaxAttempts:
                        tooltipInfo = "Max number of calls that can be made to a patient.";
                        break;

                }
                return tooltipInfo;
            }
        }
    }
}
