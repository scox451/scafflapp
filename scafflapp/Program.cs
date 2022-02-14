using scafflapp.core;
using scafflapp.core.models;
using Rhetos.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;
using scafflapp.core.services;

namespace scafflapp
{
    class Program
    {

        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                ShowHint();
                return;
            }

            var path = args[1].ToString();

            if (!File.Exists(path))
            {

                Console.WriteLine($"{path} not found");
                ShowHint();
                return;

            }

            ScaffoldService.Generate(path);




            // html
            // component ts

        }

        private static void ShowHint()
        {
            Console.WriteLine($"syntax: safflapp [entity_file_path]");
            Console.WriteLine($"entity_file_path - entity defenition csv file");
        }
    }
}