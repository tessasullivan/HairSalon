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

    [HttpGet("/stylists/{id}")]
    public ActionResult Show(int stylistId)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist stylist = Stylist.Find(stylistId);
      List<Client> clientList = stylist.GetClients(stylistId);
      model.Add("stylist", stylist);
      model.Add("clients", clientList);
      return View(model);
    }

    // This one creates new Clients with a given Stylist, not new stylists and then displays the stylist with all their clients
    [HttpPost("/stylists/{stylistId}/clients")]
    public ActionResult Create(string firstName, string lastName, string phoneNumber, int stylistId, int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist stylist = Stylist.Find(stylistId);
      Client client = new Client(firstName, lastName, phoneNumber, stylistId, id);
      client.Save();
      List<Client> allClients = stylist.GetClients(stylistId);
      model.Add("stylist", stylist);
      model.Add("clients", allClients);
      return View("Show", model);
    }

  }
}
