using System.Collections.Generic;

namespace PandaTranslator.Runtime.Data
{
    public class LanguageDefinitionData
    {
        public Dictionary<string, LanguageCategory> Categories = new Dictionary<string, LanguageCategory>();
    }

    public class LanguageCategoryData
    {
        public string Name;
        public List<string> Keys;
    }
}