using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace HairSalon.Controllers
{
  public class StylistController : Controller
  {

    [Route("/")]
    public ActionResult Index() { return View(); }
  }
}
