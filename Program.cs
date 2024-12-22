using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<SalesPerson> salesPeople = new List<SalesPerson>();

        // Collect data for 3 salespeople
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($"Enter details for SalesPerson {i + 1}:");

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Title: ");
            string title = Console.ReadLine();

            Console.WriteLine("Enter at least 3 sales figures (separated by spaces):");
            string[] salesInput = Console.ReadLine().Split(' ');
            List<double> sales = new List<double>();
            foreach (string sale in salesInput)
            {
                if (double.TryParse(sale, out double saleValue))
                {
                    sales.Add(saleValue);
                }
            }

            if (sales.Count < 3)
            {
                Console.WriteLine("Error: Please enter at least 3 sales figures.");
                i--;
                continue;
            }

            SalesPerson person = new SalesPerson(name, title, sales);
            salesPeople.Add(person);
        }

        // Generate Sales Report
        GenerateSalesReport(salesPeople);
    }

    static void GenerateSalesReport(List<SalesPerson> salesPeople)
    {
        double companyTotalSales = 0;

        Console.WriteLine("\n--- Sales Report ---");

        foreach (SalesPerson person in salesPeople)
        {
            Console.WriteLine($"\nName: {person.Name}");
            Console.WriteLine($"Title: {person.Title}");

            double totalSales = person.TotalSales();
            double minSales = person.MinSales();
            double maxSales = person.MaxSales();
            double averageSales = person.AverageSales();

            Console.WriteLine($"Total Sales: {totalSales:C}");
            Console.WriteLine($"Min Sale: {minSales:C}");
            Console.WriteLine($"Max Sale: {maxSales:C}");
            Console.WriteLine($"Average Sale: {averageSales:C}");

            companyTotalSales += totalSales;

            Console.WriteLine("Individual Sales:");
            IEnumerator<double> salesIterator = person.GetSalesIterator();
            while (salesIterator.MoveNext())
            {
                Console.WriteLine($"- {salesIterator.Current:C}");
            }
        }

        Console.WriteLine($"\nTotal Sales for the Company: {companyTotalSales:C}");
    }
}
