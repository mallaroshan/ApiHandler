using ApiHandler.DTO;
using ApiHandler.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiHandler.Controllers.ApiConfig
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiConfigController : ControllerBase
    {
        private readonly IConfigurationService _configService;

        public ApiConfigController(IConfigurationService service)
        {
            _configService = service;
        }

        [HttpPost]
        public async Task<IActionResult> SaveConfig([FromBody] ApiConfigDTO dto)
        {
            var id = await _configService.SaveAsync(dto);
            return Ok(new { configId = id });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetConfig(string id)
        {
            var config = await _configService.GetByIdAsync(id);
            return Ok(config);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllConfigs()
        {
            return Ok(await _configService.GetAsync());
        }
    }
}
