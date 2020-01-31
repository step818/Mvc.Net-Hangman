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
      Letter newLetter = new Letter("p");
      MysteryWord newWord = new MysteryWord(word, newLetter);
      return View(newWord);
    }

    [HttpPost("/hangman/{letter}")]
    public ActionResult Update(string letter)
    {
      //  I think this is a bug. No word to pass into .Find()
      MysteryWord playerWord = MysteryWord.Find(1);
      // Add the letter to the letter list _letters
      Letter newLetter = new Letter(letter);
      // Add the letter to the letter list and Guess in Mystword
      MysteryWord updatedCheck = new MysteryWord(playerWord.Word, newLetter);
      bool resBool = updatedCheck.CheckLetter();
      string isMatch = resBool.ToString();
      List<string> allLetters = Letter.GetAll();
      Console.WriteLine(playerWord.Word);
      Console.WriteLine(newLetter.Bet);
      Console.WriteLine(newLetter.Id);
      Console.WriteLine(isMatch);
      foreach(string i in allLetters)
      {
        Console.WriteLine(i);
      }
      
      //This is where you input a letter to the Guessword model
      return View(updatedCheck);
    }
  }
}