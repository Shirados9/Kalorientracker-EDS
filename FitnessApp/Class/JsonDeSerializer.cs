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
            var jsonData = System.IO.File.ReadAllText(GetPathGroceriesJson());
            var groceryList = JsonConvert.DeserializeObject<List<Groceries>>(jsonData)
                      ?? new List<Groceries>();
            return groceryList;
        }

        public List<KalorienTag> DeserializeKalorienTag()
        {
            var jsonData = System.IO.File.ReadAllText(GetPathKalorienJson());
            var KalorienTagList = JsonConvert.DeserializeObject<List<KalorienTag>>(jsonData)
                    ?? new List<KalorienTag>();
            return KalorienTagList;
        }

        public List<GewichtTag> DeserializeGewichtTag()
        {
            var jsonData = System.IO.File.ReadAllText(GetPathGewichtJson());
            var GewichtTagList = JsonConvert.DeserializeObject<List<GewichtTag>>(jsonData)
                ?? new List<GewichtTag>();
            return GewichtTagList;
        }

        public List<Extratab> DeserializeExtratab()
        {
            var jsonData = System.IO.File.ReadAllText(GetPathGewichtJson());
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
            System.IO.File.WriteAllText(GetPathGroceriesJson(), jsonData);
        }

        public void Serializer(List<KalorienTag> kalorienTagList)
        {
            //var jsonData = System.IO.File.ReadAllText(GetPathJson());
            var jsonData = JsonConvert.SerializeObject(kalorienTagList);
            System.IO.File.WriteAllText(GetPathKalorienJson(), jsonData);
        }

        public void Serializer(List<GewichtTag> gewichtTagList)
        {
           // var jsonGewichtData = System.IO.File.ReadAllText(GetPathGewichtJson());
            var jsonData = JsonConvert.SerializeObject(gewichtTagList);
            System.IO.File.WriteAllText(GetPathKalorienJson(), jsonData);
        }

        public void Serializer(List<Extratab> extraList)
        {
            var jsonData = JsonConvert.SerializeObject(extraList);
            System.IO.File.WriteAllText(GetPathExtraJson(), jsonData);
        }

        /// <summary>
        /// Pfad von Json-File
        /// </summary>
        /// <returns></returns>
        public string GetPathKalorienJson()
        {
            var parentPath = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName;
            var fullPath = System.IO.Path.Combine(Environment.CurrentDirectory, parentPath + "\\Data\\", "Kalorien.json");
            return fullPath;
        }

        public string GetPathGewichtJson()
        {
            var parentPath = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName;
            var fullPath = System.IO.Path.Combine(Environment.CurrentDirectory, parentPath + "\\Data\\", "Gewicht.json");
            return fullPath;
        }

        public string GetPathGroceriesJson()
        {
            var parentPath = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName;
            var fullPath = System.IO.Path.Combine(Environment.CurrentDirectory, parentPath + "\\Data\\", "Lebensmittel.json");
            return fullPath;
        }

        public string GetPathExtraJson()
        {
            var parentPath = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName;
            var fullPath = System.IO.Path.Combine(Environment.CurrentDirectory, parentPath + "\\Data\\", "Extras.json");
            return fullPath;
        }
    }
}
