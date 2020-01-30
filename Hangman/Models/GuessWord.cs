using System;
using System.Collections.Generic;

namespace Hangman.Models
{
  public class MysteryWord
  {
    private static List<MysteryWord> _words = new List<MysteryWord>{};
    //  The Letters list is being created when the word is being instanciated.
    public List<string> Letters { get;set; }
    public int Id { get; }
    public string Word { get; set; }
    public char First { get; }
    public MysteryWord(string word)
    {
      Word = word;
      _words.Add(this);
      Id = _words.Count;
      First = Word.ToCharArray()[0];
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
    // Might not need AddLetter
    public void AddLetter(string letter)
    {
      Letters.Add(letter);
    }
    public string FindLetter(int searchId)
    {
      return Letters[searchId-1];
    }
    public bool CheckLetter(Letter letter)
    {
      if(Word.ToLower().Contains(letter.Bet) || Word.ToUpper().Contains(letter.Bet))
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