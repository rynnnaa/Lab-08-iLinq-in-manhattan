using Lab_08_iLinq_in_manhattan.Classes;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Collections.Generic;y
using System.Linq;

namespace Lab_08_iLinq_in_manhattan
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("NEIGHBORHOODS IN MANHATTAN");
            ConvertJSON();

        }

        static void ConvertJSON()
        {
            string path = "../../../Linq.json";
            string text = "";

            //read in the file
            using (StreamReader reader = File.OpenText(path))
            {
                text = reader.ReadToEnd();
            }

            //set up the deserialized object
            var obj = JsonConvert.DeserializeObject<RootObject>(text);

            //1. print all neighborhoods
            var allneighborhoods = obj.Features.Select(f => f.Properties.Neighborhood);

            Console.WriteLine();
            Console.WriteLine("======All NeighborHoods======");
            Console.WriteLine();

            foreach (var prop in allneighborhoods)
            {
                Console.WriteLine(prop);
            }
        }

    }
}
