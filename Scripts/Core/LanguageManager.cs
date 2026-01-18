using System;
using System.IO;
using Ultimate_Translation.Items;
using UnityEditor;
using UnityEngine;

namespace Unity_Translate.Core
{
    public class LanguageManager
    {
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
            
            return languageSettings;
        }
    }
}