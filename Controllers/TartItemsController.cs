using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using sweettarttart;
using SweetTartTartApi.Models;




namespace SweetTartTartApi.Controllers
{

  [ApiController]
  [Route("api/[controller]")]
  public class TartItemsController : ControllerBase
  {
    // [HttpGet]
    // public ActionResult<List<TartItem>> Get()
    // {
    //   // get all of our TartItem items
    //   var db = new DatabaseContext();
    //   var rv = db.TartItems;
    //   return rv.ToList();
    // }

    [HttpPost]
    public ActionResult<SweetTartTart> Post([FromBody]SweetTartTart candy)
    {
      var db = new DatabaseContext();
      db.TartItems.Add(candy);
      db.SaveChanges();
      return candy;
    }

  }
}

