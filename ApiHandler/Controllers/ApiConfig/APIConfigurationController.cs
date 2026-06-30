using ApiHandler.DataAccess;
using ApiHandler.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiHandler.Controllers.ApiConfig
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIConfigurationController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public APIConfigurationController(ApplicationDbContext db) 
        {
            _db = db;
        }

        [HttpPost]
        public async Task<IActionResult> Save(SaveExternalApiDto dto)
        {
            var api = new ExternalApi
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                BaseUrl = dto.BaseUrl,
                Endpoint = dto.Endpoint,
                Method = dto.Method,
                AuthenticationType = dto.AuthenticationType,
                IsActive = true
            };

            foreach (var h in dto.Headers)
            {
                api.Headers.Add(new ApiHeader
                {
                    Id = Guid.NewGuid(),
                    HeaderName = h.HeaderName,
                    HeaderValue = h.HeaderValue,
                    IsSecret = h.IsSecret
                });
            }

            foreach (var p in dto.RequestParameters)
            {
                api.RequestParameters.Add(new RequestParameter
                {
                    Id = Guid.NewGuid(),
                    Name = p.Name,
                    JsonPath = p.JsonPath,
                    DataType = p.DataType,
                    IsRequired = p.IsRequired,
                    DefaultValue = p.DefaultValue
                });
            }

            foreach (var p in dto.ResponseParameters)
            {
                api.ResponseParameters.Add(new ResponseParameter
                {
                    Id = Guid.NewGuid(),
                    Name = p.Name,
                    JsonPath = p.JsonPath,
                    DataType = p.DataType
                });
            }

            _db.ExternalApis.Add(api);

            await _db.SaveChangesAsync();

            return Ok(api.Id);
        }
    }
}
