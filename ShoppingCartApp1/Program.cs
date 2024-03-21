// See https://aka.ms/new-console-template for more information

using System;

namespace ShoppingCartApp
{
    // Enum for product categories
    public enum ProductCategory
    {
        Clothing,
        Electronics,
        Home,
        Beauty,
        Groceries
    }

    // Base class for all products
    public class Product
    {
        // Fields
        private string name;
        private double price;
        private ProductCategory category;

        // Properties
        public string Name { get { return name; } }
        public double Price { get { return price; } }
        public ProductCategory Category { get { return category; } }

        // Constructor
        public Product(string name, double price, ProductCategory category)
        {
            this.name = name;
            this.price = price;
            this.category = category;
        }

        // Method to get information about the product
        public virtual void GetInfo()
        {
            Console.WriteLine($"Name: {name}, Price: {price}, Category: {category}");
        }
    }

    // Derived class for clothing products
    public class ClothingProduct : Product
    {
        // Fields
        private string size;
        private string color;

        // Properties
        public string Size { get { return size; } }
        public string Color { get { return color; } }

        // Constructor
        public ClothingProduct(string name, double price, ProductCategory category, string size, string color)
            : base(name, price, category)
        {
            this.size = size;
            this.color = color;
        }

        // Override method to get information about clothing product
        public override void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine($"Size: {size}, Color: {color}");
        }
    }

    // Derived class for electronics products
    public class ElectronicsProduct : Product
    {
        // Fields
        private string brand;
        private string model;

        // Properties
        public string Brand { get { return brand; } }
        public string Model { get { return model; } }

        // Constructor
        public ElectronicsProduct(string name, double price, ProductCategory category, string brand, string model)
            : base(name, price, category)
        {
            this.brand = brand;
            this.model = model;
        }

        // Override method to get information about electronics product
        public override void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine($"Brand: {brand}, Model: {model}");
        }
    }

    // Class representing a shopping cart
    public class ShoppingCart
    {
        // Fields
        private Product[] products;
        private int itemCount;

        // Properties
        public Product[] Products { get { return products; } }
        public int ItemCount { get { return itemCount; } }

        // Constructor
        public ShoppingCart(int capacity)
        {
            products = new Product[capacity];
            itemCount = 0;
        }

        // Method to add a product to the shopping cart
        public void AddProduct(Product product)
        {
            if (itemCount < products.Length)
            {
                products[itemCount] = product;
                itemCount++;
                Console.WriteLine($"{product.Name} added to the cart.");
            }
            else
            {
                Console.WriteLine("The shopping cart is full.");
            }
        }

        // Method to remove a product from the shopping cart
        public void RemoveProduct(Product product)
        {
            bool found = false;
            for (int i = 0; i < itemCount; i++)
            {
                if (products[i] == product)
                {
                    for (int j = i; j < itemCount - 1; j++)
                    {
                        products[j] = products[j + 1];
                    }
                    itemCount--;
                    found = true;
                    Console.WriteLine($"{product.Name} removed from the cart.");
                    break;
                }
            }
            if (!found)
            {
                Console.WriteLine($"{product.Name} not found in the cart.");
            }
        }
    }

    namespace Program
    {
        // Entry point for the console application
        class Program
        {
            static void Main(string[] args)
            {
                // Instantiate products and a shopping cart
                ClothingProduct shirt = new ClothingProduct("T-Shirt", 19.99, ProductCategory.Clothing, "M", "Blue");
                ElectronicsProduct phone = new ElectronicsProduct("Smartphone", 599.99, ProductCategory.Electronics, "Samsung", "Galaxy S21");
                ShoppingCart cart = new ShoppingCart(5);

                // Add products to the shopping cart
                cart.AddProduct(shirt);
                cart.AddProduct(phone);

                // Display the contents of the shopping cart
                Console.WriteLine("\nContents of the shopping cart:");
                foreach (Product product in cart.Products)
                {
                    if (product != null)
                    {
                        product.GetInfo();
                    }
                }

                // Remove a product from the shopping cart
                cart.RemoveProduct(shirt);

                // Display the updated contents of the shopping cart
                Console.WriteLine("\nUpdated contents of the shopping cart:");
                foreach (Product product in cart.Products)
                {
                    if (product != null)
                    {
                        product.GetInfo();
                    }
                }
            }
        }
    }
}
