using System.Collections.Generic;

namespace SweetTartTartApi.Model
{
  public class Location
  {
    public int Id { get; set; }
    public string Address { get; set; }
    public string ManagerName { get; set; }
    public string PhoneNumber { get; set; }

    public List<SweetTartTart> Items { get; set; } = new List<SweetTartTart>();
  }
}

