using System;
using PandaTranslator.Runtime.Core;
using UnityEditor;
using UnityEngine;

namespace PandaTranslator.Editor.Tools
{
    public class NewLanguageWindow : EditorWindow
    {
        private SystemLanguage systemLanguage = SystemLanguage.English;
        private string languageName = "English";
        public static void OpenWindow()
        {
            NewLanguageWindow window = (NewLanguageWindow)GetWindow(typeof(NewLanguageWindow), true, "New Language");
            window.Show();
        }

        private void OnGUI()
        {
            systemLanguage = (SystemLanguage)EditorGUILayout.EnumPopup("Language", systemLanguage);
            languageName = EditorGUILayout.TextField("Language name", languageName);
            if (GUILayout.Button("Create"))
            {
                var languageSettings = LanguageSettings.LoadLanguageSettings();
                var languageHelper = new LanguageEditorHelper(languageSettings);
                languageHelper.AddNewLanguage(languageName, systemLanguage);
                Close();
            }

            if (GUILayout.Button("Cancel"))
            {
                Close();
            }
        }
    }
}