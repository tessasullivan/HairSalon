using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class HairSalonTest : IDisposable
  {
    public void Dispose()
    {
      Stylist.ClearAll();
    }
    // public StylistTest()
    // {
    //   DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=tessa_sullivan_test;convert zero datetime=True;";
    // }
    [TestMethod]
    public void StylistConstructor_CreatesInstanceOfStylist_Stylist()
    {
      string firstName = "Sylvia";
      string lastName = "Green";
      Stylist stylist = new Stylist(firstName, lastName);
      Assert.AreEqual(typeof(Stylist), stylist.GetType());
    }
    [TestMethod]
    public void GetFirstName_ReturnsFirstName_String()
    {
      string firstName = "Sylvia";
      string lastName = "Green";
      Stylist stylist = new Stylist(firstName, lastName);
      string actualResult = stylist.GetFirstName();
      Assert.AreEqual(firstName, actualResult);
    }
    [TestMethod]
    public void GetLastName_ReturnsLastName_String()
    {
      string firstName = "Sylvia";
      string lastName = "Green";
      Stylist stylist = new Stylist(firstName, lastName);
      string actualResult = stylist.GetLastName();
      Assert.AreEqual(lastName, actualResult);
    }
    [TestMethod]
    public void SetFirstName_SetsFirstName_String()
    {
      string firstName = "Sylvia";
      string lastName = "Green";
      Stylist stylist = new Stylist(firstName, lastName);
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
      Stylist stylist = new Stylist(firstName, lastName);
      string newLastName = "Blue";
      stylist.SetLastName(newLastName);
      string actualResult = stylist.GetLastName();
      Assert.AreEqual(newLastName, actualResult);
    }
  }
}
