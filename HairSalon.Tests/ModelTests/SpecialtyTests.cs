using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class SpecialtyTests : IDisposable
  {
    public void Dispose()
    {
      Specialty.DeleteAll();
    }
    public SpecialtyTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=tessa_sullivan_test;convert zero datetime=True;";
    }
    // Tests both Save and Find at the same time
    [TestMethod]
    public void Save_SavesSpecialtyToDB_Specialty()
    {
      string name = "Foils";
      Specialty specialty= new Specialty(name);
      specialty.Save();
      int specialtyId = specialty.GetId();
      Specialty actual = Specialty.Find(specialtyId);
      Assert.AreEqual(specialty, actual);
    }

    [TestMethod]
    public void GetAll_GetsAllSpecialties_SpecialtyList()
    {
      string name1 = "Foils";
      string name2 = "Highlights";
      Specialty specialty1 = new Specialty(name1);
      Specialty specialty2 = new Specialty(name2);
      specialty1.Save();
      specialty2.Save();

      List<Specialty> expected = new List<Specialty> {specialty1, specialty2};
      List<Specialty> actual = Specialty.GetAll();
      CollectionAssert.AreEqual(expected, actual);
    }
    [TestMethod]
    public void GetStylists_GetsListOfStylists_StylistList()
    {
      string name = "Foils";
      Specialty specialty= new Specialty(name);
      specialty.Save();

      string firstName = "Sylvia";
      string lastName = "Green";
      string phoneNumber = "206-555-6789";
      Stylist stylist = new Stylist(firstName, lastName, phoneNumber);
      stylist.Save();
      specialty.AddStylist(stylist);

      List<Stylist> expected = new List<Stylist>{stylist};
      List<Stylist> actual = specialty.GetStylists();
      foreach (Stylist newStylist in expected)
      {
        System.Console.WriteLine("expected" + newStylist.GetFirstName());
      }      
      foreach (Stylist newStylist in actual)
      {
        System.Console.WriteLine("actual" + newStylist.GetFirstName());
      }
      CollectionAssert.AreEqual(expected, actual);
    }
  }
}