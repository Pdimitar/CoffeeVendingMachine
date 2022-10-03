using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.AspNet.Mvc;
using VendingMachince.Data;
using VendingMachine.Interfaces;
using VendingMachine.Interfaces.Reposiotry;
using VendingMachine.Service;

namespace coffeeVending
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var container = new UnityContainer();
            container.RegisterType<IVendingMachineService, VendingMachineService>();
            container.RegisterType<ICoffeeService, CoffeeService>();
            container.RegisterType<IImportedCoffeeReposiotry, ImportedCoffeeRepository>();

            var _vendingMachineService = container.Resolve<IVendingMachineService>();
            _vendingMachineService.DisplayMenu();

        }
    }
}
