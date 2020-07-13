namespace API
{
    public class ResponseBaseModel
    {
        public bool IsSuccess { get; set; }
        public long Id { get; set; }

        public int StatusCode { get; set; }
        public string Message { get; set; }

        public ResponseBaseModel(long? id)
        {
            if (id.HasValue && id.Value > 0)
            {
                Id = id.Value;
            }
        }
        public ResponseBaseModel()
        {
        }
        public ResponseBaseModel(long id)
        {
            Id = id;
        }
    }
}