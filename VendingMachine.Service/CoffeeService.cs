using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VendingMachince.Data;
using VendingMachine.Helper;
using VendingMachine.Interfaces;
using VendingMachine.Interfaces.Reposiotry;
using VendingMachine.Models;

namespace VendingMachine.Service
{
    public class CoffeeService : ICoffeeService
    {
        public readonly IImportedCoffeeReposiotry _importedCoffeeRepostiroy;
        Dictionary<string, Coffee> importedCoffees;
        public CoffeeService(IImportedCoffeeReposiotry importedCoffeeReposiotry)
        {
            _importedCoffeeRepostiroy = importedCoffeeReposiotry;
        }

        public void DisplayAllIngredients()
        {
            int index = 1;
            foreach (var info in StandardIngredientsData.StandardIngredients)
            {
                Console.WriteLine($"{index}] {info.Name}: each costs: 5 MKD");
                index++;
            }
            Console.WriteLine("Select Ingrediont");
        }

        public void DisplayImportedCoffees()
        {
            importedCoffees = _importedCoffeeRepostiroy.GetImportedCoffees();

            DisplayCoffees(importedCoffees);
        }

        public void DisplayStandardCoffees()
        {
            DisplayCoffees(StandardCoffeeData.StandardCoffees);
        }

        public bool DoesItemExist(string selectedCoffee, bool IsImported)
        {
            if (IsImported)
                return importedCoffees.ContainsKey(selectedCoffee);
            else
                return StandardCoffeeData.StandardCoffees.ContainsKey(selectedCoffee);
        }

        public Coffee GetSelectedCoffee(string selectedCoffee, bool IsImported)
        {
            if (IsImported)
                return importedCoffees.FirstOrDefault(x => x.Key == selectedCoffee).Value;
            else
                return StandardCoffeeData.StandardCoffees.FirstOrDefault(x => x.Key == selectedCoffee).Value;
        }

        private void DisplayCoffees(Dictionary<string, Coffee> coffess)
        {
            var coffeeeee = new List<Coffee>();

            Console.WriteLine($"\n\n{"#"} { "Product" } { "Ingredients".PadLeft(15) } { "Price".PadLeft(40)}");
            foreach (KeyValuePair<string, Coffee> coffee in coffess)
            {
                var ingredinets = "Coffee 1 shot";
                foreach (var ingredient in coffee.Value.Ingredients)
                {
                    var qty = ingredient.Amount > 1 ? "shots" : "shot";
                    ingredinets += $", {ingredient.Name} {ingredient.Amount} {qty}";
                }
                coffeeeee.Add(coffee.Value);
                Console.WriteLine($"{coffee.Key}] {coffee.Value.Name}: '{ingredinets}' Costs: {coffee.Value.Price} MKD each");
            }
            Console.WriteLine("Select Item to Purcahse");
        }
    }
}
