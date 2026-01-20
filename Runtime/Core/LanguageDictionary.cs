using System.Collections.Generic;
using PandaTranslator.Runtime.Components;
using PandaTranslator.Runtime.Core.Interfaces;
using PandaTranslator.Runtime.Data;

namespace PandaTranslator.Runtime.Core
{
    public class LanguageDictionary : ILanguage
    {
        private readonly Dictionary<string, LanguageItem> items;
        private LanguageSettings languageSettings;
        private Language currentLanguage;
        
        public LanguageDictionary(LanguageSettings languageSettings)
        {
            items = new Dictionary<string, LanguageItem>();
            InitializeDictionary();
        }

        private void InitializeDictionary()
        {
            var categories = languageSettings.LanguageDefinitionData.Categories;
            foreach (var category in categories)
            {
                var keys = category.Keys;
                foreach (var key in keys)
                {
                    var languagePath = category.Name + "/" + key;
                    items.Add(languagePath, new LanguageItem());
                }
            }
        }

        public void ChangeLanguage(Language language)
        {
            currentLanguage = language;
            UpdateTranslations();
        }
        public LanguageItem GetLanguageItem(string category, string key)
        {
            return null;
        }

        public LanguageItem GetLanguageItem(int categoryId, int keyId)
        {
            return null;
        }

        public LanguageItem GetLanguageItem(LanguageVariable languageVariable)
        {
            return null;
        }

        public LanguageItem GetLanguageItem(string path)
        {
            return null;
        }


        private void UpdateTranslations()
        {
            foreach (var languageCategory in currentLanguage.languageCategories)
            {
                foreach (var languageItem in languageCategory.languageItems)
                {
                    var temp = GetLanguageItem(languageCategory.categoryName,  languageItem.key);
                    temp.UpdateFromLanguageData(languageItem);
                }
            }
        }
    }
}
