using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SalesPerson
{
    public string Name { get; set; }
    public string Title { get; set; }
    private List<double> Sales { get; set; }

    // Constructor
    public SalesPerson(string name, string title, List<double> sales)
    {
        Name = name;
        Title = title;
        Sales = sales;
    }

    // Getter for sales iterator
    public IEnumerator<double> GetSalesIterator()
    {
        return Sales.GetEnumerator();
    }

    // Calculate total sales
    public double TotalSales()
    {
        return Sales.Sum();
    }

    // Get minimum sales
    public double MinSales()
    {
        return Sales.Min();
    }

    // Get maximum sales
    public double MaxSales()
    {
        return Sales.Max();
    }

    // Calculate average sales
    public double AverageSales()
    {
        return Sales.Average();
    }
}
