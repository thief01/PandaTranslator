using System.Linq;
using PandaTranslator.Runtime.Components;
using PandaTranslator.Runtime.Core;
using UnityEditor;
using UnityEngine;

namespace PandaTranslator.Editor.Drawers
{
    [CustomPropertyDrawer(typeof(LanguageVariable))]
    public class LanguageVariablePropertyDrawer : PropertyDrawer
    {
        private readonly GUIStyle style = new GUIStyle()
        {
            alignment = TextAnchor.MiddleCenter,
            fontStyle = FontStyle.Bold,
            normal = new GUIStyleState()
            {
                textColor = Color.red
            }
        };

        private string[] languages;
        private string[] categories;
        private string[] keys;
        private double lastUpdateTimeLanguages;
        private double lastUpdateTimeCategories;
        private double lastUpdateTimeKeys;
        private int selectedLanguage;
        private int selectedCategory;
        private int selectedKey;
        private bool shouldUpdateKeys;
        
        private LanguageSettings languageSettings;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            position.height = EditorGUIUtility.singleLineHeight;
            if (languageSettings == null)
                languageSettings = LanguageSettings.LoadLanguageSettings();

            UpdateLanguagesCache();
            UpdateCategoriesCache();
            UpdateKeysCache();
            DrawLanguages(position, property);
            if (!DrawCategories(position, property))
                return;
            DrawKeys(position, property);
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            if (categories == null)
            {
                return EditorGUIUtility.singleLineHeight * 2;
            }

            if (categories.Length == 0)
            {
                return EditorGUIUtility.singleLineHeight * 2;
            }

            return EditorGUIUtility.singleLineHeight * 3;
        }

        private void DrawLanguages(Rect position, SerializedProperty property)
        {
            var languageProperty = property.FindPropertyRelative("PreviewLanguage");
            selectedLanguage =EditorGUI.Popup(position, languageProperty.intValue, languages);
            languageProperty.intValue = selectedLanguage;
        }

        private bool DrawCategories(Rect position, SerializedProperty property)
        {
            position.y += EditorGUIUtility.singleLineHeight;
            if (categories == null)
            {
                EditorGUI.LabelField(position, "Not found language", style);
                return false;
            }

            if (categories.Length == 0)
            {
                EditorGUI.LabelField(position, "Not found categories", style);
                return false;
            }

            var categoryProperty = property.FindPropertyRelative("Category");

            var categoryValue = EditorGUI.Popup(position, categoryProperty.intValue, categories);
            categoryProperty.intValue = categoryValue;
            if (categoryValue != selectedCategory)
            {
                selectedCategory = categoryProperty.intValue;
                shouldUpdateKeys = true;
            }

            return true;
        }

        private bool DrawKeys(Rect position, SerializedProperty property)
        {
            position.y += EditorGUIUtility.singleLineHeight * 2;
            if (keys == null || keys.Length == 0)
            {
                EditorGUI.LabelField(position, "Not found keys", style);
                return false;
            }

            var keyProperty = property.FindPropertyRelative("Key");

            keyProperty.intValue = EditorGUI.Popup(position, keyProperty.intValue, keys);
            return true;
        }

        private void UpdateLanguagesCache()
        {
            var shouldUpdate = (EditorApplication.timeSinceStartup - lastUpdateTimeLanguages > 5);
            if (categories == null || categories.Length == 0)
            {
                shouldUpdate = true;
            }

            if (!shouldUpdate)
                return;
            languages = languageSettings.languages.Select(ctg => ctg.language.ToString())
                .ToArray();
            lastUpdateTimeLanguages = EditorApplication.timeSinceStartup;
        }

        private void UpdateCategoriesCache()
        {
            var shouldUpdate = (EditorApplication.timeSinceStartup - lastUpdateTimeCategories > 5);
            if (categories == null || categories.Length == 0)
            {
                shouldUpdate = true;
            }

            if (!shouldUpdate)
                return;
            categories = languageSettings.LanguageDefinitionData.Categories.Select(cat => cat.Name).ToArray();
            lastUpdateTimeCategories = EditorApplication.timeSinceStartup;
        }

        private void UpdateKeysCache()
        {
            var shouldUpdate = (EditorApplication.timeSinceStartup - lastUpdateTimeKeys > 5);
            if (keys == null || keys.Length == 0)
            {
                shouldUpdate = true;
            }

            if (!shouldUpdate && !shouldUpdateKeys)
                return;

            keys = languageSettings.LanguageDefinitionData.Categories[selectedCategory].Keys.ToArray();
            lastUpdateTimeKeys = EditorApplication.timeSinceStartup;
        }
    }
}