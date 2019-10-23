using Microsoft.AspNetCore.Mvc;

namespace Hangman.Controllers
{
  public class OnePlayerController : Controller
  {
    [HttpGet("/one")]
    public ActionResult Index()
    {
      return View();
    }
  }
}