using System;
using System.Collections.Generic;

namespace Hangman.Models
{
  public class MysteryWord
  {
    public string Word { get; set; }
    public int Score { get; set; }
    public int Id { get; set; }
    public static char[] charArr { get; set; }
    public static List<string> _letters = new List<string>{};
    public static List<MysteryWord> _words = new List<MysteryWord>{};
    public static List<MysteryWord> _hard = new List<MysteryWord>{};
    public static int number { get; set; }
    public MysteryWord(string word)
    {
      Score = 0;
      Id = _words.Count;
      Word = word;
      _words.Add(this);
      charArr = new char[Word.Length];
    }
    public static void ClearAllWords()
    {
      _words.Clear();
    }
    public static void ClearAllHardWords()
    {
      _hard.Clear();
    }
    public static void ClearAllLetters()
    {
      _letters.Clear();
    }
    public static List<MysteryWord> GetAll()
    {
      return _words;
    }
    public bool Win()
    {
      char[] temp = FillInBlanks(); // ['_','','_',...]

      for(int i = 0; i < temp.Length; i++)
      {
        if(temp[i] == '_')
        {
          return false;
        } 
      }
      return true;
    }
    public static int RandomId()
    {
      DateTime time = DateTime.Now;
      int secs = int.Parse(time.ToString("ss"));
      // Get a random Id within range of _hard list
      if(secs > 10)
      {
        secs = secs % 10;
      }
      if(secs > 5 && secs < 10) {
        secs = secs - 4;
      }
      number = secs;
      return secs;
    }
    public bool isGameOver()
    {
      if(Score==6) {
        return true;
      } else {
        return false;
      }
    }
    public static MysteryWord Find(int searchId)
    {
      return _words[searchId-1];
    }
    public static MysteryWord FindRandom(int id)
    {
      return _hard[id];
    }
    public void AddLetter(string letter)
    {
      _letters.Add(letter.ToLower());
    }
    public static MysteryWord Generate()
    {
      // randomId should be in Range(1,6);
      MysteryWord matrix = new MysteryWord("revolutions");
      _hard.Add(new MysteryWord("matrix"));
      _hard.Add(new MysteryWord("peekaboo"));
      _hard.Add(new MysteryWord("galvanize"));
      _hard.Add(new MysteryWord("fuchsia"));
      _hard.Add(new MysteryWord("buzzwords"));
      _hard.Add(new MysteryWord("psyche"));

      // Get random id
      int id = RandomId();
      return _hard[id];
    }
    public List<string> LettersBank()
    {
      return _letters;
    }
    public bool AlreadyGuessed(string letter)
    {
      if (_letters.Contains(letter.ToLower()))
      {
        return true;
      } else {
        return false;
      }
    }
    public bool CheckLetter()
    {
      if (_letters.Count < 1){
        return false;
      } else {
        if(Word.ToLower().Contains(_letters[_letters.Count-1]) || Word.ToUpper().Contains(_letters[_letters.Count-1]))
        {
          return true;
        }
        else
        {
          return false;
        }
      }
    }
    public char[] FillInBlanks()
    {
      char[] filledIn = Word.ToCharArray();
      char[] blanks = new char[filledIn.Length];
      for(int i =0; i< blanks.Length; i++)
      {
        if(LettersBank().Contains(filledIn[i].ToString().ToLower()))
        {
          blanks[i] = filledIn[i];
        } else {
          if(filledIn[i] == ' ')
          {
            blanks[i] = ' ';
          } else {
            blanks[i] = '_';
          }
        }
      }
      return blanks;
    }
  }
}