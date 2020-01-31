using System;
using System.Collections.Generic;

namespace Hangman.Models
{
  public class MysteryWord
  {
    public Letter Guess { get; set; }
    //  The Letters list is being created when the word is being instanciated.
    public static List<string> _gLetters = new List<string>{};
    private static List<MysteryWord> _words = new List<MysteryWord>{};
    public int Id { get; }
    public string Word { get; set; }
    public int Score { get; set; }
    public MysteryWord(string word, Letter abc)
    {
      this.Guess = abc;
      _gLetters.Add(abc.Bet);
      Score = 0;
      Word = word;
      _words.Add(this);
      Id = _words.Count;
    }
    public static void ClearAll()
    {
      _words.Clear();
    }
    public static List<MysteryWord> GetAll()
    {
      return _words;
    }
    public static List<string> GetAllLetters()
    {
      return _gLetters;
    }
    public static MysteryWord Find(int searchId)
    {
      return _words[searchId-1];
    }
    // Might not need AddLetter
    public void AddLetter(string letter)
    {
      _gLetters.Add(letter);
    }
    public string FindLetter(int searchId)
    {
      return _gLetters[searchId-1];
    }
    public bool CheckLetter()
    {
      if(Word.ToLower().Contains(Guess.Bet) || Word.ToUpper().Contains(Guess.Bet))
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