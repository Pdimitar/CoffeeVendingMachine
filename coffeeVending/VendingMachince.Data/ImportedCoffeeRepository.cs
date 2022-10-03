using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using VendingMachine.Interfaces.Reposiotry;
using VendingMachine.Models;

namespace VendingMachince.Data
{
    public class ImportedCoffeeRepository : IImportedCoffeeReposiotry
    {
        public List<Coffee> GetImportedCoffees()
        {
            XmlSerializer reader = new XmlSerializer(typeof(Coffee));

            string baseDir = AppDomain.CurrentDomain.BaseDirectory;

            var sss = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "ImporedCoffees.xml");

            StreamReader file = new StreamReader("ImporedCoffees.xml");
            List<Coffee> coffess = (List<Coffee>)reader.Deserialize(file);
            file.Close();

            return coffess;
        }
    }
}
