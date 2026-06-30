using ApiHandler.DTO;
using ApiHandler.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiHandler.Controllers.Gateway
{
    [Route("api/[controller]")]
    [ApiController]
    public class GatewayController : ControllerBase
    {
        private readonly IGatewayService _gateway;
        public GatewayController(IGatewayService gateway)
        {
            _gateway = gateway;
        }
        public class ExecuteRequest
        {
            public Dictionary<string, string?> Parameters { get; set; } = new();
        }

        [Route("execute/{Config_Id}")]
        public async Task<IActionResult> ExecuteEndpoint( int configId, [FromBody] ExecuteRequest? request)
        {
            var result = await _gateway.ExecuteApiFlowAsync(
                configId,
             request
            );

            return Ok(result);
        }


    }
}
