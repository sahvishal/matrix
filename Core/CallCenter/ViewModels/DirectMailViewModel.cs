using System;

namespace Falcon.App.Core.CallCenter.ViewModels
{
    public class DirectMailViewModel
    {
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }

        public string DirectMailType { get; set; }
        public string Notes { get; set; }
    }
}