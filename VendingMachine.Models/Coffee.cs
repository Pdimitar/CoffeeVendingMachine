using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Models
{
    public class Coffee
    {
        public Coffee()
        {
            Ingredients = new List<Ingredient>();
        }
        public Coffee(string name, int price, List<Ingredient> ingredients)
        {
            Name = name;
            Price = price;
            Ingredients = ingredients;
        }

        public string Name { get; set; }
        public int Price { get; set; }
        public List<Ingredient> Ingredients { get; set; }
    }
}
