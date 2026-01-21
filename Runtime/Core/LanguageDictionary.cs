using System.Collections.Generic;
using PandaTranslator.Runtime.Components;
using PandaTranslator.Runtime.Core.Interfaces;
using PandaTranslator.Runtime.Data;
using UnityEngine;

namespace PandaTranslator.Runtime.Core
{
    public class LanguageDictionary : ILanguage
    {
        
        private Dictionary<string, LanguageItem> items;
        private LanguageSettings languageSettings;
        private Language currentLanguage;

        private List<ILanguageComponent> languageComponentsQueue;

        public LanguageDictionary()
        {
            languageComponentsQueue = new List<ILanguageComponent>();
        }
        
        
        public void SetLanguageSettings(LanguageSettings languageSettings)
        {
            this.languageSettings = languageSettings;
            items = new Dictionary<string, LanguageItem>();
            InitializeDictionary();
        }

        public void SetLanguage(Language language)
        {
            currentLanguage = language;
            UpdateTranslations();
        }

        public void SetUpLanguageComponent(ILanguageComponent languageComponent)
        {
            var languageData = GetLanguageItem(languageComponent.GetLanguageVariable());
            languageComponent.SetLanguageData(languageData);
        }

        public LanguageItem GetLanguageItem(string category, string key)
        {
            var path = GetLanguagePath(category, key);
            return GetLanguageItem(path);
        }

        public LanguageItem GetLanguageItem(int categoryId, int keyId)
        {
            var path = GetLanguagePath(categoryId, keyId);
            return items[path];
        }

        public LanguageItem GetLanguageItem(LanguageVariable languageVariable)
        {
            var path = GetLanguagePath(languageVariable.Category, languageVariable.Key);
            return GetLanguageItem(path);
        }

        public LanguageItem GetLanguageItem(string path)
        {
            if (items.TryGetValue(path, out var item))
            {
                return item;
            }

            Debug.LogError($"LanguageDictionary.GetLanguageItem: {path} path not found");
            return null;
        }
        
        private void InitializeDictionary()
        {
            var categories = languageSettings.LanguageDefinitionData.Categories;
            foreach (var category in categories)
            {
                var keys = category.Keys;
                foreach (var key in keys)
                {
                    var languagePath = GetLanguagePath(category.Name, key);
                    items.Add(languagePath, new LanguageItem());
                }
            }
            
        }
        

        private string GetLanguagePath(int categoryId, int keyId)
        {
            var languageDefinitionData = languageSettings.LanguageDefinitionData;
            var category = languageDefinitionData.Categories[categoryId];
            var key = category.Keys[keyId];
            return GetLanguagePath(category.Name, key);
        }

        private string GetLanguagePath(string category, string key)
        {
            return category + "/" + key;
        }
        
        private void UpdateTranslations()
        {
            foreach (var languageCategory in currentLanguage.languageCategories)
            {
                foreach (var languageItem in languageCategory.languageItems)
                {
                    var temp = GetLanguageItem(languageCategory.categoryName, languageItem.key);
                    temp.UpdateFromLanguageData(languageItem);
                }
            }
        }
    }
}