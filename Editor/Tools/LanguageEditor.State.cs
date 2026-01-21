using System.Collections.Generic;
using PandaTranslator.Runtime.Core;
using UnityEditor;
using UnityEngine;

namespace PandaTranslator.Editor.Tools
{
    public partial class LanguageEditor
    {
        private const string DEFAULT_NEW_CATEGORY = "New Category";
        private const string DEFAULT_NEW_KEY = "New Key";
        private const string DEFAULT_NEW_TRANSLATION = "New translation";

        private LanguageSettings languageSettings;
        private List<Language> languages => languageSettings.languages;
        private Language currentLanguage => languageSettings.languages[selectedLanguageIndex];

        private int selectedLanguageIndex;
        private int selectedCategoryIndex;
        private int previousLanguageCount;
        private Vector2 scrollPosition;
        private string newCategoryName = DEFAULT_NEW_CATEGORY;
        private string newKeyName = DEFAULT_NEW_KEY;
        private string newTranslationContent = DEFAULT_NEW_TRANSLATION;

        private string errorMessage = "";
        private LanguageEditorHelper helper;
        
        private void SetError(string error) => errorMessage = error;
        private void ClearError() => errorMessage = "";
        
        private void InitializeState()
        {
            AssetDatabase.Refresh();
            languageSettings = LanguageSettings.LoadLanguageSettings();
            helper = new LanguageEditorHelper(languageSettings);
        }
        
        private void ShowError()
        {
            if (!string.IsNullOrEmpty(errorMessage))
            {
                EditorGUILayout.HelpBox(errorMessage, MessageType.Error);
            }
        }
    }
}