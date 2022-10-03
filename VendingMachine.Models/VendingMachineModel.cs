using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Models
{
    public class VendingMachineModel
    {
        public VendingMachineModel()
        {
            Money = 0;
        }
        public VendingMachineModel(int insertedMoney)
        {
            Money = insertedMoney;
        }
        public int Money { get; set; }

    }
}
