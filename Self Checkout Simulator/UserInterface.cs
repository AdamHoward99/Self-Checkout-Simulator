using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace Self_Checkout_Simulator
{
    public partial class UserInterface : Form
    {
        // Attributes

        SelfCheckout selfCheckout;
        BarcodeScanner barcodeScanner;
        BaggingAreaScale baggingAreaScale;
        LooseItemScale looseItemScale;
        ScannedProducts scannedProducts;
        PaymentForm paymentForm;            //Enables the User interface to get variables used in the Payment form

        // Constructor

        public UserInterface()
        {
            InitializeComponent();

            // NOTE: This is where we set up all the objects,
            // and create the various relationships between them.

            baggingAreaScale = new BaggingAreaScale();
            scannedProducts = new ScannedProducts();
            barcodeScanner = new BarcodeScanner();
            looseItemScale = new LooseItemScale();
            paymentForm = new PaymentForm();
            selfCheckout = new SelfCheckout(baggingAreaScale, scannedProducts, looseItemScale);
            barcodeScanner.LinkToSelfCheckout(selfCheckout);
            baggingAreaScale.LinkToSelfCheckout(selfCheckout);
            looseItemScale.LinkToSelfCheckout(selfCheckout);
            UpdateDisplay();
        }

        // Operations

        private void UserScansProduct(object sender, EventArgs e)
        {
            barcodeScanner.BarcodeDetected();
            UpdateDisplay();
        }

        private void UserPutsProductInBaggingAreaCorrect(object sender, EventArgs e)
        {
            baggingAreaScale.WeightChangeDetected(selfCheckout.GetCurrentProduct().GetWeight());
            UpdateDisplay();
        }

        private void UserPutsProductInBaggingAreaIncorrect(object sender, EventArgs e)
        {
            // NOTE: We are pretending to put down an item with the wrong weight.
            // To simulate this we'll use a random number, here's one for you to use.

            baggingAreaScale.WeightChangeDetected((new Random()).Next(20, 100));
            UpdateDisplay();
        }

        private void UserSelectsALooseProduct(object sender, EventArgs e)
        {
            selfCheckout.LooseProductSelected();
            UpdateDisplay();
        }

        private void UserWeighsALooseProduct(object sender, EventArgs e)
        {
            // NOTE: We are pretending to weigh a banana or whatever here.
            // To simulate this we'll use a random number, here's one for you to use.

            looseItemScale.WeightChangeDetected((new Random()).Next(20, 100));
            UpdateDisplay();
        }

        private void AdminOverridesWeight(object sender, EventArgs e)
        {

            baggingAreaScale.OverrideWeight();
            UpdateDisplay();
        }

        private void UserChoosesToPay(object sender, EventArgs e)
        {
            PaymentForm f2 = new PaymentForm();             //Creates a new form
            f2.ShowDialog();                                //Opens the new form
            selfCheckout.UserPaid();                        //Clears the weight and products from the list
            UpdateDisplay();
        }

        void UpdateDisplay()
        {
            btnUserScansBarcodeProduct.Enabled = (baggingAreaScale.IsWeightOk() && selfCheckout.GetCurrentProduct() == null);
            btnUserSelectsLooseProduct.Enabled = (baggingAreaScale.IsWeightOk() && selfCheckout.GetCurrentProduct() == null);
            btnUserWeighsLooseProduct.Enabled = looseItemScale.IsEnabled();
            btnRemoveProduct.Enabled = (scannedProducts.HasItems() && baggingAreaScale.IsWeightOk() && !looseItemScale.IsEnabled() && !selfCheckout.CanRemove());   //Only enabled when there are products in the list, and when the scales are disabled
            btnAdminRemoveProduct.Enabled = (scannedProducts.HasItems() && baggingAreaScale.IsWeightOk() && selfCheckout.CanRemove());         //Only enabled when there are products in the list and the user pressed the remove product button
            btnUserPutsProductInBaggingAreaCorrect.Enabled = (selfCheckout.GetCurrentProduct() != null && !looseItemScale.IsEnabled());  
            btnUserPutsProductInBaggingAreaIncorrect.Enabled = (selfCheckout.GetCurrentProduct() != null && !looseItemScale.IsEnabled());
            btnUserChooseToPay.Enabled = (scannedProducts.HasItems() && baggingAreaScale.IsWeightOk() && selfCheckout.GetCurrentProduct() == null && !selfCheckout.CanRemove());
            btnAdminOverridesWeight.Enabled = (scannedProducts.HasItems() && !baggingAreaScale.IsWeightOk() && selfCheckout.GetCurrentProduct() == null);
            lblScreen.Text = selfCheckout.GetPromptForUser();
            Label baggingAreaEWeight = lblBaggingAreaExpectedWeight;
            int expectedWeight = baggingAreaScale.GetExpectedWeight();
            baggingAreaEWeight.Text = expectedWeight.ToString("n2");
            Label label = lblBaggingAreaCurrentWeight;
            expectedWeight = baggingAreaScale.GetCurrentWeight();
            label.Text = expectedWeight.ToString("n2"); 
            float priceOfItem = scannedProducts.CalculatePrice() * 0.01f;
            lblTotalPrice.Text = priceOfItem.ToString("c2");
            lbBasket.Items.Clear();
            lblClubcardPoints.ResetText();
            btnScanClubcard.Enabled = (baggingAreaScale.IsWeightOk() && scannedProducts.HasItems() && !looseItemScale.IsEnabled() && !selfCheckout.CanRemove());
            foreach (Product product in scannedProducts.GetProducts())
            {
                priceOfItem = product.CalculatePrice() * 0.01f;
                string priceOfItemConvertToString = priceOfItem.ToString("c2");
                lbBasket.Items.Add(priceOfItemConvertToString + " " + product.GetName());
            }

        }

        private void btnRemoveProduct_Click(object sender, EventArgs e)
        {
            selfCheckout.EnableAdminRemove();           //Enables the Admin button to remove the product
            selfCheckout.GetPromptForUser();            //Gets the correct prompt for the current situation
            UpdateDisplay();
            btnUserScansBarcodeProduct.Enabled = false;
            btnUserSelectsLooseProduct.Enabled = false;
        }

        private void btnAdminRemoveProduct_Click(object sender, EventArgs e)
        {
            selfCheckout.AdminRemoveProduct();          //Removes the last product from the list of products
            selfCheckout.DisableAdminRemove();          //Disables the admin remove button
            UpdateDisplay();
        }

        private void btnScanClubcard_Click(object sender, EventArgs e)
        {
            double points = selfCheckout.ClubcardWasSwiped();   
            lblClubcardPoints.Text = points.ToString(); //Updates the label which holds the amount of clubcard points
        }
    }
}