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
      return View(newWord);
    }

    [HttpPost("/hangman/{letter}")]
    public ActionResult Update(string letter)
    {
      // Use the word that was just created
      MysteryWord playerWord = MysteryWord.Find(1);
      bool duplicate = playerWord.AlreadyGuessed(letter);
      if(duplicate){
        Console.WriteLine("Already guessed this letter. Try a different letter.");
      } else {
        // Add letter to the letters list
        playerWord.AddLetter(letter);
        playerWord.FillInBlanks();
        bool isMatch = playerWord.CheckLetter();
        if(isMatch)
        {
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
      // Console.WriteLine(newLetter.Id);
      // Console.WriteLine(isMatch);
      // foreach(string i in allLetters)
      // {
      //   Console.WriteLine(i);
      // }
      
      //This is where you input a letter to the Guessword model
      return View(playerWord);
    }
  }
}