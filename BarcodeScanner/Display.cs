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

        public void DisplayPrice(string price)
        {
            this._text = price;
        }

        public void DisplayProductNotFound(string barcode)
        {
            this._text = "Price not found for barcode " + barcode;
        }

        public void DisplayNoSaleInProgressMessage()
        {
            this._text = "No sale in progress. Try scanning a product";
        }
    }
}
