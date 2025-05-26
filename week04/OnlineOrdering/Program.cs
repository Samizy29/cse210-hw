using System;

class Program
{
    static void Main(string[] args)
    {
        // Order 1 - USA
        Address address1 = new Address("123 Apple St", "New York", "NY", "USA");
        Customer customer1 = new Customer("John Smith", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Book", "B001", 10.99, 2));
        order1.AddProduct(new Product("Pen", "P002", 1.50, 5));

        // Order 2 - International
        Address address2 = new Address("456 Orange Ave", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Emily Davis", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Notebook", "N003", 5.99, 3));
        order2.AddProduct(new Product("Pencil", "P004", 0.99, 10));

        // Display Order 1
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalPrice()}\n");

        // Display Order 2
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalPrice()}");
    }
}