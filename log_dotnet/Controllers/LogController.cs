using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace log_dotnet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogController : ControllerBase
    {
        private readonly ILogger<LogController> _logger;

        public LogController(ILogger<LogController> logger)
        {
            _logger = logger;
        }

        private Task logging;

        [HttpGet]
        public string Get()
        {
            if(logging == null) {
                logging = new Task(t =>
                {
                    while (true)
                    {
                        _logger.LogDebug("LogDebug");
                        _logger.LogCritical("LogCritical");
                        _logger.LogError("LogError");
                        _logger.LogInformation("LogInformation");
                        _logger.LogTrace("LogTrace");
                        _logger.LogWarning("LogWarning");
                        Task.Delay(200).Wait();
                    }
                }, "Logger task");
            }

            if(logging.Status == TaskStatus.Running)
            {
                logging.Dispose();
            }
            else
            {
                logging.RunSynchronously();
            }

            return logging.Status.ToString();
        }

        [HttpGet("once")]
        public ActionResult<string> LogOnce()
        {
            _logger.LogDebug("LogDebug " + new Random().Next());
            _logger.LogCritical("LogCritical " + new Random().Next());
            _logger.LogError("LogError " + new Random().Next());
            _logger.LogInformation("LogInformation " + new Random().Next());
            _logger.LogTrace("LogTrace " + new Random().Next());
            _logger.LogWarning("LogWarning " + new Random().Next());
            return Request.Method;
        }

    }
}
