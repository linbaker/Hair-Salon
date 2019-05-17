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
