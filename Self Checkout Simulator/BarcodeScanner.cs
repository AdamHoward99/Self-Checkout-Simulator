using System;
using System.Collections.Generic;
using System.Linq;

namespace Self_Checkout_Simulator
{
    class BarcodeScanner
    {
        // Attributes

        private SelfCheckout selfCheckout;

        // Operations

        public void BarcodeDetected()
        {
            int barcode = ProductsDAO.GetRandomProductBarcode();
            selfCheckout.BarcodeWasScanned(barcode);
        }

        public void LinkToSelfCheckout(SelfCheckout selfCheckout)
        {
            this.selfCheckout = selfCheckout;
        }
    }
}