using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using sweettarttart;
using SweetTartTartApi.Model;




namespace SweetTartTartApi.Controllers
{

  [ApiController]
  [Route("api/[controller]")]
  public class LocationsController : ControllerBase
  {

    private DatabaseContext db;

    public LocationsController()
    {
      this.db = new DatabaseContext();
    }
    [HttpGet]
    public ActionResult<List<Location>> Get()
    {
      // get all of our TartItem items

      var rv = db.Locations;
      return rv.ToList();
    }


    [HttpPost]
    public ActionResult<Location> Post([FromBody]Location location)
    {

      db.Locations.Add(location);
      db.SaveChanges();
      return location;
    }
    // 

    [HttpGet("{id}")]
    public ActionResult<Location> GetById([FromRoute]int id)
    {
      var db = new DatabaseContext();
      // i need to update the item text, complete, and updated at
      var location = db.Locations.FirstOrDefault(f => f.Id == id);
      if (location == null)
      {
        return NotFound();
      }
      return location;
    }

  }
}

