using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Geo.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class EventEndofDayListModel
    {
        public long EventId { get; set; }
        public string HostName { get; set; }
        public AddressViewModel Address { get; set; }
        public DateTime? SignOffDate { get; set; }
        public string SignOffBy { get; set; }
        public bool IsSignOff { get; set; }
        public bool IsHospitalPartnerAttached { get; set; }

        public bool IsHospitalFacilityAttached { get; set; }
        public bool IsComplete
        {
            get
            {
                if (Customers != null && Customers.Any())
                {
                    return Customers.Count(c => !c.IsComplete) < 1;
                }
                return false;
            }
        }

        public bool IsKynComplete
        {
            get
            {
                if (Customers != null && Customers.Any())
                {
                    return Customers.Count(c => !c.IsKynComplete) < 1;
                }
                return false;
            }
        }

        public IEnumerable<EventEndofDayViewModel> Customers { get; set; }
        public bool IsKynIntegrationEnabled { get; set; }
        public bool IsMspFormEnabled { get; set; }

        public bool ShowBloodPressureColumn
        {
            get
            {
                if (Customers != null && Customers.Any())
                {
                    return Customers.Any(x => x.BloodPressure == EndofDayStatus.Complete || x.BloodPressure == EndofDayStatus.Missing);
                }

                return false;
            }
        }

        public bool ShowHemoglobinColumn
        {
            get
            {
                if (Customers != null && Customers.Any())
                {
                    return Customers.Any(x => x.HemoglobinStatus == EndofDayStatus.Complete || x.HemoglobinStatus == EndofDayStatus.Missing);
                }

                return false;
            }
        }

        public bool ShowPhq9Column
        {
            get
            {
                if (Customers != null && Customers.Any())
                {
                    return Customers.Any(x => x.Phq9Status == EndofDayStatus.Complete || x.Phq9Status == EndofDayStatus.Missing);
                }

                return false;
            }
        }
        public bool ShowQualityMeasures
        {
            get
            {
                if (Customers != null && Customers.Any())
                {
                    return Customers.Any(x => x.QualityMeasuresStatus == EndofDayStatus.Complete || x.QualityMeasuresStatus == EndofDayStatus.Missing);
                }

                return false;
            }
        }

        public bool ShowFocAttestationColumn
        {
            get
            {
                if (Customers != null && Customers.Any())
                {
                    return Customers.Any(x => x.FocAttestation == EndofDayStatus.Complete || x.FocAttestation == EndofDayStatus.Missing);
                }

                return false;
            }
        }

        public bool ShowIfobtColumn
        {
            get
            {
                if (Customers != null && Customers.Any())
                {
                    return Customers.Any(x => x.Ifobt == EndofDayStatus.Complete || x.Ifobt == EndofDayStatus.Missing);
                }

                return false;
            }
        }

        public bool ShowMyBioCheckAssessment
        {
            get
            {
                if (Customers != null && Customers.Any())
                {
                    return Customers.Any(x => x.MybioStatus == EndofDayStatus.Complete || x.MybioStatus == EndofDayStatus.Missing);
                }

                return false;
            }
        }

        public bool IsHkynComplete
        {
            get
            {
                if (Customers != null && Customers.Any())
                {
                    return Customers.Count(c => !c.IsHKynComplete) < 1;
                }
                return false;
            }
        }

        public bool IsMyBioCheckAssessement
        {
            get
            {
                if (Customers != null && Customers.Any())
                {
                    return Customers.Count(c => !c.IsMyBioStatusComplete) < 1;
                }
                return false;
            }
        }

        public DateTime EventDate { get; set; }
        public bool IsShowGiftCertificateOnEod { get; set; }
        public bool IsHealthPlanEvent { get; set; }
    }
}