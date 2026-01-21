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
        private LanguageDictionary languageDictionary;
        private LanguageSettings languageSettings;

        public LanguageManager()
        {
            languageSettings = GetLanguageSettings();
            languageDictionary = new LanguageDictionary(languageSettings);
        }
        
        public ILanguage GetLanguage()
        {
            return languageDictionary;
        }
        
        public LanguageItem GetLanguageItem(string category, string key)
        {
            return languageDictionary.GetLanguageItem(category, key);
        }

        public LanguageItem GetLanguageItem(string path)
        {
            return languageDictionary.GetLanguageItem(path);
        }

        public LanguageItem GetLanguageItem(int categoryId, int keyId)
        {
            return languageDictionary.GetLanguageItem(categoryId, keyId);
        }

        public LanguageItem GetLanguageItem(LanguageVariable languageVariable)
        {
            return languageDictionary.GetLanguageItem(languageVariable);
        }

        public void SetLanguage(SystemLanguage language)
        {
            SystemLanguage.
            var newLanguage = languageSettings.languages.Find(ctg => ctg.language == language);
            if (newLanguage == null)
            {
                Debug.LogError("Could not find language " + language);
                return;
            }
            languageDictionary.ChangeLanguage(newLanguage);
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