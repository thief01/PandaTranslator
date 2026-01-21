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
    public class LanguageManager : ILanguageManager, ILanguage
    {
        public LanguageDictionary LanguageDictionary { get; private set; }
        public LanguageSettings LanguageSettings { get; private set; }

        public LanguageManager()
        {
            LanguageSettings = LanguageSettings.LoadLanguageSettings();
            LanguageDictionary = new LanguageDictionary(LanguageSettings);
        }
        
        public ILanguage GetLanguage()
        {
            return LanguageDictionary;
        }
        
        public LanguageItem GetLanguageItem(string category, string key)
        {
            return LanguageDictionary.GetLanguageItem(category, key);
        }

        public LanguageItem GetLanguageItem(string path)
        {
            return LanguageDictionary.GetLanguageItem(path);
        }

        public LanguageItem GetLanguageItem(int categoryId, int keyId)
        {
            return LanguageDictionary.GetLanguageItem(categoryId, keyId);
        }

        public LanguageItem GetLanguageItem(LanguageVariable languageVariable)
        {
            return LanguageDictionary.GetLanguageItem(languageVariable);
        }

        public void SetLanguage(SystemLanguage language)
        {
            var newLanguage = LanguageSettings.languages.Find(ctg => ctg.language == language);
            if (newLanguage == null)
            {
                Debug.LogError("Could not find language " + language);
                return;
            }
            LanguageDictionary.ChangeLanguage(newLanguage);
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