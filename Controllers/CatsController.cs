using System.Collections.Generic;
using latewin21_petshop.db;
using latewin21_petshop.Models;
using Microsoft.AspNetCore.Mvc;

namespace latewin21_petshop.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CatsController : ControllerBase
  {

    //actionResult is a wrapper that handles the request status.
    [HttpGet]
    public ActionResult<IEnumerable<Cat>> Get()
    {
      try
      {
        return Ok(FakeDB.Cats);
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    //FROMBODY uses a parameterless class constructor to map data over from the request to the model.
    [HttpPost]
    public ActionResult<Cat> Create([FromBody] Cat newCat)
    {
      try
      {
        FakeDB.Cats.Add(newCat);
        return Ok(newCat);
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    // .get("/:catId", this.GetCat)

    [HttpGet("{catId}")]
    public ActionResult<Cat> GetCat(string catId)
    {
      try
      {
        Cat catFound = FakeDB.Cats.Find(c => c.Id == catId);
        if (catFound == null)
        {
          throw new System.Exception("Cat does not exist");
        }
        return Ok(catFound);
        //NOTE can use exists to see if a list contains something, but it returns a bool so be cautious when returning.
        // bool catFound = FakeDB.Cats.Exists(c => c.Id == catId);
        // if (catFound == false)
        // {
        //   throw new System.Exception("Cat does not exist");
        // }
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<string> DeleteCat(string id)
    {
      try
      {
        Cat catToRemove = FakeDB.Cats.Find(c => c.Id == id);
        if (FakeDB.Cats.Remove(catToRemove))
        {
          return Ok("Cat Delorted");
        }
        else
        {
          throw new System.Exception("This cat does not exist.");
        }
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }


    //     .get("/:catId/kittens", this.GetKittens)

    //    [HttpGet("{catId}/kittens")]
    //     public ActionResult<IEnumerable<Kitten>> GetKittens(string catId)
    //     {
    //      
    //     }

  }
}