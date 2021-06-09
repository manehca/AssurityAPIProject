using Microsoft.VisualStudio.TestTools.UnitTesting;
using AssurityAPIProj;
using System;


namespace APITesting
{
    [TestClass]
    public class APITests
    {
        [TestMethod]
        public void VerifyCategory()
        {
            var mainPage = new MainClass();
            var response = mainPage.GetDataList();
            Assert.AreEqual("carbon credits", response.Name.ToLower());
        }

        [TestMethod]
        public void VerifyIfCanRelist()
        {
            var mainPage = new MainClass();
            var response = mainPage.GetDataList();
            Assert.IsTrue(response.CanRelist);
        }

        [TestMethod]
        public void VerifyPromotions()
        {
            var mainPage = new MainClass();
            var response = mainPage.GetDataList();

            foreach (var promotions in response.Promotions)
            {
                if (promotions.Name.ToString().ToLower() == "gallery")
                {
                    Assert.IsTrue(promotions.Description.Contains("2x larger image"));
                }

            }
        }
    }
}
