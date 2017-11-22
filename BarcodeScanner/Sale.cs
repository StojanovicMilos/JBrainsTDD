using System;
using System.Collections.Generic;

namespace BarcodeScanner
{
    public class Sale
    {
        private Display _display;
        private Catalog _catalog;
        private int _scannedPrice = -1;
        private List<int> _scannedPrices = new List<int>();

        public Sale(Display display, Catalog catalog)
        {
            this._display = display;
            _catalog = catalog;
        }

        public void OnBarcode(string barcode)
        {
            if (barcode == string.Empty)
            {
                _display.DisplayErrorMessage();
                return;
            }

            int price;
            if ((price = _catalog.GetPrice(barcode)) != 0)
            {
                _scannedPrice = price;
                _scannedPrices.Add(price);
                _display.DisplayPrice(price.ToString());
            }
            else
                _display.DisplayProductNotFound(barcode);
        }

        public void OnTotal()
        {
            bool saleInProgress = (_scannedPrice != -1);
            if(saleInProgress)
            {
                /*int sum = 0;
                foreach(var itemPrice in _scannedPrices)
                {
                    sum += itemPrice;
                }
                _display.DisplayPrice("Total: " + sum);*/
                _display.DisplayPrice("Total: " + _scannedPrice);
            }
            else
            {
                _display.DisplayNoSaleInProgressMessage();
            }
        }
    }
}
