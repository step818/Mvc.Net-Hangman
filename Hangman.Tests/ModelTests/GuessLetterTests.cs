using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hangman.Models;
using System.Collections.Generic;
using System;

namespace Hangman.Tests
{
  [TestClass]
  public class LetterTests
  {
    // public void Dispose()
    // {
    //   Letter.ClearAll();
    // }
    [TestMethod]
    public void LetterConstructor_CreatesInstOfLetter_Type()
    {
      Letter newLetter = new Letter("s");
      Assert.AreEqual(typeof(Letter), newLetter.GetType());
    }
    [TestMethod]
    public void Letter_MakeInstance_Obj()
    {
      string myLetter = "b";
      Letter newLetter = new Letter(myLetter);
      string result = newLetter.Bet;
      Assert.AreEqual(result, myLetter);
    }
  }
}