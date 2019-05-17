using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
  public class ClientsController : Controller
  {
    [HttpGet("/clients")]
    public ActionResult Index()
    {
      List<Client> allClients = Client.GetAll();
      return View(allClients);
    }

    //Displays form to allow user to enter client information
    [HttpGet("/stylists/{stylistId}/clients/new")]
    public ActionResult New(int stylistId)
    {
      Stylist stylist = Stylist.Find(stylistId);
      return View(stylist);
    }

    [HttpGet("stylists/{stylistId}/clients/{clientId}")]
    public ActionResult Show(int clientId)
    {
      Client client = Client.Find(clientId);
      return View(client);
    }
    // Ask for confirmation to delete client
    [HttpGet("/stylists/{stylist_id}/clients/{client_id}/delete")]
    public ActionResult Delete(int stylist_id, int client_id)
    {
      Client client = Client.Find(client_id);
      return View(client);
    }

    // Delete an individual client 
    [HttpPost("/stylists/{stylist_id}/clients/{client_id}/delete")]
    public ActionResult DeleteStylist(int stylist_id, int client_id)
    {
      Client client = Client.Find(client_id);
      client.Delete();
      List<Client> allClients = Client.GetAll();
      return View("Index", allClients);
    }

    // Ask for confirmation to delete all stylists and clients
    [HttpGet("/clients/deleteall")]
    public ActionResult DeleteAll()
    {
      return View();
    }
    [HttpPost("/clients/deleteAll")]
    public ActionResult DeleteEveryOne()
    {
      Client.DeleteAll();
      List<Stylist> allStylists = Stylist.GetAll();
      return View("/stylists", allStylists);
    }
  }
}

