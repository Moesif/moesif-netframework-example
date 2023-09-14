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
        public IEnumerable<Product> Get()
        {
            Console.Out.WriteLine("Product Get");
            return new Product[] {
            new Product
            {
                Id = 1234,
                Name = "Chair",
                Category = "Furniture"
            },
            new Product
            {
                Id = 567,
                Name = "Table",
                Category = "Furniture"
             }
            };
        }

        // GET api/product/5
        public Product Get(int id)
        {
            return new Product
            {
                Id = 1234,
                Name = "Chair",
                Category = "Furniture"
            };
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