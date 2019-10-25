using System;
using System.Collections.Generic;

namespace Hangman.Models
{
  public class Letter
  {
    public static List<Letter> _letters = new List<Letter>{};
    // Bet is the current user guessed letter. short for alphaBet
    public string Bet { get; set; }
    public Letter(string letter)
    {
      Bet = letter;
      _letters.Add(this);
    }
    public static List<Letter> GetAll()
    {
      return _letters;
    }
    public static void ClearAll()
    {
      _letters.Clear();
    }
  }
}