using Microsoft.AspNetCore.Mvc;
using TT.Service.ConfigSections;
using TT.Service.ViewModels;
using TT.Shared;

namespace TeachersTogether.Service.Controllers
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

            try
            {
                dataAccessParameters.ParseConnectionString(connectionString);
            }
            catch (Exception ex)
            {
                throw;
            }

            return new ConfigurationViewModel()
            {
                DataHost = dataAccessParameters["Server"],
                DbUser = dataAccessParameters["User Id"],
                DbPassword = dataAccessParameters["Password"],
            };
        }
    }
}
