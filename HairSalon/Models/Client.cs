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
    private int _stylistId;

    public Client(string firstName, string lastName, string phoneNumber, int stylistId, int id = 0)
    {
      _id = id;
      _firstName = firstName;
      _lastName = lastName;
      _phoneNumber = phoneNumber;
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
    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO clients (first_name, last_name, phone_number, stylist_id) VALUES (@FirstName, @LastName, @phoneNumber, @stylistId);";
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
      int stylistId = 0;
      while (rdr.Read())
      {
        dbId = rdr.GetInt32(0);
        firstName = rdr.GetString(1);
        lastName = rdr.GetString(2);
        phoneNumber = rdr.GetString(3);
        stylistId = rdr.GetInt32(4);
      }
      Client foundClient = new Client(firstName, lastName, phoneNumber, stylistId, dbId);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return foundClient;
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
        return (idEquality && firstNameEquality && lastNameEquality && phoneNumberEquality && stylistIdEquality);
      }
    }
  }
}