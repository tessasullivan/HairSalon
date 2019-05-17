using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class Client
  {
    int _id;
    private string _firstName;
    private string _lastName;
    private string _phoneNumber;
    private string _notes;
    private int _stylistId;

    public Client(string firstName, string lastName, string phoneNumber, int stylistId, string notes= "notes", int id = 0)
    {
      _id = id;
      _firstName = firstName;
      _lastName = lastName;
      _phoneNumber = phoneNumber;
      _notes = notes;
      _stylistId = stylistId;
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
    public string GetNotes()
    {
      return _notes;
    }
    public void SetNotes(string notes)
    {
      _notes = notes;
    }
    public int GetId()
    {
      return _id;
    }
    public int GetStylistId()
    {
      return _stylistId;
    }
    public void SetStylistId(int stylistId)
    {
      _stylistId = stylistId;
    }
    public override int GetHashCode()
    {
      return this.GetId().GetHashCode();
    }
    public override bool Equals(System.Object client2)
    {
      if (!(client2 is Client))
      {
        return false;
      }
      else 
      {
        Client client1 = (Client) client2;
        bool idEquality = (this.GetId() == client1.GetId());
        bool firstNameEquality = (this.GetFirstName() == client1.GetFirstName());
        bool lastNameEquality = (this.GetLastName() == client1.GetLastName());
        bool phoneNumberEquality = (this.GetPhoneNumber() == client1.GetPhoneNumber());
        bool stylistIdEquality = (this.GetStylistId() == client1.GetStylistId());
        bool notesEquality = (this.GetNotes() == client1.GetNotes());
        return (idEquality && firstNameEquality && lastNameEquality && phoneNumberEquality && stylistIdEquality && notesEquality);
      }
    }
    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO clients (first_name, last_name, phone_number, notes, stylist_id) VALUES (@FirstName, @LastName, @phoneNumber, @Notes, @stylistId);";
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
      MySqlParameter notes = new MySqlParameter();
      notes.ParameterName = "@Notes";
      notes.Value = this._notes;
      cmd.Parameters.Add(notes);
      MySqlParameter stylistId = new MySqlParameter();
      stylistId.ParameterName = "@stylistId";
      stylistId.Value = this._stylistId;
      cmd.Parameters.Add(stylistId);
      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;

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
      cmd.CommandText = @"SELECT * FROM clients where id = (@clientId);";
      MySqlParameter clientId = new MySqlParameter();
      clientId.ParameterName = "@clientId";
      clientId.Value = id;
      cmd.Parameters.Add(clientId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int dbId = 0;
      string firstName = "";
      string lastName = "";
      string phoneNumber = "";
      string notes = "";
      int stylistId = 0;
      while (rdr.Read())
      {
        dbId = rdr.GetInt32(0);
        firstName = rdr.GetString(1);
        lastName = rdr.GetString(2);
        phoneNumber = rdr.GetString(3);
        notes = rdr.GetString(4);
        stylistId = rdr.GetInt32(5);
      }
      if (notes == "Notes")
      {
        notes = "";
      }
      Client foundClient = new Client(firstName, lastName, phoneNumber, stylistId, notes, dbId);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return foundClient;
    }
    public void Delete()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM clients where id = (@id);";
      MySqlParameter thisId = new MySqlParameter("@id", _id);
      cmd.Parameters.Add(thisId);
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
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM clients ORDER BY last_name;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int dbId = 0;
      string firstName = "";
      string lastName = "";
      string phoneNumber = "";
      int stylistId = 0;
      string notes = "";
      while (rdr.Read())
      {
        dbId = rdr.GetInt32(0);
        firstName = rdr.GetString(1);
        lastName = rdr.GetString(2);
        phoneNumber = rdr.GetString(3);
        notes = rdr.GetString(4);
        stylistId = rdr.GetInt32(5);
        Client client = new Client(firstName, lastName, phoneNumber, stylistId, notes, dbId);
        allClients.Add(client);
      }
      conn.Close();
      if (conn != null)
      {
          conn.Dispose();
      }
      return allClients;          
    }
    public static void DeleteAll()
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
    public string GetStylistName(int stylistId)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM stylists where id = @stylistId;";
      MySqlParameter stylistIdParameter = new MySqlParameter("@stylistId", stylistId);
      cmd.Parameters.Add(stylistIdParameter);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      string firstName = "";
      string lastName = "";
      while (rdr.Read())
      {
        firstName = rdr.GetString(1);
        lastName = rdr.GetString(2);     
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return firstName + " " + lastName;
    }
    public void Edit(string first, string last, string phone, int stylistId, string notes)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText=@"UPDATE clients 
        SET first_name = @first, last_name = @last, phone_number=@phone, notes=@notes, stylist_id = @stylistId 
        WHERE id = @thisId;";
      
      MySqlParameter firstName = new MySqlParameter("@first", first);      
      MySqlParameter lastName = new MySqlParameter("@last", last);      
      MySqlParameter phoneNumber = new MySqlParameter("@phone", phone);
      MySqlParameter notesParameter = new MySqlParameter("@notes", notes);
      MySqlParameter thisId = new MySqlParameter("@thisId", _id);      
      MySqlParameter thisStylistId = new MySqlParameter("@stylistId", stylistId);      
      cmd.Parameters.Add(firstName);    
      cmd.Parameters.Add(lastName);    
      cmd.Parameters.Add(phoneNumber);
      cmd.Parameters.Add(notesParameter);
      cmd.Parameters.Add(thisId);
      cmd.Parameters.Add(thisStylistId);

      cmd.ExecuteNonQuery();
      _firstName = first;
      _lastName = last;
      _phoneNumber = phone;
      _notes = notes;
      _stylistId = stylistId;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }      
    }
  }
}