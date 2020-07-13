﻿using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Sales.ViewModels
{
    public class ContentListModel
    {
        public IEnumerable<ContentViewModel> Collection { get; set; }

        [IgnoreAudit]
        public PagingModel PagingModel { get; set; }

        public ContentListModelFilter Filter { get; set; }

    }
}