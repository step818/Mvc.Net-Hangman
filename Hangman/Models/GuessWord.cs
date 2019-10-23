using System;
using System.Collections.Generic;

namespace Hangman.Models
{
  public class MysteryWord
  {
    private static List<MysteryWord> _words = new List<MysteryWord>{};
    public string Word { get; set; }
  }
}