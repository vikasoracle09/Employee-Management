using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json;

namespace ServiceLayer
{
    public interface IUrlBuilder
    {
        Task<string> ConstructGetUrl(EmployeeModel model);
        Task<string> ConstructPostUrl(EmployeeModel model);
        Task<string> ConstructPathSegmentUrl(EmployeeModel model);
        Task<string> ConstructDeleteUrl(EmployeeModel model);
        Task<string> ConstructPutUrl(EmployeeModel model);
    }

    /// <summary>
    /// Create Dynamic URL based on user request send. Used flur to construct the url.
    /// </summary>
    public class UrlBuilder : IUrlBuilder
    {
        private readonly ConfigReader _configReader = new ConfigReader();

        private readonly string _token;

        private readonly string _baseUrl;

       internal UrlBuilder()
        {
            _baseUrl = _configReader.BasePath;
            _token = _configReader.AppKey;
        }

       public async Task<string> ConstructGetUrl(EmployeeModel model)
        {
            
            if (model != null)
            {
                return await _baseUrl.AppendPathSegment("users/").WithOAuthBearerToken(_token).SetQueryParam("name", model.Name).SetQueryParam("email", model.Email).GetAsync()
                    .ConfigureAwait(false).GetAwaiter().GetResult().Content.ReadAsStringAsync();
            }

           
            return await _baseUrl.AppendPathSegment("users/").WithOAuthBearerToken(_token).GetAsync()
                .ConfigureAwait(false).GetAwaiter().GetResult().Content.ReadAsStringAsync();
        }

       public async Task<string> ConstructPostUrl(EmployeeModel model)
       {
           HttpContent content =
               new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

           return await _baseUrl.AppendPathSegment("users/").WithOAuthBearerToken(_token).PostAsync(content).ConfigureAwait(false).GetAwaiter().GetResult().Content.ReadAsStringAsync();
        }

       public async Task<string> ConstructPathSegmentUrl(EmployeeModel model)
       {
           return await _baseUrl.AppendPathSegment("users/").AppendPathSegment(123).WithHeader("Token", _token).GetAsync()
               .ConfigureAwait(false).GetAwaiter().GetResult().Content.ReadAsStringAsync();
       }


       public async Task<string> ConstructDeleteUrl(EmployeeModel model)
       {
           return await _baseUrl.AppendPathSegment("users/").AppendPathSegment(model.ID).WithOAuthBearerToken(_token).DeleteAsync()
               .ConfigureAwait(false).GetAwaiter().GetResult().Content.ReadAsStringAsync();
        }

       public async Task<string> ConstructPutUrl(EmployeeModel model)
       {
           HttpContent content =
               new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            return await _baseUrl.AppendPathSegment("users/").AppendPathSegment(model.ID).WithOAuthBearerToken(_token).PutAsync(content)
               .ConfigureAwait(false).GetAwaiter().GetResult().Content.ReadAsStringAsync();
       }
    }
}
