using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Shoe2Shop.Service.WApi.Controllers
{
    public class StoresController : ApiController
    {
        // GET: api/Stores
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Stores/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Stores
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Stores/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Stores/5
        public void Delete(int id)
        {
        }
    }
}
