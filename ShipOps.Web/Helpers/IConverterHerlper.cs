using ShipOps.Common.Models;
using ShipOps.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShipOps.Web.Helpers
{
    public interface IConverterHerlper
    {
        CompanyResponse ToCompanyResponse(CompanyEntity companyEntity);

        NewsResponse ToNewResponse(NewEntity newEntity);

    }
}
