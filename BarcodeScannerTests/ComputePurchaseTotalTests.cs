using BarcodeScanner;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BarcodeScannerTests
{
    [TestClass]
    public class ComputePurchaseTotalTests
    {
        [TestMethod]
        public void ZeroItems()
        {
            Assert.AreEqual(0, Sale.ComputePurchaseTotal(new List<int>()));
        }

        [TestMethod]
        public void OneItem()
        {
            Assert.AreEqual(120, Sale.ComputePurchaseTotal(new List<int> { 120 }));
        }

        [TestMethod]
        public void MultipleItems()
        {
            Assert.AreEqual(2455, Sale.ComputePurchaseTotal(new List<int> { 850, 1275, 330 }));
        }
    }
}
