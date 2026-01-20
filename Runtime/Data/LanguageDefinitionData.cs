using System.Collections.Generic;

namespace PandaTranslator.Runtime.Data
{
    [System.Serializable]
    public class LanguageDefinitionData
    {
        public List<LanguageCategoryDefinition> Categories = new List<LanguageCategoryDefinition>();
    }
}