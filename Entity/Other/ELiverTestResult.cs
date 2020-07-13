namespace Falcon.Entity.Other
{
    public class ELiverTestResult
    {
        private long _liverTestId = 0;
        private long _eventCustomerId = 0;
        private bool _isEvaluated = false;
        private bool _unableToScreen = false;
        private int _resultEvaluationStatus = 0;
        private string _resultUpdatedBy = string.Empty;
        private string _technicianNotes = string.Empty;


        
        public bool? IsPartial { get; set; }

        
        public long LiverTestId
        {
            get { return _liverTestId; }
            set { _liverTestId = value; }
        }

        
        public long EventCustomerId
        {
            get { return _eventCustomerId; }
            set { _eventCustomerId = value; }
        }

        
        public bool TestEvaluated
        {
            get { return _isEvaluated; }
            set { _isEvaluated = value; }
        }

        public int EvaluationStatus
        {
            get { return _resultEvaluationStatus; }
            set { _resultEvaluationStatus = value; }
        }
        public string TestUpdatedBy
        {
            get { return _resultUpdatedBy; }
            set { _resultUpdatedBy = value; }
        }

        
        public bool UnableToScreen
        {
            get { return _unableToScreen; }
            set { _unableToScreen = value; }
        }

        
        public string TechnicianRemarks
        {
            get { return _technicianNotes; }
            set { _technicianNotes = value; }
        }
    }
}
