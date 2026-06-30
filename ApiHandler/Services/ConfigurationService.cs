using ApiHandler.DataAccess;
using ApiHandler.DTO;
using ApiHandler.Interface;
using Microsoft.EntityFrameworkCore;

namespace ApiHandler.Services
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly ApplicationDbContext _db;
        public ConfigurationService(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<object> SaveAsync(ApiConfigDTO dto)
        {
            try
            {
                var entity = new ApiConfiguration
                {
                    Name = dto.Name,
                    BaseUrl = dto.Url,
                    Endpoint = string.Empty,
                    HttpMethod = dto.Method,
                    AuthType = dto.AuthType ?? "None",
                    AuthValue = dto.AuthValue,
                    Headers = dto.AuthHeaderName,
                    IsActive = true,
                    CreatedOn = DateTime.UtcNow
                };

                foreach (var mapping in dto.FieldMappings)
                {
                    entity.FieldMappings.Add(new FieldMapping
                    {
                        JsonPath = mapping.JsonPath,
                        DatabaseColumn = mapping.DatabaseColumn,
                        DataType = mapping.DataType
                    });
                }

                _db.ApiConfigurations.Add(entity);
                await _db.SaveChangesAsync();

                return entity.Id;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<object> GetAsync()
        {
            try
            {
                var dbName = _db.Database.GetConnectionString();
                var config = await _db.ExternalApis
                 .Include(x => x.RequestParameters).Include(x => x.ResponseParameters)               
                 .ToListAsync();

                return config;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<object> GetByIdAsync(string id)
        {
            try
            {
                var config = await _db.ExternalApis
                            .Where(x => x.Id == Guid.Parse(id))
                            .FirstOrDefaultAsync();

                return config;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<object> SaveFieldMapping(FieldMapping dto)
        {
            try
            {
                var config = await _db.FieldMappings.AddAsync(dto);

                _db.SaveChanges();

                return config;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
