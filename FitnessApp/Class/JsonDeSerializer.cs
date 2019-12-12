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
        /// Deserialize Json zu List<Groceries>
        /// </summary>
        /// <returns></returns>
        public List<Groceries> Deserializer()
        {
            var jsonData = System.IO.File.ReadAllText(GetPathJson("Lebensmittel.json"));
            var groceryList = JsonConvert.DeserializeObject<List<Groceries>>(jsonData)
                      ?? new List<Groceries>();
            return groceryList;
        }

        /// <summary>
        /// Deserialize Json zu List<GewichtTag>
        /// </summary>
        /// <returns></returns>
        public List<GewichtTag> DeserializeGewichtTag()
        {
            var jsonData = System.IO.File.ReadAllText(GetPathJson("Gewicht.json"));
            var gewichtList = JsonConvert.DeserializeObject<List<GewichtTag>>(jsonData)
                      ?? new List<GewichtTag>();
            return gewichtList;
        }

        /// <summary>
        /// Deserialize Json zu List<KalorienTag>
        /// </summary>
        /// <returns></returns>
        public List<KalorienTag> DeserializeKalorienTag()
        {
            var jsonData = System.IO.File.ReadAllText(GetPathJson("Kalorien.json"));
            var kalorienList = JsonConvert.DeserializeObject<List<KalorienTag>>(jsonData)
                      ?? new List<KalorienTag>();
            return kalorienList;
        }

        public List<Extratab> DeserializeExtratab()
        {
            var jsonData = System.IO.File.ReadAllText(GetPathJson("Extras.json"));
            var ExtraList = JsonConvert.DeserializeObject<List<Extratab>>(jsonData)
                ?? new List<Extratab>();
            return ExtraList;
        }

        /// <summary>
        /// Serialize Json
        /// </summary>
        /// <param name="groceryList"></param>
        public void Serializer(List<Groceries> groceryList)
        {
            //var jsonData = System.IO.File.ReadAllText(GetPathJson());
            var jsonData = JsonConvert.SerializeObject(groceryList);
            System.IO.File.WriteAllText(GetPathJson("Lebensmittel.json"), jsonData);
        }

        /// <summary>
        /// Serialize Json
        /// </summary>
        /// <param name="gewichtList"></param>
        public void Serializer(List<GewichtTag> gewichtList)
        {
            //var jsonData = System.IO.File.ReadAllText(GetPathJson());
            var jsonData = JsonConvert.SerializeObject(gewichtList);
            System.IO.File.WriteAllText(GetPathJson("Gewicht.json"), jsonData);
        }

        /// <summary>
        /// Serialize Json
        /// </summary>
        /// <param name="kalorienList"></param>
        public void Serializer(List<KalorienTag> kalorienList)
        {
            //var jsonData = System.IO.File.ReadAllText(GetPathJson());
            var jsonData = JsonConvert.SerializeObject(kalorienList);
            System.IO.File.WriteAllText(GetPathJson("Kalorien.json"), jsonData);
        }

        /// <summary>
        /// Serialize Json
        /// </summary>
        /// <param name="kalorienList"></param>
        public void Serializer(List<Extratab> extrasList)
        {
            //var jsonData = System.IO.File.ReadAllText(GetPathJson());
            var jsonData = JsonConvert.SerializeObject(extrasList);
            System.IO.File.WriteAllText(GetPathJson("Extras.json"), jsonData);
        }

        /// <summary>
        /// Pfad von Json-File
        /// </summary>
        /// <returns></returns>
        public string GetPathJson(string jsonFile)
        {
            var parentPath = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName;
            var fullPath = System.IO.Path.Combine(Environment.CurrentDirectory, parentPath + "\\Data\\", jsonFile);
            return fullPath;
        }
    }
}
