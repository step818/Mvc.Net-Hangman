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
    public ActionResult Show(string word)
    {
      MysteryWord newWord = new MysteryWord(word);
      return View();
    }
    [HttpPost("/hangman/letter")]
    public ActionResult Update()
    {
      //This is where you input a letter to the GuessWord model
      return RedirectToAction("Show");
    }
  }
}