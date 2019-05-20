using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace HairSalon.Models
{
  public class Specialty
  {
    public string Type {get; set;}
    public int Id {get; set;}

    public Specialty(string type, int id = 0)
    {
      Type = type;
      Id = id;
    }

    public override bool Equals(System.Object otherSpecialty)
    {
      if (!(otherSpecialty is Specialty))
      {
        return false;
      }
      else
      {
        Specialty newSpecialty = (Specialty) otherSpecialty;
        bool idEquality = this.Id.Equals(newSpecialty.Id);
        bool typeEquality = this.Type.Equals(newSpecialty.Type);
        return (idEquality && typeEquality);
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
      cmd.CommandText = @"DELETE FROM specialties;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }


    public static List<Specialty> GetAll()
    {
      List<Specialty> allSpecialties = new List<Specialty> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM specialties;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int SpecialtyId = rdr.GetInt32(0);
        string SpecialtyName = rdr.GetString(1);
        Specialty newSpecialty = new Specialty(SpecialtyName, SpecialtyId);
        allSpecialties.Add(newSpecialty);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allSpecialties;
    }


    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO specialties (type) VALUES (@type);";
      MySqlParameter type = new MySqlParameter();
      type.ParameterName = "@type";
      type.Value = this.Type;
      cmd.Parameters.Add(type);
      cmd.ExecuteNonQuery();
      Id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public void AddStylist(Stylist newStylist)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO stylists_specialties (specialty_id, stylist_id) VALUES (@SpecialtyId, @StylistId);";
      MySqlParameter specialty_id = new MySqlParameter();
      specialty_id.ParameterName = "@SpecialtyId";
      specialty_id.Value = Id;
      cmd.Parameters.Add(specialty_id);
      MySqlParameter stylist_id = new MySqlParameter();
      stylist_id.ParameterName = "@StylistId";
      stylist_id.Value = newStylist.Id;
      cmd.Parameters.Add(stylist_id);
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }


    public List<Stylist> GetStylists()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT stylists.* FROM specialties
      JOIN stylists_specialties ON (specialties.id = stylists_specialties.specialty_id)
      JOIN stylists ON (stylists_specialties.stylist_id = stylists.id)
      WHERE specialties.id = @SpeacialtyId;";
      MySqlParameter specialtyIdParameter = new MySqlParameter();
      specialtyIdParameter.ParameterName = "@SpeacialtyId";
      specialtyIdParameter.Value = Id;
      cmd.Parameters.Add(specialtyIdParameter);
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      List<Stylist> stylists = new List<Stylist>{};
      while(rdr.Read())
      {
        int stylistId = rdr.GetInt32(0);
        string stylistFirstName = rdr.GetString(1);
        string stylistLastName = rdr.GetString(2);
        Stylist newStylist = new Stylist(stylistFirstName, stylistLastName, stylistId);
        stylists.Add(newStylist);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return stylists;
    }

    public static Specialty Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM specialties WHERE id = (@searchId);";
      cmd.Parameters.AddWithValue("@searchId", id);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int SpecialtyId = 0;
      string SpecialtyType = "";
      while(rdr.Read())
      {
        SpecialtyId = rdr.GetInt32(0);
        SpecialtyType = rdr.GetString(1);
      }
      Specialty newSpecialty = new Specialty(SpecialtyType, SpecialtyId);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return newSpecialty;
    }

  }
}
