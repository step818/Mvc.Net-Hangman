using System;
using System.Collections.Generic;

namespace Hangman.Models
{
  public class Player
  {
    public int Score { get; set; }
    public Letter Guess { get; set; }
    public MysteryWord CurrentWord { get; set; }
    public static List<Player> _games = new List<Player>{};
    public Player (MysteryWord wrd)
    {
      CurrentWord = wrd;
      Score = 0;
      _games.Add(this);
    }

    public static Player Find(int searchId){
      return _games[searchId-1];
    }

    public static int giveMeNine()
    {
      return 9;
    }
  }
}