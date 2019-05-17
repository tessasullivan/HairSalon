using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests 
{
  [TestClass]
  public class StylistsControllerTests : IDisposable
  {
    public void Dispose()
    {
      Stylist.DeleteAll();
    }
    public StylistsControllerTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=tessa_sullivan_test;convert zero datetime=True;";
    }
    [TestMethod]
    public void Index_ReturnsCorrectView_True () {
      StylistsController controller = new StylistsController ();
      ActionResult indexView = controller.Index ();
      Assert.IsInstanceOfType (indexView, typeof (ViewResult));
    }
    [TestMethod]
    public void Index_HasCorrectModelType_StylistList()
    {
      StylistsController controller = new StylistsController();
      ViewResult indexView = controller.Index() as ViewResult;
      var result = indexView.ViewData.Model;
      Assert.IsInstanceOfType(result, typeof(List<Stylist>));
    }
    [TestMethod]
    public void Create_ReturnsCorrectActionType_StylistList()
    {
      string firstName = "Sylvia";
      string lastName = "Green";
      string phoneNumber = "206-555-6789";
      int id = 1;
      Stylist stylist = new Stylist(firstName, lastName, phoneNumber, id);
      StylistsController controller = new StylistsController();
      IActionResult view = controller.Create(firstName, lastName, phoneNumber, id);
      Assert.IsInstanceOfType(view, typeof(RedirectToActionResult));
    }

    [TestMethod]
    public void Create_RedirectsToCorrectAction_Index()
    {
      string firstName = "Sylvia";
      string lastName = "Green";
      string phoneNumber = "206-555-6789";
      Stylist stylist = new Stylist(firstName, lastName, phoneNumber);
      int id = stylist.GetId();
      StylistsController controller = new StylistsController();
      RedirectToActionResult actionResult = controller.Create(firstName, lastName, phoneNumber, id) as RedirectToActionResult;
      string result = actionResult.ActionName;
      Assert.AreEqual(result, "Index");
    }
    [TestMethod]
    public void New_ReturnsCorrectView_True () 
    {
      StylistsController controller = new StylistsController ();
      ActionResult newView = controller.New ();
      Assert.IsInstanceOfType (newView, typeof (ViewResult));
    }
    [TestMethod]
    public void Delete_ReturnsCorrectView_True ()
    {
      string firstName = "Sylvia";
      string lastName = "Green";
      string phoneNumber = "206-555-6789";
      Stylist stylist = new Stylist(firstName, lastName, phoneNumber);
      int id = stylist.GetId();
      StylistsController controller = new StylistsController ();
      ActionResult deleteView = controller.Delete(id);
      Assert.IsInstanceOfType (deleteView, typeof (ViewResult));      
    }
  }
}