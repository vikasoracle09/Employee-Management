using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ServiceLayer
{
    public interface IService
    {
        List<Datum> GetData();
        List<Datum> GetSpecificData(string name);
        Task<bool>CreateUser(EmployeeModel model);
        Task<bool> EditUser(EmployeeModel model);
        Task<bool> DeleteUser(EmployeeModel model);
    }

    public class Service : IService
    {
        private readonly IUrlBuilder _urlBuilder = new UrlBuilder();

        public List<Datum> GetData()
        {
            var data = _urlBuilder.ConstructGetUrl(null);


            var list = JsonConvert.DeserializeObject<Root>(data.Result);

            if (list != null)
            {
                var res = list.data;
                return res;
            }

            return null;
        }

        public List<Datum> GetSpecificData(string name)
        {
            var model = new EmployeeModel
            {
                Name = name
            };
            var data = _urlBuilder.ConstructGetUrl(model);


            var list = JsonConvert.DeserializeObject<Root>(data.Result);

            if (list != null) return list.data;

            return null;
        }

        public async Task<bool>CreateUser(EmployeeModel model)
        {
            
            var data = await _urlBuilder.ConstructPostUrl(model);

            var res = (JObject)JsonConvert.DeserializeObject(data);

            if (res != null)
            {
                var num =  res.Value<string>("code");

                return num == "201";
            }

            return false;
        }

        public async Task<bool> EditUser(EmployeeModel model)
        {

            var data = await _urlBuilder.ConstructPutUrl(model);

            var res = (JObject)JsonConvert.DeserializeObject(data);

            if (res != null)
            {
                var num = res.Value<string>("code");

                return num == "201";
            }

            return false;
        }


        public async Task<bool> DeleteUser(EmployeeModel model)
        {

            var data = await _urlBuilder.ConstructDeleteUrl(model);

            var res = (JObject)JsonConvert.DeserializeObject(data);

            if (res != null)
            {
                var num = res.Value<string>("code");

                return num == "204";
            }

            return false;
        }


    }
}
