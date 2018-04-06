using ExampleApp.Infraestructure;
using ExampleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ExampleApp.Controllers
{
    public class ProductsController : ApiController
    {
        IRepository repo;

        public ProductsController(IRepository repoImpl) {
            repo = repoImpl;
        }

        // GET api/<controller>
        public IHttpActionResult GetAll()
        {
            return Ok(repo.Products);
        }

        public IHttpActionResult Delete(int id)
        {
            repo.DeleteProduct(id);
            return new NoContentResult();
        }

        public void Post(Product product)
        {
            repo.SaveProduct(product);
        }

        [HttpGet]
        [Route("api/products/noop")]
        public IHttpActionResult NoOp() => Ok();
    }
}