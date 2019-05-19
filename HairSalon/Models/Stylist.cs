using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class Stylist
  {
    private int _id;
    private string _firstName;
    private string _lastName;
    private string _phoneNumber;
    public Stylist(string firstName, string lastName, string phoneNumber, int id = 0)
    {
      _id = id;
      _firstName = firstName;
      _lastName = lastName;
      _phoneNumber = phoneNumber;
    }
    public string GetFirstName()
    {
      return _firstName;
    }
    public void SetFirstName(string firstName)
    {
      _firstName = firstName;
    }
    public string GetLastName()
    {
      return _lastName;
    }
    public void SetLastName(string lastName)
    {
      _lastName = lastName;
    }
    public string GetPhoneNumber()
    {
      return _phoneNumber;
    }
    public void SetPhoneNumber(string phoneNumber)
    {
      _phoneNumber = phoneNumber;
    }
    public int GetId()
    {
      return _id;
    }
    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM stylists;DELETE FROM specialties_stylists;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
    public override int GetHashCode()
    {
      return this.GetId().GetHashCode();
    }
    public override bool Equals(System.Object stylist2)
    {
      if (!(stylist2 is Stylist))
      {
        return false;
      }
      else 
      {
        Stylist stylist1 = (Stylist) stylist2;
        bool idEquality = (this.GetId() == stylist1.GetId());
        bool firstNameEquality = (this.GetFirstName() == stylist1.GetFirstName());
        bool lastNameEquality = (this.GetLastName() == stylist1.GetLastName());
        return (idEquality && firstNameEquality && lastNameEquality);
      }
    }    
    public static Stylist Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM stylists where id = (@stylistId);";
      MySqlParameter stylistId = new MySqlParameter();
      stylistId.ParameterName = "@stylistId";
      stylistId.Value = id;
      cmd.Parameters.Add(stylistId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int dbId = 0;
      string firstName = "";
      string lastName = "";
      string phoneNumber = "";
      while (rdr.Read())
      {
        dbId = rdr.GetInt32(0);
        firstName = rdr.GetString(1);
        lastName = rdr.GetString(2);
        phoneNumber = rdr.GetString(3);
      }
      Stylist foundStylist = new Stylist(firstName, lastName, phoneNumber, dbId);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return foundStylist;
    }
    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO stylists (first_name, last_name, phone_number) VALUES (@FirstName, @LastName, @phoneNumber);";
      MySqlParameter firstName = new MySqlParameter();
      firstName.ParameterName = "@FirstName";
      firstName.Value = this._firstName;
      cmd.Parameters.Add(firstName);
      MySqlParameter lastName = new MySqlParameter();
      lastName.ParameterName = "@LastName";
      lastName.Value = this._lastName;
      cmd.Parameters.Add(lastName);
      MySqlParameter phoneNumber = new MySqlParameter();
      phoneNumber.ParameterName = "@phoneNumber";
      phoneNumber.Value = this._phoneNumber;
      cmd.Parameters.Add(phoneNumber);
      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
    public static List<Stylist> GetAll()
    {
      List<Stylist> allStylists = new List<Stylist>{};

      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM stylists ORDER BY last_name;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int dbId = 0;
      string firstName = "";
      string lastName = "";
      string phoneNumber = "";
      while (rdr.Read())
      {
        dbId = rdr.GetInt32(0);
        firstName = rdr.GetString(1);
        lastName = rdr.GetString(2);
        phoneNumber = rdr.GetString(3);
        Stylist stylist = new Stylist(firstName, lastName, phoneNumber, dbId);
        allStylists.Add(stylist);
      }
      conn.Close();
      if (conn != null)
      {
          conn.Dispose();
      }
      return allStylists;
    }
    public List<Client> GetClients()
    {
      List<Client> allClients = new List<Client> {};

      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM clients where stylist_id = (@stylist_id) ORDER BY last_name;";
      MySqlParameter stylist_id = new MySqlParameter();
      stylist_id.ParameterName = "@stylist_id";
      stylist_id.Value = _id;
      cmd.Parameters.Add(stylist_id);

      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int dbId = 0;
      string firstName = "";
      string lastName = "";
      string phoneNumber = "";
      string notes ="";
      while (rdr.Read())
      {
        dbId = rdr.GetInt32(0);
        firstName = rdr.GetString(1);
        lastName = rdr.GetString(2);
        phoneNumber = rdr.GetString(3);
        notes = rdr.GetString(4);

        Client client = new Client(firstName, lastName, phoneNumber, _id, notes, dbId);
        allClients.Add(client);
      }
      conn.Close();
      if (conn != null)
      {
          conn.Dispose();
      }
      return allClients;
    }
    public void Delete()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM stylists where id = (@id);DELETE FROM specialties_stylists WHERE stylist_id = (@id);";
      MySqlParameter thisId = new MySqlParameter("@id", _id);
      cmd.Parameters.Add(thisId);
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
    public void Edit(string first, string last, string phone)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText=@"UPDATE stylists SET first_name = @first, last_name = @last, phone_number=@phone WHERE id = @thisId;";
      
      MySqlParameter firstName = new MySqlParameter("@first", first);      
      MySqlParameter lastName = new MySqlParameter("@last", last);      
      MySqlParameter phoneNumber = new MySqlParameter("@phone", phone);
      MySqlParameter thisId = new MySqlParameter("@thisId", _id);      
      cmd.Parameters.Add(firstName);    
      cmd.Parameters.Add(lastName);    
      cmd.Parameters.Add(phoneNumber);
      cmd.Parameters.Add(thisId);

      cmd.ExecuteNonQuery();
      _firstName = first;
      _lastName = last;
      _phoneNumber = phone;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }      
    }
    public void AddSpecialty(Specialty specialty)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO specialties_stylists (specialty_id, stylist_id) VALUES (@specialtyId, @stylistId);";
      MySqlParameter specialtyId = new MySqlParameter("@specialtyId", specialty.GetId());
      MySqlParameter stylistId = new MySqlParameter("@stylistId", _id);
      cmd.Parameters.Add(specialtyId);
      cmd.Parameters.Add(stylistId);
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }        
    }
    public void RemoveSpecialty(Specialty specialty)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM specialties_stylists WHERE specialty_id = @specialtyId;";
      int specialtyId = specialty.GetId();
      MySqlParameter specialtyIdParameter = new MySqlParameter("@specialtyID", specialtyId);
      cmd.Parameters.Add(specialtyIdParameter);
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }      
    }
    public List<Specialty> GetSpecialties()
    {
      List<Specialty> allSpecialties = new List<Specialty>{};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand; 
      cmd.CommandText = @"SELECT specialties.* FROM stylists
        JOIN specialties_stylists ON (stylists.id = specialties_stylists.stylist_id)
        JOIN specialties ON (specialties.id = specialties_stylists.specialty_id)
        WHERE stylists.id = @thisId ORDER BY specialty;";
      MySqlParameter thisId = new MySqlParameter("@thisId", _id);
      cmd.Parameters.Add(thisId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
        int specialtyId = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        Specialty specialty = new Specialty(name, specialtyId);
        allSpecialties.Add(specialty);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allSpecialties;
    }
  }
}