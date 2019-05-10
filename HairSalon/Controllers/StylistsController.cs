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
  }
}
