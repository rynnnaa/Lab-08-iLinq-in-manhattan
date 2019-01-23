using System;
using System.IO;
using System.Collections.Generic;
using Lab_08_iLinq_in_manhattan.Classes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

            //2. filter out neighborhoods without names
            var hoodswithnames = from n in allneighborhoods
                                     //name is not empty
                                 where n != ""
                                 select n;
            Console.WriteLine();
            Console.WriteLine("========Display Neighborhoods with names========");
            Console.WriteLine();

            foreach (var prop in hoodswithnames)
            {
                Console.WriteLine(prop);
            }

            //remove duplicates
            var nodupes = hoodswithnames.Distinct();
            Console.WriteLine();
            Console.WriteLine("============Remove neighborhood duplicates=======");
            Console.WriteLine();

            foreach (var prop in nodupes)
            {
                Console.WriteLine(prop);
            }

            //4.Consolidate previous queries into a single query
            var consolidatedqueries = obj.Features.Where(n => n.Properties.Neighborhood.Length > 0)
                .GroupBy(g => g.Properties.Neighborhood)
                .Select(s => s.First());

            Console.WriteLine();
            Console.WriteLine("=====Consolidate Queries========");
            Console.WriteLine();

            foreach (var prop in consolidatedqueries)
            {
                Console.WriteLine(prop.Properties.Neighborhood);

            }

            //5. Rewrite a question using Linq, not lambda
            var rewrite = allneighborhoods.Where(i => i != "");

            Console.WriteLine();
            Console.WriteLine("==========ReWritten Second Query");
            Console.WriteLine();

            foreach (var prop in hoodswithnames)
            {
                Console.WriteLine(prop);
            }

        }
    }
}
