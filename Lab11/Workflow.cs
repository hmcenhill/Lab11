using System;
using System.Collections.Generic;
using System.Text;

namespace Lab11
{
    public static class Workflow
    {
        public static bool KeepGoing(string question)
        {
            while (true)
            {
                Console.Write($"{question} (y/n): ");
                var input = Console.ReadLine();
                if (input.ToLower() == "y")
                {
                    Console.Clear();
                    return true;
                }
                if (input.ToLower() == "n") return false;
                Console.Write("Input Error: ");
            }
        }
        public static void DisplayEnumValues(Type myEnum)
        {
            var i = 0;
            foreach (var category in Enum.GetValues(myEnum))
            {
                Console.WriteLine($"{i} - {category.ToString()}");
                i++;
            }
        }
    }
}
