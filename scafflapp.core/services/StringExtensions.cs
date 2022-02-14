using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace scafflapp.core.services
{
    public static class StingExtensions
    {

        public static string Capitolize(this string str)
        {
            return char.ToUpper(str[0]) + str.Substring(1);
        }


        public static string ToTitleCase(this string str)
        {
            string pattern = @"/[A-Z]{2,}(?=[A-Z][a-z]+[0-9]*|\b)|[A-Z]?[a-z]+[0-9]*|[A-Z]|[0-9]+/g";

            var result = string.Join(' ',
                new Regex(pattern)
                    .Matches(str)
                    .Select(x => x.Value.ToLower().Capitolize())
                );

            return result;
        }

        public static string ToSentenceCase(this string str)
        {
            string pattern = @"/[A-Z]{2,}(?=[A-Z][a-z]+[0-9]*|\b)|[A-Z]?[a-z]+[0-9]*|[A-Z]|[0-9]+/g";

            var result = string.Join(' ',
                new Regex(pattern)
                    .Matches(str)
                    .Select(x => x.Value.ToLower())
                );

            return result.Capitolize();
        }
        public static string ToSnakeCase(this string str)
        {
            string pattern = @"/[A-Z]{2,}(?=[A-Z][a-z]+[0-9]*|\b)|[A-Z]?[a-z]+[0-9]*|[A-Z]|[0-9]+/g";

            var result = string.Join('_',
                new Regex(pattern)
                    .Matches(str)
                    .Select(x => x.Value.ToLower())
                );

            return result;
        }

        public static string ToKebabCase(this string str)
        {
            string pattern = @"/[A-Z]{2,}(?=[A-Z][a-z]+[0-9]*|\b)|[A-Z]?[a-z]+[0-9]*|[A-Z]|[0-9]+/g";

            var result = string.Join('-',
                new Regex(pattern)
                    .Matches(str)
                    .Select(x => x.Value.ToLower())
                );

            return result;
        }
        public static string ToPascalCase(this string str)
        {
            // string pattern = @"/\w\S*/g";

            // str = str.Replace('-',' ');
            // str = str.Replace('_',' ');
            string pattern = @"/[A-Z]{2,}(?=[A-Z][a-z]+[0-9]*|\b)|[A-Z]?[a-z]+[0-9]*|[A-Z]|[0-9]+/g";

            var result = string.Concat(
                new Regex(pattern)
                    .Matches(str)
                    .Select(match =>
                    {
                        var word = match.Value.ToString();

                        return word.Substring(0, 1).ToUpper() + word.Substring(1).ToLower();


                    })
                );

            return result;
        }

        public static string ToCamelCase(this string str)
        {
            str = str.ToPascalCase();

            return char.ToLower(str[0]) + str.Substring(1);
        }

        public static string ToPlural(this string str)
        {

            return str + "s";
        }



        public static void TestStringHelper()
        {
           string titleCase = "Model Name";
            string sentenceCase = "Model name";
            string lowerCase = "model name";
            string pascalCase = "ModelName";
            string camelCase = "modelName";
            string snakeCase = "model_name";
            string kebabCase = "model-name";

            Debug.WriteLine("\nstring.ToTitleCase()");
            Debug.WriteLine($"({titleCase}) => {titleCase.ToTitleCase()}");
            Debug.WriteLine($"({sentenceCase}) => {sentenceCase.ToTitleCase()}");
            Debug.WriteLine($"({lowerCase}) => {lowerCase.ToTitleCase()}");
            Debug.WriteLine($"({pascalCase}) => {pascalCase.ToTitleCase()}");
            Debug.WriteLine($"({camelCase}) => {camelCase.ToTitleCase()}");
            Debug.WriteLine($"({snakeCase}) => {snakeCase.ToTitleCase()}");
            Debug.WriteLine($"({kebabCase}) => {kebabCase.ToTitleCase()}");

            Debug.WriteLine("\nstring.ToSentenceCase()");
            Debug.WriteLine($"({titleCase}) => {titleCase.ToSentenceCase()}");
            Debug.WriteLine($"({sentenceCase}) => {sentenceCase.ToSentenceCase()}");
            Debug.WriteLine($"({lowerCase}) => {lowerCase.ToSentenceCase()}");
            Debug.WriteLine($"({pascalCase}) => {pascalCase.ToSentenceCase()}");
            Debug.WriteLine($"({camelCase}) => {camelCase.ToSentenceCase()}");
            Debug.WriteLine($"({snakeCase}) => {snakeCase.ToSentenceCase()}");
            Debug.WriteLine($"({kebabCase}) => {kebabCase.ToSentenceCase()}");

            Debug.WriteLine("\nstring.ToPascalCase()");
            Debug.WriteLine($"({titleCase}) => {titleCase.ToPascalCase()}");
            Debug.WriteLine($"({sentenceCase}) => {sentenceCase.ToPascalCase()}");
            Debug.WriteLine($"({lowerCase}) => {lowerCase.ToPascalCase()}");
            Debug.WriteLine($"({pascalCase}) => {pascalCase.ToPascalCase()}");
            Debug.WriteLine($"({camelCase}) => {camelCase.ToPascalCase()}");
            Debug.WriteLine($"({snakeCase}) => {snakeCase.ToPascalCase()}");
            Debug.WriteLine($"({kebabCase}) => {kebabCase.ToPascalCase()}");

            Debug.WriteLine("\nstring.ToCamelCase()");
            Debug.WriteLine($"({titleCase}) => {titleCase.ToCamelCase()}");
            Debug.WriteLine($"({sentenceCase}) => {sentenceCase.ToCamelCase()}");
            Debug.WriteLine($"({lowerCase}) => {lowerCase.ToCamelCase()}");
            Debug.WriteLine($"({pascalCase}) => {pascalCase.ToCamelCase()}");
            Debug.WriteLine($"({camelCase}) => {camelCase.ToCamelCase()}");
            Debug.WriteLine($"({snakeCase}) => {snakeCase.ToCamelCase()}");
            Debug.WriteLine($"({kebabCase}) => {kebabCase.ToCamelCase()}");

            Debug.WriteLine("\nstring.ToSnakeCase()");
            Debug.WriteLine($"({titleCase}) => {titleCase.ToSnakeCase()}");
            Debug.WriteLine($"({sentenceCase}) => {sentenceCase.ToSnakeCase()}");
            Debug.WriteLine($"({lowerCase}) => {lowerCase.ToSnakeCase()}");
            Debug.WriteLine($"({pascalCase}) => {pascalCase.ToSnakeCase()}");
            Debug.WriteLine($"({camelCase}) => {camelCase.ToSnakeCase()}");
            Debug.WriteLine($"({snakeCase}) => {snakeCase.ToSnakeCase()}");
            Debug.WriteLine($"({kebabCase}) => {kebabCase.ToSnakeCase()}");

            Debug.WriteLine("\nstring.ToKebabCase()");
            Debug.WriteLine($"({titleCase}) => {titleCase.ToKebabCase()}");
            Debug.WriteLine($"({sentenceCase}) => {sentenceCase.ToKebabCase()}");
            Debug.WriteLine($"({lowerCase}) => {lowerCase.ToKebabCase()}");
            Debug.WriteLine($"({pascalCase}) => {pascalCase.ToKebabCase()}");
            Debug.WriteLine($"({camelCase}) => {camelCase.ToKebabCase()}");
            Debug.WriteLine($"({snakeCase}) => {snakeCase.ToKebabCase()}");
            Debug.WriteLine($"({kebabCase}) => {kebabCase.ToKebabCase()}");

        }
    }
}

