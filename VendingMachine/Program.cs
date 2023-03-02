/*
 * Vending Machine
 * 3/2/2023
 * C#.NET I
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            string selection;
            Vender machine = SetupVender();
            do
            {
                Console.WriteLine(machine);
                Console.Write("Enter a selection or exit >> ");
                selection = Console.ReadLine().Trim().ToUpper();
                if (selection != "EXIT")
                {
                    SelectionNumber number;
                    bool correctInput = Enum.TryParse(selection, out number);
                    if (correctInput)
                    {
                        bool successfulVend = machine.Vend(number);
                        if (successfulVend)
                        {
                            Console.WriteLine("Successfully vended item!");
                        }
                        else
                        {
                            Console.WriteLine("Invalid selection! Out of product.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid selection! Unrecognized input.");
                    }
                    Console.WriteLine();
                }
            } while (selection != "EXIT");
        }

        /// <summary>
        /// Populates a Vender object.
        /// </summary>
        /// <returns>A populated Vender object.</returns>
        public static Vender SetupVender()
        {
            string[] snacks =
            {
                "Lay's Potato Chips",
                "Cheetos",
                "Funjuns",
                "M&Ms",
                "Snickers",
                "Fritos"
            };
            decimal[] prices = { 1.25M, 1.5M, 1.5M, 1.0M, 1.0M, 1.25M };
            int[] amounts = { 5, 5, 5, 10, 10, 5 };
            return new Vender(snacks, prices, amounts);
        }
    }
}
