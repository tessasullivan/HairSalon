using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace HairSalon.Controllers
{
  public class ClientsController : Controller
  {

    [Route("/clients")]
    public ActionResult Index() { return View(); }
  }
}
