using System;
using System.IO;
using System.Linq;
using PandaTranslator.Runtime.Core.Interfaces;
using PandaTranslator.Runtime.Data;
using UnityEditor;
using UnityEngine;

namespace PandaTranslator.Runtime.Core
{
    public class LanguageManager : ILanguageManager
    {
        private LanguageDictionary languageDictionary;
        
        public ILanguage GetLanguage()
        {
            return languageDictionary;
        }
        
        public LanguageSettings GetLanguageSettings()
        {
            var languageSettings = Resources.Load<LanguageSettings>("Language Settings");
            return languageSettings;
        }
#if UNITY_EDITOR
        public static LanguageSettings LazyLoadLanguageSettings()
        {
            var languageSettings = Resources.Load<LanguageSettings>("Language Settings");
            return languageSettings;
        }
        public LanguageSettings GetOrCreateLanguageSettings()
        {
            var languageSettings = GetLanguageSettings();

            if (languageSettings == null)
            {
                languageSettings = ScriptableObject.CreateInstance<LanguageSettings>();
                Directory.CreateDirectory("Assets/Resources/");
                AssetDatabase.CreateAsset(languageSettings, "Assets/Resources/Language Settings.asset");
            }

            FixLanguageSettings(languageSettings);
            return languageSettings;
        }

        private static void FixLanguageSettings(LanguageSettings languageSettings)
        {

            var languages = Resources.LoadAll<Language>("Languages/");
            languageSettings.languages = languages.ToList();
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
#endif
    }
}