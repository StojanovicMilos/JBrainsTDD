using BarcodeScanner;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;

namespace BarcodeScannerTests
{
    [TestClass]
    public class FormatMonetaryAmountTests
    {
        [TestMethod]
        public void Simple()
        {
            Assert.AreEqual("$7.95", new Display().Format(795));
        }

        [TestMethod]
        public void Simple1()
        {
            Assert.AreEqual("$7.89", new Display().Format(789));
        }

        [TestMethod]
        public void Simple2()
        {
            Assert.AreEqual("$5.20", new Display().Format(520));
        }

        [TestMethod]
        public void Simple3()
        {
            Assert.AreEqual("$4.00", new Display().Format(400));
        }

        [TestMethod]
        public void Zero()
        {
            Assert.AreEqual("$0.00", new Display().Format(0));
        }

        [TestMethod]
        public void Simple4()
        {
            Assert.AreEqual("$0.02", new Display().Format(2));
        }

        [TestMethod]
        public void Simple5()
        {
            Assert.AreEqual("$0.37", new Display().Format(37));
        }


    }
}
