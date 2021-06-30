<h1 align="center">Self-Checkout Simulator</h1>
<p align="center">This project is a C# software demo for a self-checkout machine commonly found in supermarkets today. Realistic features have been implemented into this application such as weighing scales for the items, a payment system, and points that give customers discounts similar to a clubcard point system.</p>

## Screenshot
<p align="center">
  <img alt ="Application Visual UI" src = "https://user-images.githubusercontent.com/74617187/124037502-92531500-d9f7-11eb-87ac-f055b91424f9.png"/>
</p>
  
## How To Use
The application makes use of Microsoft WinForms to create UI in which users can interact with the application. Users are able to scan either barcoded products or loose products and add the items to the scanned products list; when scanning loose products it is required for users to weigh the product and place it in the bagging area. 

There is additional admin functionality in the application allowing for admins to override the checkout when the bagging area doesn't contain the correct weight as a result of the user incorrectly placing the item. Admins also have the ability to confirm the removal of an item from the scanned products list if a user does not wish to purchase the item anymore.

When the user has finished scanning all the products, they will have the option to pay by either card or cash; an additional form will appear for this when the 'pay for products' button has been pressed. For card payments, users are required to enter the pin number of the card in an additional form.

## Built With
- C#
- Microsoft WinForms

## Contributors

**Adam Howard**
- [Profile] (https://github.com/AdamHoward99)

**Kai Henry**
- [Profile] (https://github.com/O0longTea)
