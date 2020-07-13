using System.Collections.Generic;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Marketing.Interfaces
{
    public interface IPrintOrderFactory
    {

        List<PrintOrderItem> CreatePrintOrderItemShipping(string filePath, OrganizationRoleUser statusUpdatedBy);

    }
}