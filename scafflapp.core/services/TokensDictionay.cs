using System.Collections.Generic;
using System.Text;
using scafflapp.core.models;

namespace scafflapp.core.services
{
    public class TokensDictionay : Dictionary<string, string>
    {
        public Dictionary<string, string> EntitNames { get; set; }
        //readonly string rootPath = @"c:\projects\chinook\console\template";

        public TokensDictionay(string entityName, List<EntityProperty> columns)
        {
            string entityDetailName = $"{entityName}Detail";

            this.Add("~!sentence!~", entityName.ToSentenceCase());
            this.Add("~!pascal!~", entityName.ToPascalCase());
            this.Add("~!kebab!~", entityName.ToKebabCase());
            this.Add("~!snake!~", entityName.ToSnakeCase());
            this.Add("~!camel!~", entityName.ToCamelCase());

            this.Add("~!detail-sentence!~", entityDetailName.ToSentenceCase());
            this.Add("~!detail-pascal!~", entityDetailName.ToPascalCase());
            this.Add("~!detail-kebab!~", entityDetailName.ToKebabCase());
            this.Add("~!detail-snake!~", entityDetailName.ToSnakeCase());
            this.Add("~!detail-camel!~", entityDetailName.ToCamelCase());

            this.Add("~!plural-camel!~", entityName.ToPlural().ToCamelCase());
            this.Add("~!detail-plural-camel!~", entityDetailName.ToPlural().ToCamelCase());
            this.Add("~!plural-pascal!~", entityName.ToPlural().ToPascalCase());
            this.Add("~!detail-plural-pascal!~", entityDetailName.ToPlural().ToPascalCase());

        

        }
    }
}

