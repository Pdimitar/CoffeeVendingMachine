using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Models
{
    public class Ingredient
    {
        public Ingredient()
        {

        }
        public Ingredient(string name, int? amount)
        {
            Name = name;
            Amount = amount;
        }

        public string Name { get; set; }
        public int? Amount { get; set; }
    }
}
