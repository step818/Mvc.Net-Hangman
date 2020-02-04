using System;
using System.Collections.Generic;

namespace Hangman.Models
{
  public class Letter
  {
    // Bet is the current user guessed letter. short for alphaBet
    public string Bet { get; set; }
    public int Id { get; set; }
    // public List<string> _letters = new List<string>{};
    public Letter(string letter)
    {
      Bet = letter;
      // _letters.Add(letter);
    }
  }
}