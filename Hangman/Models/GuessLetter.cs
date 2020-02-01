using System;
using System.Collections.Generic;

namespace Hangman.Models
{
  public class Letter
  {
    // Bet is the current user guessed letter. short for alphaBet
    public string Bet { get; set; }
    public int Id { get; set; }
    public List<string> _letters = new List<string>{};
    public Letter(string letter)
    {
      // Now I can check letter within word here because I have the word!
      Bet = letter;
      _letters.Add(letter);
    }

    // public bool CheckLetter()
    // {
    //   if(CurrentWord.Word.ToLower().Contains(Bet) || CurrentWord.Word.ToUpper().Contains(Bet))
    //   {
    //     return true;
    //   }
    //   else
    //   {
    //     IncPoint();
    //     return false;
    //   }
    // } 

    // public int IncPoint()
    // {
    //   return CurrentWord.Score++;
    // }
  }
}