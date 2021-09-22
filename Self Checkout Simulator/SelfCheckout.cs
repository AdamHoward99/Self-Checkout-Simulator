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
        private bool AdminRemove = false;           //To enable the admin to remove a product
        private Product lastScannedProduct;         //The last product that is put on the list, used to remove the product
        private int lastScannedProductWeight;       //The last products weight, used to accordingly remove the weight from the scale
        private Product[] AddedProductList = new Product[30];   //Collects all products that are scanned by the user, used to know which product to remove
        private int listIndex = 0;                  //Array placer that puts each added product in a new cell of the array

        // Constructor

        public SelfCheckout()
        {
            baggingArea = new BaggingAreaScale();
            scannedProducts = new ScannedProducts();
            looseItemScale = new LooseItemScale();
        }

        // Operations
        public bool ContainsProduct() => scannedProducts.HasItems();

        public void LooseProductSelected()
        {
            currentProduct = ProductsDAO.GetRandomLooseProduct();
            looseItemScale.Enabled = true;
        }

        public void LooseItemAreaWeightChanged(int weightOfLooseItem)
        {
            looseItemScale.Enabled = false;
  
            currentProduct.SetWeight(weightOfLooseItem);
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
            baggingArea.Weight += correctlyWeighed ? currentProduct.GetWeight() : new Random().Next(20, 100);
            currentProduct = null;
        }

        public void UserPaid()
        {
            scannedProducts.Reset();
            baggingArea.Reset();
        }

        public string GetPromptForUser()
        {
            if (scannedProducts.HasItems() && baggingArea.IsCorrectWeight() && currentProduct == null && !CanRemove())
            {
                return "Scan an item or pay.";
            }
            if (baggingArea.IsCorrectWeight() && currentProduct == null && !CanRemove())
            {
                return "Scan an item.";
            }
            if (looseItemScale.Enabled)
            {
                return "Place item on scale.";
            }
            if (currentProduct != null && !looseItemScale.Enabled)
            {
                return "Place the item in the bagging area.";
            }
            if (scannedProducts.HasItems() && !baggingArea.IsCorrectWeight())
            {
                return "Please wait, assistant is on the way.";
            }
            if(scannedProducts.HasItems() && baggingArea.IsCorrectWeight() && CanRemove())       //If the admin is removing the product from the list
            {
                return "Please wait, assistant is on the way.";
            }
            return "ERROR: Unknown state!";
        }

        public Product GetCurrentProduct()
        {
            return currentProduct;
        }

        public int GetLastScannedProductWeight()        //Gets the weight of the last scanned product
        {
            AddedProductList[listIndex] = AddedProductList[listIndex-1];                //Gets the product before the last scanned product
            lastScannedProductWeight = AddedProductList[listIndex].GetWeight();         //Gets the weight of the last scanned product
            return lastScannedProductWeight;
        }

        public void AdminWeightOverride() => baggingArea.OverrideWeight();
        public bool IsScaleWeightCorrect() => baggingArea.IsCorrectWeight();

        public BaggingAreaScale GetBaggingScale() => baggingArea;
        public List<Product> GetProducts() => scannedProducts.GetProducts();

        public double GetTotal() => scannedProducts.CalculatePrice() * 0.01D;

        public void AdminRemoveProduct()                                //Initiates when the admin presses the remove the product button
        {
            AddedProductList[listIndex] = AddedProductList[listIndex - 1];
            scannedProducts.Remove(AddedProductList[listIndex]);        //Removes the desired product from the list
            baggingArea.RemoveWeight(AddedProductList[listIndex].GetWeight());       //Removes weight from the scale accordingly
            --listIndex;                                                //Decrements to get the previous array cell and previous scanned product
        }

        public void EnableAdminRemove()                                 //Initiates when the user presses the remove product button and enables the admin remove button
        {
            AdminRemove = true;
        }

        public void DisableAdminRemove()                                //Once the admin button has been pressed it becomes disabled
        {
            AdminRemove = false;
        }

        public bool CanRemove()                                         //Checks to see if the admin button has been enabled
        {
            return AdminRemove;
        }

        public double ClubcardWasSwiped()
        {
            double points = Math.Floor(scannedProducts.CalculatePrice() * 0.01f);   //Converts every £1 spent into 1 Clubcard point
            return points;
        }
    }
}