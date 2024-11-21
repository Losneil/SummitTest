using Core;
using System.Text.RegularExpressions;

namespace Test.Api.Services
{
    public class TestService
    {
        public TestService() {  }

        public async Task<Response> ObtenerDataDict(DataDict dataDict)
        {
            var numerico = Regex.IsMatch(dataDict.Test!.Input!, "^[0-9]$");
            Response response = new Response();
            if (numerico)
            {
                NumericService numericService = new NumericService(dataDict);
                response.ServiceState = numericService.StartService();
                response.Dictionary = dataDict;
                return response;
            }
            else
            {
                AlphanumericService numericService = new AlphanumericService(dataDict);
                response.ServiceState = numericService.StartService();
                response.Dictionary = dataDict;
                return response;
            }
        }
    }
}
