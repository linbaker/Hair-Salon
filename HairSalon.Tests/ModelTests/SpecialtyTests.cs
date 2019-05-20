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
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=;port=3306;database=lindsey_baker_test;";
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

    [TestMethod]
    public void Save_DatabaseAssignsIdToSpecialty_Id()
    {
      Specialty testSpecialty = new Specialty("Highlights");
      testSpecialty.Save();

      Specialty savedSpecialty = Specialty.GetAll()[0];

      int result = savedSpecialty.Id;
      int testId = testSpecialty.Id;

      Assert.AreEqual(testId, result);
    }

    [TestMethod]
    public void AddStylist_AddsStylistToSpecialty_StylistList()
    {
      Specialty testSpecialty = new Specialty("Gardening");
      testSpecialty.Save();
      Stylist testStylist = new Stylist("Edward", "Scissorhands");
      testStylist.Save();

      testSpecialty.AddStylist(testStylist);

      List<Stylist> result = testSpecialty.GetStylists();
      List<Stylist> testList = new List<Stylist>{testStylist};

      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void GetStylist_ReturnsAllSpecialtyStylist_SpecialtyList()
    {
      Specialty testSpecialty = new Specialty("Meat Pies");
      testSpecialty.Save();
      Stylist testStylist = new Stylist("Sweeney", "Todd");
      testStylist.Save();
      Stylist testStylistTwo = new Stylist("Edward", "Scissorhands");
      testStylist.Save();

      testSpecialty.AddStylist(testStylist);
      List<Stylist> result = testSpecialty.GetStylists();
      List<Stylist> testList = new List<Stylist> {testStylist};

      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Find_ReturnsSpecialtyInDatabase_Specialty()
    {
      Specialty testSpecialty = new Specialty("Mohawks");
      testSpecialty.Save();

      Specialty foundSpecialty = Specialty.Find(testSpecialty.Id);

      Assert.AreEqual(testSpecialty, foundSpecialty);
    }

    [TestMethod]
    public void DeleteSpecialty_DeletesSpecialtyAssociationsFromDatabase_SpecialtyList()
    {
      Stylist testStylist = new Stylist ("Jane", "Doe");
      testStylist.Save();
      string testType = "Mohawk";
      Specialty testSpecialty = new Specialty(testType);
      testSpecialty.Save();

      testSpecialty.AddStylist(testStylist);
      testSpecialty.DeleteSpecialty();
      List<Specialty> resultStylistSpecialties = testStylist.GetSpecialties();
      List<Specialty> testStylistSpecialties = new List<Specialty> {};

      CollectionAssert.AreEqual(testStylistSpecialties, resultStylistSpecialties);
    }

  }
}
