using api.Models;
using frontend.Base;
using Newtonsoft.Json;

namespace frontend.Repository.Data
{
    public class SPRRepository : GeneralRepository<Proyek,String>
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
        public async Task<Proyek> GetSPRProyek
            (int IdProyek)
        {
            Proyek entities = new Proyek();


            using (var response = await httpClient.GetAsync(address.APILink + $"Proyek/{IdProyek}"))
            {
                string apiResponse = response.Content.ReadAsStringAsync().Result;
                entities = JsonConvert.DeserializeObject<Proyek>(apiResponse);
            }

            return entities;


        }
    }
}
