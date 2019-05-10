using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
  public class ClientsController : Controller
  {
    //Displays form to allow user to enter client information
    [HttpGet("/stylists/{stylistId}/clients/new")]
    public ActionResult New(int stylistId)
    {
      Stylist stylist = Stylist.Find(stylistId);
      return View(stylist);
    }
    
    // This one creates new Items within a given Category, not new Categories:
    // [HttpPost("/stylists/{stylistId}/clients")]
    // public ActionResult Create(string firstName, string lastName, string phoneNumber, int id)
    // {
    //   Stylist stylist = new Client(firstName, lastName, phoneNumber, id);
    //   stylist.Save();
    //   List<Stylist> allStylists = Stylist.GetAll();

    //   return RedirectToAction("Index", allStylists);
    // }


    // public ActionResult Create()
    // {
    //   Dictionary<string, object> model = new Dictionary<string, object>();
    //   Category foundCategory = Category.Find(categoryId);
    //   Item newItem = new Item(itemDescription, dueDate, categoryId);
    //   newItem.Save();
    //   foundCategory.AddItem(newItem);
    //   List<Item> categoryItems = foundCategory.GetItems(categoryId);
    //   model.Add("items", categoryItems);
    //   model.Add("category", foundCategory); 
    //   return View("Show", model);
    // }
  }
}

