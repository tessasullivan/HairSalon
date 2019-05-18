using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
  public class SpecialtiesController : Controller
  {
    [HttpGet("/specialties")]
    public ActionResult Index() 
    {
      List<Specialty> allSpecialties = Specialty.GetAll();
      return View(allSpecialties); 
    }
    [HttpGet("/specialties/new")]
    public ActionResult New()
    {
      return View();
    }
    [HttpPost("/specialties")]
    public ActionResult Create(string specialty)
    {
      Specialty newSpecialty = new Specialty(specialty);
      newSpecialty.Save();
      List<Specialty> allSpecialties = Specialty.GetAll();
      return RedirectToAction("Index", allSpecialties);
    }
    // Displays list of specialties and allows user to add stylist to specialty
    [HttpGet("/specialties/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Specialty specialty = Specialty.Find(id);
      List<Stylist> allStylists = Stylist.GetAll();
      model.Add("specialty", specialty);
      model.Add("stylists", allStylists);
      return View(model);
    }
    // Adds stylist to specialty
    [HttpPost("/specialties/{id}/stylists/new")]
    public ActionResult AddStylist(int id, int stylistId)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Specialty specialty = Specialty.Find(id);
      Stylist stylist = Stylist.Find(stylistId);
      List<Stylist> allStylists = Stylist.GetAll();
      model.Add("specialty", specialty);
      model.Add("stylists", allStylists);
      return RedirectToAction("Show", model);
    }
  }
}
