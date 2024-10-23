using frontend.Base;
using frontend.Repository.Interface;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace frontend.Repository
{
    public class GeneralRepository<TEntity, TId> : IRepository<TEntity, TId> where TEntity : class
    {
        private readonly Address address;
        private readonly string request;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly HttpClient httpClient;

        public GeneralRepository(Address address, string request)
        {
            this.address = address;
            this.request = request;
            _contextAccessor = new HttpContextAccessor();
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(address.APILink)
            };
        }

        public HttpStatusCode Delete(TId id)
        {
            var result = httpClient.DeleteAsync(request + id).Result;
            return result.StatusCode;
        }


        public async Task<List<TEntity>> Get()
        {
            try
            {
                List<TEntity> entities = new List<TEntity>();

                using (var response = await httpClient.GetAsync(request))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    entities = JsonConvert.DeserializeObject<List<TEntity>>(apiResponse);
                }

                return entities;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error Informations");
                Console.WriteLine(e);
                throw;
            }
        }




        public async Task<TEntity> Get(TId id)
        {
            TEntity entity = null;

            using (var response = await httpClient.GetAsync(request + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entity = JsonConvert.DeserializeObject<TEntity>(apiResponse);
            }
            return entity;
        }

        public HttpStatusCode Put(TEntity entity)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
            var result = httpClient.PutAsync(request, content).Result;
            return result.StatusCode;
        }
        public HttpStatusCode Post(TEntity entity)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync(address.APILink + request, content).Result;
            return result.StatusCode;
        }
    }
}
