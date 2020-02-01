using System;
using System.Collections.Generic;

namespace Hangman.Models
{
  public class Player
  {
    public int Score { get; set; }
    public Letter Guess { get; set; }
    public MysteryWord CurrentWord { get; set; }
    public Player (Letter letter, MysteryWord wrd)
    {
      Guess = letter;
      CurrentWord = wrd;
    }
  }
}