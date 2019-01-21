using System;
using System.IO;


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
        }
    }
}
