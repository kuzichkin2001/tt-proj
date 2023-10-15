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
        private readonly DisabledFunctionalConfigSection _disabledFunctional;

        public ConfigurationApiController(
            DataAccessConfigSection dataAccess,
            DisabledFunctionalConfigSection disabledFunctional)
        {
            _dataAccess = dataAccess;
            _disabledFunctional = disabledFunctional;
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
                UiDisabledFeatures = _disabledFunctional.UiDisabledFeatures,
                BackDisabledControllers = _disabledFunctional.DisabledControllers
            };
        }
    }
}
