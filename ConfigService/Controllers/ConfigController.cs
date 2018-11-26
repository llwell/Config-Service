using ConfigService.Common;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ConfigService.Controllers
{
    [Produces("application/json")]
    [Route(Global.ROUTE_PX + "/[controller]")]
    [EnableCors("AllowSameDomain")]
    public class ConfigController : Controller
    {
        [HttpGet]
        public ActionResult Get(string env)
        {
            return Json(new { s="123", b="456"});
        }

    }

}