using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using HairSalon.Models;

namespace HairSalon.Tests
{

  [TestClass]
  public class StylistTest : IDisposable
  {
    public StylistTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=3306;database=hairsalon_test;";
    }
    public void Dispose()
    {
      Recip.DeleteAll();
      Category.DeleteAll();
    }

    [TestMethod]
    public void GetAllStylists_ReturnsnoStylist_0()
    {
      int result = Stylist.GetAll().Count;
      Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void Equals_ReturnsTrueForSame_Stylist()
    {
      Stylist firstStylist = new Stylist("Amy", "Novo");
      Stylist secondStylist = new Stylist("Amy", "Novo");
      Assert.AreEqual(firstStylist, secondStylist);
    }

    [TestMethod]
    public void Save_DBAssignIdToStylist_Id()
    {
      Stylist testStylist = new Stylist("Amy", "Novo");
      testStylist.Save();
      Stylist savedStylist = Stylist.GetAll()[0];
      int result = savedStylist.GetId();
      int testId = testStylist.GetId();
      Assert.AreEqual(testId, result);
    }
    [TestMethod]
    public void Save_SavesStylistToDB_StylistList()
    {

      Stylist testStylist = new Stylist("Amy", "Novo");
      testStylist.Save();
      List<Stylist> result = Stylist.GetAll();
      List<Stylist> testList = new List<Stylist>{testStylist};      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void GetAll_ListStylists_StylistList()
    {
      Stylist newStylist1 = new Stylist("Gabriella", "Smith");
      newStylist1.Save();
      Stylist newStylist2 = new Stylist("Ann", "Peters");
      newStylist2.Save();
      List<Stylist> allStylists = Stylist.GetAll();
      List<Stylist> expectedList = new List<Stylist>{newStylist1, newStylist2};
      CollectionAssert.AreEqual(allStylists, expectedList);
    }
  }
}
