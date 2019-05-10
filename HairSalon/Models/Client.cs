using System.Collections.Generic;
using System;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class Client
  {
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public DateTime ClientSince {get; set;}
    public int StylistId {get; set;}
    public int Id {get; set;}

    public Client (string firstName, string lastName, DateTime clientSince, int stylistId, int id = 0)
    {
      FirstName = firstName;
      LastName = lastName;
      ClientSince = clientSince;
      StylistId = stylistId;
      Id = id;
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM clients;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static List<Client> GetAll()
    {
      List<Client> allClients = new List<Client> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM clients;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int clientId = rdr.GetInt32(0);
        string clientFirstName = rdr.GetString(1);
        string clientLastName = rdr.GetString(2);
        DateTime clientSince = rdr.GetDateTime(3);
        int clientStylistId = rdr.GetInt32(4);
        Client newClient = new Client(clientFirstName, clientLastName, clientSince, clientStylistId, clientId);
        allClients.Add(newClient);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allClients;
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO clients (first_name, last_name, client_since, stylist_id) VALUES (@first_name, @last_name, @client_since, @stylist_id);";
      // cmd.Parameters.AddWithValue("@first_name", first_name);
      MySqlParameter firstName = new MySqlParameter();
      firstName.ParameterName = "@first_name";
      firstName.Value = this.FirstName;
      cmd.Parameters.Add(firstName);
      MySqlParameter lastName = new MySqlParameter();
      lastName.ParameterName = "@last_name";
      lastName.Value = this.LastName;
      cmd.Parameters.Add(lastName);
      MySqlParameter clientSince = new MySqlParameter();
      clientSince.ParameterName = "@client_since";
      clientSince.Value = this.ClientSince;
      cmd.Parameters.Add(clientSince);
      MySqlParameter stylistId = new MySqlParameter();
      stylistId.ParameterName = "@stylist_id";
      stylistId.Value = this.StylistId;
      cmd.Parameters.Add(stylistId);
      cmd.ExecuteNonQuery();
      Id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
  }
}
