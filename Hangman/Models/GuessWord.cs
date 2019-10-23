using System;
using System.Collections.Generic;

namespace Hangman.Models
{
  public class MysteryWord
  {
    private static List<MysteryWord> _words = new List<MysteryWord>{};
    public List<Letter> Letters { get;set; }
    public int Id { get;set; }
    public string Word { get; set; }
    public MysteryWord(string word)
    {
      Word = word;
      _words.Add(this);
      Id = _words.Count;
      Letters = new List<Letter>{};
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