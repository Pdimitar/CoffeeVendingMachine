using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Interfaces;
using VendingMachine.Service;

namespace VendingMachine.Test
{
    [TestClass]
    public class VendingMachineTests
    {

        [DataTestMethod]
        [DataRow("1", 1)]
        [DataRow("2", 2)]
        [DataRow("5", 5)]
        [DataRow("10", 10)]
        [DataRow("50", 10)]
        [DataRow("100", 100)]
        public void TestInsertMoney(string input, int expected)
        {
            VendingMachineService vm = new VendingMachineService();
            vm.InsertMoney(input);
            decimal result = vm.vendingMachine.Money;

            Assert.AreEqual((decimal)expected, result);
        }

        [TestMethod]
        public void TestColletsMoeny()
        {
            VendingMachineService vm = new VendingMachineService();
            vm.InsertMoney("5");
            vm.CollectChange();

            Assert.AreEqual(vm.vendingMachine.Money, 0);
        }
    }
}
