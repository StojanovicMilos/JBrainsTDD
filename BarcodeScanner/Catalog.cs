using System;
using System.Collections.Generic;

namespace BarcodeScanner
{
    public class Catalog
    {
        //public Dictionary<string, string> PricesByBarcode { get; set; }
        public Dictionary<string, int> PricesByBarcodeInCents { get; set; }

        /*public Catalog(Dictionary<string, string> pricesByBarcode)
        {
            PricesByBarcode = pricesByBarcode;
        }*/

        public Catalog(Dictionary<string, int> pricesByBarcodeInCents)
        {
            PricesByBarcodeInCents = pricesByBarcodeInCents;
        }

        public Catalog()
        {
            PricesByBarcodeInCents = new Dictionary<string, int>();
        }

        public int GetPrice(string barcode)
        {
            PricesByBarcodeInCents.TryGetValue(barcode, out int price);
            return price;
        }

        public static Catalog CatalogWithoutBarcodes(string barcode1, string barcode2, string barcode3)
        {
            return new Catalog();
        }
    }
}