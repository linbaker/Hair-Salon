using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Tests
{
  [TestClass]
  public class ClientTest : IDisposable
  {

    public void Dispose()
    {
      Client.ClearAll();
    }

    public ClientTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=lindsey_baker_test;";
    }

    [TestMethod]
    public void ClientConstructor_CreatesInstanceOfClient_Client()
    {
      Client newClient = new Client("first name", "last name", new DateTime(2019,05,01), 1);
      Assert.AreEqual(typeof(Client), newClient.GetType());
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_ClientList()
    {
      List<Client> newList = new List<Client> { };

      List<Client> result = Client.GetAll();

      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsClients_ClientList()
    {
      Client newClient1 = new Client("first name", "last name", new DateTime(2019,05,01), 1);
      newClient1.Save();
      Client newClient2 = new Client("first name1", "last name1", new DateTime(2019,05,02), 2);
      newClient2.Save();
      List<Client> newList = new List<Client> { newClient1, newClient2 };

      List<Client> result = Client.GetAll();

      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectClientFromDatabase_Client()
    {
      Client testClient = new Client("first name1", "last name1", new DateTime(2019,05,02), 1);
      testClient.Save();

      Client foundClient = Client.Find(testClient.Id);

      Assert.AreEqual(testClient, foundClient);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfNamesAreTheSame_Client()
    {
      Client firstClient = new Client("first name1", "last name1", new DateTime(2019,05,02), 1);
      Client secondClient = new Client("first name1", "last name1", new DateTime(2019,05,02), 1);

      Assert.AreEqual(firstClient, secondClient);
    }

  }
}
