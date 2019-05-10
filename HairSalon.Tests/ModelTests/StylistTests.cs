using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Tests
{
  [TestClass]
  public class StylistTest: IDisposable
  {
    public void Dispose()
    {
      Stylist.ClearAll();
      Client.ClearAll();
    }
    public StylistTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=lindsey_baker_test;";
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfNamesAreTheSame_Stylist()
    {
      Stylist firstStylist = new Stylist("Jane", "Doe");
      Stylist secondStylist = new Stylist("Jane", "Doe");

      Assert.AreEqual(firstStylist, secondStylist);
    }

    [TestMethod]
    public void GetAll_ReturnsAllStylistObjects_StylistList()
    {

      Stylist newStylist1 = new Stylist("Jane", "Doe");
      newStylist1.Save();
      Stylist newStylist2 = new Stylist("Lindsey", "Baker");
      newStylist2.Save();
      List<Stylist> newList = new List<Stylist> { newStylist1, newStylist2 };

      List<Stylist> result = Stylist.GetAll();

      CollectionAssert.AreEqual(newList, result);
    }



    [TestMethod]
    public void StylistConstructor_CreatesInstanceOfStylist_Stylist()
    {
      Stylist newStylist = new Stylist("Jane", "Doe");
      Assert.AreEqual(typeof(Stylist), newStylist.GetType());
    }


    [TestMethod]
    public void Save_SavesStylistToDatabase_StylistList()
    {
      Stylist testStylist = new Stylist("Jane", "Doe");
      testStylist.Save();

      List<Stylist> result = Stylist.GetAll();
      List<Stylist> testList = new List<Stylist>{testStylist};

      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Save_DatabaseAssignsIdToStylist_Id()
    {
      Stylist testStylist = new Stylist("Jane", "Doe");
      testStylist.Save();

      Stylist savedStylist = Stylist.GetAll()[0];

      int result = savedStylist.Id;
      int testId = testStylist.Id;

      Assert.AreEqual(testId, result);
    }

    [TestMethod]
    public void Find_ReturnsStylistInDatabase_Stylist()
    {
      //Arrange
      Stylist testStylist = new Stylist("Jane", "Doe");
      testStylist.Save();

      //Act
      Stylist foundStylist = Stylist.Find(testStylist.Id);

      //Assert
      Assert.AreEqual(testStylist, foundStylist);
    }

    [TestMethod]
    public void GetClients_ReturnsEmptyHairSalon_HairSalon()
    {
      Stylist newStylist = new Stylist("Jane", "Doe");
      List<Client> newList = new List<Client> { };

      List<Client> result = newStylist.GetClients();

      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetClients_RetrievesAllClientsWithStylist_HairSalon()
    {
      Stylist testStylist = new Stylist("Jane", "Doe");
      testStylist.Save();
      Client firstClient = new Client("Jane", "Doe", testStylist.Id);
      firstClient.Save();
      Client secondClient = new Client("Jane", "Doe", testStylist.Id);
      secondClient.Save();
      List<Client> testHairSalon = new List<Client> {firstClient, secondClient};
      List<Client> resultHairSalon = testStylist.GetClients();

      CollectionAssert.AreEqual(testHairSalon, resultHairSalon);
    }


  }
}
