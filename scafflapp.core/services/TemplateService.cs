using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using scafflapp.core.models;

namespace scafflapp.core.services
{
    public class TemplateService
    {

        private TemplateStore _templateStore;
        public List<Template> Templates { get; set; }

        public TemplateService()
        {
            _templateStore = new TemplateStore();

            (bool result, Templates) = LoadTemplates("template-definition.csv");

        }
        public static (bool success, List<Template>) LoadTemplates(string inputFileName)
        {
            var validRows = new List<Template>();
            var invalidRows = new List<string>();

            int index = 0;

            var emptyLineCount = 0;
            var line = "";

            try
            {
                /*
                 * If interested in blank line count
                 */
                using (var reader = File.OpenText(inputFileName))
                {
                    while ((line = reader.ReadLine()) != null) // EOF
                    {
                        if (string.IsNullOrWhiteSpace(line))
                        {
                            emptyLineCount++;
                        }
                    }
                }

                using (var parser = new TextFieldParser(inputFileName))
                {

                    parser.Delimiters = new[] { "," };
                    while (true)
                    {

                        string[] parts = parser.ReadFields();

                        if (parts == null)
                        {
                            break;
                        }

                        index += 1;

                        if (parts.Length != 9)
                        {
                            invalidRows.Add(string.Join(",", parts));
                            continue;
                        }

                        // Skip first row which in this case is a header with column names
                        if (index <= 1) continue;

                        validRows.Add(new Template()
                        {
                            Name = parts[0],
                            Description = parts[1],
                            TemplatePath = parts[2],
                            TargetFilename = parts[3],
                            TargetPath = parts[4]

                        });

                    }
                }

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error parsing definitions", ex);
            }

            return (true, validRows);

        }

        public string GetTemplateSource(Template item)
        {
            return _templateStore.GetTemplate(item.TemplatePath);
        }
    }
}
