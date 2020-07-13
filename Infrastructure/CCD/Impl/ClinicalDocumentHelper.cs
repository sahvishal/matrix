using System.Collections.Generic;
using Falcon.App.Core;
using Falcon.App.Core.CCD.ValueType;
using Falcon.App.Core.CCD.ViewModels;

namespace Falcon.App.Infrastructure.CCD.impl
{
    public class ClinicalDocumentHelper
    {
        public static List<OrderedPair<ClinicalCodeType, ClinicalCode>> ClinicalCodes { get { return GetClinicalCode(); } }
        public static List<OrderedPair<LoincCode, ClinicalCode>> LoincCodes { get { return GetLoincCode(); } }
        public static List<OrderedPair<ClinicalRootType, ClinicalRoot>> ClinicalRoots { get { return GetClinicalRoot(); } }

        private static List<OrderedPair<ClinicalCodeType, ClinicalCode>> GetClinicalCode()
        {
            var clinicialCodes = new List<OrderedPair<ClinicalCodeType, ClinicalCode>>
            {
                new OrderedPair<ClinicalCodeType, ClinicalCode>(ClinicalCodeType.Gender,new ClinicalCode("M", "Male", CodeSystemName.AdministrativeGender, ClinicalDocumentRoots.AdministrativeGenderCode)),
                new OrderedPair<ClinicalCodeType, ClinicalCode>(ClinicalCodeType.Gender,new ClinicalCode("F", "Female", CodeSystemName.AdministrativeGender, ClinicalDocumentRoots.AdministrativeGenderCode)),
                new OrderedPair<ClinicalCodeType, ClinicalCode>(ClinicalCodeType.Gender,new ClinicalCode("U", "Unknown", CodeSystemName.AdministrativeGender, ClinicalDocumentRoots.AdministrativeGenderCode))
            };

            return clinicialCodes;
        }

        private static List<OrderedPair<LoincCode, ClinicalCode>> GetLoincCode()
        {
            var clinicialCodes = new List<OrderedPair<LoincCode, ClinicalCode>>
            {
                new OrderedPair<LoincCode, ClinicalCode>(LoincCode.VitalSigns,
                    new ClinicalCode
                    {
                        Code = "8716-3",DisplayName = "Vital Signs",CodeSystem = CodeSystemName.Loinc,CodeSystemName = ClinicalDocumentRoots.VitalSign
                    }),
                new OrderedPair<LoincCode, ClinicalCode>(LoincCode.VitalSignsCode,
                    new ClinicalCode
                    {
                        Code = "74728-7",DisplayName = "Vital Signs",CodeSystem = CodeSystemName.Loinc,CodeSystemName = ClinicalDocumentRoots.VitalSign
                    }),
                new OrderedPair<LoincCode, ClinicalCode>(LoincCode.SystolicBloodPressures,
                    new ClinicalCode
                    {
                        Code = "8480-6",DisplayName = "SYSTOLIC BLOOD PRESSURE",CodeSystem = CodeSystemName.Loinc,CodeSystemName = ClinicalDocumentRoots.VitalSign
                    }),
                new OrderedPair<LoincCode, ClinicalCode>(LoincCode.DiastolicBloodPressures,
                    new ClinicalCode
                    {
                        Code = "8462-4",DisplayName = "DIASTOLIC BLOOD PRESSURE",CodeSystem = CodeSystemName.Loinc,CodeSystemName = ClinicalDocumentRoots.VitalSign
                    }),
                new OrderedPair<LoincCode, ClinicalCode>(LoincCode.HeartRate,
                    new ClinicalCode
                    {
                        Code = "8867-4",DisplayName = "HEART RATE",CodeSystem = CodeSystemName.Loinc,CodeSystemName = ClinicalDocumentRoots.VitalSign
                    }),
                new OrderedPair<LoincCode, ClinicalCode>(LoincCode.Height,
                    new ClinicalCode
                    {
                        Code = "8302-2",DisplayName = "HEIGHT",CodeSystem = CodeSystemName.Loinc,CodeSystemName = ClinicalDocumentRoots.VitalSign
                    }),
                new OrderedPair<LoincCode, ClinicalCode>(LoincCode.Weight,
                    new ClinicalCode
                    {
                        Code = "3141-9",DisplayName = "WEIGHT",CodeSystem = CodeSystemName.Loinc,CodeSystemName = ClinicalDocumentRoots.VitalSign
                    }),
                new OrderedPair<LoincCode, ClinicalCode>(LoincCode.Bmi,
                    new ClinicalCode
                    {
                        Code = "39156-5",DisplayName = "BODY MASS INDEX",CodeSystem = CodeSystemName.Loinc,CodeSystemName = ClinicalDocumentRoots.VitalSign
                    }),
                //For Result Section
                new OrderedPair<LoincCode, ClinicalCode>(LoincCode.ResultSection,
                    new ClinicalCode
                    {
                        Code = "30954-2",DisplayName = "Result",CodeSystem = CodeSystemName.Loinc,CodeSystemName = ClinicalDocumentRoots.Result
                    }),
                new OrderedPair<LoincCode, ClinicalCode>(LoincCode.AwvAaa,
                    new ClinicalCode
                    {
                        Code = "10191-5",DisplayName = "ABDOMEN",CodeSystem = CodeSystemName.Loinc,CodeSystemName = ClinicalDocumentRoots.Abdominal
                    }),

                new OrderedPair<LoincCode, ClinicalCode>(LoincCode.LipidProfile,
                    new ClinicalCode
                    {
                        Code = "0",DisplayName = "LIPID PROFILE",CodeSystem = CodeSystemName.Loinc,CodeSystemName = ClinicalDocumentRoots.LipidProfile
                    }),
                new OrderedPair<LoincCode, ClinicalCode>(LoincCode.LipidTriglycerides,
                    new ClinicalCode
                    {
                        Code = "2571-8",DisplayName = "TRIGLYCERIDES",CodeSystem = CodeSystemName.Loinc,CodeSystemName = ClinicalDocumentRoots.LipidProfile
                    }),
                new OrderedPair<LoincCode, ClinicalCode>(LoincCode.LipidHdlcholesterol,
                    new ClinicalCode
                    {
                        Code = "2085-9",DisplayName = "HDL CHOLESTEROL",CodeSystem = CodeSystemName.Loinc,CodeSystemName = ClinicalDocumentRoots.LipidProfile
                    }),
                new OrderedPair<LoincCode, ClinicalCode>(LoincCode.LipidLdlcholesterol,
                    new ClinicalCode
                    {
                        Code = "18262-6",DisplayName = "LDL CHOLESTEROL",CodeSystem = CodeSystemName.Loinc,CodeSystemName = ClinicalDocumentRoots.LipidProfile
                    }),
                new OrderedPair<LoincCode, ClinicalCode>(LoincCode.LipidGlucose,
                    new ClinicalCode
                    {
                        Code = "2345-7",DisplayName = "Glucose",CodeSystem = CodeSystemName.Loinc,CodeSystemName = ClinicalDocumentRoots.LipidProfile
                    }),

                new OrderedPair<LoincCode, ClinicalCode>(LoincCode.AaaLargestSagittalMeasurement,
                    new ClinicalCode
                    {
                        Code = "0",DisplayName = "Largest Sagittal Measurement",CodeSystem = CodeSystemName.Loinc,CodeSystemName = ClinicalDocumentRoots.AaaLargestSagittalMeasurement
                    }),
                new OrderedPair<LoincCode, ClinicalCode>(LoincCode.AaaLargestSagittalLocation,
                    new ClinicalCode
                    {
                        Code = "0",
                        DisplayName = "Largest Sagittal Location",
                        CodeSystem = CodeSystemName.Loinc,
                        CodeSystemName = ClinicalDocumentRoots.AaaLargestSagittalLocation
                    }),
                new OrderedPair<LoincCode, ClinicalCode>(LoincCode.AaaLargestTransverseMeasurement1,
                    new ClinicalCode
                    {
                        Code = "0",
                        DisplayName = "Largest Sagittal Location",
                        CodeSystem = CodeSystemName.Loinc,
                        CodeSystemName = ClinicalDocumentRoots.AaaLargestTransverseMeasurement1
                    }),
                new OrderedPair<LoincCode, ClinicalCode>(LoincCode.AaaLargestTransverseMeasurement2,
                    new ClinicalCode
                    {
                        Code = "0",
                        DisplayName = "Largest Sagittal Location",
                        CodeSystem = CodeSystemName.Loinc,
                        CodeSystemName = ClinicalDocumentRoots.AaaLargestTransverseMeasurement2
                    }),
                new OrderedPair<LoincCode, ClinicalCode>(LoincCode.AaaLargestMeasurementTransverseLocation,
                    new ClinicalCode
                    {
                        Code = "0",
                        DisplayName = "Largest Sagittal Location",
                        CodeSystem = CodeSystemName.Loinc,
                        CodeSystemName = ClinicalDocumentRoots.AaaLargestMeasurementTransverseLocation
                    }),
                new OrderedPair<LoincCode, ClinicalCode>(LoincCode.AaaPeakSystolicVelocityMeasurement,
                    new ClinicalCode
                    {
                        Code = "0",
                        DisplayName = "Largest Sagittal Location",
                        CodeSystem = CodeSystemName.Loinc,
                        CodeSystemName = ClinicalDocumentRoots.AaaPeakSystolicVelocityMeasurement
                    }),
                new OrderedPair<LoincCode, ClinicalCode>(LoincCode.AaaPeakSystolicVelocityLocation,
                    new ClinicalCode
                    {
                        Code = "0",
                        DisplayName = "Largest Sagittal Location",
                        CodeSystem = CodeSystemName.Loinc,
                        CodeSystemName = ClinicalDocumentRoots.AaaPeakSystolicVelocityLocation
                    }),
                new OrderedPair<LoincCode, ClinicalCode>(LoincCode.AaaResidualLumenMeasurement1,
                    new ClinicalCode
                    {
                        Code = "0",
                        DisplayName = "Largest Sagittal Location",
                        CodeSystem = CodeSystemName.Loinc,
                        CodeSystemName = ClinicalDocumentRoots.AaaResidualLumenMeasurement1
                    }),
                new OrderedPair<LoincCode, ClinicalCode>(LoincCode.AaaResidualLumenMeasurement2,
                    new ClinicalCode
                    {
                        Code = "0",
                        DisplayName = "Largest Sagittal Location",
                        CodeSystem = CodeSystemName.Loinc,
                        CodeSystemName = ClinicalDocumentRoots.AaaResidualLumenMeasurement2
                    }),
                new OrderedPair<LoincCode, ClinicalCode>(LoincCode.AaaAorticDissection,
                    new ClinicalCode
                    {
                        Code = "0",
                        DisplayName = "Largest Sagittal Location",
                        CodeSystem = CodeSystemName.Loinc,
                        CodeSystemName = ClinicalDocumentRoots.AaaAorticDissection
                    }),
                new OrderedPair<LoincCode, ClinicalCode>(LoincCode.AaaPlaque,
                    new ClinicalCode
                    {
                        Code = "0",
                        DisplayName = "Largest Sagittal Location",
                        CodeSystem = CodeSystemName.Loinc,
                        CodeSystemName = ClinicalDocumentRoots.AaaPlaque
                    }),
                new OrderedPair<LoincCode, ClinicalCode>(LoincCode.AaaThrombus,
                    new ClinicalCode
                    {
                        Code = "0",
                        DisplayName = "Largest Sagittal Location",
                        CodeSystem = CodeSystemName.Loinc,
                        CodeSystemName = ClinicalDocumentRoots.AaaThrombus
                    }),

                    new OrderedPair<LoincCode, ClinicalCode>(LoincCode.Urinalysis,new ClinicalCode
                    {
                        Code = "0",
                        DisplayName = "URINALYSIS",
                        CodeSystem = CodeSystemName.Loinc,
                        CodeSystemName = ClinicalDocumentRoots.Urinalysis
                    }),
                     new OrderedPair<LoincCode, ClinicalCode>(LoincCode.AwvGlucose,new ClinicalCode
                    {
                        Code = "2345-7",
                        DisplayName = "GLUCOSE",
                        CodeSystem = CodeSystemName.Loinc,
                        CodeSystemName = ClinicalDocumentRoots.AwvGlucose
                    }),
            };

            return clinicialCodes;
        }

        private static List<OrderedPair<ClinicalRootType, ClinicalRoot>> GetClinicalRoot()
        {
            var clinicialCodes = new List<OrderedPair<ClinicalRootType, ClinicalRoot>>
            {
                new OrderedPair<ClinicalRootType, ClinicalRoot>(ClinicalRootType.VitalSigns,new ClinicalRoot("2014-06-09","2.16.840.1.113883.10.20.22.4.26" )),
                new OrderedPair<ClinicalRootType, ClinicalRoot>(ClinicalRootType.BloodPressures,new ClinicalRoot("2014-06-09","2.16.840.1.113883.10.20.22.4.27" )),
                new OrderedPair<ClinicalRootType, ClinicalRoot>(ClinicalRootType.LipidProfile,new ClinicalRoot("1003678195","1.3.6.1.4.1.22812.4.58601.0.4.5" )),
                new OrderedPair<ClinicalRootType, ClinicalRoot>(ClinicalRootType.LipidGlucose,new ClinicalRoot("","2.16.840.1.113883.10.20.1.31" )),
                new OrderedPair<ClinicalRootType, ClinicalRoot>(ClinicalRootType.LipidHdlcholesterol,new ClinicalRoot("","2.16.840.1.113883.3.88.11.32.16" )),
                new OrderedPair<ClinicalRootType, ClinicalRoot>(ClinicalRootType.LipidLdlcholesterol,new ClinicalRoot("","2.16.840.1.113883.3.88.11.83.15.1" )),
                new OrderedPair<ClinicalRootType, ClinicalRoot>(ClinicalRootType.LipidTriglycerides,new ClinicalRoot("","1.3.6.1.4.1.19376.1.5.3.1.4.13" )),

                new OrderedPair<ClinicalRootType, ClinicalRoot>(ClinicalRootType.AwvAaa,new ClinicalRoot("","1.3.6.1.4.1.19376.1.5.3.1.4.5" )),

                new OrderedPair<ClinicalRootType, ClinicalRoot>(ClinicalRootType.AaaLargestSagittalMeasurement,new ClinicalRoot("","" )),
                new OrderedPair<ClinicalRootType, ClinicalRoot>(ClinicalRootType.AaaLargestSagittalLocation,new ClinicalRoot("","" )),
                new OrderedPair<ClinicalRootType, ClinicalRoot>(ClinicalRootType.AaaLargestTransverseMeasurement1,new ClinicalRoot("","" )),
                new OrderedPair<ClinicalRootType, ClinicalRoot>(ClinicalRootType.AaaLargestTransverseMeasurement2,new ClinicalRoot("","" )),
                new OrderedPair<ClinicalRootType, ClinicalRoot>(ClinicalRootType.AaaLargestMeasurementTransverseLocation,new ClinicalRoot("","" )),
                new OrderedPair<ClinicalRootType, ClinicalRoot>(ClinicalRootType.AaaPeakSystolicVelocityMeasurement,new ClinicalRoot("","" )),
                new OrderedPair<ClinicalRootType, ClinicalRoot>(ClinicalRootType.AaaPeakSystolicVelocityLocation,new ClinicalRoot("","" )),
                new OrderedPair<ClinicalRootType, ClinicalRoot>(ClinicalRootType.AaaResidualLumenMeasurement1,new ClinicalRoot("","" )),
                new OrderedPair<ClinicalRootType, ClinicalRoot>(ClinicalRootType.AaaResidualLumenMeasurement2,new ClinicalRoot("","" )),
                new OrderedPair<ClinicalRootType, ClinicalRoot>(ClinicalRootType.AaaAorticDissection,new ClinicalRoot("","" )),
                new OrderedPair<ClinicalRootType, ClinicalRoot>(ClinicalRootType.AaaPlaque,new ClinicalRoot("","" )),
                new OrderedPair<ClinicalRootType, ClinicalRoot>(ClinicalRootType.AaaThrombus,new ClinicalRoot("","" )),

                new OrderedPair<ClinicalRootType, ClinicalRoot>(ClinicalRootType.Urinalysis,new ClinicalRoot("10031013537","1.3.6.1.4.1.22812.4.58601.0.4.5" )),
                new OrderedPair<ClinicalRootType, ClinicalRoot>(ClinicalRootType.AwvGlucose,new ClinicalRoot("10194015233","1.3.6.1.4.1.22812.4.58601.0.4.5" )),
            };

            return clinicialCodes;
        }
    }
}