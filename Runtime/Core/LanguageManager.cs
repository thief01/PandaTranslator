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
        
        public ILanguage GetLanguage()
        {
            throw new NotImplementedException();
        }
        public static LanguageSettings GetLanguageSettings()
        {
            var languageSettings = Resources.Load<LanguageSettings>("Language Settings");
            return languageSettings;
        }

        public static LanguageSettings GetOrCreateLanguageSettings()
        {
            var languageSettings = GetLanguageSettings();

            if (languageSettings == null && Application.isEditor)
            {
                languageSettings = ScriptableObject.CreateInstance<LanguageSettings>();
                Directory.CreateDirectory("Assets/Resources/");
                AssetDatabase.CreateAsset(languageSettings, "Assets/Resources/Language Settings.asset");

            }
            else
            {
                throw new NullReferenceException("Language Settings not found");
            }

            FixLanguageSettings(languageSettings);
            return languageSettings;
        }

        private static void FixLanguageSettings(LanguageSettings languageSettings)
        {
#if UNITY_EDITOR
            var languages = Resources.LoadAll<Language>("Languages/");
            languageSettings.languages = languages.ToList();
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
#endif
        }


    }
}