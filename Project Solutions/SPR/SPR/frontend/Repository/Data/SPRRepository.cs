using api.Models;
using api.Models.ViewModel;
using frontend.Base;
using Newtonsoft.Json;
using System.Text;

namespace frontend.Repository.Data
{
    public class SPRRepository : GeneralRepository<SPR,String>
    {
        private readonly Address address;
        private readonly string request;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly HttpClient httpClient;
public SPRRepository(Address address, string request="SPR/"):base(address, request) 
        {
            this.address = address;
            this.request = request;
            _contextAccessor = new HttpContextAccessor();
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(address.APILink)
            };
            //aktifin kalau udah pakai jw aja
            //httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + address.JWToken);

        }
        public async Task<RequestForm> CreateSPR(SPRContentDetilView entity)
        {
            try {
                RequestForm entities =new RequestForm();
                StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
                using (var response = httpClient.PostAsync(address.APILink+ "SPR/CreateSPR", content).Result)
                {
                    string apiResponse = response.Content.ReadAsStringAsync().Result;
                    entities = JsonConvert.DeserializeObject<RequestForm>(apiResponse);
                }

                return entities;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public async Task<List<SPR>> GetSPRByProject(int proyekId)
        {
            try
            {
                List<SPR> entities = new List<SPR>();


                using (var response = await httpClient.GetAsync(address.APILink + $"SPR/GetSPRByProject/{proyekId}"))
                {
                    string apiResponse = response.Content.ReadAsStringAsync().Result;
                    entities = JsonConvert.DeserializeObject<List<SPR>>(apiResponse);
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
