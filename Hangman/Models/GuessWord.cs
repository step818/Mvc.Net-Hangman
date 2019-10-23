using System;
using System.Collections.Generic;

namespace Hangman.Models
{
  public class MysteryWord
  {
    private static List<MysteryWord> _words = new List<MysteryWord>{};
    private static List<MysteryWord> _letters = new List<MysteryWord>{};
    public int Id { get;set; }
    public string Word { get; set; }
    public MysteryWord(string word)
    {
      Word = word;
      _words.Add(this);
      Id = _words.Count;
    }
    public static void ClearAll()
    {
      _words.Clear();
    }
    public bool CheckLetter(char letter)
    {
      if(Word.Contains(letter))
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