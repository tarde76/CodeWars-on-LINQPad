using System;

namespace Find_the_smallest;
public class Program
{
    static void Main(string[] args)
    {
        string? number = null;
        do
        {
            Console.Write("Enter number: ");
            number = Console.ReadLine();
            if (Int64.TryParse(number, out var parsedNumber))
            {
                var smallest = ToSmallest.Smallest(parsedNumber);
                Console.WriteLine($"{parsedNumber} = [{String.Join(", ", smallest)}]");
            }
            else if (!String.IsNullOrWhiteSpace(number))
                Console.WriteLine("Wrong number. Try again");
        } while (!String.IsNullOrWhiteSpace(number));
    }
}
