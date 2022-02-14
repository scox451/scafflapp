using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using scafflapp.core.models;
using SearchOption = System.IO.SearchOption;

namespace scafflapp.core.services
{

    public class TemplateStore
    {

        public Dictionary<string, string> TemplateCache { get; set; }

        private string _rootPath;

        public TemplateStore(string templatesPath = @".")
        {
            _rootPath = templatesPath;
            TemplateCache = new Dictionary<string, string>();

            foreach (var filePath in Directory.GetFiles(templatesPath, "*.*", SearchOption.AllDirectories))
            {
                string fileContents = File.ReadAllText(filePath);
                string key = Path.GetFileName(filePath);
                TemplateCache.Add(key, fileContents);
            }
        }

        public string GetTemplate(string templatePath)
        {
            string result = null;

            if (TemplateCache.ContainsKey(templatePath))
                return TemplateCache[templatePath];

            var fullpath = _rootPath + templatePath;
            if (File.Exists(fullpath))
            {
                result = File.ReadAllText(fullpath);
                TemplateCache.Add(templatePath, result);
            }

            return result;

        }

       



    }
}