namespace Falcon.App.Core.Medical.ViewModels
{
    public class FraminghamSourceViewData
    {
        public string Range { get; set; }
        public int? MinValue { get; set; }
        public int? MaxValue { get; set; }

        public int MaleScore { get; set; }
        public int FemaleScore { get; set; }
    }
}


