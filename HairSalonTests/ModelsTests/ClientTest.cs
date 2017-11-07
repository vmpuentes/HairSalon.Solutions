using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Tests
{

  [TestClass]

  public class HairSalonTest : IDisposable
  {
    public HairSalonTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=victor_puentes_test;";
    }

    public void Dispose()
    {
      Client.DeleteAll();
    }

    [TestMethod]
    public void GetAll_DatabaseEmptyFirst_0()
    {
      //Arrange, Act
      int result = Client.GetAll().Count;

      //Assert
      Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void Save_SaveToDB_ClientList()
    {
      //Arrange
      Client testClient = new Client("Amy Novo", 1, 1);

      //Act
      testClient.Save();
      List<Client> result = Client.GetAll();
      List<Client> testList = new List<Client>{testClient};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Equals_OverrideIfNameisSame_Client()
    {
      //Arrange, Act
      Client Client1 = new Client("Amy Novo", 1);
      Client Client2 = new Client("Amy Novo", 1);

      //Assert
      Assert.AreEqual(Client1, Client2);
    }

    [TestMethod]
    public void Save_IdToObject_Id()
    {
      //Assert
      Client testClient = new Client("Amy Novor", 1, 2);

      //Act
      testClient.Save();
      Client savedClient = Client.GetAll()[0];

      int result = savedClient.GetId();
      int testId = testClient.GetId();

      //Assert
      Assert.AreEqual(testId, result);
    }

    [TestMethod]
    public void Update_UpdateClientInDB_String()
    {
      // Arrange
      string name = "Amy Novo";
      Client testClient = new Client(name, 1, 2);
      testClient.Save();
      string newName = "Ann Peters";

      // Act
      testClient.UpdateName(newName);

      string result = Client.Find(testClient.GetId()).GetName();

      // Assert
      Assert.AreEqual(newName, result);
    }

    [TestMethod]
    public void Find_FindClientInDB_Client()
    {
      // Arrange
      Client testClient = new Client("Amy Novo", 1, 2);
      testClient.Save();

      // Act
      Client findClient = Client.Find(testClient.GetId());

      // Assert
      Assert.AreEqual(testClient, foundClient);
    }


  }
}
