using System;
namespace MyFirstConsoleApplication

{
    class Program
    {
        static void Main(string[] args)
        {
            var name = "Kevin Saunders";
            var location = "Idaho";
            var time = DateTime.Now;
            var xmas = getNextChristmas(time);

            Console.WriteLine($"My name is {name}.");
            Console.WriteLine($"I am in {location}.");
            Console.WriteLine($"The Date is {time:d}.");
            Console.WriteLine($"Only {(xmas-time).TotalDays:f0} more days till Christmas!");
            Console.WriteLine();
            var window = new GlazerCalc();
            window.Main();
            Console.WriteLine("Thank you! Goodbye.");
            Console.ReadKey();
        }

        public static DateTime getNextChristmas(DateTime now)
        {
            var year = now.Year;
            var xmas = new DateTime(year, 12, 25);

            if (xmas.Date < now.Date)
            {
                year += 1;
                xmas = new DateTime (year, 12, 25);
            }

            
            return xmas;
        }
    }
}

// This code was borrowed from  C# Programming Yellow Book by Rob Miles
// as part of a tutorial. I have made only minor alterations to this code.

class GlazerCalc
{
    public void Main()
    {
        double width, height, woodLength, glassArea;
        string widthString, heightString;
        Console.WriteLine(
            "What is the width of the window you want to build?\n(in meters)");
        widthString = Console.ReadLine();
        width = double.Parse(widthString);
        Console.WriteLine(
            "What is the height of the window?\n(in meters)");
        heightString = Console.ReadLine();
        height = double.Parse(heightString);
        woodLength = 2 * (width + height) * 3.25;
        glassArea = 2 * (width * height);
        Console.WriteLine("The length of the wood is " +
        woodLength + " feet");
        Console.WriteLine("The area of the glass is " +
        glassArea + " square meters");
    }
}




