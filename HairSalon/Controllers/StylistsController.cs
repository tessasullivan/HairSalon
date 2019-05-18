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
      Dictionary<string, object> model = new Dictionary<string, object>();
      List<Specialty> allSpecialities = Specialty.GetAll();
      model.Add("stylist", stylist);
      model.Add("specialties", allSpecialities);
      return View(model);
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
      Dictionary<string, object> model = new Dictionary<string, object>();
      List<Specialty> allSpecialities = Specialty.GetAll();
      model.Add("stylist", stylist);
      model.Add("specialties", allSpecialities);
      return View("Show", model);      
    }

    [HttpGet("/stylists/{id}/edit")]
    public ActionResult Edit(int id)
    {
      Stylist stylist = Stylist.Find(id);
      return View(stylist);
    }

    [HttpPost("/stylists/{id}")]
    public ActionResult Update(int id, string first, string last, string phone)
    {
      Stylist stylist = Stylist.Find(id);
      stylist.Edit(first, last, phone);
      Dictionary<string, object> model = new Dictionary<string, object>();
      List<Specialty> allSpecialities = Specialty.GetAll();
      model.Add("stylist", stylist);
      model.Add("specialties", allSpecialities);
      return View("Show", model);
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

    // Ask for confirmation to delete all stylists and clients
    [HttpGet("/stylists/delete")]
    public ActionResult DeleteAll()
    {
      return View();
    }
    [HttpPost("/stylists/delete")]
    public ActionResult DeleteEveryOne()
    {
      Stylist.DeleteAll();
      Client.DeleteAll();
      List<Stylist> allStylists = Stylist.GetAll();
      return View("Index", allStylists);
    }
    // Add speciality to stylist
    [HttpPost("/stylists/{id}/specialties/new")]
    public ActionResult AddSpecialty(int id, int specialtyId)
    {
      Stylist stylist = Stylist.Find(id);
      Specialty specialty = Specialty.Find(specialtyId);
      stylist.AddSpecialty(specialty);

      Dictionary<string, object> model = new Dictionary<string, object>();
      List<Specialty> allSpecialities = Specialty.GetAll();
      model.Add("stylist", stylist);
      model.Add("specialties", allSpecialities);
      return View("Show", model);      
    }
    // [HttpGet("/stylists/{id}/specialties/remove/{specialtyId}")]
    // public ActionResult ConfirmRemoveSpecialty(int id, int specialtyId)
    // {
    //   Stylist stylist = Stylist.Find(id);
    //   Specialty specialty = Specialty.Find(specialtyId);

    //   System.Console.WriteLine("specialtyId " + specialtyId);
    //   System.Console.WriteLine("stylistId " + id);

    //   Dictionary<string, object> model = new Dictionary<string, object>();
    //   List<Specialty> allSpecialities = Specialty.GetAll();
    //   model.Add("stylist", stylist);
    //   model.Add("specialties", allSpecialities);
    //   return View(model);      
    // }
    // Removes specialty from stylist and returns to stylist page
    [HttpPost("/stylists/{id}/specialties/remove/{specialtyId}")]
    public ActionResult RemoveSpecialty(int id, int specialtyId)
    {
      Stylist stylist = Stylist.Find(id);
      Specialty specialty = Specialty.Find(specialtyId);
      stylist.RemoveSpecialty(specialty);

      Dictionary<string, object> model = new Dictionary<string, object>();
      List<Specialty> allSpecialities = Specialty.GetAll();
      model.Add("stylist", stylist);
      model.Add("specialties", allSpecialities);
      return View("Show", model);      
    }
  }
}
