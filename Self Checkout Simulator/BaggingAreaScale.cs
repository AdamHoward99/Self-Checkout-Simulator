namespace Self_Checkout_Simulator
{
    class BaggingAreaScale
    {
        // Attributes
        public int Weight { get; set; }
        public int ExpectedWeight { get; set; }

        // Operations
        public bool IsCorrectWeight() => Weight == ExpectedWeight;
        public void OverrideWeight() => Weight = ExpectedWeight;

        public void RemoveWeight(int lastProductWeight)      //Removes the weight of a product that has been removed
        {
            Weight = ExpectedWeight - lastProductWeight;                               //Sets the scale accordingly
            ExpectedWeight = ExpectedWeight - lastProductWeight;
        }

        public void Reset()
        {
            ExpectedWeight = 0;
            Weight = 0;
        }

    }
}