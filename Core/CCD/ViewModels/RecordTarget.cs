using System;
using System.Xml.Serialization;

namespace Falcon.App.Core.CCD.ViewModels
{
    public class RecordTarget
    {
        [XmlElement]
        public PatientRole PatientRole { get; set; }

        public RecordTarget()
        {
            PatientRole = new PatientRole();
        }
        public RecordTarget(PatientRole patientRole)
        {
            PatientRole = patientRole;
        }
    }

    



}