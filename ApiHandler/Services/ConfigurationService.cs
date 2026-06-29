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
                var config = await _db.AddAsync(dto);

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
        public async Task<object> GetByIdAsync(int id)
        {
			try
			{
                var config = await _db.ApiConfigurations.FirstOrDefaultAsync(x => x.Id == id);

                return config;

            }
			catch (Exception)
			{

				throw;
			}
        }
    }
}
