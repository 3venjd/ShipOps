using ShipOps.Common.Models;
using System.Threading.Tasks;

namespace ShipOps.Common.Services
{
    public interface IApiService
    {
        Task<Response> GetCompanyAsync(string company_name, string urlBase, string servicePrefix, string Controller);
    }
}
