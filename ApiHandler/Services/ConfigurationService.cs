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
                var param = new ApiConfiguration
                {



                };
                 var config = await _db.ApiConfigurations.AddAsync(param);

                _db.SaveChanges();

                return config;

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
                var config = await _db.ApiConfigurations.ToListAsync();

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
                var config = await _db.ApiConfigurations
                            .Where(x => x.Id == Guid.Parse(id))
                            .FirstOrDefaultAsync();

                return config;

            }
			catch (Exception)
			{

				throw;
			}
        }
    }
}
