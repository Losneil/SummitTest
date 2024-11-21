using Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Api.Services;

namespace Test.Api.Controllers
{
    [ApiController]
    [Route("api/controlador")]
    public class TestController : ControllerBase
    {
        private readonly TestService testService;
        public TestController(TestService testService) 
        {
            this.testService = testService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DataDict dataDict)
        {
            return Ok(await testService.ObtenerDataDict(dataDict));
        }
    }
}
