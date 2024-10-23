using api.Models;
using frontend.Base;
using Newtonsoft.Json;

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
        public async Task<SPR> GetSPRSPR
            (int IdSPR)
        {
            SPR entities = new SPR();


            using (var response = await httpClient.GetAsync(address.APILink + $"SPR/{IdSPR}"))
            {
                string apiResponse = response.Content.ReadAsStringAsync().Result;
                entities = JsonConvert.DeserializeObject<SPR>(apiResponse);
            }

            return entities;


        }
    }
}
