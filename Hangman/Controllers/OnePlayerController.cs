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
      MysteryWord.counter++;
      if(MysteryWord.counter > 4) {
        MysteryWord.ClearAllWords();
        MysteryWord.ClearAllHardWords();
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
          // For all blanks that are that letter, fill them in
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