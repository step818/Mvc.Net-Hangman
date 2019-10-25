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
      return View(newWord);
    }
    [HttpPost("/hangman/{letter}")]
    public ActionResult Update(string letter)
    {
      MysteryWord playerWord = MysteryWord.Find(1);
      Letter newLetter = new Letter(letter);
      bool resBool = playerWord.CheckLetter(newLetter);
      string result = resBool.ToString();
      Console.WriteLine("hello");
      //This is where you input a letter to the GuessWord model
      return RedirectToAction("Show");
    }
  }
}