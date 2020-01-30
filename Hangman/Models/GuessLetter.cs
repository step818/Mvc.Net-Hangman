using System;
using System.Collections.Generic;

namespace Hangman.Models
{
  public class Letter
  {
    public MysteryWord CurrentWord;
    public string userWord;
    public static List<string> _letters = new List<string>{};
    // Bet is the current user guessed letter. short for alphaBet
    public string Bet { get; set; }
    public int Id { get; set; }
    public Letter(string letter, MysteryWord word)
    {
      // Now I can check letter within word here because I have the word!
      this.userWord = word.Word;
      this.Bet = letter;
      _letters.Add(this.Bet);
      Id = _letters.Count;
    }
    public static List<string> GetAll()
    {
      return _letters;
    }
    public static void ClearAll()
    {
      _letters.Clear();
    }
    public bool checkL(string Bet) {
        if(userWord.ToLower().Contains(Bet) || userWord.ToUpper().Contains(Bet))
      {
        return true;
      }
      else
      {
        return false;
      }
    }
  }
}