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
    public void GetCategories_ReturnsAllStCategories_CategoryList()
    {
      //Arrange
      Stylist testStylist = new Stylist("Mow the lawn");
      testStylist.Save();

      Client testClient1 = new Client("Home stuff");
      testClient1.Save();Stylist

      Client testClient2 = new Client("Work stuff");
      testClient2.Save();

      //Act
      testClient.AddClient(testClient1);
      List<Client> result = testStylist.GetClient();
      List<Client> testList = new List<Client> {testClient1};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    // [TestMethod]
    // public void GetAll_DatabaseEmptyAtFirst_0()
    // {
    //   //Arrange, Act
    //   int result = Task.GetAll().Count;
    //
    //   //Assert
    //   Assert.AreEqual(0, result);
    // }
    //
    // [TestMethod]
    // public void Equals_TrueForSameDescription_Task()
    // {
    //   //Arrange, Act
    //   Task firstTask = new Task("Mow the lawn");
    //   Task secondTask = new Task("Mow the lawn");
    //
    //   //Assert
    //   Assert.AreEqual(firstTask, secondTask);
    // }
    //
    // [TestMethod]
    // public void Save_TaskSavesToDatabase_TaskList()
    // {
    //   //Arrange
    //   Task testTask = new Task("Mow the lawn");
    //   testTask.Save();
    //
    //   //Act
    //   List<Task> result = Task.GetAll();
    //   List<Task> testList = new List<Task>{testTask};
    //
    //   //Assert
    //   CollectionAssert.AreEqual(testList, result);
    // }
    //
    // [TestMethod]
    // public void Save_AssignsIdToObject_id()
    // {
    //   //Arrange
    //   Task testTask = new Task("Mow the lawn");
    //   testTask.Save();
    //
    //   //Act
    //   Task savedTask = Task.GetAll()[0];
    //
    //   int result = savedTask.GetId();
    //   int testId = testTask.GetId();
    //
    //   //Assert
    //   Assert.AreEqual(testId, result);
    // }
    //
    // [TestMethod]
    // public void Find_FindsTaskInDatabase_Task()
    // {
    //   //Arrange
    //   Task testTask = new Task("Mow the lawn");
    //   testTask.Save();
    //
    //   //Act
    //   Task result = Task.Find(testTask.GetId());
    //
    //   //Assert
    //   Assert.AreEqual(testTask, result);
    // }
    // [TestMethod]
    // public void AddCategory_AddsCategoryToTask_CategoryList()
    // {
    //   //Arrange
    //   Task testTask = new Task("Mow the lawn");
    //   testTask.Save();
    //
    //   Category testCategory = new Category("Home stuff");
    //   testCategory.Save();
    //
    //   //Act
    //   testTask.AddCategory(testCategory);
    //
    //   List<Category> result = testTask.GetCategories();
    //   List<Category> testList = new List<Category>{testCategory};
    //
    //   //Assert
    //   CollectionAssert.AreEqual(testList, result);
    // }
  }
}
