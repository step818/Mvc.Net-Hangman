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
      // For 6 words in a row, don't repeat any words
      if(MysteryWord.counter > 5) {
        MysteryWord.ClearAllIds();
        Console.WriteLine("cleared al ids");
      }
      MysteryWord.ClearAllLetters();
      MysteryWord.ClearAllWords();
      MysteryWord.ClearAllHardWords();
      return View();
    }

    [HttpGet("/hard")]
    public ActionResult Show()
    {  
      MysteryWord newWord = MysteryWord.Generate();
      Console.WriteLine(newWord.Word);
      Console.WriteLine(MysteryWord.randomId);
      MysteryWord.counter++;
      Console.WriteLine(MysteryWord.counter);
      return View(newWord);
    }
    [HttpPost("/hard/{letter}")]
    public ActionResult Update(string letter)
    {
      // Use the word that was just created  
      MysteryWord playerWord = MysteryWord.FindRandom(MysteryWord.randomId);
      bool duplicate = playerWord.AlreadyGuessed(letter);
      if(duplicate){
        Console.WriteLine("Already guessed this letter. Try a different letter.");
      } else {
        playerWord.AddLetter(letter);
        bool isMatch = playerWord.CheckLetter();
        if(isMatch)
        {
          bool win = playerWord.Win();
        } else {
          playerWord.Score++;
        }
        bool lose = playerWord.isGameOver();
        if(lose)
        {
          Console.WriteLine("You lose");
        }
      }
      return View(playerWord);
    }
  }
}