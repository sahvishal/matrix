using System.ComponentModel;

namespace Falcon.App.Core.Enum
{
    public enum ProspectCustomerTag
    {
        Unspecified,

        [Description("Online Registration")]
        OnlineSignup,

        [Description("CallCenter Registration")]
        CallCenterSignup,

        [Description("Wellness Seminar")]
        WellnessSeminar,

        [Description("Non-Serviced Zip code")]
        NotServicedZip,

        [Description("Gift Certificate Purchase")]
        GiftCertificatePurchase,

        [Description("Insurance concerns")]
        InsuranceConcerns,

        [Description("Pricing concerns")]
        PricingConcerns,

        [Description("No events in the area")]
        NoEventsInTheArea,

        [Description("Morning appointment preferred")]
        MorningAppointmentPreferred,

        [Description("Afternoon appointment preferred")]
        AfternoonAppointmentPreferred,

        Cancellation,

        [Description("No Show")]
        NoShow,

        [Description("All Events Full")]
        AllEventsFull,

        [Description("Doctor Concerns")]
        DoctorConcerns,

        [Description("Poor Location")]
        PoorLocation,

        Corporate,

        [Description("Survey Response")]
        SurveyResponse,

        [Description("Indecisive/Undecided")]
        IndecisiveUndecided,

        [Description("Tests already done or scheduled")]
        TestsAlreadyDoneOrScheduled,

        [Description("Events not in area or unable to attend")]
        EventsNotInAreaOrUnableToAttend,

        [Description("I'm Healthy/No screening needed")]
        NoScreeningNeeded,

        [Description("Language barrier/Mobility Issue")]
        LanguageBarrierMobilityIssue,

        [Description("Prefer doctor's office")]
        PreferDoctorOffice,

        [Description("Getting Home visit by Nurse")]
        GettingHomeVisitByNurse,

        [Description("Don't know HCP or Program")]
        DonotKnowHcpProgram,

        [Description("Add to waiting list")]
        AddToWaitingList,

        [Description("Requested home visit")]
        RequestedHomeVisit,

        /*************************/

        [Description("Booked Appointment")]
        BookedAppointment,

        [Description("Will Speak with Physician")]
        SpeakWithPhysician,

        [Description("Call Back Later")]
        CallBackLater,

        [Description("Recently Saw Doc or Future Doc Appt")]
        RecentlySawDoc,

        [Description("Not Interested")]
        NotInterested,

        [Description("No Events in Area")]
        NoEventsinArea,

        [Description("Date/Time Conflict")]
        DateTimeConflict,

        [Description("Home Visit Requested")]
        HomeVisitRequested,

        [Description("Mobility Issue: No Home Visit Requested")]
        MobilityIssue,

        [Description("Transportation Issue: No Home Visit Requested")]
        TransportationIssue,

        [Description("Do Not Call")]
        DoNotCall,

        [Description("Deceased/Dead")]
        Deceased,

        [Description("Moved/Relocated")]
        MovedRelocated,

        [Description("No Longer on Insurance Plan")]
        NoLongeronInsurancePlan,

        [Description("Language Barrier")]
        LanguageBarrier,

        [Description("In Long-Term Care / Nursing Home")]
        InLongTermCareNursingHome,

        [Description("Incorrect Phone Number")]
        IncorrectPhoneNumber,

        [Description("Transfer To Matrix Medical Network")]
        TransferToHealthFair,

        [Description("Other")]
        Other,

        [Description("Hang Up")]
        Hangup,

        [Description("Transfer Unsuccessful")]
        TransferUnsuccessful,

        [Description("Not Eligible")]
        NotEligible,

        [Description("Customer Service")]
        CustomerService,

        [Description("Left Message")]
        LeftMessage,

        [Description("Mobility Issues")]
        MobilityIssues_LeftMessageWithOther,

        [Description("Debilitating Disease")]
        DebilitatingDisease,

        [Description("Patient Confirmed")]
        PatientConfirmed,

        [Description("Cancel Appointment")]
        CancelAppointment,

        [Description("Reschedule Appointment")]
        RescheduleAppointment,

        [Description("Confirmed, HRA not complete")]
        ConfirmedHRANotComplete,

        [Description("Language Barrier")]
        ConfirmLanguageBarrier,

        [Description("Incorrect Phone Number")]
        IncorrectPhoneNumber_TalkedToOthers,

        [Description("No convenient in area")]
        NoConvenientInArea,

        [Description("No Events in list")]
        NoEventsInList,

        //Warm Transfer Disposition

        [Description("Declined Mobile and Transferred to Home")]
        DeclinedMobileAndTransferredToHome,

        [Description("Declined Mobile and Home Visit")]
        DeclinedMobileAndHomeVisit,

        [Description("Member states Ineligible - Mastectomy")]
        MemberStatesIneligibleMastectomy,

        [Description("Declined- Member not mammo available, no events in area")]
        DeclinedMemberNotMammoAvailableNoEventsInArea,

        [Description("Declined Mammo - Not interested in Mammogram")]
        DeclinedMammoNotinterestedInMammogram,

        ////  Add new  Dispositions For talked to Patient
        [Description("CHAT completed")]
        CHATCompleted,

        [Description("Requested CHAT Mailed")]
        RequestedCHATMailed,

        [Description("Member Doesn't have time for questions")]
        MemberDoesntHaveTimeForQuestions,

        [Description("Member Does not feel comfortable answering Questions")]
        MemberDoesNotFeelComfortableAnsweringQuestions,

        [Description("Follow up - Call Escalated")]
        FollowUpCallEscalated,

        [Description("Member Confirmed Change")]
        MemberConfirmedChange,

        [Description("Cancelled Appointment")]
        CancelledAppointment,
         


    }
}
