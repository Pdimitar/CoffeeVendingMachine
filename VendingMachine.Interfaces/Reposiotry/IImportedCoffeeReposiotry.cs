using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Models;

namespace VendingMachine.Interfaces.Reposiotry
{
    public interface IImportedCoffeeReposiotry
    {
        Dictionary<string, Coffee> GetImportedCoffees();
    }
}
