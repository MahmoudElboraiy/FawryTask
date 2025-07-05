using FawryTask;
var shippableAndExpirableProduct = new List<ShippableAndExpirableProduct>
{
    new ShippableAndExpirableProduct
    {
        Name = "Cake",
        Price = 1000.00m,
        Quantity = 3,
        Weight = 2.5m,
        ShippingDate = DateTime.Now,
        ExpirationDate = DateTime.Now.AddYears(1),
        ShippingFeesPerKilo = 40.00m
    },
    new ShippableAndExpirableProduct
    {
        Name = "Medicne",
        Price = 500.00m,
        Quantity = 2,
        Weight = 0.5m,
        ShippingDate = DateTime.Now,
        ExpirationDate = DateTime.Now.AddYears(1),
        ShippingFeesPerKilo = 20.00m
    },
    new ShippableAndExpirableProduct
    {
        Name = "Jucie",
        Price = 30.00m,
        Quantity = 5,
        Weight = 0.8m,
        ShippingDate = DateTime.Now,
        ExpirationDate = DateTime.Now.AddYears(1),
        ShippingFeesPerKilo = 10.00m
    },
};
var notShippableAndExpirableProduct = new List<NotShippableAndExpirableProduct>
{
    new NotShippableAndExpirableProduct
    {
        Name = "Milk",
        Price = 1.50m,
        Quantity = 10,
        ExpirationDate = DateTime.Now.AddDays(7)
    },
    new NotShippableAndExpirableProduct
    {
        Name = "Bread",
        Price = 2.00m,
        Quantity = 5,
        ExpirationDate = DateTime.Now.AddDays(3)
    },
    new NotShippableAndExpirableProduct
    {
        Name = "Eggs",
        Price = 3.00m,
        Quantity = 1,
        ExpirationDate = DateTime.Now.AddDays(-7)
    },
};
var shippableAndNotExpirableProduct = new List<ShippableAndNotExpirableProduct>
{
   new ShippableAndNotExpirableProduct
   {
       Name = "Books",
       Price = 20.00m,
       Quantity = 2,
       Weight = 1.5m,
       ShippingDate = DateTime.Now,
         ShippingFeesPerKilo = 5.00m
   },
    new ShippableAndNotExpirableProduct
    {
         Name = "Clothes",
         Price = 50.00m,
         Quantity = 3,
         Weight = 0.8m,
         ShippingDate = DateTime.Now,
            ShippingFeesPerKilo = 10.00m
    },
    new ShippableAndNotExpirableProduct
    {
         Name = "Toys",
         Price = 15.00m,
         Quantity = 4,
         Weight = 0.5m,
         ShippingDate = DateTime.Now,
            ShippingFeesPerKilo = 8.00m
    },
};
var products = new List<Product>();
products.AddRange(shippableAndExpirableProduct);
products.AddRange(notShippableAndExpirableProduct);
products.AddRange(shippableAndNotExpirableProduct);
var productsToBuy = new List<ProductToBuy>
{
    new ProductToBuy
    {
        Name = "Milk",
        Quantity = 2,
    },
    new ProductToBuy
    {
        Name = "Medicne",
        Quantity = 100,
    },
    new ProductToBuy
    {
        Name = "Eggs",
        Quantity = 1,
    },
    new ProductToBuy
    {
        Name = "Books",
        Quantity = 1,
    }
};
Customer Mahmoud = new Customer
{
    Name = "Mahmoud",
    PhoneNumber = "01208033610",
    Address = "123 Main St, City, Country",
    Balance = 10000.00m,
    ProductsToBuy = productsToBuy
};
Cart cart = new Cart();
foreach (var product in Mahmoud.ProductsToBuy)
{
    Product productToAdd = products.FirstOrDefault(p => p.Name == product.Name);
    if(productToAdd.Quantity <product.Quantity)
    {
        Console.WriteLine($"Not enough stock for {product.Name}. Available: {productToAdd.Quantity}, Requested: {product.Quantity}");
        continue;
    }
    if(productToAdd is NotShippableAndExpirableProduct t1 )
    {
        if(t1.ExpirationDate < DateTime.Now)
        {
            Console.WriteLine($"The {t1.Name} is Expired");
            continue;
        }
    }
    if (productToAdd is ShippableAndExpirableProduct t2)
    {
        if (t2.ExpirationDate < DateTime.Now)
        {
            Console.WriteLine("This is Expired Product");
            continue;
        }
    }
    if (productToAdd is ShippableAndExpirableProduct test)
    {
        test.Address = Mahmoud.Address;
        test.ShippingDate = DateTime.Now;
        test.ExpirationDate = DateTime.Now.AddYears(1);
        cart.Products.Add(test);
    }
    else if(productToAdd is ShippableAndNotExpirableProduct test2)
    {
        test2.Address = Mahmoud.Address;
        test2.ShippingDate = DateTime.Now;
        cart.Products.Add(test2);
    }
    else if (productToAdd is NotShippableAndExpirableProduct test3)
    {
        test3.ExpirationDate = DateTime.Now.AddDays(7);
        cart.Products.Add(test3);
    }
}
if(cart.Products.Count == 0)
{
    Console.WriteLine("No products added to the cart.");
    return;
}
if (Mahmoud.Balance < cart.Subtotal + cart.ShippingFees)
{
    Console.WriteLine("Insufficient balance to complete the purchase.");
    return;
}
var order = new Order();
order.Subtotal = cart.Subtotal;
order.ShippingFees = cart.ShippingFees;
order.Total = order.Subtotal + order.ShippingFees;
Console.WriteLine($"\n   CONSOLE OUTPUT");
Console.WriteLine("** Shipment notice **");
int totalweight = 0;
foreach(var product in cart.Products)
{
    
    if (product is IShippingItem shippingItem)
    {
        Console.WriteLine($"{product.Quantity}x  {product.Name}      {shippingItem.Weight}");
        totalweight += (int)(shippingItem.Weight * product.Quantity);
    }
}
Console.WriteLine($"Total package weight {totalweight}\n");
Console.WriteLine("** Checkout receipt **");
foreach (var product in cart.Products)
{
    Console.WriteLine($"{product.Quantity}x  {product.Name}      {product.Price}");
}
Console.WriteLine("-------------------------\r\n");
Console.WriteLine($"Subtotal {cart.Subtotal}");
Console.WriteLine($"Shipping {cart.ShippingFees}");
Console.WriteLine($"Amount {cart.ShippingFees+cart.Subtotal}");
Mahmoud.Balance -= cart.Subtotal + cart.ShippingFees;
Console.WriteLine($"Current Balance {Mahmoud.Balance}");
List<ProductToShipped> productToShippeds = new List<ProductToShipped>();
int Id = 0;
foreach (var product in cart.Products)
{
    if(product is ShippableAndExpirableProduct t1)
    {
        ProductToShipped productToShipped = new ProductToShipped();
        productToShipped.Id = Id++;
        productToShipped.Name = t1.Name;
        productToShipped.Quantity = t1.Quantity;
        productToShipped.Weight = t1.Weight;
        productToShippeds.Add(productToShipped);
    }
    else if(product is ShippableAndNotExpirableProduct t2)
    {
        ProductToShipped productToShipped = new ProductToShipped();
        productToShipped.Id = Id++;
        productToShipped.Name = t2.Name;
        productToShipped.Quantity = t2.Quantity;
        productToShipped.Weight = t2.Weight;
        productToShippeds.Add(productToShipped);
    }
}