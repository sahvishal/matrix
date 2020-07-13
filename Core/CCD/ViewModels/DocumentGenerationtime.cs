using System;
using System.Xml.Serialization;

namespace Falcon.App.Core.CCD.ViewModels
{
    public class DocumentGenerationtime
    {
        [XmlIgnore]
        public DateTime? GenerationTime { get; set; }

        [XmlAttribute("value")]
        public string EffectiveTime
        {
            get
            {
                return GenerationTime.HasValue ? GenerationTime.Value.ToString("yyyyMMddhhmmss") : string.Empty;
            }
            set
            {
                DateTime generatedOn;

                if (DateTime.TryParse(value, out generatedOn))
                {
                    GenerationTime = generatedOn;
                }
            }
        }


        public DocumentGenerationtime()
        {

        }
        public DocumentGenerationtime(DateTime time)
        {
            GenerationTime = time;
        }
    }

    public class DocumentGenerationDate
    {
        [XmlIgnore]
        public DateTime? GenerationTime { get; set; }

        [XmlAttribute("value")]
        public string EffectiveTime
        {
            get
            {
                return GenerationTime.HasValue ? GenerationTime.Value.ToString("yyyyMMdd") : string.Empty;
            }
            set
            {
                DateTime generatedOn;

                if (DateTime.TryParse(value, out generatedOn))
                {
                    GenerationTime = generatedOn;
                }
            }
        }

        public DocumentGenerationDate()
        {

        }

        public DocumentGenerationDate(DateTime time)
        {
            GenerationTime = time;
        }
    }
}