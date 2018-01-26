//Author Ray Medrano
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
    public class DepartmentController : Controller
    {
        private ApplicationDbContext _context;
        // Constructor method to create an instance of context to communicate with our database.
        public DepartmentController(ApplicationDbContext ctx)
        {
            _context = ctx;
        }
        //this get method will return a list of all departments.
        [HttpGet]
        public IActionResult Get()
        {
            var departments = _context.Department.ToList();
            if (departments == null)
            {
                return NotFound();
            }
            return Ok(departments);
        }
        //This overloaded method will get a single department by passing the department id to the method
        // GET api/Department/1
        [HttpGet("{id}", Name = "GetSingleDepartment")]
        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                //if is valid - find the single instance of department where department id = id
                Department department = _context.Department.Single(g => g.Id == id);

                if (department == null)
                {
                    return NotFound();
                }

                return Ok(department);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound();
            }
        }
        //This method will post to the department table when it is passed a valid JSON object
        // POST api/Department
        [HttpPost]
        public IActionResult Post([FromBody]Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Department.Add(department);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DepartmentExists(department.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("GetSingleDepartment", new { id = department.Id }, department);
        }
        //This method will change an existing item in the database at the id at the end of the url when passed a vaid JSON object
        // PUT api/Department/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != department.Id)
            {
                return BadRequest();
            }
            _context.Department.Update(department);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(id))
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


        private bool DepartmentExists(int DepartmentId)
        {
            return _context.Department.Any(g => g.Id == DepartmentId);
        }

    }
}