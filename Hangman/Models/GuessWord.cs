using System;
using System.Collections.Generic;

namespace Hangman.Models
{
  public class MysteryWord
  {
    public string Word { get; set; }
    public static List<MysteryWord> _words = new List<MysteryWord>{};
    public MysteryWord(string word)
    {
      Word = word;
      _words.Add(this);
    }
    // public static void ClearAll()
    // {
    //   _words.Clear();
    // }
    // public static List<MysteryWord> GetAll()
    // {
    //   return _words;
    // }
    // public List<string> GetAllLetters()
    // {
    //   return _gLetters;
    // }
    public static MysteryWord Find(int searchId)
    {
      return _words[searchId-1];
    }
    // // Might not need AddLetter
    // public void AddLetter(string letter)
    // {
    //   _gLetters.Add(letter);
    // }
    // public string FindLetter(int searchId)
    // {
    //   return _gLetters[searchId-1];
    // }
    // public bool CheckLetter()
    // {
    //   if(Word.ToLower().Contains(Guess.Bet) || Word.ToUpper().Contains(Guess.Bet))
    //   {
    //     return true;
    //   }
    //   else
    //   {
    //     IncPoint(false);
    //     return false;
    //   }
    // }
  }
}