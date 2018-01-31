// Author : Chris Miller
// Expose the product table to api acess though api/product

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BangazonApi.Data;
using BangazonApi.Models;

namespace BangazonApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private ApplicationDbContext _context;
        // Constructor method to create an instance of context to communicate with our database.
        public ProductController(ApplicationDbContext ctx)
        {
            _context = ctx;
        }

        // Use GET request to return a list of all products - Include Owner information
        // GET api/product/
        [HttpGet]
        public IActionResult Get()
        {
            var products = _context.Product.Select(p => 
                new {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Quantity = p.Quantity,
                    Price = p.Price,
                    Owner = p.Customer,
                    ProductType = p.ProductType}).ToList();
            if (products == null)
            {
                return NotFound();
            }
            return Ok(products);
        }

        // Use GET request to return a single product - Include Owner information
        // GET api/product/#
        [HttpGet("{id}", Name = "GetSingleProduct")]
        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var product = _context.Product.Select(p => new {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Quantity = p.Quantity,
                    Price = p.Price,
                    Owner = p.Customer,
                    ProductType = p.ProductType
                }).Single(g => g.Id == id);

                if (product == null)
                {
                    return NotFound();
                }

                return Ok(product);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound(ex);
            }
        }

        // Use POST request to add product to the database using this format
        // { "name": "string", "description": "string", "price": int, "quantity": int, "customerId": int }
        // POST api/product
        [HttpPost]
        public IActionResult Post([FromBody]Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Product.Add(product);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ProductExists(product.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("GetSingleProduct", new { id = product.Id }, product);
        }

        // Edit an entry in the product table with the PUT command using the following format
        // { "id": int, "name": "string", "description": "string", "price": int, "quantity": int, "customerId": int }
        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.Id)
            {
                return BadRequest();
            }
            _context.Product.Update(product);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return new StatusCodeResult(StatusCodes.Status204NoContent);
        }

        // Remove an entry from the Product Table by passing the id in the rout paramaters
        // DELETE api/product/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Product product = _context.Product.Single(g => g.Id == id);

            if (product == null)
            {
                return NotFound();
            }
            _context.Product.Remove(product);
            _context.SaveChanges();
            return Ok(product);
        }

        private bool ProductExists(int ProductId)
        {
            return _context.Product.Any(g => g.Id == ProductId);
        }

    }
}