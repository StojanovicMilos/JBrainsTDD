using BarcodeScanner;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BarcodeScannerTests
{
    [TestClass]
    public class SellMultipleItemsTests
    {
        /*private readonly Catalog _catalog = new Catalog(new Dictionary<string, string>{
            { "12345", "$7.95" },
            { "23456", "$12.50" }
        });*/

        [TestMethod]
        public void ZeroItems()
        {
            Display display = new Display();
            Sale sale = new Sale(display, null);

            sale.OnTotal();

            Assert.AreEqual("No sale in progress. Try scanning a product", display.GetText());
        }

        [TestMethod]
        public void OneItemFound()
        {
            Display display = new Display();
            Catalog catalog = new Catalog(new Dictionary<string, int>{
                { "12345", 650 }
            });
            Sale sale = new Sale(display, catalog);

            sale.OnBarcode("12345");
            sale.OnTotal();

            Assert.AreEqual("Total: $6.50", display.GetText());
        }

        [TestMethod]
        public void OneItemNotFound()
        {
            Display display = new Display();
            Catalog catalog = new Catalog(new Dictionary<string, int>{
                { "12345", 650 }
            });
            Sale sale = new Sale(display, catalog);

            sale.OnBarcode("99999");
            sale.OnTotal();

            Assert.AreEqual("No sale in progress. Try scanning a product", display.GetText());
        }

        [TestMethod]
        public void SeveralItemsAllFound()
        {
            Display display = new Display();
            Catalog catalog = new Catalog(new Dictionary<string, int>{
                { "1", 850},
                { "2", 1275},
                { "3", 330 }
            });
            Sale sale = new Sale(display, catalog);

            sale.OnBarcode("1");
            sale.OnBarcode("2");
            sale.OnBarcode("3");
            sale.OnTotal();

            Assert.AreEqual("Total: $24.55", display.GetText());
        }

        [TestMethod]
        public void SeveralItemsAllNotFound()
        {
            Display display = new Display();
            Catalog catalog = Catalog.CatalogWithoutBarcodes(
                "product you won't find",
                "another product you won't find",
                "third product you won't find");
            Sale sale = new Sale(display, catalog);

            sale.OnBarcode("product you won't find");
            sale.OnBarcode("another product you won't find");
            sale.OnBarcode("third product you won't find");
            sale.OnTotal();

            Assert.AreEqual("No sale in progress. Try scanning a product", display.GetText());
        }

        [TestMethod]
        public void SeveralItemsSomeNotFound()
        {
            Display display = new Display();
            Catalog catalog = new Catalog(new Dictionary<string, int>{
                { "1", 1200},
                { "2", 500}
            });
            Sale sale = new Sale(display, catalog);

            sale.OnBarcode("1");
            sale.OnBarcode("you don't know this product");
            sale.OnBarcode("2");
            sale.OnTotal();

            Assert.AreEqual("Total: $17.00", display.GetText());
        }

        [TestMethod]
        public void SeveralItemsOneOfWhitchOneIsEmpty()
        {
            Display display = new Display();
            Catalog catalog = new Catalog(new Dictionary<string, int>{
                { "1", 3100},
                { "2", 460}
            });
            Sale sale = new Sale(display, catalog);

            sale.OnBarcode("1");
            sale.OnBarcode("");
            sale.OnBarcode("2");
            sale.OnTotal();

            Assert.AreEqual("Total: $35.60", display.GetText());
        }
    }
}
