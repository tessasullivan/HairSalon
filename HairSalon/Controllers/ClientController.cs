using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace HairSalon.Controllers
{
  public class ClientController : Controller
  {

    [Route("/")]
    public ActionResult Index() { return View(); }
  }
}
