using System.Collections.Generic;
using System;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class Stylist
  {
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public int Id {get; set;}

    public Stylist (string firstName, string lastName, int id = 0)
    {
      FirstName = firstName;
      LastName = lastName;
      Id = id;
    }
  }
}
