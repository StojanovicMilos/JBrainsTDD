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
        public void Simplest0()
        {
            Assert.AreEqual("$7.95", Format(795));
        }

        [TestMethod]
        public void Simplest1()
        {
            Assert.AreEqual("$7.89", Format(789));
        }

        [TestMethod]
        public void Simplest2()
        {
            Assert.AreEqual("$5.20", Format(520));
        }

        [TestMethod]
        public void Simplest3()
        {
            Assert.AreEqual("$4.00", Format(400));
        }

        [TestMethod]
        public void Zero()
        {
            Assert.AreEqual("$0.00", Format(0));
        }

        [TestMethod]
        public void Simplest4()
        {
            Assert.AreEqual("$0.02", Format(2));
        }

        [TestMethod]
        public void Simplest5()
        {
            Assert.AreEqual("$0.37", Format(37));
        }

        private string Format(int priceInCents)
        {
            return string.Format("${0:0.00}", (double)priceInCents / 100);
        }
    }
}
