using System;
using System.Collections.Generic;
using System.Linq;


namespace Shopping_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            
            List<string> basket = new List<string> { "Apple", "Apple", "Banana", "Melon", "Melon", "Lime", "Lime", "Lime" };


            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Itmes \t Unit Price \t Quantity \t Total Price");
            Console.WriteLine("--------------------------------------------------");
            decimal totalCost = CalculateTotalCost(basket);
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("Grand Total cost of the Basket:  \t"+totalCost+"p");
            Console.WriteLine("----------------------------------------------------");
        }

        static decimal CalculateTotalCost(List<string> basket)
        {
           // Dictionary<string, int> itemCounts = basket.GroupBy(item => item).ToDictionary(group => group.Key, group => group.Count());
            var itemCounts = basket.GroupBy(item => item)
                             .Select(group => new { Item = group.Key, Count = group.Count() })
                             .OrderBy(result => result.Item);
            decimal totalCost = 0;

            foreach (var items in itemCounts)
            {
                switch (items.Item)
                {
                    case "Apple":
                        totalCost += items.Count * 35;
                        Console.WriteLine($"{items.Item}: \t 35p \t\t {items.Count} \t\t {items.Count * 35}p");
                        break;
                    case "Banana":
                        totalCost += items.Count * 20;
                        Console.WriteLine($"{items.Item}:\t 20p \t\t {items.Count} \t\t {items.Count * 20}p");
                        break;
                    case "Melon":
                        totalCost += (items.Count / 2 + items.Count % 2) * 50; // Buy one get one free
                        Console.WriteLine($"{items.Item}: \t 50p \t\t {items.Count} \t\t {(items.Count / 2 + items.Count % 2) * 50}p - (Buy one get one free)");
                        break;
                    case "Lime":
                        totalCost += (items.Count / 3 * 2 + items.Count % 3) * 15; // Three for the price of two
                        Console.WriteLine($"{items.Item}: \t 15p \t\t {items.Count} \t\t {(items.Count / 3 * 2 + items.Count % 3) * 15}p - (Three for the price of two)");
                        break;
                    default:
                        Console.WriteLine($"Unknown item in the basket: {items.Item}");
                        break;
                }
            }

            return totalCost;
        }
    }
}
