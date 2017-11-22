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

        internal int GetPrice(string barcode)
        {
            PricesByBarcodeInCents.TryGetValue(barcode, out int price);
            return price;
        }
    }
}