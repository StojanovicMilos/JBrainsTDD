using System;
using System.Collections.Generic;

namespace BarcodeScanner
{
    public class Sale
    {
        private Display _display;
        private Catalog _catalog;
        private int _scannedPrice = -1;
        private List<int> _pendingPruchaseItemPrices = new List<int>();

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
                _pendingPruchaseItemPrices.Add(price);
                _display.DisplayPrice(price);
            }
            else
                _display.DisplayProductNotFound(barcode);
        }

        public void OnTotal()
        {
            bool saleInProgress = (_scannedPrice != -1);
            if(saleInProgress)
            {
                int sum = PendingPurchaseTotal();
                _display.DisplayPurchaseTotal(sum);
                //_display.DisplayPrice(_scannedPrice);
            }
            else
            {
                _display.DisplayNoSaleInProgressMessage();
            }
        }

        private int PendingPurchaseTotal()
        {
            return ComputePurchaseTotal(_pendingPruchaseItemPrices);
        }

        public static int ComputePurchaseTotal(List<int> pendingPruchaseItemPrices)
        {
            int sum = 0;
            foreach (var itemPrice in pendingPruchaseItemPrices)
            {
                sum += itemPrice;
            }
            return sum;
        }
    }
}
