using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Hangman.Models;

namespace Hangman.Controllers
{
  public class TwoPlayerController : Controller
  {
    [HttpGet("/two")]
    public ActionResult Index()
    {
      return View();
    }
    [HttpPost("/hangman")]
    public ActionResult Show(string makeWord)
    {
      MysteryWord newWord = new MysteryWord(makeWord);
      return View();
    }
    [HttpPost("/hangman")]
    public ActionResult Guess()
    {
      return RedirectToAction("Show");
    }
  }
}