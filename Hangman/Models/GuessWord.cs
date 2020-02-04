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
    public MysteryWord(string word)
    {
      Score = 0;
      Id = _words.Count;
      Word = word;
      _words.Add(this);
      charArr = new char[Word.Length];
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
    public bool Win()
    {
      char[] temp = FillInBlanks(); // ['*','*','*',...]

      for(int i = 0; i < temp.Length; i++)
      {
        if(temp[i] == '*')
        {
          return false;
        } 
      }
      return true;
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
    public void AddLetter(string letter)
    {
      _letters.Add(letter.ToLower());
    }
    public List<string> LettersBank()
    {
      return _letters;
    }
    // public string FindLetter(int searchId)
    // {
    //   return _gLetters[searchId-1];
    // }
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
          // IncPoint(false);
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
            blanks[i] = '*';
          }
        }
      }
      return blanks;
    }


  }
}