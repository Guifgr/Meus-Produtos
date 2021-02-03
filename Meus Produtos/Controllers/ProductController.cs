using Meus_Produtos.Models;
using Meus_Produtos.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Meus_Produtos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;

        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet]
        public ActionResult GetAllProducts()
        {
            //This return will check in the DB all persons and return an Object with all person objects
            return Ok(_productService.FindAll());
        }

        [HttpGet("{param}")]
        public IActionResult GetProductById(long param)
        {
            long Id = param;
            //Get Person and save in a variable 
            var person = _productService.FindById(Id);

            //Check if .this person exists if !exists then return an 404 not found
            if (person == null) return NotFound();

            //If the person with the specifield id exists then will return all the data from the DB in an single object
            return Ok(person);
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            //If the person object !exists then will return an BadRequest 
            if (product == null) return BadRequest();
            //If all person data is ok then will create an new person and save in the DB
            return Ok(_productService.Create(product));
        }

        [HttpPut]
        public IActionResult UpdateProduct([FromBody] Product product)
        {
            //If the person object !exists then will return an BadRequest 
            if (product == null) return BadRequest();
            //If all person data is ok then will Update person and save in the DB
            return Ok(_productService.Update(product));
        }


        [HttpDelete("{param}")]
        public IActionResult DeleteProductById(long param)
        {
            long id = param;
            //Get Person and save in a variable 
            _productService.Delete(id);

            //If the person with the specifield id exists then will return all the data from the DB in an single object
            return NoContent();
        }
    }
}
