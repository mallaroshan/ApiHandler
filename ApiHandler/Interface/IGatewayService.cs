using static ApiHandler.Controllers.Gateway.GatewayController;

namespace ApiHandler.Interface
{
    public interface IGatewayService
    {
        Task<object> ExecuteApiFlowAsync(Guid Config_id, ExecuteRequest request);
    }
}
