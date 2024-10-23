using Microsoft.Extensions.Options;

namespace frontend.Base
{
    public class Address
    {
        public string APILink = "https://localhost:7011/API/";

        public Address(IOptions<AppSettings> options)
        {
            APILink = options.Value.ApiBaseUrl;
        }
    }
}
