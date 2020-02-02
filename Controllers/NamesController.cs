using System.Collections.Generic;
using System.Web.Http;

namespace MessagehandlerWithWebAPI.Controllers
{
    [RoutePrefix("api/v1")]
    public class NamesController : ApiController
    {
        [HttpGet]
        [Route("names")]
        public IEnumerable<string> GetNames()
        {
            return new List<string>() { "Akin", "Mark","thurbarh"};
        }
    }
}
