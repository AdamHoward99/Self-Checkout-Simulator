using System;
using System.Collections.Generic;

namespace Self_Checkout_Simulator
{
    class SelfCheckout
    {
        // Attributes
        private BaggingAreaScale baggingArea;
        private ScannedProducts scannedProducts;
        private Product currentProduct;

        public SelfCheckout()
        {
            baggingArea = new BaggingAreaScale();
            scannedProducts = new ScannedProducts();
        }

        // Operations
        public bool ContainsProduct() => scannedProducts.ContainsItems();

        public void LooseProductSelected() => currentProduct = ProductsDAO.GetRandomLooseProduct();

        public void LooseItemAreaWeightChanged(int weightOfLooseItem)
        {
            currentProduct.Weight = weightOfLooseItem;
            scannedProducts.Add(currentProduct);
            baggingArea.ExpectedWeight = scannedProducts.CalculateWeight();
        }

        public void BarcodeWasScanned(int barcode)
        {
            currentProduct = ProductsDAO.SearchUsingBarcode(barcode);
            scannedProducts.Add(currentProduct);
            baggingArea.ExpectedWeight = scannedProducts.CalculateWeight();
        }

        public void BaggingAreaWeightChanged(bool correctlyWeighed)
        {
            baggingArea.Weight += correctlyWeighed ? currentProduct.Weight : new Random().Next(20, 100);
            currentProduct = null;
        }

        public void UserPaid()
        {
            scannedProducts.Reset();
            baggingArea.Reset();
        }

        public Product GetCurrentProduct() => currentProduct;

        public int GetLastScannedProductWeight() => scannedProducts.GetLastItem().Weight;

        public void AdminWeightOverride() => baggingArea.OverrideWeight();

        bool IsScaleWeightCorrect() => baggingArea.IsCorrectWeight();

        public BaggingAreaScale GetBaggingScale() => baggingArea;

        public List<Product> GetProducts() => scannedProducts.GetProducts();

        public double GetTotal() => scannedProducts.CalculatePrice() * 0.01D;

        public void AdminRemoveProduct()                                //Initiates when the admin presses the remove the product button
        {
            baggingArea.RemoveWeight(scannedProducts.GetLastItem().Weight);       //Removes weight from the scale accordingly
            scannedProducts.Remove();        //Removes the last product
        }
    }
}