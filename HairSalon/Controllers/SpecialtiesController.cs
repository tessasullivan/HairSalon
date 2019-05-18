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

    // Display edit form
    [HttpGet("/specialties/{id}/edit")]
    public ActionResult Edit(int id)
    {
      Specialty specialty = Specialty.Find(id);
      return View(specialty);
    }
    // Edit the specialty and return to specialty page
    [HttpPost("/specialties/{id}")]
    public ActionResult Update(int id, string newSpecialty)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Specialty specialty = Specialty.Find(id);
      specialty.Edit(newSpecialty);

      List<Stylist> allStylists = Stylist.GetAll();
      model.Add("specialty", specialty);
      model.Add("stylists", allStylists);
      return View("Show", model);
    }

    // Ask to confirm deleting specialty
    [HttpGet("/specialties/{id}/delete")]
    public ActionResult Delete(int id)
    {
      Specialty specialty = Specialty.Find(id);
      return View(specialty);
    }

    // Delete specialty
    [HttpPost("/specialties/{id}/delete")]
    public ActionResult DeleteSpecialty(int id)
    {
      Specialty specialty = Specialty.Find(id);
      specialty.Delete();
      List<Specialty> allSpecialties = Specialty.GetAll();
      return View("Index", allSpecialties);    
    }

    // Ask for confirmation to delete all specialties
    [HttpGet("/specialties/delete")]
    public ActionResult DeleteAll()
    {
      List<Specialty> allSpecialties = Specialty.GetAll();
      return View(allSpecialties);
    }

    // Delete all specialties
    [HttpPost("/specialties/delete")]
    public ActionResult DeleteAllSpecialties()
    {
      Specialty.DeleteAll();
      List<Specialty> allSpecialties = Specialty.GetAll();
      return View("Index", allSpecialties);
    }

    // Adds stylist to specialty
    [HttpPost("/specialties/{id}/stylists/new")]
    public ActionResult AddStylist(int id, int stylistId)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Specialty specialty = Specialty.Find(id);
      Stylist stylist = Stylist.Find(stylistId);
      specialty.AddStylist(stylist);
      List<Stylist> allStylists = Stylist.GetAll();
      model.Add("specialty", specialty);
      model.Add("stylists", allStylists);
      return RedirectToAction("Show", model);
    }

    // Ask user if they really want to remove a stylist from a specialty
    [HttpGet("/specialties/{id}/stylists/remove/{stylistid}")]
    public ActionResult RemoveStylist(int id, int stylistId)
    {
      Specialty specialty = Specialty.Find(id);
      Stylist stylist = Stylist.Find(stylistId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("specialty", specialty);
      model.Add("stylist", stylist);      
      return View(model);
    }

    // Remove stylist from specialty
    [HttpPost("/specialties/{id}/stylists/remove/{stylistId}")]
    public ActionResult RemovesStylist(int id, int stylistId)
    {
      Specialty specialty = Specialty.Find(id);
      Stylist stylist = Stylist.Find(stylistId);
      specialty.RemoveStylist(stylist);

      Dictionary<string, object> model = new Dictionary<string, object>();
      List<Stylist> allStylists = Stylist.GetAll();
      model.Add("specialty", specialty);
      model.Add("stylists", allStylists);       
      return View("Show", model);
    }
  }
}
