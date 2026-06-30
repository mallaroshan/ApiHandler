using ApiHandler.DTO;

namespace ApiHandler.Interface
{
    public interface IConfigurationService
    {
        Task<object> SaveAsync(ApiConfigDTO dto);
        Task<object> GetAsync();
        Task<object> GetByIdAsync(string id);
    }
}
