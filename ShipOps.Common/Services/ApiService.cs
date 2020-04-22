using Newtonsoft.Json;
using ShipOps.Common.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ShipOps.Common.Services
{
    public class ApiService : IApiService
    {
        public async Task<Response> GetCompanyAsync(string company_name, string urlBase, string servicePrefix, string Controller)
        {
			try
			{
				HttpClient client = new HttpClient
				{
					BaseAddress = new Uri(urlBase)
				};

				string url = $"{servicePrefix}{Controller}/{company_name}";
				HttpResponseMessage response = await client.GetAsync(url);
				string result = await response.Content.ReadAsStringAsync();

				if (!response.IsSuccessStatusCode)
				{
					return new Response
					{
						IsSuccess = false,
						Message = result,

					};
				}

				CompanyResponse model = JsonConvert.DeserializeObject<CompanyResponse>(result);
				return new Response
				{
					IsSuccess = true,
					Result = model
				};

			}
			catch (Exception ex)
			{

				return new Response
				{
					IsSuccess = false,
					Message = ex.Message
				};
			}
        }
    }
}
