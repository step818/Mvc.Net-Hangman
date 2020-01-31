using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hangman.Models;
using System.Collections.Generic;
using System;

namespace Hangman.Tests
{
  [TestClass]
  public class LetterTests : IDisposable
  {
    public void Dispose()
    {
      Letter.ClearAll();
    }
    [TestMethod]
    public void LetterConstructor_CreatesInstOfLetter_Type()
    {
      MysteryWord newWord = new MysteryWord("nice");
      Letter newLetter = new Letter("s", newWord);
      Assert.AreEqual(typeof(Letter), newLetter.GetType());
    }
    [TestMethod]
    public void Letter_MakeInstance_Obj()
    {
      MysteryWord newWord = new MysteryWord("nice");
      string myLetter = "b";
      Letter newLetter = new Letter(myLetter, newWord);
      string result = newLetter.Bet;
      Assert.AreEqual(result, myLetter);
    }
    [TestMethod]
    public void GetAll_ReturnLetters_List()
    {
      MysteryWord newWord = new MysteryWord("nice");
      // Set up a letter list
      Letter newLetter1 = new Letter("a", newWord);
      Letter newLetter2 = new Letter("b", newWord);
      List<string> myLetters = new List<string> {newLetter1.Bet, newLetter2.Bet};
      List<string> result = Letter.GetAll();
      // Assert
      CollectionAssert.AreEqual(myLetters, result);
    }
    [TestMethod]
    public void checkL_ReturnsBool_True()
    {
      MysteryWord newWord = new MysteryWord("hello");
      Letter newLetter = new Letter("H", newWord);
      bool result = newLetter.checkL(newLetter.Bet);
      Assert.AreEqual(true, result);
    }
  }
}