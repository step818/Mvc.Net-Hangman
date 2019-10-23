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
  }
}