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
     
            try
            {
                Assert.AreEqual("carbon credits", response.Name.ToLower());
            }
            catch (AccessViolationException e)
            {
                throw e;
            }
        }

        [TestMethod]
        public void VerifyIfCanRelist()
        {
            var mainPage = new MainClass();
            var response = mainPage.GetDataList();
           
            try
            {
                Assert.IsTrue(response.CanRelist);
            }
            catch (AccessViolationException e)
            {
                throw e;
            }
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
                    try
                    {
                        Assert.IsTrue(promotions.Description.Contains("2x larger image"));
                    }
                    catch (AccessViolationException e)
                    {
                        throw e;
                    }
                }

            }
        }
    }
}
