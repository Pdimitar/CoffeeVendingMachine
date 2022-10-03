using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Models;

namespace VendingMachine.Helper
{
    public static class StandardIngredientsData
    {
        public static List<Ingredient> StandardIngredients = new List<Ingredient>()
        {
            new Ingredient("Milk", 0),
            new Ingredient("Sugar", 0),
            new Ingredient("Caramelle", 0),
            new Ingredient("Creamer", 0)
        };

    }
}
