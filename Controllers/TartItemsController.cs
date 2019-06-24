using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using sweettarttart;
using SweetTartTartApi.Model;




namespace SweetTartTartApi.Controllers
{

  [ApiController]
  [Route("api/[controller]")]
  public class TartItemsController : ControllerBase
  {

    private DatabaseContext db;

    public TartItemsController()
    {
      this.db = new DatabaseContext();
    }
    [HttpGet]
    public ActionResult<List<SweetTartTart>> Get()
    {
      // get all of our TartItem items

      var rv = db.TartItems;
      return rv.ToList();
    }

    [HttpGet("outofstock")]
    public ActionResult<List<SweetTartTart>> GetAllOutOfStock()
    {
      // get all of our TartItem items

      var rv = db.TartItems.Where(x => x.NumberInStock < 1);
      return rv.ToList();
    }


    [HttpPost("{locationId}")]
    public ActionResult<SweetTartTart> Post([FromBody]SweetTartTart tartitem, [FromQuery]int locationId)
    {

      // get the user that has teh access token
      var location = db.Locations.FirstOrDefault(l => l.Id == locationId);
      if (location == null)
      {
        // if the user doesnt exist, make it
        location = new Location
        {
          Id = locationId
        };
        db.Locations.Add(location);
        db.SaveChanges();
      }
      // set the the item.UserId = user.id
      // somethingGoofy.UserId = user.Id;
      // db.ToDoItems.Add(somethingGoofy);

      location.Items.Add(tartitem);

      db.SaveChanges();
      return tartitem;
    }


    [HttpPut("{id}")]
    public ActionResult<SweetTartTart> UpdateItem([FromRoute]int id, [FromBody]SweetTartTart item)
    {

      // i need to update the item text, complete, and updated at
      var candy = db.TartItems.FirstOrDefault(f => f.Id == id);
      candy.SKU = item.SKU;
      candy.Name = item.Name;
      candy.ShortDescription = item.ShortDescription;
      candy.NumberInStock = item.NumberInStock;
      candy.Price = item.Price;
      candy.LocationId = item.LocationId;
      db.SaveChanges();
      return candy;
    }

    [HttpGet("{id}")]
    public ActionResult<SweetTartTart> GetById([FromRoute]int id)
    {
      var db = new DatabaseContext();
      // i need to update the item text, complete, and updated at
      var candy = db.TartItems.FirstOrDefault(f => f.Id == id);
      if (candy == null)
      {
        return NotFound();
      }
      return candy;
    }

    [HttpGet("SKU/{SKU}")]
    public ActionResult<SweetTartTart> GetBySKU([FromRoute]int SKU)
    {

      // i need to update the item text, complete, and updated at
      var candy = db.TartItems.FirstOrDefault(f => f.SKU == SKU);
      if (candy == null)
      {
        return NotFound();
      }
      return candy;
    }


    [HttpDelete("{id}")]
    public ActionResult DeleteItem(int id)
    {

      var item = db.TartItems.FirstOrDefault(f => f.Id == id);
      if (item == null)
      {
        return NotFound();
      }
      else
      {
        db.TartItems.Remove(item);
        db.SaveChanges();
        return Ok();
      }
    }

  }
}

