using BarcodeScanner;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BarcodeScannerTests
{
    [TestClass]
    public class ScanOneItemTests
    {
        /*private readonly Catalog _pricesByBarcode = new Catalog(new Dictionary<string, string>{
            { "12345", "$7.95" },
            { "23456", "$12.50" }
        });*/
        private readonly Catalog _pricesByBarcodeInCents = new Catalog(new Dictionary<string, int>{
            { "12345", 795 },
            { "23456", 1250 }
        });
        private Display _display;
        private Sale _sale;

        private void SetUp()
        {
            _display = new Display();
            _sale = new Sale(_display, _pricesByBarcodeInCents);
        }

        [TestMethod]
        public void ProductFound0()
        {
            SetUp();

            _sale.OnBarcode("12345");

            Assert.AreEqual("795", _display.GetText());
        }

        [TestMethod]
        public void ProductFound1()
        {
            SetUp();

            _sale.OnBarcode("23456");

            Assert.AreEqual("1250", _display.GetText());
        }

        [TestMethod]
        public void ProductNotFound0()
        {
            SetUp();

            _sale.OnBarcode("999");

            Assert.AreEqual("Price not found for barcode 999", _display.GetText());
        }

        [TestMethod]
        public void ProductNotFound1()
        {
            SetUp();

            _sale.OnBarcode("888");

            Assert.AreEqual("Price not found for barcode 888", _display.GetText());
        }

        [TestMethod]
        public void EmptyBarcode()
        {
            //TODO #2 now it's definitely a smell as it can't use the same SetUp method as other tests
            /*Display display = new Display();
            //TODO #1 null in constructor might be a smell, meaning the class might be doing too much - violating SRP
            Sale sale = new Sale(display, null);*/
            SetUp();

            _sale.OnBarcode("");

            Assert.AreEqual("Error! Empty barcode.", _display.GetText());
        }
    }
}
