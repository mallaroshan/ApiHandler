using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiHandler.Controllers.Gateway
{
    [Route("api/[controller]")]
    [ApiController]
    public class GatewayController : ControllerBase
    {
        private readonly IApiOrchestrationService _orchestrationService;
        public GatewayController(IApiOrchestrationService  orchestrationService)
        {
            _orchestrationService = orchestrationService;
        }

        [Route("execute/{Config_Id}")]
        public async Task<IActionResult> ExecuteEndpoint(
        int configId,
        [FromBody] ExecuteRequestDto? request)
        {
            var result = await _orchestrationService.ExecuteApiFlowAsync(
                configId,
                triggerType: "Manual",
                runtimeParams: request?.RuntimeParams
            );

            return Ok(result);
        }

        public class ExecuteRequestDto
        {
            public Dictionary<string, string>? RuntimeParams { get; set; }
        }
    }
}
