using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hangman.Models;
using System;
using System.Collections.Generic;

namespace Hangman.Tests
{
  [TestClass]
  public class MysteryWordTest : IDisposable
  {
    public void Dispose()
    {
      MysteryWord.ClearAllWords();
    }
    [TestMethod]
    public void MysteryWord_MakeObject_Obj()
    {
      string myWord = "Back to the future";
      MysteryWord newWord = new MysteryWord(myWord);
      string result = newWord.Word;
      Assert.AreEqual(result, myWord);
    }
    [TestMethod]
    public void MysteryWord_MakeObjId_Id()
    {
      string myWord = "VsCode";
      MysteryWord newWord = new MysteryWord(myWord);
      int result = newWord.Id;
      Assert.AreEqual(result, 0);
    }
    [TestMethod]
    public void GetAll_ReturnsList_List()
    {
      string word1 = "Meowing cat";
      string word2 = "Barking dog";
      MysteryWord newWord1 = new MysteryWord(word1);
      MysteryWord newWord2 = new MysteryWord(word2);
      List<MysteryWord> newList = new List<MysteryWord> {newWord1, newWord2};
      List<MysteryWord> result = MysteryWord.GetAll();
      CollectionAssert.AreEqual(result, newList);
    }
    // [TestMethod]
    // public void AddList_ReturnLetterWithinWord_List()
    // {
    //   // Create Word and add Letter instances to List through MysteryWord
    //   string myWord = "poop";
    //   MysteryWord newWord = new MysteryWord(myWord);
    //   // Set up an arranged list through Letter
    //   string urLetter1 = "a";
    //   string urLetter2 = "s";
    //   Letter newLetter1 = new Letter(urLetter1, newWord);
    //   Letter newLetter2 = new Letter(urLetter2, newWord);
    //   // Arranged List with newLetter1.Bet="a", newLetter2.Bet="b"
    //   List<string> urLetterGuesses = new List<string> {newLetter1.Bet, newLetter2.Bet};
    //   // Add instances of Letter Class to MysteryWord instance of newWord
    //   newWord.AddLetter(newLetter1.Bet);
    //   newWord.AddLetter(newLetter2.Bet);
    //   // Result List with newWord.Word="poop" , newWord.Id= 1 , newWord.Letters = {newLetter1.Bet, newLetter2.Bet} = {"a", "b"} 
    //   // Letters property no longer in MysteryWord
    //   List<string> result = newWord.Letters;
    //   // Assert
    //   CollectionAssert.AreEqual(result, urLetterGuesses);
    // }
    [TestMethod]
    public void Find_ReturnWordListThis_MysteryWord()
    {
      // Setup
      string myWord1 = "James Burke";
      string myWord2 = "Carl Sagan";
      MysteryWord newWord1 = new MysteryWord(myWord1);
      MysteryWord newWord2 = new MysteryWord(myWord2);
      // Test the function
      MysteryWord result = MysteryWord.Find(2);
      //Assert
      Assert.AreEqual(result, newWord2);
    }
    [TestMethod]
    public void CheckLetter_ReturnFalse_Bool()
    {
      // Arrange a mysteryword instance and a letter instance
      MysteryWord newWord = new MysteryWord("Dollar tree");
      Letter newLetter = new Letter("z");
      // Get the actual result
      bool result = newWord.CheckLetter();
      //Assert
      Assert.AreEqual(false, result);
    }
    [TestMethod]
    public void CheckLetter_ReturnTrue_Bool()
    {
      // Arrange a mysteryWord instance and a letter instance
      MysteryWord newWord = new MysteryWord("Dollar Tree");
      newWord.AddLetter("R");
      // Get the result from the method
      bool result = newWord.CheckLetter();
      // Assert
      Assert.AreEqual(true, result);
    }
    [TestMethod]
    public void FillInBlanks_ReturnsInitial_CharArray()
    {
      MysteryWord newWord = new MysteryWord("This is");
      char[] result = newWord.FillInBlanks();
      char[] test = {'_','_','_','_',' ','_','_'};
      Assert.AreEqual(test[4], result[4]);
    }
  }
}