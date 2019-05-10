using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests 
{
  [TestClass]
  public class ClientsControllerTests : IDisposable
  {
    public void Dispose()
    {
      Client.ClearAll();
    }
    public ClientsControllerTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=tessa_sullivan_test;convert zero datetime=True;";
    }
    [TestMethod]
    public void New_ReturnsCorrectView_True () 
    {
      int stylistId = 1;
      ClientsController controller = new ClientsController ();
      ActionResult indexView = controller.New(stylistId);
      Assert.IsInstanceOfType (indexView, typeof (ViewResult));
    }


    // [TestMethod]
    // public void Create_ReturnsCorrectActionType_StylistList()
    // {
    //   string firstName = "Sylvia";
    //   string lastName = "Green";
    //   string phoneNumber = "206-555-6789";
    //   int id = 1;
    //   Client client = new Client(firstName, lastName, phoneNumber, id);
    //   ClientsController controller = new ClientsController();
    //   IActionResult view = controller.Create(firstName, lastName, phoneNumber, id);
    //   Assert.IsInstanceOfType(view, typeof(RedirectToActionResult));
    // }
  }
}