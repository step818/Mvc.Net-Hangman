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

    [HttpGet("/hard")]
    public ActionResult Show()
    {
      Random random = new Random();    
      int rand = random.Next(1, 6);   
      MysteryWord newWord = MysteryWord.Generate(rand);
      return View(newWord);
    }
    [HttpPost("/hard/{letter}")]
    public ActionResult Update(string letter)
    {
      // Use the word that was just created
      Random random = new Random();    
      int rand = random.Next(1, 6);  
      MysteryWord playerWord = MysteryWord.FindRandom(rand);
      bool duplicate = playerWord.AlreadyGuessed(letter);
      if(duplicate){
        ViewBag.Message = string.Format("Hello {0}.\\nCurrent Date and Time: {1}", letter, DateTime.Now.ToString());
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