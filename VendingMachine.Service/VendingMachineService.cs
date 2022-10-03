using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VendingMachine.Helper;
using VendingMachine.Interfaces;
using VendingMachine.Models;

namespace VendingMachine.Service
{
    public class VendingMachineService : IVendingMachineService
    {
        private ICoffeeService _coffeeService;
        public VendingMachineModel vendingMachine = new VendingMachineModel();
        public VendingMachineService()
        {

        }
        public VendingMachineService(ICoffeeService coffeeService)
        {
            _coffeeService = coffeeService;
        }
        public void DisplayMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Coffee Menu");
                Console.WriteLine("1] Display Standard coffees");
                Console.WriteLine("2] Custom Coffee");
                Console.WriteLine("3] Imported Coffee");
                Console.WriteLine("4] Insert money");
                Console.WriteLine("5] Collect Change");
                Console.WriteLine($"Amount: {vendingMachine.Money}");
                Console.Write("Please Select number and press 'Enter' ");

                string selectedOption = Console.ReadLine().ToUpper();

                switch (selectedOption)
                {
                    case "1":
                        _coffeeService.DisplayStandardCoffees();
                        var selectedCoffee = Console.ReadLine();
                        PurchaseSelectedCoffee(selectedCoffee, false);
                        break;
                    case "2":
                        _coffeeService.DisplayAllIngredients();
                        var customCoffe = new Coffee();
                        customCoffe.Name = "Custom Coffee";
                        customCoffe.Price = 10;
                        while (true)
                        {
                            var addedIngredientOrStopAdding = Console.ReadLine();
                            if (addedIngredientOrStopAdding.ToUpper() == "Q")
                            {
                                PurchaseCustomCoffee(customCoffe);
                                break;
                            }
                            else
                            {
                                AddIngredient(addedIngredientOrStopAdding, customCoffe);
                            }
                        }
                        break;
                    case "3":
                        _coffeeService.DisplayImportedCoffees();
                        var selectedImportedCoffee = Console.ReadLine();
                        PurchaseSelectedCoffee(selectedImportedCoffee, true);
                        break;
                    case "4":
                        Console.WriteLine("Insert money");
                        Console.WriteLine("Accepted amounts: 1, 2, 5, 10, 50, 100");
                        while (true)
                        {
                            var addedMoneyOrStopInsertingMoney = Console.ReadLine();
                            if (addedMoneyOrStopInsertingMoney.ToUpper() == "Q")
                                break;
                            else
                                InsertMoney(addedMoneyOrStopInsertingMoney);
                        }
                        break;
                    case "5":
                        CollectChange();
                        break;
                    default:
                        Console.WriteLine("Please select valid option");
                        break;
                }
            }
        }

        private void PurchaseCustomCoffee(Coffee customCoffe)
        {
            if (vendingMachine.Money >= customCoffe.Price)
            {
                var ingredinets = "Coffee 1 shot";
                foreach (var info in customCoffe.Ingredients)
                {
                    var qty = info.Amount > 1 ? "shots" : "shot";
                    ingredinets += $", {info.Name} {info.Amount} {qty}";
                }

                Console.WriteLine($"Enjoy your customm coffee: '{ingredinets}' Costs: {customCoffe.Price} MKD");

                vendingMachine.Money -= customCoffe.Price;
            }
            else
            {
                Console.WriteLine($"Not enough money to purchase {customCoffe.Name}");
            }
            Thread.Sleep(2500);
        }

        private void AddIngredient(string selecedIngredient, Coffee customCoffe)
        {
            int ingredient;
            bool validIngredient = int.TryParse(selecedIngredient, out ingredient);

            if (validIngredient && IsIngredinetAccepted(ingredient))
            {
                switch (ingredient)
                {
                    case 1:
                        if (customCoffe.Ingredients.Any(x => x.Name == "Milk"))
                        {
                            customCoffe.Ingredients.FirstOrDefault(x => x.Name == "Milk").Amount += 1;
                        }
                        else
                        {
                            customCoffe.Ingredients.Add(new Ingredient("Sugar", 1));
                        }
                        break;
                    case 2:
                        if (customCoffe.Ingredients.Any(x => x.Name == "Sugar"))
                        {
                            customCoffe.Ingredients.FirstOrDefault(x => x.Name == "Sugar").Amount += 1;
                        }
                        else
                        {
                            customCoffe.Ingredients.Add(new Ingredient("Caramelle", 1));
                        }
                        break;
                    case 3:
                        if (customCoffe.Ingredients.Any(x => x.Name == "Caramelle"))
                        {
                            customCoffe.Ingredients.FirstOrDefault(x => x.Name == "Caramelle").Amount += 1;
                        }
                        else
                        {
                            customCoffe.Ingredients.Add(new Ingredient("Creamer", 1));
                        }
                        break;
                    case 4:
                        if (customCoffe.Ingredients.Any(x => x.Name == "Creamer"))
                        {
                            customCoffe.Ingredients.FirstOrDefault(x => x.Name == "Creamer").Amount += 1;
                        }
                        else
                        {
                            customCoffe.Ingredients.Add(new Ingredient("Creamer", 1));
                        }
                        break;
                }
                customCoffe.Price += 5;
                Console.WriteLine("Ingredient added to coffee: Add more or press 'Q' to stop and purcahase coffee");
            }
            else
            {
                Console.WriteLine("Pease seelct valid ingredient");

            }
        }

        private bool IsIngredinetAccepted(int selecedIngredient)
        {
            return AcceptedIngredientsCommon.AcceptedIngredients.Any(x => x == selecedIngredient);

        }
        public void CollectChange()
        {
            Console.WriteLine($"Your change is {vendingMachine.Money}");
            vendingMachine.Money = 0;
            Thread.Sleep(2500);
        }

        public void InsertMoney(string addedMoney)
        {
            int amount;
            bool validAmount = int.TryParse(addedMoney, out amount);

            if (validAmount && IsMoneyAccepted(amount))
            {
                vendingMachine.Money += amount;
                Console.WriteLine("Amount added to machine: Add more or press 'Q' to stop inserting money");
            }
            else
            {
                Console.WriteLine("Pease insert valid amount of money");
            }
        }

        private bool IsMoneyAccepted(int validAmount)
        {
            return AcceptedMoneyCommon.AcceptedAmouns.Any(x => x == validAmount);
        }

        private void PurchaseSelectedCoffee(string selectedCoffee, bool isImported)
        {
            if (_coffeeService.DoesItemExist(selectedCoffee, isImported))
            {
                var coffeeToMake = _coffeeService.GetSelectedCoffee(selectedCoffee, isImported);
                if (vendingMachine.Money >= coffeeToMake.Price)
                {
                    Console.WriteLine($"Enjoy your {coffeeToMake.Name}");
                    vendingMachine.Money -= coffeeToMake.Price;
                }
                else
                {
                    Console.WriteLine($"Not enough money to purchase {coffeeToMake.Name}");
                }
            }
            else
            {
                Console.WriteLine($"Coffee does not exist");
            }
            Thread.Sleep(2500);
        }
    }
}
