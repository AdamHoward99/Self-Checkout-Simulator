namespace Self_Checkout_Simulator
{
    abstract class Product
    {
        public Product(int barcode, string name, int price)
        {
            Barcode = barcode;
            Name = name;
            Price = price;
        }

        public int Barcode { get; protected set; }
        public string Name { get; protected set; }
        public int Weight { get; set; }
        public int Price { get; protected set; }

        public abstract int CalculatePrice();
        public abstract bool IsLooseProduct();
    }
}

namespace Self_Checkout_Simulator
{
    class LooseProduct : Product
    {
        public LooseProduct(int barcode, string name, int price) : base(barcode, name, price)
        {}

        public override int CalculatePrice() => Price * Weight / 100;
        public override bool IsLooseProduct() => true;
    }
}

namespace Self_Checkout_Simulator
{
    class PackagedProduct : Product
    {
        public PackagedProduct(int barcode, string name, int price, int weightInGrams) : base(barcode, name, price)
        {
            Weight = weightInGrams;
        }

        public override int CalculatePrice() => Price;
        public override bool IsLooseProduct() => false;
    }
}