using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using Core.Policities;

namespace Core
{
    public class AlphanumericService : DataService
    {
        private DataDict _dataDict;
        public AlphanumericService(DataDict dataDict):base(dataDict) 
        {
            _dataDict = dataDict;
        }
        

        protected override ServiceState Process()
        {
            if (GetDefinition().Result != null)
                return ServiceState.Accepted;
            else
                return ServiceState.Rejected;
        }

        private async Task<string> GetDefinition()
        {
            var options = new JsonSerializerOptions { PropertyNamingPolicy = new JsonPolicities(), WriteIndented = true };
            HttpClient httpClient = new HttpClient();
            using HttpResponseMessage response = await httpClient
                .GetAsync("https://api.dictionaryapi.dev/api/v2/entries/en/" + _dataDict.Test!.Input + "");
            var jsonResponse = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var jsonObject = JToken.Parse(jsonResponse);
                var definition = jsonObject.SelectToken("[0].meanings[0].definitions[0].definition")!.ToString();
                _dataDict.Test.ResponseText = definition;
                return definition;
            }
            else
            {
                var jsonObject = JObject.Parse(jsonResponse);
                var data = jsonObject.SelectToken("message")!.ToString();
                throw new Exception(data);
            }
        }
    }
}
