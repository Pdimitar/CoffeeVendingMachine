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
        public Dictionary<string, Coffee> GetImportedCoffees()
        {
            Dictionary<string, Coffee> importedCoffees = new Dictionary<string, Coffee>();

            XmlRootAttribute xRoot = new XmlRootAttribute();
            xRoot.ElementName = "ArrayOfCoffee";
            xRoot.IsNullable = true;

            XmlSerializer serializer = new XmlSerializer(typeof(List<Coffee>), xRoot);

            using (FileStream stream = File.OpenRead("ImportedCoffees.xml"))
            {
                List<Coffee> dezerializedList = (List<Coffee>)serializer.Deserialize(stream);
                
                var index = 1;
                foreach (var coffee in dezerializedList)
                {
                    importedCoffees.Add($"B{index}", coffee);
                    index++;
                }

                return importedCoffees;
            }
        }
    }
}
