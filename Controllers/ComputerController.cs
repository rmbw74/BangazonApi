//Author: Chase Steely
//Purpose: To allow Bangazonians to access Computer table in the API, allowing them to GET, PUT, POST, and DELETE
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BangazonApi.Data;
using BangazonApi.Models;

namespace BangazonApi.Controllers
{
    [Route("api/[controller]")]
    public class ComputerController : Controller
    {
        private ApplicationDbContext _context;
        // Constructor method to create an instance of context to communicate with our database.
        public ComputerController(ApplicationDbContext ctx)
        {
            _context = ctx;
        }
        //Gets all computers in the API
        //GET api/Computer/
        [HttpGet]
        public IActionResult Get()
        {
            var computer = _context.Computer.ToList();
            if (computer == null)
            {
                return NotFound();
            }
            return Ok(computer);
        }
        //Gets a single computer in the API by id
        // GET api/Computer/id
        [HttpGet("{id}", Name = "GetSingleComputer")]
        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Computer computer = _context.Computer.Single(g => g.Id == id);

                if (computer == null)
                {
                    return NotFound();
                }

                return Ok(computer);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound(ex);
            }
        }
        // Allows you to post/add a computer to the api
        // POST api/Computer
        [HttpPost]
        public IActionResult Post([FromBody]Computer computer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Computer.Add(computer);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ComputerExists(computer.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("GetSingleComputer", new { id = computer.Id }, computer);
        }
        //Allows you to edit data on the Computer table for a single computer by id
        // PUT api/Computer/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Computer computer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != computer.Id)
            {
                return BadRequest();
            }
            _context.Computer.Update(computer);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComputerExists(id))
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
        //Allows you to delete a row in the Computer table for a single computer by id
        // DELETE api/Computer/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Computer computer = _context.Computer.Single(g => g.Id == id);

            if (computer == null)
            {
                return NotFound();
            }
            _context.Computer.Remove(computer);
            _context.SaveChanges();
            return Ok(computer);
        }

        private bool ComputerExists(int ComputerId)
        {
            return _context.Computer.Any(g => g.Id == ComputerId);
        }

    }
}