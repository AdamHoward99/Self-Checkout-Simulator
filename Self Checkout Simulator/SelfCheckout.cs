using System;
using System.Collections.Generic;
using System.Linq;

namespace Self_Checkout_Simulator
{
    class SelfCheckout
    {
        // Attributes
        private BaggingAreaScale baggingArea;
        private ScannedProducts scannedProducts;
        private LooseItemScale looseItemScale;
        private Product currentProduct;
        private Product lastScannedProduct;         //The last product that is put on the list, used to remove the product
        private Product[] AddedProductList = new Product[30];   //Collects all products that are scanned by the user, used to know which product to remove
        private int listIndex = 0;                  //Array placer that puts each added product in a new cell of the array

        public SelfCheckout()
        {
            baggingArea = new BaggingAreaScale();
            scannedProducts = new ScannedProducts();
            looseItemScale = new LooseItemScale();
        }

        // Operations
        public bool ContainsProduct() => scannedProducts.ContainsItems();

        public void LooseProductSelected()
        {
            currentProduct = ProductsDAO.GetRandomLooseProduct();
            looseItemScale.Enabled = true;
        }

        public void LooseItemAreaWeightChanged(int weightOfLooseItem)
        {
            looseItemScale.Enabled = false;
            currentProduct.Weight = weightOfLooseItem;
            scannedProducts.Add(currentProduct);
            AddedProductList[listIndex] = currentProduct;           //Puts the scanned item in the array
            lastScannedProduct = AddedProductList[listIndex];
            baggingArea.ExpectedWeight = scannedProducts.CalculateWeight();
            ++listIndex;                                            //Increments so any new scanned product is at the next position in the array
        }

        public void BarcodeWasScanned(int barcode)
        {
            currentProduct = ProductsDAO.SearchUsingBarcode(barcode);
            scannedProducts.Add(currentProduct);
            AddedProductList[listIndex] = currentProduct;           //Puts the scanned item in the array
            lastScannedProduct = AddedProductList[listIndex];
            baggingArea.ExpectedWeight = scannedProducts.CalculateWeight();
            ++listIndex;                                            //Increments so any new scanned product is at the next position in the array
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

        public int GetLastScannedProductWeight()        //Gets the weight of the last scanned product
        {
            AddedProductList[listIndex] = AddedProductList[listIndex-1];                //Gets the product before the last scanned product
            return AddedProductList[listIndex].Weight;
        }

        public void AdminWeightOverride() => baggingArea.OverrideWeight();
        bool IsScaleWeightCorrect() => baggingArea.IsCorrectWeight();

        public BaggingAreaScale GetBaggingScale() => baggingArea;
        public List<Product> GetProducts() => scannedProducts.GetProducts();

        public double GetTotal() => scannedProducts.CalculatePrice() * 0.01D;

        public void AdminRemoveProduct()                                //Initiates when the admin presses the remove the product button
        {
            AddedProductList[listIndex] = AddedProductList[listIndex - 1];
            scannedProducts.Remove(AddedProductList[listIndex]);        //Removes the desired product from the list
            baggingArea.RemoveWeight(AddedProductList[listIndex].Weight);       //Removes weight from the scale accordingly
            --listIndex;                                                //Decrements to get the previous array cell and previous scanned product
        }
    }
}