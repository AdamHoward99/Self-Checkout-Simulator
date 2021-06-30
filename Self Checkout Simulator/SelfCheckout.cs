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

        public SelfCheckout(BaggingAreaScale baggingArea, ScannedProducts scannedProducts, LooseItemScale looseItemScale)
        {
            this.baggingArea = baggingArea;
            this.scannedProducts = scannedProducts;
            this.looseItemScale = looseItemScale;
        }

        // Operations

        public void LooseProductSelected()
        {
            currentProduct = ProductsDAO.GetRandomLooseProduct();
            looseItemScale.Enable();
        }

        public void LooseItemAreaWeightChanged(int weightOfLooseItem)
        {
            currentProduct.SetWeight(weightOfLooseItem);
            scannedProducts.Add(currentProduct);
            AddedProductList[listIndex] = currentProduct;           //Puts the scanned item in the array
            lastScannedProduct = AddedProductList[listIndex];       
            baggingArea.SetExpectedWeight(scannedProducts.CalculateWeight());
            ++listIndex;                                            //Increments so any new scanned product is at the next position in the array
        }

        public void BarcodeWasScanned(int barcode)
        {
            currentProduct = ProductsDAO.SearchUsingBarcode(barcode);
            scannedProducts.Add(currentProduct);
            AddedProductList[listIndex] = currentProduct;           //Puts the scanned item in the array
            lastScannedProduct = AddedProductList[listIndex];
            baggingArea.SetExpectedWeight(scannedProducts.CalculateWeight());
            ++listIndex;                                            //Increments so any new scanned product is at the next position in the array
        }

        public void BaggingAreaWeightChanged()
        {
            currentProduct = null;
        }

        public void UserPaid()
        {
            scannedProducts.Reset();
            baggingArea.Reset();
        }

        public string GetPromptForUser()
        {
            if (scannedProducts.HasItems() && baggingArea.IsWeightOk() && currentProduct == null && !CanRemove())
            {
                return "Scan an item or pay.";
            }
            if (baggingArea.IsWeightOk() && currentProduct == null && !CanRemove())
            {
                return "Scan an item.";
            }
            if (looseItemScale.IsEnabled())
            {
                return "Place item on scale.";
            }
            if (currentProduct != null && !looseItemScale.IsEnabled())
            {
                return "Place the item in the bagging area.";
            }
            if (scannedProducts.HasItems() && !baggingArea.IsWeightOk())
            {
                return "Please wait, assistant is on the way.";
            }
            if(scannedProducts.HasItems() && baggingArea.IsWeightOk() && CanRemove())       //If the admin is removing the product from the list
            {
                return "Please wait, assistant is on the way.";
            }
            return "ERROR: Unknown state!";
        }

        public Product GetCurrentProduct()
        {
            return currentProduct;
        }

        public void AdminOverrideWeight(BaggingAreaScale ba)
        {
            baggingArea = ba;
        }

        public int GetLastScannedProductWeight()        //Gets the weight of the last scanned product
        {
            AddedProductList[listIndex] = AddedProductList[listIndex-1];                //Gets the product before the last scanned product
            lastScannedProductWeight = AddedProductList[listIndex].GetWeight();         //Gets the weight of the last scanned product
            return lastScannedProductWeight;
        }

        public void AdminRemoveProduct()                                //Initiates when the admin presses the remove the product button
        {
            AddedProductList[listIndex] = AddedProductList[listIndex - 1];
            scannedProducts.Remove(AddedProductList[listIndex]);        //Removes the desired product from the list
            baggingArea.RemoveWeight();                                 //Removes weight from the scale accordingly
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