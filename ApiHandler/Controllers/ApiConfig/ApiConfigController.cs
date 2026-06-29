using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiHandler.Controllers.ApiConfig
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiConfigController : ControllerBase
    {
        private readonly IApiConfigService _configService;

        [HttpPost]
        public async Task<IActionResult> SaveConfig([FromBody] ApiConfigDto dto)
        {
            var id = await _configService.SaveAsync(dto);
            return Ok(new { configId = id });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetConfig(int id)
        {
            var config = await _configService.GetByIdAsync(id);
            return Ok(config);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllConfigs()
        {
            return Ok(await _configService.GetAllAsync());
        }
    }
}
