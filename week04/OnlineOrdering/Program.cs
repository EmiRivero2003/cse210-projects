using System;

class Program
{
    static void Main(string[] args)
    {
        Product p1 = new Product("JoyStick Dualsence ps5", 299, 20.99, 3);
        Product p2 = new Product("Keyboard Fantech K613", 239, 12.30, 2);
        Product p3 = new Product("Mouse Meetion MT-GM015", 199, 10.50, 4);
        Product p4 = new Product("Monitor Kolke 25' 75HZ", 264, 16.60, 1);

        Address addr1 = new Address("533 Main St", "San Francisco", "CL", "USA");
        Address addr2 = new Address("Colon 988", "Melo", "CR", "UY");

        Customer cust1 = new Customer("Leonard Hanks", addr1);
        Customer cust2 = new Customer("Emiliano Rivero", addr2);

        List<Product> products1 = new List<Product>() { p1, p2 };
        Order order1 = new Order(products1, cust1);
        List<Product> products2 = new List<Product> { p3, p4 };
        Order order2 = new Order(products2, cust2);

        Console.WriteLine("Packing Label:");
        Console.WriteLine(order1.GetPackingLabel());

        Console.WriteLine("\nShipping Label:");
        Console.WriteLine(order1.GetShippingLabel());

        Console.WriteLine($"\nTotal Price: ${order1.GetTotalCost():0.00}");

        Console.WriteLine("\n--------------------------\n");

        Console.WriteLine("Packing Label:");
        Console.WriteLine(order2.GetPackingLabel());

        Console.WriteLine("\nShipping Label:");
        Console.WriteLine(order2.GetShippingLabel());

        Console.WriteLine($"\nTotal Price: ${order2.GetTotalCost():0.00}");
    }
}