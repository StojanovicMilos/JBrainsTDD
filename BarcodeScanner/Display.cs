using System;

namespace BarcodeScanner
{
    public class Display
    {
        private string _text;

        public string GetText()
        {
            return this._text;
        }

        public void DisplayErrorMessage()
        {
            this._text = "Error! Empty barcode.";
        }

        public void DisplayPrice(int price)
        {
            this._text = Format(price);
        }

        public void DisplayPurchaseTotal(int sum)
        {
            this._text = "Total: " + Format(sum);
        }

        public void DisplayProductNotFound(string barcode)
        {
            this._text = "Price not found for barcode " + barcode;
        }

        public void DisplayNoSaleInProgressMessage()
        {
            this._text = "No sale in progress. Try scanning a product";
        }

        public string Format(int priceInCents)
        {
            return string.Format("${0:0.00}", (double)priceInCents / 100);
        }

        
    }
}
