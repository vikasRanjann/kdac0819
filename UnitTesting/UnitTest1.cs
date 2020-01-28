using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySecurityLib;


namespace UnitTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string result = Security.GetOTP("1",5);
            Assert.AreNotEqual(String.Empty, result);
        }
        [TestMethod]
        public void TestMethod2()
        {
            string pwd = "Sunbeam";
            string encData = null;
            bool result = Security.Encrypt(pwd, out encData);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TestMethod3()
        {
            string pwd = "vHK4GrTDbOc=";
            string decData = null;
            bool result = Security.Decrypt(pwd, out decData);
            Assert.AreEqual(true, result);
        }

    }
}
