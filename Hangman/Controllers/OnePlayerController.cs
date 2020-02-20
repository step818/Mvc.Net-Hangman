using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Hangman.Models;

namespace Hangman.Controllers
{
  public class OnePlayerController : Controller
  {
    [HttpGet("/one")]
    public ActionResult Index()
    {
      MysteryWord.ClearAllWords();
      MysteryWord.ClearAllLetters();
      return View();
    }

    [HttpPost("/hard")]
    public ActionResult Show()
    {
      // Create a method that generates a newWord
      //  for the user to play against
      return View(newWord);
    }
  }
}