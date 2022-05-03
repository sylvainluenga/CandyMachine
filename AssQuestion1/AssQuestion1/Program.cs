using System;
using System.Collections.Generic;

namespace AssQuestion1
{
    class Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
    class Program
    {
        static readonly List<Item> items = new List<Item>
        {
            new Item
            {
                Name = "Candy",
                Price = 1
            },
            new Item
            {
                Name = "Chips",
                Price = 20
            },
            new Item
            {
                Name = "Gum",
                Price = 15
            },
            new Item
            {
                Name = "Cookie",
                Price = 5
            }
        };

        static void Main(string[] args)
        {
            Console.WriteLine("WELCOME TO THE GYM CANDY MACHINE");
            Console.WriteLine("*********************************");
            while(true)
            {
                Console.WriteLine("List of items");
                Console.WriteLine("-------------");
                PrintItems();
                Console.Write("Enter your choice (q to Quit) : ");
                var input = Console.ReadLine();
                if (input.ToLower() == "q")
                {
                    break;
                }
                else
                {
                    SelectItem(input);
                }
            }
        }

        static void PrintItems()
        {
            for(var i = 0; i < items.Count; i++)
            {
                var item = items[i];
                Console.WriteLine($"{i} {item.Name}");
            }
        } 

        static void SelectItem(string itemSelection)
        {
            if (int.TryParse(itemSelection, out var itemIndex))
            {
                if (itemIndex < 0 || itemIndex >= items.Count)
                {
                    PrintError($"Invalid section. your selection must range from 0 to {items.Count - 1}");
                }
                else
                {
                    var done = false;
                    while(!done)
                    {
                        var item = items[itemIndex];
                        Console.WriteLine($"This item cost: {item.Price} R");
                        Console.WriteLine("\n1 Pay\n2 Go back to main menu");
                        Console.Write("Enter your choice: ");
                        var selectionInput = Console.ReadLine();
                        if (int.TryParse(selectionInput, out var selection))
                        {
                            switch(selection)
                            {
                                case 1:
                                    BuyItem(item);
                                    done = true;
                                    break;
                                case 2:
                                    done = true;
                                    break;
                                default:
                                    PrintError("Invalid selection your selection must be either 0 or 1");
                                    break;
                            }
                        }
                        else
                        {
                            PrintError("Invalid selection your selection must be a valid number");
                        }
                    }
                }
            }
            else
            {
                PrintError("Invalid selection, your selection must be a number");
            }
        }

        static void BuyItem(Item item)
        {
            while(true)
            {
                Console.Write("Enter money (or enter Q to back): ");
                var moneyInput = Console.ReadLine();
                if (moneyInput.ToLower() == "q") break;
                if (int.TryParse(moneyInput, out var money))
                {
                    if (money < item.Price)
                    {
                        PrintError("Unsufficient fund.");
                    }
                    else
                    {
                        PrintSuccess($"Thank you Sensei Alex, your purchase was successfull. your change is {money - item.Price}R");
                        break;
                    }
                }
                else
                {
                    PrintError("Your money must be a valid number");
                }
            }
        }
       
        static void PrintError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void PrintSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
