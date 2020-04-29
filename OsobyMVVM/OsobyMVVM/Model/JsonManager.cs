using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Text.Json;
//using System.Text.Json.Serialization;
using System.IO;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace OsobyMVVM.Model
{
   static class JsonManager
    {
        static string path = @"../../people.json";
        public static void PersonToJson(Person p)
        {
            string jsonString;
           // jsonString = JsonSerializer.Serialize(p);
            jsonString = JsonConvert.SerializeObject(p);
            //    jsonString = JsonConvert.SerializeObject(p, Formatting.Indented);

            File.AppendAllText(path,jsonString+Environment.NewLine);

        }

        public static ObservableCollection<Person> LoadJsonBase()
        {
            ObservableCollection<Person> oc = new ObservableCollection<Person>();
            Person p;
            if(File.Exists(path))
            {
                using (var reader = new StreamReader(path))
                {
                    string line = null;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (!string.IsNullOrEmpty(line))
                        {
                            p = JsonConvert.DeserializeObject<Person>(line);
                            oc.Add(p);
                        }
                    }
                }
            }
            if (oc == null) oc = new ObservableCollection<Person>();
            return oc;
        }
    }
}
