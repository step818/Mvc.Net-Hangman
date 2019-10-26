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
      Letter newLetter = new Letter("");
      return View(newWord);
    }
    [HttpPost("/hangman/letter")]
    public ActionResult Update(string letter)
    {
      MysteryWord playerWord = MysteryWord.Find(1);
      // Add the letter to the letter list _letters
      Letter newLetter = new Letter(letter);
      // Add the letter to the letter list in MystWord
      playerWord.AddLetter(newLetter);
      bool resBool = playerWord.CheckLetter(newLetter);
      string result = resBool.ToString();
      List<Letter> guessedLetters = playerWord.Letters;
      List<Letter> allLetters = Letter.GetAll();
      Console.WriteLine(newLetter.Bet);
      Console.WriteLine(result);
      //This is where you input a letter to the GuessWord model
      return RedirectToAction("Show", allLetters);
    }
  }
}