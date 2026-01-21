using System.Runtime.CompilerServices;
using PandaTranslator.Runtime.Core;
using PandaTranslator.Runtime.Data;

namespace PandaTranslator.Editor.Tools
{
    public class LanguageEditorHelper
    {
        private LanguageSettings languageSettings;
        public LanguageEditorHelper(LanguageSettings languageSettings)
        {
            this.languageSettings = languageSettings;
        }

        public void AddNewLanguage(string name)
        {
            
        }

        public void RemoveLanguage(string name)
        {
            
        }

        public LanguageCategoryDefinition AddNewCategory(string name)
        {
            var categoryDefinition = GetCategory(name);
            if (categoryDefinition != null)
            {
                return categoryDefinition;
            }
            var newCategory = new LanguageCategoryDefinition()
            {
                Name = name
            };
            languageSettings.LanguageDefinitionData.Categories.Add(newCategory);
            AddCategoryToAllLanguages(name);
            return newCategory;
        }

        public bool AddNewKey(int category, string key)
        {
            var categoryDefinition = languageSettings.LanguageDefinitionData.Categories[category];
            if (categoryDefinition.Keys.Contains(key))
            {
                return false;
            }
            categoryDefinition.Keys.Add(key);
            AddKeyToAllLanguages(categoryDefinition.Name, key);
            return true;
        }

        public bool AddNewKey(string category, string key)
        {
            var categoryDefinition = GetCategory(category);
            if (categoryDefinition == null)
            {
                categoryDefinition = AddNewCategory(category);
            }

            if (categoryDefinition.Keys.Contains(key))
            {
                return false;
            }
            categoryDefinition.Keys.Add(key);
            AddKeyToAllLanguages(category, key);
            return true;
        }

        public bool RemoveCategory(string name)
        {
            var categoryDefinition = GetCategory(name);
            RemoveCategoryFromAllLanguages(name);
            return languageSettings.LanguageDefinitionData.Categories.Remove(categoryDefinition);
        }

        public bool RemoveCategory(int index)
        {
            var categoryDefinition = GetCategory(index);
            RemoveCategoryFromAllLanguages(categoryDefinition.Name);
            return languageSettings.LanguageDefinitionData.Categories.Remove(categoryDefinition);
        }

        public bool RemoveKey(string category, string key)
        {
            var categoryDefinition = GetCategory(category);
            if (categoryDefinition == null)
            {
                return false;
            }

            RemoveKeyFromAllLanguages(category, key);
            return categoryDefinition.Keys.Remove(key);
        }

        public bool RemoveKey(int categoryId, string key)
        {
            var categoryDefinition = languageSettings.LanguageDefinitionData.Categories[categoryId];
            if (categoryDefinition.Keys.Contains(key))
            {
                return false;
            }
            categoryDefinition.Keys.Add(key);
            RemoveKeyFromAllLanguages(categoryDefinition.Name, key);
            return true;
        }

        public int GetCategoryIndex(LanguageCategoryDefinition categoryDefinition)
        {
            return  languageSettings.LanguageDefinitionData.Categories.IndexOf(categoryDefinition);
        }

        public LanguageCategoryDefinition GetCategory(string name)
        {
            return languageSettings.LanguageDefinitionData.Categories.Find(ctg => ctg.Name == name);
        }

        public LanguageCategoryDefinition GetCategory(int category)
        {
            return languageSettings.LanguageDefinitionData.Categories[category];
        }

        private void AddCategoryToAllLanguages(string name)
        {
            var languages = languageSettings.languages;

            for (int i = 0; i < languages.Count; i++)
            {
                var newCategory = new LanguageCategory()
                {
                    categoryName = name
                };
                languages[i].languageCategories.Add(newCategory);
            }
        }

        private void AddKeyToAllLanguages(string category, string key)
        {
            var languages = languageSettings.languages;

            for (int i = 0; i < languages.Count; i++)
            {
                var languageCategory =  languages[i].languageCategories.Find(ctg => ctg.categoryName == category);
                languageCategory.AddLanguageItem(key, "");
            }
        }

        private void RemoveCategoryFromAllLanguages(string category)
        {
            var languages = languageSettings.languages;

            for (int i = 0; i < languages.Count; i++)
            {
                var languageCategory = languages[i].languageCategories.Find(ctg => ctg.categoryName == category);
                languages[i].languageCategories.Remove(languageCategory);
            }
        }

        private void RemoveKeyFromAllLanguages(string category, string key)
        {
            var languages = languageSettings.languages;

            for (int i = 0; i < languages.Count; i++)
            {
                var languageCategory =  languages[i].languageCategories.Find(ctg => ctg.categoryName == category);
                languageCategory.RemoveLanguageItem(key);                
            }
        }
    }
}