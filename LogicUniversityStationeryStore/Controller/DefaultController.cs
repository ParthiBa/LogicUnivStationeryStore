using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LogicUniversityStationeryStore.Controller
{
    public class DefaultController : ApiController
    {
        // GET: api/Default
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Default/5
        public int Get(int id)
        {
            return id;
        }

        // POST: api/Default
        public string  Post([FromBody]string value)
        {
            return "hello"+ value;
        }

        // PUT: api/Default/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Default/5
        public void Delete(int id)
        {
        }
    }
}
