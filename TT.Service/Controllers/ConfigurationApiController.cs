using Microsoft.AspNetCore.Mvc;
using TT.Host.ConfigSections;
using TT.Service.ViewModels;
using TT.Shared;

namespace TT.Service.Controllers
{
    [Route("api/configuration")]
    [ApiController]
    public class ConfigurationApiController : ControllerBase
    {
        private readonly DataAccessConfigSection _dataAccess;

        public ConfigurationApiController(DataAccessConfigSection dataAccess)
        {
            _dataAccess = dataAccess;
        }

        [HttpGet]
        [Route("")]
        public ConfigurationViewModel GetConfiguration()
        {
            var connectionString = _dataAccess.ConnectionString;
            var dataAccessParameters = new DataAccessParameters();

            dataAccessParameters.ParseConnectionString(connectionString);

            return new ConfigurationViewModel()
            {
                DataHost = dataAccessParameters["Server"],
                DataStorageName = dataAccessParameters["Database"],
                DbPort = dataAccessParameters["Port"],
                DbUser = dataAccessParameters["User Id"],
                DbPassword = dataAccessParameters["Password"],
            };
        }
    }
}
