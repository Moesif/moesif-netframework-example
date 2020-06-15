using Moesif.NetFramework.Example.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Moesif.NetFramework.Example
{
    public class ProductController : ApiController
    {
        // GET api/product
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/product/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/product
        public IHttpActionResult Post([FromBody] Product product)
        {

            return Ok(product);
        }

        // PUT api/product/5
        public IHttpActionResult Put(int id, [FromBody] Product value)
        {
            return Ok(value);
        }

        // DELETE api/product/5
        public void Delete(int id)
        {
        }
    }
}