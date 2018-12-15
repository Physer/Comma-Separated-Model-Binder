using System.Web.Http;

namespace CSMB.Sandbox.Framework
{
    [Route("api/values")]
    public class ValuesController : ApiController
    {
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            return Json(new int[] { 1, 2, 3, 4, 5 });
        }

        public IHttpActionResult Get(int[] values)
        {
            return Json(values);
        }
    }
}