using Moesif.NetFramework.Example.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace Moesif.NetFramework.Example
{
    public class ProductController : ApiController
    {
        // GET api/product
        public IEnumerable<Product> Get()
        {
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
            if (id < 22)
            {
                return new Product
                {
                    Id = id,
                    Name = "Small Chair",
                    Category = "Furniture"
                };
            }
            else
            {
                string content = GenerateLargeResponseBody(id);
                return new Product
                {
                    Id = id,
                    Name = $"Largggggggggggggge Chair [{id} KB]",
                    Category = content
                };
            }
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

        private static string GenerateLargeResponseBody(int sizeInKB)
        {
            const string baseString = "This is a test string. ";
            int repetitions = (sizeInKB * 1024 * 1024) / baseString.Length;
            return new string('A', repetitions); // Create a large string filled with 'A's
        }

        //[System.Web.Http.HttpGet("download")]
        //public IHttpActionResult Download(int sizeInMB)
        //{
        //    // byte[] fileBytes = File.ReadAllBytes("path/to/file");
        //    // return File(fileBytes, "application/octet-stream", "filename.ext");
        //    string content = GenerateLargeResponseBody(sizeInMB);
        //    return new Product
        //    {
        //        Id = sizeInMB,
        //        Name = "Chair",
        //        Category = content
        //    };
        //}

    }
}