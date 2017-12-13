using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestHousing;

namespace UnitTestHousing
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void VerifyUserDetails_Successful_Test()
        {
            //arrange
            //Create new instance of database connection
            dcarronHousingEntitiesTest db = new dcarronHousingEntitiesTest();
            //Create new instance of class that contains method to be tested
            MainWindow mw = new MainWindow();
            string testUName = "student";
            string testPassword = "password";
            User expected = new User()
            {
                UName = "student",
                Password = "password",
                
            };

            //act
            //This is the method under test
            User actual = mw.VerifyUserDetails(testUName, testPassword);

            //assert
            //This test does not run as expected
            Assert.AreEqual<User>(expected, actual, "Error when extracting User from database");


        }
        [TestMethod]
        public void VerifyUserDetails_Failed_Test()
        {
            //arrange
            //Create new instance of database connection
            dcarronHousingEntitiesTest db = new dcarronHousingEntitiesTest();
            //Create new instance of class that contains method to be tested
            MainWindow mw = new MainWindow();
            string testUName = "stud";
            string testPassword = "password";

            User expected = new User()
            {
                UName = "student",
                Password = "password",
               
            };

            //act
            //This is the method under test
            User actual = mw.VerifyUserDetails(testUName, testPassword);

            //assert
            //This test does not run as expected
            Assert.AreEqual<User>(expected, actual, "Error when extracting User from database");


        }
    }

    internal class MainWindow
    {
    }
}

