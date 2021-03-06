using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ServiceLayer
{
   public class EmployeeModel
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
