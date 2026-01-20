using System.Collections.Generic;

namespace PandaTranslator.Runtime.Data
{
    [System.Serializable]
    public class LanguageDefinitionData
    {
        public List<LanguageCategoryDefinition> Categories = new List<LanguageCategoryDefinition>();
    }

    [System.Serializable]
    public class LanguageCategoryDefinition
    {
        public string Name;
        public List<string> Keys;
    }
}