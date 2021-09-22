using System;
using System.Collections.Generic;
using System.Linq;

namespace Self_Checkout_Simulator
{
    class BaggingAreaScale
    {
        // Attributes
        public int Weight { get; set; }
        public int ExpectedWeight { get; set; }
        private int AllowedWeightDifference { get; set; }

        // Operations
        public bool IsCorrectWeight() => Weight == ExpectedWeight + AllowedWeightDifference;
        public int GetExpectedWeightWithDifference() => ExpectedWeight + AllowedWeightDifference;

        public void OverrideWeight()
        {
            AllowedWeightDifference = Weight - ExpectedWeight;
        }

        public void RemoveWeight(int lastProductWeight)      //Removes the weight of a product that has been removed
        {
            Weight = ExpectedWeight - lastProductWeight;                               //Sets the scale accordingly
            ExpectedWeight = ExpectedWeight - lastProductWeight;
            AllowedWeightDifference = 0;
        }

        public void Reset()
        {
            AllowedWeightDifference = 0;
            ExpectedWeight = 0;
            Weight = 0;
        }

    }
}