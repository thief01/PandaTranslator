using System.Collections.Generic;
using PandaTranslator.Runtime.Data;
using UnityEngine;

namespace PandaTranslator.Runtime.Core
{
    public class LanguageSettings : ScriptableObject
    {
        public SystemLanguage DefaultLanguage = SystemLanguage.English;
        public LanguageDefinitionData LanguageDefinitionData;

        public List<Language> languages = new List<Language>();
    }
}