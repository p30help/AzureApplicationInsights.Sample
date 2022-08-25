using Microsoft.AspNetCore.Mvc;

namespace AzureApplicationInsightsSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        
        private readonly ILogger<CustomersController> _logger;

        public CustomersController(ILogger<CustomersController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// send logs to telemetry
        /// </summary>
        /// <returns></returns>
        /// <exception cref="DangerException"></exception>
        [HttpPost("SaveLogs")]
        public async Task SaveLogs()
        {
            var id = Guid.NewGuid();
            var name = Guid.NewGuid();
            _logger.LogTrace("Trace id:{id}, Name: {name}", id, name);
            _logger.LogDebug("Debug id:{id}, Name: {name}", id, name);
            _logger.LogError("Error id:{id}, Name: {name}", id, name);
            _logger.LogWarning("Warning id:{id}, Name: {name}", id, name);
            _logger.LogInformation("Information id:{id}, Name: {name}", id, name);
            _logger.LogCritical("Critical error - oh my god, id:{id}, Name: {name}", id, name);

            try
            {
                throw new DangerException("This is very dangrous error");
            }
            catch (Exception exp)
            {
                _logger.LogError(exp, "this is a danger exp, be carefull");
            }
        }
    }
}