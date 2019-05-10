using System.Collections.Generic;
using System;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class Clients
  {
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public DateTime ClientSince {get; set;}
    public int StylistId {get; set;}
    public int Id {get; set;}

    public Restaurant (string firstName, string lastName, DateTime clientSince, int clientId, int id = 0)
    {
      FirstName = firstName;
      LastName = lastName;
      ClientSince = clientSince;
      ClientId = clientId;
      Id = id;
    }
  }
}
