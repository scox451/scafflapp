using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Rhetos.Utilities;
using scafflapp.core.models;

namespace scafflapp.core.services
{
    public class ScaffoldService
    {
        private static TemplateService _templateService;
        private static TokensDictionay _tokensDictionary;

        public static void Generate(string entityDefPath)
        {

            var (success,
                allEntities,
                invalidRows,
                emtpyLineCount) = EntityStore.LoadEntites(entityDefPath);

            _templateService = new TemplateService();

            var entities = allEntities.OrderBy(c => c.Entity)
                    .ThenBy(c => c.Ordinal)
                    .GroupBy(c => c.Entity);

            foreach (var entity in entities)
            {

                BuildSection(entity);
            }
        }

        private static void BuildSection(IGrouping<string, EntityProperty> entity)
        {

            _tokensDictionary = new TokensDictionay(entity.Key, entity.ToList());
            NgTokens.Append(_tokensDictionary, entity.ToList());
            
            foreach (var item in _templateService.Templates)
            {
                ////generate payload
                var templateSource = _templateService.GetTemplateSource(item);
                var payload = ReplaceTokens(templateSource);
                var targetPath = ReplaceTokens(item.TargetPath);
                var targetFilename = ReplaceTokens(item.TargetFilename);

                SavePayload(payload, targetPath, targetFilename);

            }
        }

        private static void SavePayload(string payload, string targetPath, string targetFilename)
        {
            new FileInfo(targetPath).Directory.Create();
            var fullPath = targetPath + targetFilename;

            if (File.Exists(fullPath))
                File.Move(fullPath, $"{fullPath}.{DateTime.Now.ToString("yyyyMMdd'_'HHmmss")}.bak");

            File.WriteAllText(fullPath, payload);
        }

        private static string ReplaceTokens(string template)
        {
            FastReplacer fr = new FastReplacer("~!", "!~");

            fr.Append(template);

            foreach (var token in _tokensDictionary)
            {
                fr.Replace(token.Key, token.Value);
            }

            return fr.ToString();
        }

    }
}