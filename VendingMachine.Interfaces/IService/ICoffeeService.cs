using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Models;

namespace VendingMachine.Interfaces
{
    public interface ICoffeeService
    {
        void DisplayStandardCoffees();
        bool DoesItemExist(string selectedCoffee, bool IsImported = false);
        Coffee GetSelectedCoffee(string selectedCoffee, bool IsImported = false);
        void DisplayAllIngredients();
        void DisplayImportedCoffees();
    }
}
