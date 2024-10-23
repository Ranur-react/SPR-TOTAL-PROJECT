using api.Models;
using frontend.Base;

namespace frontend.Repository.Data
{
    public class ProyekRepository : GeneralRepository<Proyek, String>
    {
        private readonly Address address;
        private readonly string request;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly HttpClient httpClient;
    }
}
