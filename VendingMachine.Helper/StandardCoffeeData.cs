using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Models;

namespace VendingMachine.Helper
{
    public static class StandardCoffeeData
    {
        public static Dictionary<string, Coffee> StandardCoffees = new Dictionary<string, Coffee>()
        {
            {"A1", new Coffee("Latte", 20, new List<Ingredient>(){new Ingredient("Milk",2),new Ingredient("Sugar",1) })},
            {"A2", new Coffee("Macchiato",25,new List<Ingredient>(){new Ingredient("Milk",1),new Ingredient("Sugar",1) })},
            {"A3", new Coffee("Espresso",10,new List<Ingredient>(){new Ingredient("Sugar",1) })},
            {"A4", new Coffee("Americano",15,new List<Ingredient>(){new Ingredient("Sugar",1), new Ingredient("Milk",1)})}
        };
    }
}
