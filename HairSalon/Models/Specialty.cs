using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class Specialty
  {
    int _id;
    private string _specialty;

    public Specialty(string specialty, int id=0)
    {
      _id = id;
      _specialty = specialty;
    }
    public string GetSpecialty()
    {
      return _specialty;
    }
    public void SetSpecialty(string speciality)
    {
      _specialty = speciality;
    }
    public int GetId()
    {
      return _id;
    }
    public override int GetHashCode()
    {
      return this.GetId().GetHashCode();
    }
    public override bool Equals(System.Object speciality2)
    {
      if (!(speciality2 is Specialty))
      {
        return false;
      }
      else 
      {
        Specialty speciality1 = (Specialty) speciality2;
        bool idEquality = (this.GetId() == speciality1.GetId());
        bool specialityEq = (this.GetSpecialty() == speciality1.GetSpecialty());
        return (idEquality && specialityEq);
      }
    }
    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM specialties;DELETE FROM specialties_stylists;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }      
    }
    public void Delete()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM specialties WHERE id = (@thisId);DELETE FROM specialties_stylists WHERE specialty_id = (@thisId);";
      MySqlParameter thisId = new MySqlParameter("@thisId", _id);
      cmd.Parameters.Add(thisId);
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }      
    }
    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO specialties (specialty) VALUES (@name);";
      MySqlParameter speciality = new MySqlParameter("@name", _specialty);
      cmd.Parameters.Add(speciality);
      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }           
    }
    public static Specialty Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM specialties WHERE id = (@thisId);";
      MySqlParameter specialityParameter = new MySqlParameter("@thisId", id);
      cmd.Parameters.Add(specialityParameter);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int dbId = 0;
      string speciality = "";
      while (rdr.Read())
      {
        dbId = rdr.GetInt32(0);
        speciality = rdr.GetString(1);
      }
      Specialty foundSpeciality = new Specialty(speciality, dbId);

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return foundSpeciality;
    }
    public void Edit(string specialty)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE specialties SET specialty = (@specialty) WHERE id = @thisId;";
      MySqlParameter specialtyParameter = new MySqlParameter("@specialty", specialty);
      MySqlParameter thisId = new MySqlParameter("@thisId", _id);
      cmd.Parameters.Add(specialtyParameter);
      cmd.Parameters.Add(thisId);
      cmd.ExecuteNonQuery();
      _specialty = specialty;
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
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM specialties;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int dbId = 0;
      string name = "";
      while (rdr.Read())
      {
        dbId = rdr.GetInt32(0);
        name = rdr.GetString(1);
        Specialty speciality = new Specialty(name, dbId);
        allSpecialties.Add(speciality);     
      }      
      conn.Close();
      if (conn != null)
      {
          conn.Dispose();
      }
      return allSpecialties;
    }
    public void AddStylist(Stylist stylist)
    {
      int stylistId = stylist.GetId();
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO specialties_stylists (specialty_id, stylist_id) VALUES (@specialtyId, @stylistId);";
      MySqlParameter specialtyId = new MySqlParameter("@specialtyId", _id);
      MySqlParameter stylistIdParameter = new MySqlParameter("@stylistId", stylistId);
      cmd.Parameters.Add(specialtyId);
      cmd.Parameters.Add(stylistIdParameter);
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      } 
    }
    public void RemoveStylist(Stylist stylist)
    {
      int stylistId = stylist.GetId();
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM specialties_stylists WHERE stylist_id = @stylistId;"; 
      MySqlParameter stylistIdParameter = new MySqlParameter("@stylistId", stylistId);
      cmd.Parameters.Add(stylistIdParameter);
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }            
    }
    public List<Stylist> GetStylists()
    {
      List<Stylist> allStylists = new List<Stylist>{};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT stylists.* FROM specialties
        JOIN specialties_stylists ON (specialties.id = specialties_stylists.specialty_id)
        JOIN stylists ON (stylists.id = specialties_stylists.stylist_id)
        WHERE specialties.id = @thisId;";
      MySqlParameter thisId = new MySqlParameter("@thisId", _id);
      cmd.Parameters.Add(thisId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
        int stylistId = rdr.GetInt32(0);
        string first = rdr.GetString(1);
        string last = rdr.GetString(2);
        string phone = rdr.GetString(3);
        Stylist stylist = new Stylist(first, last, phone, stylistId);
        allStylists.Add(stylist);
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
