using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Self_Checkout_Simulator
{
    static class NProductsDAO
    {
        //Collection of data would be contained in database
        private static List<Product> Products = new List<Product>
        {
            new PackagedProduct(102397, "Bacon", 209, 300),
            new PackagedProduct(124567, "Cheese", 119, 150),
            new PackagedProduct(193467, "Toothpaste", 109, 75),
            new PackagedProduct(207545, "BBQ Sauce", 149, 100),
            new PackagedProduct(274563, "Bread", 79, 500),
            new PackagedProduct(345692, "Cat Food", 249, 1000),
            new PackagedProduct(367594, "Marmite", 225, 115),
            new PackagedProduct(490732, "Butter", 99, 500),
            new PackagedProduct(654347, "Eggs", 129, 400),
            new PackagedProduct(600234, "Pasta", 99, 750),
            new PackagedProduct(734542, "Sour Cream", 100, 300),
            new PackagedProduct(874537, "Prawns", 209, 650),
            new PackagedProduct(893475, "Rice", 139, 600),
            new PackagedProduct(914374, "Rocket", 100, 100),
            new PackagedProduct(923534, "Pizza", 109, 600),

            new LooseProduct(120583, "Ginger", 26),
            new LooseProduct(432895, "Carrot", 12),
            new LooseProduct(438543, "Tomato", 27),
            new LooseProduct(543704, "Onion", 18),
            new LooseProduct(634293, "Pepper", 17),
            new LooseProduct(731343, "Potato", 10),
            new LooseProduct(813432, "Parsnip", 21),
        };

        public static Product SearchUsingBarcode(int barcode) => Products.Find(p => p.GetBarcode() == barcode);


    }
}
