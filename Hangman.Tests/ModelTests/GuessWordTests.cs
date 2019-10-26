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
      MysteryWord.ClearAll();
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
      Assert.AreEqual(result, 1);
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
    [TestMethod]
    public void AddList_ReturnLetterWithinWord_List()
    {
      // Set up an arranged list through Letter
      string urLetter1 = "a";
      string urLetter2 = "s";
      Letter newLetter1 = new Letter(urLetter1);
      Letter newLetter2 = new Letter(urLetter2);
      // Arranged List with newLetter1.Bet="a", newLetter2.Bet="b"
      List<Letter> urLetterGuesses = new List<Letter> {newLetter1, newLetter2};
      // Create Word and add Letter instances to List through MysteryWord
      string myWord = "poop";
      MysteryWord newWord = new MysteryWord(myWord);
      // Add instances of Letter Class to MysteryWord instance of newWord
      newWord.AddLetter(newLetter1);
      newWord.AddLetter(newLetter2);
      // Result List with newWord.Word="poop" , newWord.Id= 1 , newWord.Letters = {newLetter1.Bet, newLetter2.Bet} = {"a", "b"} 
      List<Letter> result = newWord.Letters;
      // Assert
      CollectionAssert.AreEqual(result, urLetterGuesses);
    }
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
      bool result = newWord.CheckLetter(newLetter);
      //Assert
      Assert.AreEqual(false, result);
    }
    [TestMethod]
    public void CheckLetter_ReturnTrue_Bool()
    {
      // Arrange a mysteryWord instance and a letter instance
      MysteryWord newWord = new MysteryWord("Dollar tree");
      Letter newLetter = new Letter("t");
      // Get the result from the method
      bool result = newWord.CheckLetter(newLetter);
      // Assert
      Assert.AreEqual(true, result);
    }
    [TestMethod]
    public void FindLetter_ReturnsLetterFromList_Letter()
    {
      MysteryWord newWord = new MysteryWord("ice cream");
      Letter newLetter = new Letter("c");
      newWord.AddLetter(newLetter);
      Letter result = newWord.FindLetter(1);
      Assert.AreEqual(newLetter, result);
    }
  }
}