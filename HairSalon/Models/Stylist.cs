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
    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO stylist (first_name, last_name) VALUES (@firstName, @lastName);";
      MySqlParameter firstName = new MySqlParameter();
      firstName.ParameterName = "@firstName";
      firstName.Value = this.FirstName;

      MySqlParameter lastName = new MySqlParameter();
      lastName.ParameterName = "@lastName";
      lastName.Value = this.LastName;

      cmd.Parameters.Add(firstName);
      cmd.Parameters.Add(lastName);
      cmd.ExecuteNonQuery();
      Id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static List<Stylist> GetAll()
    {
      List<Stylist> allStylists = new List<Stylist> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM stylists;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int StylistId = rdr.GetInt32(0);
        string StylistFirstName = rdr.GetString(1);
        string StylistLastName = rdr.GetString(2);
        Stylist newStylist = new Stylist(StylistFirstName, StylistLastName, StylistId);
        allStylists.Add(newStylist);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allStylists;
    }

  }
}
