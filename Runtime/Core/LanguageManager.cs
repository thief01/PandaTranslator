using System;
using System.IO;
using System.Linq;
using PandaTranslator.Runtime.Components;
using PandaTranslator.Runtime.Core.Interfaces;
using PandaTranslator.Runtime.Data;
using UnityEditor;
using UnityEngine;

namespace PandaTranslator.Runtime.Core
{
    public class LanguageManager : ILanguageManager
    {
        public ILanguage LanguageDictionary { get; private set; }
        public LanguageSettings LanguageSettings { get; private set; }

        public LanguageManager(ILanguage language)
        {
            LanguageSettings = LanguageSettings.LoadLanguageSettings();
            language.SetLanguageSettings(LanguageSettings);
            LanguageDictionary = language;
        }
        
        public ILanguage GetLanguage()
        {
            return LanguageDictionary;
        }

        public void SetLanguage(SystemLanguage language)
        {
            var newLanguage = LanguageSettings.languages.Find(ctg => ctg.language == language);
            if (newLanguage == null)
            {
                Debug.LogError("Could not find language " + language);
                return;
            }
            LanguageDictionary.SetLanguage(newLanguage);
        }
        
#if UNITY_EDITOR
        public LanguageSettings GetOrCreateLanguageSettings()
        {
            var languageSettings = LanguageSettings.LoadLanguageSettings();

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