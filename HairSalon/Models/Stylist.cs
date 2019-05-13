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
    private List<Client> _clients;
    public Stylist(string firstName, string lastName, string phoneNumber, int id = 0)
    {
      _id = id;
      _firstName = firstName;
      _lastName = lastName;
      _phoneNumber = phoneNumber;
      _clients = new List<Client>{};
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
    public void AddClient(Client client)
    {
      _clients.Add(client);
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
      cmd.CommandText = @"SELECT * FROM stylists;";
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
    public List<Client> GetClients(int stylistId)
    {
      List<Client> allClients = new List<Client> {};

      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM clients where stylist_id = (@stylist_id);";
      MySqlParameter stylist_id = new MySqlParameter();
      stylist_id.ParameterName = "@stylist_id";
      stylist_id.Value = stylistId;
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


    public void Delete(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM stylists where id = (@id);";
      MySqlParameter thisId = new MySqlParameter();
      thisId.ParameterName = "@id";
      thisId.Value = id;
      cmd.Parameters.Add(thisId);
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM stylists;";
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
  }
}