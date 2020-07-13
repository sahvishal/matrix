using Falcon.DataAccess.Other;

namespace Falcon.DataAccess.Deprecated
{
    public class AppointmentSlotValidator
    {
        public bool IsDuplicateAppointmentSlot(string appointmentId, out string errorMessage)
        {
            return IsDuplicateAppointmentSlot(appointmentId, null, null, out errorMessage);
        }

        public bool IsDuplicateAppointmentSlot(string appointmentId, string userName, string id, out string errorMessage)
        {
            var otherDAL = new OtherDAL();
            long existingAppointmentSlotId = otherDAL.CheckDuplicateAppointment(appointmentId);
            if (existingAppointmentSlotId > 0)
            {
                if (id != null)
                {
                    errorMessage = string.Format("This appointment slot has already been selected. Please " +
                        "<a href=\"/Public/Customer/RegisterCustomer.aspx?User={0}&ID={1}\">click here</a> " +
                        "to go back and choose another appointment slot.", userName, id);
                }
                else
                {
                    errorMessage = "This appointment slot has already been selected. Please go back and choose another appointment slot.";
                }
                return true;
            }
            errorMessage = string.Empty;
            return false;
        }
    }
}