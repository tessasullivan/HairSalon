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
    public Client(string firstName, string lastName, int id = 0)
    {
      _id = id;
      _firstName = firstName;
      _lastName = lastName;
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
    public int GetId()
    {
      return _id;
    }
    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO clients (first_name, last_name) VALUES (@FirstName, @LastName);";
      MySqlParameter firstName = new MySqlParameter();
      firstName.ParameterName = "@FirstName";
      firstName.Value = this._firstName;
      cmd.Parameters.Add(firstName);
      MySqlParameter lastName = new MySqlParameter();
      lastName.ParameterName = "@LastName";
      lastName.Value = this._lastName;
      cmd.Parameters.Add(lastName);
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
      while (rdr.Read())
      {
        dbId = rdr.GetInt32(0);
        firstName = rdr.GetString(1);
        lastName = rdr.GetString(2);
      }
      Client foundClient = new Client(firstName, lastName, dbId);
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
        return (idEquality && firstNameEquality && lastNameEquality);
      }
    }
  }
}