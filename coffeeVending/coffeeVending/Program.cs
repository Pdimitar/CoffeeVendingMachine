using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Interfaces;
using VendingMachine.Service;

namespace coffeeVending
{
    class Program
    {
   
        static void Main(string[] args)
        {
            IVendingMachineService _vendingMachineService = new VendingMachineService(); // <- interface
            _vendingMachineService.DisplayMenu();
        }
    }
}
