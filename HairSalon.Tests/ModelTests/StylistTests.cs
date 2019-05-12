using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class StylistTests : IDisposable
  {
    public void Dispose()
    {
      Stylist.ClearAll();
    }
    public StylistTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=tessa_sullivan_test;convert zero datetime=True;";
    }
    [TestMethod]
    public void StylistConstructor_CreatesInstanceOfStylist_Stylist()
    {
      string firstName = "Sylvia";
      string lastName = "Green";
      string phoneNumber = "206-555-6789";
      Stylist stylist = new Stylist(firstName, lastName, phoneNumber);
      Assert.AreEqual(typeof(Stylist), stylist.GetType());
    }
    [TestMethod]
    public void GetFirstName_ReturnsFirstName_String()
    {
      string firstName = "Sylvia";
      string lastName = "Green";
      string phoneNumber = "206-555-6789";
      Stylist stylist = new Stylist(firstName, lastName, phoneNumber);
      string actualResult = stylist.GetFirstName();
      Assert.AreEqual(firstName, actualResult);
    }
    [TestMethod]
    public void GetLastName_ReturnsLastName_String()
    {
      string firstName = "Sylvia";
      string lastName = "Green";
      string phoneNumber = "206-555-6789";
      Stylist stylist = new Stylist(firstName, lastName, phoneNumber);
      string actualResult = stylist.GetLastName();
      Assert.AreEqual(lastName, actualResult);
    }
    [TestMethod]
    public void SetFirstName_SetsFirstName_String()
    {
      string firstName = "Sylvia";
      string lastName = "Green";
      string phoneNumber = "206-555-6789";
      Stylist stylist = new Stylist(firstName, lastName, phoneNumber);
      string newFirstName = "Jacqueline";
      stylist.SetFirstName(newFirstName);
      string actualResult = stylist.GetFirstName();
      Assert.AreEqual(newFirstName, actualResult);
    }
    [TestMethod]
    public void SetLastName_SetsLastName_String()
    {
      string firstName = "Sylvia";
      string lastName = "Green";
      string phoneNumber = "206-555-6789";
      Stylist stylist = new Stylist(firstName, lastName, phoneNumber);
      string newLastName = "Blue";
      stylist.SetLastName(newLastName);
      string actualResult = stylist.GetLastName();
      Assert.AreEqual(newLastName, actualResult);
    }
    [TestMethod]
    public void GetPhoneNumber_ReturnsPhoneNumber_string()
    {
      string firstName = "Sylvia";
      string lastName = "Green";
      string phoneNumber = "206-555-6789";
      Stylist stylist = new Stylist(firstName, lastName, phoneNumber);
      string actualResult = stylist.GetPhoneNumber();
      Assert.AreEqual(phoneNumber, actualResult);
    }
    [TestMethod]
    public void SetPhoneNumber_SetsPhoneNumber_string()
    {
      string firstName = "Sylvia";
      string lastName = "Green";
      string phoneNumber = "206-555-6789";
      Stylist stylist = new Stylist(firstName, lastName, phoneNumber);
      string newPhoneNumber = "206-777-0000";
      stylist.SetPhoneNumber(newPhoneNumber);
      string actualResult = stylist.GetPhoneNumber();
      Assert.AreEqual(newPhoneNumber, actualResult);
    }
    //This test implicitly tests the FindStylist method so no explicit test was written for it.
    [TestMethod]
    public void Save_SavesStylistToDB_Stylist()
    {
      string firstName = "Sylvia";
      string lastName = "Green";
      string phoneNumber = "206-555-6789";
      Stylist stylist = new Stylist(firstName, lastName, phoneNumber);
      stylist.Save();
      int stylistId = stylist.GetId();
      Stylist actualResult = Stylist.Find(stylistId);
      Assert.AreEqual(stylist, actualResult);
    }
    [TestMethod]
    public void GetAll_GetsAllStylists_StylistList()
    {
      string firstName = "Sylvia";
      string lastName = "Green";
      string phoneNumber = "206-555-6789";
      Stylist stylist = new Stylist(firstName, lastName, phoneNumber);
      stylist.Save();
      string firstName2 = "Michael";
      string lastName2 = "Hunt";
      string phoneNumber2 = "206-666-6789";
      Stylist stylist2 = new Stylist(firstName2, lastName2, phoneNumber2);
      stylist2.Save();
      List<Stylist> expectedResult = new List<Stylist> {stylist, stylist2};
      List<Stylist>actualResult = Stylist.GetAll();
      CollectionAssert.AreEqual(expectedResult, actualResult);
    }
    [TestMethod]
    public void GetClients_GetsClientListForOneStylist_ClientList()
    {
      string firstName = "Sylvia";
      string lastName = "Green";
      string phoneNumber = "206-555-6789";
      Stylist stylist = new Stylist(firstName, lastName, phoneNumber);
      stylist.Save();
      int stylistId = stylist.GetId();
      // string clientFirstName = "Jack";
      // string clientLastName = "Daniels";
      // string clientPhoneNumber = "253-555-6789";
      // Client client = new Client(clientFirstName, clientLastName, clientPhoneNumber, stylistId);
      // client.Save();
      List<Client> expectedResult = new List<Client> {};
      // // List<Client> expectedResult = new List<Client> {client};
      // List<Client> actualResult = stylist.GetClients(stylistId);
      // System.Console.WriteLine("actual result "+ actualResult);

      Dictionary<string, object> model1 = new Dictionary<string, object>();
      Stylist stylist2 = Stylist.Find(stylistId);
      Client client = new Client(firstName, lastName, phoneNumber, stylistId);
      client.Save();
      List<Client> allClients = stylist2.GetClients(stylistId);
      System.Console.WriteLine("number in allClients is " + allClients.Count);
      model1.Add("stylist", stylist2);
      model1.Add("clients", allClients);
            System.Console.WriteLine("number in model1 is " + model1.Count);
            // System.Console.WriteLine("number in model1 clients is " + model1["clients"].Count);
            System.Console.WriteLine("type " + model1["clients"].GetType());

      // System.Console.WriteLine("get name " + model1["clients"][0].GetFirstName());
          foreach (string key in model1.Keys)
            {
                foreach (Client client1  in model1[key])
                {
                    Console.WriteLine(client1.GetFirstName());
                }
            }

      CollectionAssert.AreEqual(expectedResult, allClients);
    }
  }
}
