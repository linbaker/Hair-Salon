using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Tests
{
  [TestClass]
  public class SpecialtyTest : IDisposable
  {

    public void Dispose()
    {
      Specialty.ClearAll();
      Stylist.ClearAll();
    }

    public SpecialtyTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=lindsey_baker_test;";
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfTypesAreTheSame_Specialty()
    {
      Specialty firstSpecialty = new Specialty("colorist");
      Specialty secondSpecialty = new Specialty("colorist");

      Assert.AreEqual(firstSpecialty, secondSpecialty);
    }

    [TestMethod]
    public void SpecialtyConstructor_CreatesInstanceOfSpecialty_Specialty()
    {
      Specialty newSpecialty = new Specialty("test specialty");

      Assert.AreEqual(typeof(Specialty), newSpecialty.GetType());
    }

    [TestMethod]
    public void GetAll_ReturnsAllSpecialtyObjects_SpecialtyList()
    {
      string name01 = "Colorist";
      string name02 = "Extenstions";
      Specialty newSpecialtyOne = new Specialty(name01);
      newSpecialtyOne.Save();
      Specialty newSpecialtyTwo = new Specialty(name02);
      newSpecialtyTwo.Save();
      List<Specialty> newList = new List<Specialty> { newSpecialtyOne, newSpecialtyTwo };
      List<Specialty> result = Specialty.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Save_SavesSpecialtyToDatabase_SpecialtyList()
    {
      Specialty testSpecialty = new Specialty("Waxing");
      testSpecialty.Save();
      List<Specialty> result = Specialty.GetAll();
      List<Specialty> testList = new List<Specialty>{testSpecialty};
      CollectionAssert.AreEqual(testList, result);
    }

    // [TestMethod]
    // public void AddStylist_AddsStylistToSpecialty_StylistList()
    // {
    //   Specialty testSpecialty = new Specialty("Gardening");
    //   testSpecialty.Save();
    //   Stylist testStylist = new Stylist("Edward", "Scissorhands");
    //   testStylist.Save();
    //
    //   testSpecialty.AddStylist(testStylist);
    //
    //   List<Stylist> result = testSpecialty.GetStylists();
    //   List<Stylist> testList = new List<Stylist>{testStylist};
    //   Console.WriteLine(result);
    //   Console.WriteLine(testList);
    //
    //   Assert.AreEqual(testList, result);
    // }

    [TestMethod]
    public void GetStylist_ReturnsAllSpecialtyStylist_CategoryList()
    {
      Specialty testSpecialty = new Specialty("Meat Pies");
      testSpecialty.Save();
      Stylist testStylist = new Stylist("Sweeney", "Todd");
      testStylist.Save();

      testSpecialty.AddStylist(testStylist);
      List<Stylist> result = testSpecialty.GetStylists();
      List<Stylist> testList = new List<Stylist> {testStylist};

      CollectionAssert.AreEqual(testList, result);
    }
  }
}
