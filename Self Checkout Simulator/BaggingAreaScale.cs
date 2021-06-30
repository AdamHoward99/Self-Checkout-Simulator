using System;
using System.Collections.Generic;
using System.Linq;

namespace Self_Checkout_Simulator
{
    class BaggingAreaScale
    {
        // Attributes

        private int weight;
        private SelfCheckout selfCheckout;
        private int expected;
        private int allowedDifference;
        private int lastScannedProductWeight;       //Is used to calculate how much weight to remove from the scale
        
        
        // Operations

        public int GetCurrentWeight()
        {
            return weight;
        }

        public bool IsWeightOk()
        {
            return expected + allowedDifference == weight;
        }

        public int GetExpectedWeight()
        {
            return expected + allowedDifference;
        }

        public void SetExpectedWeight(int expected)
        {
            this.expected = expected;
        }

        public void OverrideWeight()
        {
            allowedDifference = weight - expected;
        }

        public void RemoveWeight()      //Removes the weight of a product that has been removed
        {
            lastScannedProductWeight = selfCheckout.GetLastScannedProductWeight();      //Gets the removed products weight
            weight = expected - lastScannedProductWeight;                               //Sets the scale accordingly
            expected = expected - lastScannedProductWeight;
            allowedDifference = 0;
        }

        public void Reset()
        {
            int reset = 0;
            allowedDifference = reset;
            expected = reset;
            weight = reset;
        }

        public void LinkToSelfCheckout(SelfCheckout sc)
        {
            selfCheckout = sc;
        }

        // NOTE: In reality the difference wouldn't be passed in here, the
        //       scale would detect the change and notify the self checkout

        public void WeightChangeDetected(int difference)
        {
            weight += difference;
            selfCheckout.BaggingAreaWeightChanged();
        }
    }
}