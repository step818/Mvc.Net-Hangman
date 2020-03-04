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
    public static int randomId { get; set; }
    public static List<int> _ids = new List<int>{};
    public static int counter = 0;
    public MysteryWord(string word)
    {
      Score = 0;
      Id = _words.Count;
      Word = word;
      _words.Add(this);
      charArr = new char[word.Length];
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
    public static bool isRecent(int id)
    {
      if(_ids.Contains(id))
      {
        return true;
      } else {
        return false;
      }
    }
    public static int RandomId()
    {
      DateTime time = DateTime.Now;
      int secs = int.Parse(time.ToString("ss"));
      // Get a random Id within range of _hard list
      if(secs > 24 && secs % 2 == 0)
      {
        secs = (secs / 3) + 5;
      }
      if(secs > 24 && secs % 2 != 0) {
        secs = (secs / 3) + 4;
      }
      randomId = secs;
      return randomId;
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
      return _words[id];
    }
    public void AddLetter(string letter)
    {
      _letters.Add(letter.ToLower());
    }
    public static MysteryWord Generate()
    {
      // randomId should be in Range(1,25);
      MysteryWord matrix1 = new MysteryWord("matrix");
      MysteryWord matri2 = new MysteryWord("peekaboo");
      MysteryWord matrx3 = new MysteryWord("galvanize");
      MysteryWord matix4 = new MysteryWord("fuchsia");
      MysteryWord marix5 = new MysteryWord("buzzwords");
      MysteryWord mtrix6 = new MysteryWord("psyche");
      MysteryWord atrix7 = new MysteryWord("revolutions");
      MysteryWord m1atri8x = new MysteryWord("jazziest");
      MysteryWord ma2tri9 = new MysteryWord("cobweb");
      MysteryWord mat10rx = new MysteryWord("buffoon");
      MysteryWord mati11x = new MysteryWord("croquet");
      MysteryWord marix12 = new MysteryWord("daiquiri");
      MysteryWord mtrix13 = new MysteryWord("frizzled");
      MysteryWord matrix14 = new MysteryWord("kilobyte");
      MysteryWord matri15 = new MysteryWord("kiwifruit");
      MysteryWord matrx16 = new MysteryWord("mnemonic");
      MysteryWord matix17 = new MysteryWord("pneumatic");
      MysteryWord marix18 = new MysteryWord("onyx");
      MysteryWord mtrix19 = new MysteryWord("rickshaw");
      MysteryWord matrix20 = new MysteryWord("nymph");
      MysteryWord matri21 = new MysteryWord("luxury");
      MysteryWord matrx22 = new MysteryWord("quixotic");
      MysteryWord matix23 = new MysteryWord("megahertz");
      MysteryWord marix24 = new MysteryWord("topaz");
      MysteryWord mtrix25 = new MysteryWord("jukebox");

      // Get random id
      int id = RandomId();
      if(isRecent(id)) {
        System.Threading.Thread.Sleep(2000);
        Generate();
      }
      _ids.Add(id);
      return _words[id];
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