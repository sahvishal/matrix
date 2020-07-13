namespace Falcon.App.Core.Medical.ViewModels
{
    public class FindingEditModel
    {
        /// <summary>
        /// Transactional Id
        /// </summary>
        public long ResultFindingId { get; set; }

        /// <summary>
        /// Id corresponds to the Master Table
        /// </summary>
        public long FindingId { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public bool IsSelected { get; set; }

        public decimal? MaxValue { get; set; }
        public decimal? MinValue { get; set; }
    }


}