using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
  public class StylistsController : Controller
  {
    [HttpGet("/stylists")]
    public ActionResult Index() 
    {
      List<Stylist> allStylists = Stylist.GetAll();
      return View(allStylists);
    }
    [HttpGet("/stylists/{id}")]
    public ActionResult Show(int id)
    {
      Stylist stylist = Stylist.Find(id);
      return View(stylist);
    }
    //Displays form for adding a stylist
    [HttpGet("/stylists/new")]
    public ActionResult New()
    {
      return View();
    }
    
    //This method creates a stylist and then returns the user to the Index page
    [HttpPost("/stylists")]
    public ActionResult Create(string firstName, string lastName, string phoneNumber, int id)
    {
      Stylist stylist = new Stylist(firstName, lastName, phoneNumber, id);
      stylist.Save();
      List<Stylist> allStylists = Stylist.GetAll();

      return RedirectToAction("Index", allStylists);
    }

    // This method adds a new client and then returns user to the specific stylist page
    [HttpPost("/stylists/{stylistId}/clients")]
    public ActionResult Create(string firstName, string lastName, string phoneNumber, string notes, int stylistId, int id)
    {
      Stylist stylist = Stylist.Find(stylistId);
      if (String.IsNullOrEmpty(notes))
      {
        notes="";
      }
      Client client = new Client(firstName, lastName, phoneNumber, stylistId, notes, id);
      client.Save();
      return View("Show", stylist);      
    }

    // Ask for confirmation of delete
    [HttpGet("/stylists/{id}/delete")]
    public ActionResult Delete(int id)
    {
      Stylist stylist = Stylist.Find(id);
      return View(stylist);
    }

    // Delete an individual stylist along with their clients and return to list of stylists
    [HttpPost("/stylists/{id}/delete")]
    public ActionResult DeleteStylist(int id)
    {
      Stylist stylist = Stylist.Find(id);
      List<Client> clients = stylist.GetClients();
      foreach (Client client in clients)
      {
        client.Delete();
      }
      stylist.Delete();
      List<Stylist> allStylists = Stylist.GetAll();
      return View("Index", allStylists);
    }
  }
}
