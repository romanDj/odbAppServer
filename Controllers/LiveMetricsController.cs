using gasDiesel.Providers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Numerics;
using System.Security.Claims;
using System.Web;
using System.Web.Http;

namespace gasDiesel.Controllers
{
    public class LiveMetricsController : ApiController
    {
        readonly IDbContext db;

        public LiveMetricsController(IDbContext dbContext)
        {
             db = dbContext;
        }



        // GET api/<controller>
        public IEnumerable<Models.LiveMetric> Get()
        {
            return db.GasDieselContext.LiveMetrics.ToList();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [Authorize]
        public int[] Post([FromBody] MetricsData data)
        {
            var principal = User as ClaimsPrincipal;
            var subjectClaim = principal.FindFirst("sub");
            if (subjectClaim == null) {
                throw new HttpException(500, "Subject is null");
            }
            List<int> ids = new List<int>();

            Debug.WriteLine(JsonConvert.SerializeObject(data));

            foreach (LiveMetric liveMetric in data.liveMetrics)
            {
                
                try {
                    if (liveMetric.name == "location")
                    {
                        Dictionary<string, string> gps  = JsonConvert.DeserializeObject<Dictionary<string, string>>(liveMetric.value);
                        Models.Location obj = new Models.Location {
                            Latitude = double.Parse(gps["latitude"], CultureInfo.InvariantCulture),
                            Longitude = double.Parse(gps["longitude"], CultureInfo.InvariantCulture),
                            Dt = (new DateTime(1970, 1, 1)).AddMilliseconds((Double)liveMetric.ts).ToLocalTime(),
                            Subject = subjectClaim.Value
                        };
                        db.GasDieselContext.Locations.Add(obj);
                        db.GasDieselContext.SaveChanges();
                    }
                    else
                    {
                        Models.LiveMetric obj = new Models.LiveMetric
                        {
                            Name = liveMetric.name,
                            Value = liveMetric.value,
                            Dt = (new DateTime(1970, 1, 1)).AddMilliseconds((Double)liveMetric.ts).ToLocalTime(),
                            Subject = subjectClaim.Value
                        };
                        db.GasDieselContext.LiveMetrics.Add(obj);
                        db.GasDieselContext.SaveChanges();
                    }
                    ids.Add(liveMetric.rowid);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }   
            }

            Debug.WriteLine(ids);

            return ids.ToArray();
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }

    public class MetricsData
    {
        public List<LiveMetric> liveMetrics { get; set; }
    }

    public class LiveMetric
    {
        public int rowid { get; set; }
        public BigInteger ts { get; set; }
        public string name { get; set; }
        public string value { get; set; }
    }
}