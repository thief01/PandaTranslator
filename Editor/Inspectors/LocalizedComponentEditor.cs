using System.Collections.Generic;
using PandaTranslator.Runtime.Components;
using PandaTranslator.Runtime.Core;
using UnityEditor;
using UnityEngine;

namespace PandaTranslator.Editor.Inspectors
{
    [CustomEditor(typeof(LocalizedComponent), true)]
    public class LocalizedComponentEditor : UnityEditor.Editor
    {
        private LocalizedComponent localizedComponent;
        private List<Language> languages;
        private LanguageVariable languageVariable;

        private void OnEnable()
        {
            localizedComponent = (LocalizedComponent)target;
            languageVariable = localizedComponent.LanguageVariable;
            var languageSettings = LanguageManager.LazyLoadLanguageSettings();
            if (languageSettings == null)
                return;
            languages = languageSettings.languages;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (languages == null || languages.Count == 0)
            {
                GUILayout.Label("No languages found");
                return;
            }

            if (GUILayout.Button("Test lang"))
            {
                var lang = languages[languageVariable.PreviewLanguage];
                var langItem = lang.GetLanguageItem(languageVariable);
                localizedComponent.SetLanguageData(langItem);
            }
        }
    }
}