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
    [HttpGet("/specialties/{id}")]
    public ActionResult Show(int id)
    {
      Specialty specialty = Specialty.Find(id);
      return View(specialty);
    }
  }
}
