using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {

            double latA = -16.400410;
            double lonA = -71.504046;
            double latB = -16.400441;
            double lonB = -71.507041;
            double latC = -16.404506;
            double lonC = -71.513654;
            double latD = -16.420361;
            double lonD = -71.525924;
            return new string[] {
                "["+H3.GeoToH3(latA, lonA,15) + ","+H3.GeoToH3(latB, lonB,15)+ ","+H3.GeoToH3(latC, lonC,15) + ","+H3.GeoToH3(latD, lonD,15)+ "]",
                "["+H3.GeoToH3(latA, lonA,14) + ","+H3.GeoToH3(latB, lonB,14)+ ","+H3.GeoToH3(latC, lonC,14) + ","+H3.GeoToH3(latD, lonD,14)+ "]",
                "["+H3.GeoToH3(latA, lonA,13) + ","+H3.GeoToH3(latB, lonB,13)+ ","+H3.GeoToH3(latC, lonC,13) + ","+H3.GeoToH3(latD, lonD,13)+ "]",
                "["+H3.GeoToH3(latA, lonA,12) + ","+H3.GeoToH3(latB, lonB,12)+ ","+H3.GeoToH3(latC, lonC,12) + ","+H3.GeoToH3(latD, lonD,12)+ "]",
                "["+H3.GeoToH3(latA, lonA,11) + ","+H3.GeoToH3(latB, lonB,11)+ ","+H3.GeoToH3(latC, lonC,11) + ","+H3.GeoToH3(latD, lonD,11)+ "]",
                "["+H3.GeoToH3(latA, lonA,10) + ","+H3.GeoToH3(latB, lonB,10)+ ","+H3.GeoToH3(latC, lonC,10) + ","+H3.GeoToH3(latD, lonD,10)+ "]",
                "["+H3.GeoToH3(latA, lonA,9) + ","+H3.GeoToH3(latB, lonB,9)+ ","+H3.GeoToH3(latC, lonC,9) + ","+H3.GeoToH3(latD, lonD,9)+ "]",
                "["+H3.GeoToH3(latA, lonA,8) + ","+H3.GeoToH3(latB, lonB,8)+ ","+H3.GeoToH3(latC, lonC,8) + ","+H3.GeoToH3(latD, lonD,8)+ "]",
                "["+H3.GeoToH3(latA, lonA,7) + ","+H3.GeoToH3(latB, lonB,7)+ ","+H3.GeoToH3(latC, lonC,7) + ","+H3.GeoToH3(latD, lonD,7)+ "]",
                "["+H3.GeoToH3(latA, lonA,6) + ","+H3.GeoToH3(latB, lonB,6)+ ","+H3.GeoToH3(latC, lonC,6) + ","+H3.GeoToH3(latD, lonD,6)+ "]",
                "["+H3.GeoToH3(latA, lonA,5) + ","+H3.GeoToH3(latB, lonB,5)+ ","+H3.GeoToH3(latC, lonC,5) + ","+H3.GeoToH3(latD, lonD,5)+ "]",
                "["+H3.GeoToH3(latA, lonA,4) + ","+H3.GeoToH3(latB, lonB,4)+ ","+H3.GeoToH3(latC, lonC,4) + ","+H3.GeoToH3(latD, lonD,4)+ "]",
                "["+H3.GeoToH3(latA, lonA,3) + ","+H3.GeoToH3(latB, lonB,3)+ ","+H3.GeoToH3(latC, lonC,3) + ","+H3.GeoToH3(latD, lonD,3)+ "]",
                "["+H3.GeoToH3(latA, lonA,2) + ","+H3.GeoToH3(latB, lonB,2)+ ","+H3.GeoToH3(latC, lonC,2) + ","+H3.GeoToH3(latD, lonD,2)+ "]",
                "["+H3.GeoToH3(latA, lonA,1) + ","+H3.GeoToH3(latB, lonB,1)+ ","+H3.GeoToH3(latC, lonC,1) + ","+H3.GeoToH3(latD, lonD,1)+ "]",
            };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
