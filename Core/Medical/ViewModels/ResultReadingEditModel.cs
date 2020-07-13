using System.Collections.Generic;
using System.Linq;

namespace Falcon.App.Core.Medical.ViewModels
{
    public abstract class ResultReadingEditModel
    {
        /// <summary>
        /// Transactional Id
        /// </summary>
        public long ResultReadingId { get; set; }

        public int CurrentSourceReading { get; set; }
        /// <summary>
        /// Id corresponds to the Master Table
        /// </summary>
        public long ReadingId { get; set; }
        public string Label { get; set; }
        public int DefaultSourceReading { get; set; }
    }

    public class ResultReadingEditModel<T> : ResultReadingEditModel
    {
        public T Value { get; set; }
    }

    public class CompoundResultReadingEditModel<T> : ResultReadingEditModel<T>
    {
        public IEnumerable<FindingEditModel> Findings { get; set; }
        
        public FindingEditModel SelectedFinding
        {
            get
            {
                if (Findings != null && Findings.Count() > 0)
                {
                    var selected = Findings.Where(f => f.IsSelected).SingleOrDefault();
                    if (selected != null) return selected;
                }
                return null;
            }
        }
    }

}