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
    public static List<MysteryWord> GetAll()
    {
      return _words;
    }
    public static MysteryWord Find(int searchId)
    {
      return _words[searchId-1];
    }
    public void AddLetter(Letter letter)
    {
      Letters.Add(letter);
    }
    public bool CheckLetter(Letter letter)
    {
      if(Word.Contains(letter.Bet))
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