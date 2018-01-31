 //Author: Kolden Prue 
//Purpose: To allow Bangazonians to access the training table in the API, allowing them to GET, PUT, POST, and DELETE(only dates that are yet to come)
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
  public class TrainingController : Controller
  {
    private ApplicationDbContext _context;
    // Constructor method to create an instance of context to communicate with our database.
    public TrainingController(ApplicationDbContext ctx)
    {
      _context = ctx;
    }

    [HttpGet]
    public IActionResult Get()
    {
      var trainings = _context.Training.ToList();
      if (trainings == null)
      {
        return NotFound();
      }
      return Ok(trainings);
    }

    // GET api/product/5
    [HttpGet("{id}", Name = "GetSingleTraining")]
    public IActionResult Get(int id)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      try
      {
        Training training = _context.Training.Single(g => g.Id == id);

        if (training == null)
        {
          return NotFound();
        }

        return Ok(training);
      }
      catch (System.InvalidOperationException ex)
      {
        return NotFound(ex);
      }
    }

    // POST api/values
    [HttpPost]
    public IActionResult Post([FromBody]Training training)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      _context.Training.Add(training);

      try
      {
        _context.SaveChanges();
      }
      catch (DbUpdateException)
      {
        if (TrainingExists(training.Id))
        {
          return new StatusCodeResult(StatusCodes.Status409Conflict);
        }
        else
        {
          throw;
        }
      }
      return CreatedAtRoute("GetSingleTraining", new { id = training.Id }, training);
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody]Training training)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      if (id != training.Id)
      {
        return BadRequest();
      }
      _context.Training.Update(training);
      try
      {
        _context.SaveChanges();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!TrainingExists(id))
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

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      Training training = _context.Training.Single(g => g.Id == id);

      if (training == null)
      {
        return NotFound();
      }
      //Here we are comparing the dates from training.Start to the current date to make sure a prior training program isn't deleted. The Compare() method and c# does this and returns a value of a negative, 0 , or above zero to base the comparison.
      
      DateTime today = DateTime.Now;
      DateTime TrainingDate = training.Start;
      int comparison = DateTime.Compare(today, TrainingDate);
      if (comparison >= 0)
      {
        return BadRequest();
      }
      else
      {

        _context.Training.Remove(training);
        _context.SaveChanges();
        return Ok(training);
      }
    }

    private bool TrainingExists(int TrainingId)
    {
      return _context.Training.Any(g => g.Id == TrainingId);
    }

  }
}