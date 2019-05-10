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

    public override bool Equals(System.Object otherClient)
    {
      if (!(otherClient is Client))
      {
        return false;
      }
      else
      {
        Client newClient = (Client) otherClient;
        bool idEquality = this.Id == newClient.Id;
        bool firstNameEquality = this.FirstName == newClient.FirstName;
        bool lastNameEquality = this.LastName == newClient.LastName;
        bool clientSinceEquality = this.ClientSince == newClient.ClientSince;
        bool stylistEquality = this.StylistId == newClient.StylistId;
        return (idEquality && firstNameEquality && lastNameEquality && clientSinceEquality && stylistEquality);
      }
    }

    public override int GetHashCode()
    {
      return this.Id.GetHashCode();
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
      cmd.CommandText = @"INSERT INTO clients (first_name, last_name, client_since, stylist_id) VALUES (@first_name, @last_name, @client_since, @stylistId);";
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
      stylistId.ParameterName = "@stylistId";
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
    public static Client Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM clients WHERE id = (@searchId);";
      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = id;
      cmd.Parameters.Add(searchId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int clientId = 0;
      string clientFirstName = "";
      string clientLastName = "";
      DateTime clientSince = DateTime.Today;
      int clientStylistId = 0;
      while(rdr.Read())
      {
        clientId = rdr.GetInt32(0);
        clientFirstName = rdr.GetString(1);
        clientLastName = rdr.GetString(2);
        clientSince = rdr.GetDateTime(3);
        clientStylistId = rdr.GetInt32(4);

      }
      Client newClient = new Client(clientFirstName, clientLastName, clientSince, clientStylistId, clientId);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return newClient;
    }

    public void Edit(string newFirstName, string newLastName, DateTime newClientSince)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmdFirstName = conn.CreateCommand() as MySqlCommand;
      cmdFirstName.CommandText = @"UPDATE clients SET first_name = @newFirstName WHERE id = @searchId;";
      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = Id;
      cmdFirstName.Parameters.Add(searchId);

      FirstName = newFirstName;
      MySqlParameter firstName = new MySqlParameter();
      firstName.ParameterName = "@newFirstName";
      firstName.Value = newFirstName;
      cmdFirstName.Parameters.Add(firstName);

      LastName = newLastName;
      var cmdLastName = conn.CreateCommand() as MySqlCommand;
      cmdLastName.CommandText = @"UPDATE clients SET last_name = @newLastName WHERE id = @searchId;";
      cmdLastName.Parameters.Add(searchId);
      MySqlParameter lastName = new MySqlParameter();
      lastName.ParameterName = "@newLastName";
      lastName.Value = newLastName;
      cmdLastName.Parameters.Add(lastName);

      ClientSince = newClientSince;
      var cmdClientSince = conn.CreateCommand() as MySqlCommand;
      cmdClientSince.CommandText = @"UPDATE clients SET client_since = @newClientSince WHERE id = @searchId;";
      cmdClientSince.Parameters.Add(searchId);
      MySqlParameter clientSince = new MySqlParameter();
      clientSince.ParameterName = "@newClientSince";
      clientSince.Value = newClientSince;
      cmdClientSince.Parameters.Add(clientSince);

      cmdFirstName.ExecuteNonQuery();
      cmdLastName.ExecuteNonQuery();
      cmdClientSince.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public void DeleteClient()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM clients WHERE id = @thisId;";
      MySqlParameter thisId = new MySqlParameter();
      thisId.ParameterName = "@thisId";
      thisId.Value = Id;
      cmd.Parameters.Add(thisId);
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

  }
}
