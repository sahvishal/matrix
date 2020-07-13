using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Enum;
using System.Web.UI;
using Falcon.App.Core.Extensions;

namespace Falcon.App.UI.App.UCCommon
{
    public partial class UcEventAppointment : UserControl
    {
        public long? EventId
        {
            get
            {
                long eventId;
                long.TryParse(ViewState["EventId"].ToString(), out eventId);

                return eventId > 0 ? (long?)eventId : null;
            }
            set
            {
                ViewState["EventId"] = value;
            }
        }

        public long ScreeningTime
        {
            get
            {
                long screeningTime;
                long.TryParse(ViewState["ScreeningTime"].ToString(), out screeningTime);

                return screeningTime;
            }
            set
            {
                ViewState["ScreeningTime"] = value;
            }
        }

        public long PackageId
        {
            get
            {
                if (ViewState["PackageId"] == null)
                    return 0;

                long packageId;
                long.TryParse(ViewState["PackageId"].ToString(), out packageId);

                return packageId;
            }
            set
            {
                ViewState["PackageId"] = value;
            }
        }


        public string TestIds
        {
            get
            {
                return ViewState["TestIds"] != null ? Convert.ToString(ViewState["TestIds"]) : string.Empty;

            }
            set
            {
                ViewState["TestIds"] = value;
            }
        }


        public ViewType CurrentViewType { get; set; }

        public bool return_f = true;

        public UcEventAppointment()
        {
            EventId = null;
        }

        public void SetAppointmentIds(IEnumerable<long> appointmentIds)
        {
            if (appointmentIds.IsNullOrEmpty())
            {
                hfSlotIds.Value = "";
                return;
            }

            hfSlotIds.Value = string.Join(",", appointmentIds);
        }

        public IEnumerable<long> GetAppointmentIds()
        {
            if (string.IsNullOrEmpty(hfSlotIds.Value)) return null;

            var slotIdString = hfSlotIds.Value.Split(new[] { ',' });
            if (!slotIdString.Any()) return new long[0];

            long slotId;
            return slotIdString.Where(s => long.TryParse(s.Trim(), out slotId)).Select(s => Convert.ToInt64(s.Trim())).ToArray();
        }

    }

}