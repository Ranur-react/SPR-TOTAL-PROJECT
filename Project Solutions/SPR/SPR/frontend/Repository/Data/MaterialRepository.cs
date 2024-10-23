using api.Models;
using frontend.Base;

namespace frontend.Repository.Data
{
    public class MaterialRepository : GeneralRepository<Material, Guid>
    {
        private readonly Address address;
        private readonly string request;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly HttpClient httpClient;
        public MaterialRepository(Address address, string request = "Proyek/") : base(address, request)
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
