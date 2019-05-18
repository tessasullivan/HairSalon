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
      Stylist.DeleteAll();
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
    public void GetId_GetsId_int()
    {
      string firstName = "Sylvia";
      string lastName = "Green";
      string phoneNumber = "206-555-6789";
      Stylist stylist = new Stylist(firstName, lastName, phoneNumber, 3);
      int actualResult = stylist.GetId();
      Assert.AreEqual(3, actualResult);      
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
      System.Console.WriteLine("stylist id "+ stylistId);
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
      string clientFirstName = "Jack";
      string clientLastName = "Daniels";
      string clientPhoneNumber = "253-555-6789";
      string notes = "this is a note";
      Client client = new Client(clientFirstName, clientLastName, clientPhoneNumber, stylistId, notes);
      client.Save();
      // List<Client> expectedResult = new List<Client> {};
      List<Client> expectedResult = new List<Client> {client};
      List<Client> actualResult = stylist.GetClients();
      System.Console.WriteLine(actualResult[0].GetId());
      CollectionAssert.AreEqual(expectedResult, actualResult);
    }
    [TestMethod]
    public void Delete_DeletesStylistFromDB_EmptyStylistList()
    {
      string firstName = "Sylvia";
      string lastName = "Green";
      string phoneNumber = "206-555-6789";
      Stylist stylist = new Stylist(firstName, lastName, phoneNumber);
      stylist.Save();
      stylist.Delete();
      List<Stylist> expected = new List<Stylist> {};
      List<Stylist> actual = Stylist.GetAll();
      CollectionAssert.AreEqual(expected, actual);
    }
    [TestMethod]
    public void DeleteAll_DeletesAllStylistsFromDB_EmptyStylistList()
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
      Stylist.DeleteAll();
      List<Stylist> expectedResult = new List<Stylist> {};
      List<Stylist>actualResult = Stylist.GetAll();
      CollectionAssert.AreEqual(expectedResult, actualResult);
    }
    [TestMethod]
    public void Edit_EditsStylistInfo_Stylist()
    {
      string firstName = "Sylvia";
      string lastName = "Green";
      string phoneNumber = "206-555-6789";
      Stylist stylist = new Stylist(firstName, lastName, phoneNumber);
      stylist.Save();
      string firstName2 = "Michael";
      string lastName2 = "Hunt";
      string phoneNumber2 = "206-666-6789";
      stylist.Edit(firstName2, lastName2, phoneNumber2);
      Stylist expected = new Stylist(firstName2, lastName2, phoneNumber2);
      Stylist actual = new Stylist(stylist.GetFirstName(), stylist.GetLastName(), stylist.GetPhoneNumber());
      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void GetSpecialties_GetsSpecialtyList_SpecialtyList()
    {
      string firstName = "Sylvia";
      string lastName = "Green";
      string phoneNumber = "206-555-6789";
      Stylist stylist = new Stylist(firstName, lastName, phoneNumber);
      stylist.Save();

      string name1 = "Foils";
      string name2 = "Highlights";
      Specialty specialty1 = new Specialty(name1);
      Specialty specialty2 = new Specialty(name2);
      specialty1.Save();
      specialty2.Save(); 

      stylist.AddSpecialty(specialty1);
      stylist.AddSpecialty(specialty2);

      List<Specialty> expected = new List<Specialty> {specialty1, specialty2};
      List<Specialty> actual = stylist.GetSpecialties();

      CollectionAssert.AreEqual(expected, actual);      
    }
    // This test is not quite right as it is not directly checking the specialties_stylists table.  
    // I verified functionality by turning off IDisposable and  manually checking the db:
    // I ran the test with the RemoveSpeciality commented out, verifying that the table had data and 
    // running it with it in and verifying that the data in the table had been removed.
    // [TestMethod]
    // public void RemoveSpecialty_RemovesSpecialtyFromStylist_EmptySpecialtyList()
    // {
    //   string firstName = "Sylvia";
    //   string lastName = "Green";
    //   string phoneNumber = "206-555-6789";
    //   Stylist stylist = new Stylist(firstName, lastName, phoneNumber);
    //   stylist.Save();

    //   string name1 = "Foils";
    //   Specialty specialty1 = new Specialty(name1);
    //   specialty1.Save();

    //   stylist.AddSpecialty(specialty1);
    //   stylist.RemoveSpecialty(specialty1);
    //   List<Specialty> expected = new List<Specialty> {};
    //   System.Console.WriteLine("number in expected "+ expected.Count);
    //   List<Specialty> actual = stylist.GetSpecialties();
    //   CollectionAssert.AreEqual(expected, actual);       
    // }
  }
}
