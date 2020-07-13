using System.ComponentModel;

namespace Falcon.App.Core.CallCenter.Enum
{
    public enum CallType
    {
        [Description("Register New Customer")]
        Register_New_Customer = 1,
        [Description("Existing Customer")]
        Existing_Customer = 2,
        Report_Status = 3,
        Request_Print_Version = 4,
        Password_Request = 5,
        Others = 6,
        Edit_Customer = 7,
        Reset_Password = 8,
        Change_Package = 9,
        Apply_Coupon = 10,
        Reschedule = 11,
        Register_NewEvent = 12,
        Login_Issue = 13,
        Other_Issues = 14,
        Gift_Certificate,
        Print_Order_Confirmation,
        Review_Customer,
        Reminder_Mail,
        Cancel_Appointment
    }
}