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
    [HttpPost("/hangman/{wordId}/letter")]
    public ActionResult Update(int wordId, string letter)
    {
      Letter newLetter = new Letter(letter);
      MysteryWord playerWord = MysteryWord.Find(wordId);
      bool resBool = playerWord.CheckLetter(newLetter);
      string result = resBool.ToString();
      //This is where you input a letter to the GuessWord model
      return RedirectToAction(result);
    }
  }
}