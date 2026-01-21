#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.Linq;
using PandaTranslator.Runtime.Core;
using PandaTranslator.Runtime.Data;
using UnityEditor;
using UnityEngine;

namespace PandaTranslator.Editor.Tools
{
    public partial class LanguageEditor : EditorWindow
    {
        [MenuItem("Mimi Games/Language Editor")]
        private static void OpenWindow()
        {
            LanguageEditor window = (LanguageEditor)GetWindow(typeof(LanguageEditor));
            window.Show();
        }

        private void OnValidate()
        {
            InitializeState();
        }

        private void OnEnable()
        {
            InitializeState();
        }

        private void OnGUI()
        {
            LanguageSelection();
            CategorySelection();
            AddingTranslation();

            scrollPosition = GUILayout.BeginScrollView(scrollPosition);
            DrawLangView();
            GUILayout.EndScrollView();

            EditorUtility.SetDirty(currentLanguage);
        }
        
        private void LanguageSelection()
        {
            GUILayout.BeginHorizontal();
            var langs = languageSettings.languages.Select(ctg => $"{ctg.name} ({ctg.language})").ToArray();
            var tempLang = EditorGUILayout.Popup(selectedLanguageIndex, langs);
            if (selectedLanguageIndex != tempLang)
            {
                selectedLanguageIndex = tempLang;
                selectedCategoryIndex = 0;
            }

            if (GUILayout.Button("Add language"))
            {
                NewLanguageWindow.OpenWindow();
            }

            GUILayout.EndHorizontal();
        }

        private void CategorySelection()
        {
            GUILayout.BeginHorizontal();
            var categories = languageSettings.LanguageDefinitionData.Categories.Select(category => category.Name).ToArray();
            var tempCategory = EditorGUILayout.Popup(selectedCategoryIndex, categories);
            if (selectedCategoryIndex != tempCategory)
            {
                selectedCategoryIndex = tempCategory;
            }

            newCategoryName = EditorGUILayout.TextField(newCategoryName);
            if (GUILayout.Button("Add category"))
            {
                errorMessage = "";
                var categoryDefinition = helper.AddNewCategory(newCategoryName);
                selectedCategoryIndex = helper.GetCategoryIndex(categoryDefinition);
            }

            if (currentLanguage.languageCategories.Count > 0 && GUILayout.Button("Remove category"))
            {
                errorMessage = "";
                helper.RemoveCategory(selectedCategoryIndex);
                selectedCategoryIndex = 0;
                return;
            }

            GUILayout.EndHorizontal();
        }

        private void AddingTranslation()
        {
            GUILayout.BeginHorizontal();

            newKeyName = EditorGUILayout.TextField(newKeyName);
            newTranslationContent = EditorGUILayout.TextField(newTranslationContent);
            if (GUILayout.Button("Add translation"))
            {
                errorMessage = "";

                if (!helper.AddNewKey(selectedCategoryIndex, newKeyName))
                {
                    errorMessage = "Translation already exists";
                }

                var categoryDefinition = helper.GetCategory(selectedCategoryIndex);
                var keyId = categoryDefinition.Keys.FindIndex(ctg => ctg == newKeyName);
                var languageItem = currentLanguage.GetLanguageItem(selectedCategoryIndex, keyId);
                languageItem.translation = newTranslationContent;
            }

            GUILayout.EndHorizontal();
        }

        private void DrawLangView()
        {
            if (!string.IsNullOrEmpty(errorMessage))
            {
                EditorGUILayout.HelpBox(errorMessage, MessageType.Error);
            }

            var categories = currentLanguage.languageCategories;
            if (categories.Count == 0)
            {
                errorMessage = "No categories found";
                return;
            }

            var translations = currentLanguage.languageCategories[selectedCategoryIndex].languageItems;
            translations = translations.OrderBy(ctg => ctg.key).ToList();

            foreach (var translation in translations)
            {
                DrawSingleTranslationLine(translation, "-", RemoveTranslation);
            }
        }

        private void DrawSingleTranslationLine(LanguageItem languageItem, string buttonActionText,
            Action<LanguageItem> onButtonClick)
        {
            GUILayout.BeginHorizontal();

            
            EditorGUILayout.LabelField(languageItem.key);
            GUILayoutOption[] options = { GUILayout.Width(150), GUILayout.Height(50) };
            languageItem.translation = EditorGUILayout.TextArea(languageItem.translation, options);
            languageItem.audioClip =
                (AudioClip)EditorGUILayout.ObjectField(languageItem.audioClip, typeof(AudioClip), false, options);
            languageItem.sprite =
                (Sprite)EditorGUILayout.ObjectField(languageItem.sprite, typeof(Sprite), false, options);
            if (GUILayout.Button(buttonActionText, GUILayout.Width(50), GUILayout.Height(50)))
            {
                errorMessage = "";
                onButtonClick.Invoke(languageItem);
            }

            GUILayout.EndHorizontal();
        }

        private void RemoveTranslation(LanguageItem languageItem)
        {
            var categoryName = helper.GetCategory(selectedCategoryIndex);
            helper.RemoveKey(categoryName.Name, languageItem.key);
        }
    }
}
#endif