using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Hangman.Models;

namespace Hangman.Controllers
{
  public class TwoPlayerController : Controller
  {
    // Brings up Index form to post to /hangman
    [HttpGet("/two")]
    public ActionResult Index()
    {
      return View();
    }
    // Brings up Show which is main gane page
    [HttpPost("/hangman")]
    public ActionResult Show(string word)
    {
      MysteryWord newWord = new MysteryWord(word);
      //Letter newLetter = new Letter("", newWord);
      return View(newWord);
    }

    [HttpPost("/hangman/{letter}")]
    public ActionResult Update(string letter)
    {
      //  I think this is a bug. No word to pass into .Find()
      MysteryWord playerWord = MysteryWord.Find(1);
      // Add the letter to the letter list _letters
      Letter newLetter = new Letter(letter, playerWord);
      // Add the letter to the letter list in Mystword
      //  playerWord.AddLetter(newLetter);
      bool resBool = playerWord.CheckLetter(newLetter);
      string isMatch = resBool.ToString();
      // List<Letter> guessedLetters = playerWord.Letters;
      List<string> allLetters = Letter.GetAll();
      // string gL = guessedLetters[0].ToString();
      // string aL = allLetters[0].ToString();
      Console.WriteLine(newLetter.Bet);
      Console.WriteLine(newLetter.Id);
      Console.WriteLine(newLetter.userWord);
      // Console.WriteLine(playerWord.Letters.Count);
      Console.WriteLine(isMatch);
      foreach(string i in allLetters)
      {
        Console.WriteLine(i);
      }
      
      //This is where you input a letter to the Guessword model
      return RedirectToAction("Show", allLetters);
    }
  }
}