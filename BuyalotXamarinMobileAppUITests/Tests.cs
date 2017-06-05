using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace BuyalotXamarinMobileAppUITests
{
    [TestFixture(Platform.Android)]
    //[TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void AppLaunches()
        {
            app.Screenshot("First screen.");
        }

        //[Test]
        //public void AddProducts2()
        //{
        //    //Arrange
        //    app.EnterText("EntryCat", "Kitchen");

        //    //Act
        //    app.Tap("ButtonCatCreate");

        //    //Assert
        //    var appResult = app.Query("DispCat").FirstOrDefault(result => result.Text == "Kitchen");
        //    Assert.IsTrue(appResult != null, "Categories.get does not display correct results");
        //}



        [Test]
        public void Add_Category()
        {
            //Arrange
            app.EnterText("EntryCat", "Kitchen");

            //Act
            app.Tap("ButtonCatCreate");

            //Assert
            var appResult = app.Query("DisplayCat").FirstOrDefault(result => result.Text == "Kitchen");
            Assert.IsTrue(appResult != null, "Categories.get does not display correct results");
        }
    }
}

