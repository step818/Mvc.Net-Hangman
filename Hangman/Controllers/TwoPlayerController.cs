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
      MysteryWord.ClearAllWords();
      MysteryWord.ClearAllLetters();
      return View();
    }
    // Brings up Show which is main game page
    [HttpPost("/hangman")]
    public ActionResult Show(string word)
    {
      MysteryWord newWord = new MysteryWord(word);
      return View(newWord);
    }

    [HttpPost("/hangman/{letter}")]
    public ActionResult Update(string letter)
    {
      // Use the word that was just created
      MysteryWord playerWord = MysteryWord.Find(1);
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