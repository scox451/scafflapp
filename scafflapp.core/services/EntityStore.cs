using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using scafflapp.core.models;

namespace scafflapp.core.services
{

    public class EntityStore
    {
        public static (bool Success, List<EntityProperty>, List<string>, int EmptyLineCount) LoadEntites(string inputFileName)
        {
            var validRows = new List<EntityProperty>();
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

                        int ordinal;
                        bool isNull = true;

                        var validRow = int.TryParse(parts[2], out ordinal) &&
                                       bool.TryParse(parts[5], out isNull);



                        if (validRow)
                        {

                            validRows.Add(new EntityProperty()
                            {
                                Entity = parts[0],
                                Name = parts[1],
                                Ordinal = ordinal,
                                Type = parts[3],
                                TypeSize = parts[4],
                                IsNull = isNull

                            });

                        }
                        else
                        {
                            // fields to review in specific rows
                            invalidRows.Add(string.Join(",", parts));
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error parsing definitions", ex);
            }

            return (true, validRows, invalidRows, emptyLineCount);

        }

    }
}