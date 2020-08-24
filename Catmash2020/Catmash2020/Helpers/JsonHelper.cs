using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Catmash2020.Services
{
    public static class JsonHelper
    {
        public static T GetJson<T>(string filename)
        {
            using (StreamReader r = new StreamReader(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Datas\" + filename + ".json").Replace(".Tests", "")))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(json);
            }
        }

        public static void WriteInDatabase<T>(T datas, string filename)
        {
            using (StreamWriter w = new StreamWriter(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Datas\" + filename + ".json").Replace(".Tests", "")))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(w, datas);
            }
        }
    }
}
