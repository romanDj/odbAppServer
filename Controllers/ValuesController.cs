using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace gasDiesel.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        // [Authorize(Roles = "Administrator")]
        [Authorize]
        public dynamic Get()
        {
            var principal = User as ClaimsPrincipal;
            var subjectClaim = principal.FindFirst("sub");
            if (subjectClaim != null)
            {
                return subjectClaim.Value;
            }
            return null;                     
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
