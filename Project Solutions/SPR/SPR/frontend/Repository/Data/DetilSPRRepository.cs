using api.Models;
using api.Models.ViewModel;
using frontend.Base;
using Newtonsoft.Json;
using System.Text;

namespace frontend.Repository.Data
{
    public class DetilSPRRepository : GeneralRepository<DetilSPR, Guid>
    {
        private readonly Address address;
        private readonly string request;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly HttpClient httpClient;

        public DetilSPRRepository(Address address, string request = "DetilSPR/") : base(address, request)
        {
            this.address = address;
            this.request = request;
            _contextAccessor = new HttpContextAccessor();
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(address.APILink)
            };
        }
        public async Task<RequestForm> GetBySPR(String SPRKode)
        {
            try
            {
                RequestForm entities = new RequestForm();
                //StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
                using (var response = httpClient.GetAsync(address.APILink + "DetilSPR/GetBySPR/" + SPRKode).Result)
                {
                    string apiResponse = response.Content.ReadAsStringAsync().Result;
                    entities = JsonConvert.DeserializeObject<RequestForm>(apiResponse);
                }

                return entities;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;

            }
        }

    }
}
