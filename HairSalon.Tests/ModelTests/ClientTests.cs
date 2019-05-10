using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class ClientTests : IDisposable
  {
    public void Dispose()
    {
      Client.ClearAll();
    }
    public ClientTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=tessa_sullivan_test;convert zero datetime=True;";
    }
    [TestMethod]
    public void ClientConstructor_CreatesInstanceOfClient_Client()
    {
      string firstName = "Jack";
      string lastName = "Daniels";
      string phoneNumber = "253-555-6789";
      Client client = new Client(firstName, lastName, phoneNumber);
      Assert.AreEqual(typeof(Client), client.GetType());
    }
    [TestMethod]
    public void GetFirstName_ReturnsFirstName_String()
    {
      string firstName = "Jack";
      string lastName = "Daniels";
      string phoneNumber = "253-555-6789";
      Client client = new Client(firstName, lastName, phoneNumber);
      string actualResult = client.GetFirstName();
      Assert.AreEqual(firstName, actualResult);      
    } 
    [TestMethod]
    public void GetLastName_ReturnsLastName_String()
    {
      string firstName = "Jack";
      string lastName = "Daniels";
      string phoneNumber = "253-555-6789";
      Client client = new Client(firstName, lastName, phoneNumber);
      string actualResult = client.GetLastName();
      Assert.AreEqual(lastName, actualResult);      
    }  
    [TestMethod]
    public void SetFirstName_SetsFirstName_String()
    {
      string firstName = "Jack";
      string lastName = "Daniels";
      string phoneNumber = "253-555-6789";
      Client client = new Client(firstName, lastName, phoneNumber);
      string newFirstName = "Jill";
      client.SetFirstName(newFirstName);
      string actualResult = client.GetFirstName();
      Assert.AreEqual(newFirstName, actualResult); 
    } 
    [TestMethod]
    public void SetLastName_SetsLastName_String()
    {
      string firstName = "Jack";
      string lastName = "Daniels";
      string phoneNumber = "253-555-6789";
      Client client = new Client(firstName, lastName, phoneNumber);
      string newLastName = "Beam";
      client.SetLastName(newLastName);
      string actualResult = client.GetLastName();
      Assert.AreEqual(newLastName, actualResult); 
    }
    [TestMethod]
    public void GetPhoneNumber_GetsPhoneNumber_String()
    {
      string firstName = "Jack";
      string lastName = "Daniels";
      string phoneNumber = "253-555-6789";
      Client client = new Client(firstName, lastName, phoneNumber);
      string actualResult = client.GetPhoneNumber();
      Assert.AreEqual(phoneNumber, actualResult);
    }
    [TestMethod]
    public void SetPhoneNumber_SetsPhoneNumber_String()
    {
      string firstName = "Jack";
      string lastName = "Daniels";
      string phoneNumber = "253-555-6789";
      Client client = new Client(firstName, lastName, phoneNumber);
      string newPhoneNumber = "425-666-0000";
      client.SetPhoneNumber(newPhoneNumber);
      string actualResult = client.GetPhoneNumber();
      Assert.AreEqual(newPhoneNumber, actualResult);
    }
    [TestMethod]
    public void Save_SavesClientToDB_Client()
    {
      string firstName = "Jack";
      string lastName = "Daniels";
      string phoneNumber = "253-555-6789";
      Client client = new Client(firstName, lastName, phoneNumber);
      client.Save();
      int clientId = client.GetId();
      Client actualResult = Client.Find(clientId);
      Assert.AreEqual(client, actualResult);    
    }
  }
}