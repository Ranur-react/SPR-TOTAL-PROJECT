using api.Models;
using frontend.Base;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace frontend.Repository.Data
{
    public class ProyekRepository : GeneralRepository<Proyek, int>
    {
        private readonly Address address;
        private readonly string request;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly HttpClient httpClient;

        public ProyekRepository(Address address, string request="Proyek/") : base(address, request)
        {
            this.address = address;
            this.request = request;
            _contextAccessor = new HttpContextAccessor();
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(address.APILink)
            };
        }
    }
}
