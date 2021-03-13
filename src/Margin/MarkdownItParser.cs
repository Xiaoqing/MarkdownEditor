
namespace SpecFirst.MarkdownParser
{
    using System;
    using System.IO;
    using System.Reflection;
    using Jurassic;

    public class MarkdownItParser
    {
        public static string ParseMarkdownToHtml(string markdownText)
        {
            string html;
            try
            {
                var bundleFile = Path.Combine(GetFolder(), "margin\\bundle.js");
                var engine = new ScriptEngine();
                engine.SetGlobalValue("markdownTable", markdownText);
                engine.ExecuteFile(bundleFile);
                html = engine.GetGlobalValue("result").ToString();
            }
            catch (Exception e)
            {
                throw new InvalidOperationException($"Can not parse markdown text to HTML", e);
            }

            return html;
        }

        private static string GetFolder()
        {
            string assembly = Assembly.GetExecutingAssembly().Location;
            return Path.GetDirectoryName(assembly);
        }
    }
}
