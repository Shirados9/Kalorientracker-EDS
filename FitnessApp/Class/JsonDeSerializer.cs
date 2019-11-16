using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using Newtonsoft.Json;

namespace FitnessApp.Class
{
    public class JsonDeSerializer
    {

        /// <summary>
        /// Deserialize Json
        /// </summary>
        /// <returns></returns>
        public List<Groceries> Deserializer()
        {
            var jsonData = System.IO.File.ReadAllText(GetPathJson());
            var groceryList = JsonConvert.DeserializeObject<List<Groceries>>(jsonData)
                      ?? new List<Groceries>();
            return groceryList;
        }

        /// <summary>
        /// Serialize Json
        /// </summary>
        /// <param name="groceryList"></param>
        public void Serializer(List<Groceries> groceryList)
        {
            //var jsonData = System.IO.File.ReadAllText(GetPathJson());
            var jsonData = JsonConvert.SerializeObject(groceryList);
            System.IO.File.WriteAllText(GetPathJson(), jsonData);
        }

        /// <summary>
        /// Pfad von Json-File
        /// </summary>
        /// <returns></returns>
        public string GetPathJson()
        {
            var parentPath = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName;
            var fullPath = System.IO.Path.Combine(Environment.CurrentDirectory, parentPath + "\\Data\\", "Lebensmittel.json");
            return fullPath;
        }
    }
}
