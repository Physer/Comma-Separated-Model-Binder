using System.Web.Http;

namespace CSMB.Sandbox.Framework
{
    [RoutePrefix("api/values")]
    public class ValuesController : ApiController
    {
        [HttpGet]
        [Route("list")]
        public IHttpActionResult List([FromUri] int[] values)
        {
            return Json(values);
        }

        [HttpGet]
        public IHttpActionResult Get([FromUri] int value)
        {
            return Json(value);
        }

        [HttpGet]
        public IHttpActionResult Default()
        {
            return Json("Values API");
        }

    }
}