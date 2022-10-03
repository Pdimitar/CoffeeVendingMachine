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

        public CoffeeService()
        {
            _importedCoffeeRepostiroy = new ImportedCoffeeRepository();
        }

        Dictionary<string, Coffee> standardCoffees = StandardCoffeeData.StandardCoffees;
        Dictionary<string, Coffee> ImportedCoffess = new Dictionary<string, Coffee>();

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
            List<Coffee> importedCoffees = _importedCoffeeRepostiroy.GetImportedCoffees();


            Console.WriteLine($"\n\n{"#"} { "Product" } { "Ingredients".PadLeft(15) } { "Price".PadLeft(40)}");
            foreach (KeyValuePair<string, Coffee> coffee in ImportedCoffess)
            {
                var ingredinets = "Coffee 1 shot";
                foreach (var ingredient in coffee.Value.Ingredients)
                {
                    var qty = ingredient.Amount > 1 ? "shots" : "shot";
                    ingredinets += $", {ingredient.Name} {ingredient.Amount} {qty}";
                }

                Console.WriteLine($"{coffee.Key}] {coffee.Value.Name}: '{ingredinets}' Costs: {coffee.Value.Price} MKD each");
            }

            Console.WriteLine("Select Item to Purcahse");
        }

        public void DisplayStandardCoffees()
        {

            Console.WriteLine($"\n\n{"#"} { "Product" } { "Ingredients".PadLeft(15) } { "Price".PadLeft(40)}");
            foreach (KeyValuePair<string, Coffee> coffee in standardCoffees)
            {
                var ingredinets = "Coffee 1 shot";
                foreach (var ingredient in coffee.Value.Ingredients)
                {
                    var qty = ingredient.Amount > 1 ? "shots" : "shot";
                    ingredinets += $", {ingredient.Name} {ingredient.Amount} {qty}";
                }

                Console.WriteLine($"{coffee.Key}] {coffee.Value.Name}: '{ingredinets}' Costs: {coffee.Value.Price} MKD each");
            }

            Console.WriteLine("Select Item to Purcahse");
        }

        public bool DoesItemExist(string selectedCoffee)
        {
            return standardCoffees.ContainsKey(selectedCoffee);
        }

        public Coffee GetSelectedCoffee(string selectedCoffee, bool IsImported)
        {
            return standardCoffees.FirstOrDefault(x => x.Key == selectedCoffee).Value;

        }


    }
}
