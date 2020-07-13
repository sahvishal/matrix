(function () {
    'use strict';

    angular.module(ApplicationConfiguration.applicationModuleName).constant(CoreConfiguration.constants, {
        ProgressBarStatus: {
            NotStarted: 1,
            Started: 2,
            QuarterComplete: 3,
            HalfComplete: 4,
            ThreeFourthComplete: 5,
            Complete: 6
        },
        RequestStatus: {
            InValid: 1,
            Completed: 2,
            InvalidOperation: 3,
            Valid: 4
        },
        SortOrderBy: {
            EventDate: 0,
            Distance: 1
        },
        EventType: {
            Retail: 68,
            Corporate: 69
        },
        RegistrationMode: {
            Both: 0,
            Public: 1,
            Private: 2
        },
        ProspectCustomer:
        {
            Source: {
                Online: 106
            },
            Tag: {
                OnlineSignup: 1,
                NotServicedZip: 4
            },
            HealthPlanTag: {
                SpeakWithPhysician: 'SpeakWithPhysician',
                CallBackLater: 'CallBackLater',
                RecentlySawDoc: 'RecentlySawDoc',
                NotInterested: 'NotInterested',
                NoEventsinArea: 'NoEventsinArea',
                DateTimeConflict: 'DateTimeConflict',
                HomeVisitRequested: 'HomeVisitRequested',
                MobilityIssue: 'MobilityIssue',
                TransportationIssue: 'TransportationIssue',
                DoNotCall: 'DoNotCall',
                Deceased: 'Deceased',
                MovedRelocated: 'MovedRelocated',
                NoLongeronInsurancePlan: 'NoLongeronInsurancePlan',
                LanguageBarrier: 'LanguageBarrier',
                InLongTermCareNursingHome: 'InLongTermCareNursingHome',
                IncorrectPhoneNumber: 'IncorrectPhoneNumber',
                LeftMessage: 'LeftMessage',
                MobilityIssues_LeftMessageWithOther: 'MobilityIssues_LeftMessageWithOther',
                DebilitatingDisease: 'DebilitatingDisease',
                PatientConfirmed: "PatientConfirmed",
                CancelAppointment: "CancelAppointment",
                RescheduleAppointment: "RescheduleAppointment",
                IncorrectPhoneNumber_TalkedToOthers: "IncorrectPhoneNumber_TalkedToOthers",
                NoConvenientInArea: "NoConvenientInArea",
                NoEventsInList: "NoEventsInList"
            }


        },
        DisplayControlType: {
            Radio: 124,
            TextBox: 126,
            CheckBox: 125,
            TextArea: 127,
            DateTypeTextBox: 183
        },
        TestTypes: {
            Echocardiogram: 4,
            KYN: 23,
            Thyroid: 5,
            Psa: 20,
            Crp: 17,
            Testosterone: 28,
            MenBloodPanel: 64,
            WomenBloodPanel: 65
        },
        BloodWorkTestIds: {
            Thyroid: 5,
            Psa: 20,
            Crp: 17,
            Testosterone: 28,
            VitaminD: 66,
            MenBloodPanel: 64,
            WomenBloodPanel: 65
        },
        RaceTypes: {
            None: 0,
            Caucasian: 1,
            Asian: 2,
            AfricanAmerican: 3,
            Hispanic: 4,
            NativeAmerican: 5,
            Latino: 6,
            DeclinesToReport: 7,
            Other: 8
        },
        PaymentType: {
            Check: { Id: 1, Name: 'Check' },
            CreditCard: { Id: 2, Name: 'Credit Card' },
            Cash: { Id: 4, Name: 'Cash' },
            DemandDraft: { Id: 5, Name: 'Demand Draft' },
            MoneyOrder: { Id: 6, Name: 'Money Order' },
            eCheck: { Id: 7, Name: 'eCheck' },
            GiftCertificate: { Id: 8, Name: 'Gift Certificate' },
            Insurance: { Id: 9, Name: 'Insurance' }
        },
        Gender: {
            Unspecified: 184,
            Male: 185,
            Female: 186
        },
        CallQueueCategory:
        {
            EasiestToConvertProspect: 'EasiestToConvertProspect',
            Annual: 'Annual',
            CallBack: 'CallBack',
            FillEvents: "FillEvents",
            Upsell: 'Upsell',
            Confirmation: 'Confirmation'
        },
        CallStatus:
        {
            NoAnswer: 32,
            VoiceMessage: 33,
            Attended: 34,
            Initiated: 35,
            LeftMessageWithOther: 242,
            IncorrectPhoneNumber: 243,
            NoEventsInArea: 280,
            CallSkipped: 325,
            TalkedtoOtherPerson: 408,
            InvalidNumber: 409,
        },
        HealthPlanCallQueueCategory:
        {
            CallRound: 'CallRound',
            FillEventsHealthPlan: 'FillEventsHealthPlan',
            NoShows: 'NoShows',
            ZipRadius: "ZipRadius",
            UncontactedCustomers: "UncontactedCustomers",
            MailRound: "MailRound",
            LanguageBarrier: "LanguageBarrier",
            AppointmentConfirmation: "AppointmentConfirmation"
        },
        ProgressBarSteps: {
            None: 0,
            Location: 1,
            PreQualifiedTest: 2,
            Packages: 3,
            Tests: 4,
            Appointment: 5,
            PersonalInformation: 6,
            Payment: 7
        },
        Products: {
            Ultrasound: 2
        },
        CallQueueSortOrderBy: {
            EventDate: 0,
            Distance: 1,
            EventName: 2,
            AvailableAppointmentSlots: 3
        },
        SortOrderType: {
            Ascending: 0,
            Descending: 1
        },
        CustomerRegistrationNotesType: {
            AppointmentNote: 81,
            CustomerNote: 82,
            CancellationNote: 128,
            PostScreeningFollowUpNotes: 143,
            LeftWithoutScreeningNotes: 337
        },
        NotesTabContactHistory: {
            CallHistoryTab: 0,
            NotesCustomerNotesTab: 1,
            DirectMailTab: 2
        },
        UploadActivityType: {
            OnlyMail: 331,
            OnlyCall: 332,
            BothMailAndCall: 333
        },
        AttendedConfirmationDispositions: [
            //{ Name: "Cancel Appointment", Alias: "CancelAppointment", HelpText: "Patient had requested the appointment be cancelled." },
            //{ Name: "Patient Not Sure, Call Back Later", Alias: "CallBackLater", HelpText: "Patient has requested a call back later." },
            //{ Name: "CHAT completed", Alias: "CHATCompleted", HelpText: "CHAT completed." },
            //{ Name: "Follow up - Call Escalated", Alias: "FollowUpCallEscalated", HelpText: "Follow up - Call Escalated." },
            //{ Name: "Member Confirmed Change", Alias: "MemberConfirmedChange", HelpText: "Member Confirmed Change." },
            //{ Name: "Member Does not feel comfortable answering Questions", Alias: "MemberDoesNotFeelComfortableAnsweringQuestions", HelpText: "Member Does not feel comfortable answering Questions." },
            //{ Name: "Member Doesn't have time for questions", Alias: "MemberDoesntHaveTimeForQuestions", HelpText: "Member Doesn't have time for questions." },
            //{ Name: "Not Interested", Alias: "NotInterested", HelpText: "Not Interested." },
            //{ Name: "Requested CHAT Mailed", Alias: "RequestedCHATMailed", HelpText: "Requested CHAT Mailed." },
            //{ Name: "Reschedule Appointment", Alias: "RescheduleAppointment", HelpText: "Patient has requested appointment be rescheduled." }

             { Name: "Cancel Appointment", Alias: "CancelAppointment", HelpText: "Patient had requested the appointment be cancelled." },
            { Name: "Confirmed, HRA not complete", Alias: "ConfirmedHRANotComplete", HelpText: "Patient has confirmed but HRA not completed." },
            { Name: "Language Barrier", Alias: "ConfirmLanguageBarrier", HelpText: "Patient in not comfortable with English." },
            { Name: "Patient Confirmed", Alias: "PatientConfirmed", HelpText: "Patient has agreed to the visit and has the questionnaires completed." },
            { Name: "Patient Not Sure, Call Back Later", Alias: "CallBackLater", HelpText: "Patient has requested a call back later." },
            { Name: "Reschedule Appointment", Alias: "RescheduleAppointment", HelpText: "Patient has requested appointment be rescheduled." }
        ],
        ActivityTypes: [
            { Text: "Only Mail", Value: 331 },
            { Text: "Only Call", Value: 332 },
            { Text: "Both Mail And Call", Value: 333 }
        ],

        PatientConsent: {
            Unknown: 405,
            Granted: 406,
            Rejected: 407
        },

        ControlType: {
            Radio: 124,
            TextBox: 126
        },
    });
}());