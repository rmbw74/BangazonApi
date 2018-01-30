//Author Ray Medrano
//Purpose is to allow bangazonians access to the employee resource through the url api/employee
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
    public class EmployeeController : Controller
    {
        private ApplicationDbContext _context;
        // Constructor method to create an instance of context to communicate with our database.
        public EmployeeController(ApplicationDbContext ctx)
        {
            _context = ctx;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var employees = _context.Employee.ToList();
            if (employees == null)
            {
                return NotFound();
            }
            return Ok(employees);
        }
        //This overloaded method will get a single employee by passing the employee id to the method
        // GET api/Employee/5
        [HttpGet("{id}", Name = "GetSingleEmployee")]
        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                //if is valid - find the single instance of employee where employee id = id
                Employee employee = _context.Employee.Single(g => g.Id == id);

                if (employee == null)
                {
                    return NotFound();
                }

                return Ok(employee);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound();
            }
        }
        //This method will post to the employee table when it is passed a valid JSON object
        //with the following format {"firstName": <string>,"lastName": <string>,"isSupervisor": <int>,"departmentId": <int>}
        // POST api/Employee
        [HttpPost]
        public IActionResult Post([FromBody]Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Employee.Add(employee);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (EmployeeExists(employee.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("GetSingleEmployee", new { id = employee.Id }, employee);
        }

       //This method will change an existing item in the database at the id at the end of the url when passed a vaid JSON object
        //with the following format {"id":<int>,firstName": <string>,"lastName": <string>,"isSupervisor": <int>,"departmentId": <int>}
        //the id property must match the id in the URL.
        // PUT api/Employee/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employee.Id)
            {
                return BadRequest();
            }
            _context.Employee.Update(employee);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
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


        private bool EmployeeExists(int EmployeeId)
        {
            return _context.Employee.Any(g => g.Id == EmployeeId);
        }

    }
}