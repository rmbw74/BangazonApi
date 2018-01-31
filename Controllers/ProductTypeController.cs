// Author : Chris Miller
// Expose the ProductType table to api access


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
    public class ProductTypeController : Controller
    {
        private ApplicationDbContext _context;
        // Constructor method to create an instance of context to communicate with our database.
        public ProductTypeController(ApplicationDbContext ctx)
        {
            _context = ctx;
        }

        // Use GET request to return a list of all producTypes
        // GET api/producttypes/
        [HttpGet]
        public IActionResult Get()
        {
            var producttypes = _context.ProductType.Select(pt => new {Id = pt.Id, Description = pt.Description}).ToList();
            if (producttypes == null)
            {
                return NotFound();
            }
            return Ok(producttypes);
        }

        
        // Use GET request to return a single all producTypes by passing in the id via route paramaters
        // GET api/productType/5
        [HttpGet("{id}", Name = "GetSingleProductType")]
        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var producttype = _context.ProductType.Select(pt => new {Id = pt.Id, Description = pt.Description}).Single(g => g.Id == id);

                if (producttype == null)
                {
                    return NotFound();
                }

                return Ok(producttype);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound(ex);
            }
        }

        // Use POST request to add product to the database using this format
        // {"description": "string"}
        // POST api/product
        [HttpPost]
        public IActionResult Post([FromBody]ProductType producttype)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ProductType.Add(producttype);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ProductTypeExists(producttype.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("GetSingleProductType", new { id = producttype.Id }, producttype);
        }
        // Use PUT method to edit producttypes in the database using this format
        // {"id": int, description": "string"}
        // PUT api/values/id
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]ProductType producttype)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != producttype.Id)
            {
                return BadRequest();
            }
            _context.ProductType.Update(producttype);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductTypeExists(id))
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

        // Remove an entry from the ProductType Table by passing the id in the rout paramaters
        // DELETE api/product/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ProductType producttype = _context.ProductType.Single(g => g.Id == id);

            if (producttype == null)
            {
                return NotFound();
            }
            _context.ProductType.Remove(producttype);
            _context.SaveChanges();
            return Ok(producttype);
        }

        private bool ProductTypeExists(int ProductTypeId)
        {
            return _context.ProductType.Any(g => g.Id == ProductTypeId);
        }

    }
}