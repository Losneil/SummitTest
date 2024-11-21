using Core.Policities;
using Newtonsoft.Json.Linq;
using System.Numerics;
using System.Text.Json;

namespace Core
{
    public class NumericService : DataService
    {
        private DataDict _dataDict;
        public NumericService(DataDict dataDict) : base(dataDict)
        {
            _dataDict = dataDict;
        }
        protected override ServiceState Process()
        {
            if (GetValue().Result != null)
                return ServiceState.Accepted;
            else
                return ServiceState.Rejected;
        }

        private async Task<string> GetValue()
        {
            var options = new JsonSerializerOptions { PropertyNamingPolicy = new JsonPolicities(), WriteIndented = true };
            HttpClient httpClient = new HttpClient();
            using HttpResponseMessage response = await httpClient
                .GetAsync("https://api.coinbase.com/v2/exchange-rates?currency=USD");

            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var jsonObject = JObject.Parse(jsonResponse);
            var valor = jsonObject.SelectToken("data.rates.COP")!.ToString();
            double valorDecimal = Convert.ToDouble(valor);
            double valorDecimalTruncado = Math.Truncate(valorDecimal);
            int parametroEntero = Convert.ToInt32(_dataDict.Test!.Input);
            double valorFinal = parametroEntero * valorDecimalTruncado;
            _dataDict.Test!.ResponseText = valorFinal.ToString();
            return valorFinal.ToString();
        }
    }
}
