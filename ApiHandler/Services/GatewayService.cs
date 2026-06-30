using ApiHandler.DataAccess;
using ApiHandler.DTO;
using ApiHandler.Interface;
using Microsoft.EntityFrameworkCore;

namespace ApiHandler.Services
{
    public class GatewayService : IGatewayService
    {
        private readonly ApplicationDbContext _db;
        private readonly IHttpClientFactory _httpClientFactory;

        public GatewayService(ApplicationDbContext db, IHttpClientFactory httpClientFactory)
        {
            _db = db;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<object> ExecuteApiFlowAsync(Guid Config_id, Dictionary<string, string?> inputValues)
        {
            try
            {
                var api = await _db.ExternalApis
           .Include(a => a.RequestParameters)
           .Include(a => a.ResponseParameters)
           .Include(a => a.Headers)
           .FirstOrDefaultAsync(a => a.Id == Config_id)
           ?? throw new InvalidOperationException("ExternalApi not found");


                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
