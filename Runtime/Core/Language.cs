using System;
using System.Collections.Generic;
using System.Linq;
using PandaTranslator.Runtime.Components;
using PandaTranslator.Runtime.Core.Interfaces;
using PandaTranslator.Runtime.Data;
using UnityEngine;

namespace PandaTranslator.Runtime.Core
{
    public class Language : ScriptableObject, ILanguage
    {
        public SystemLanguage language;
        public List<LanguageCategory> languageCategories;

        public bool AddCategory(LanguageCategory languageCategory)
        {
            if (languageCategories.Exists(ctg => ctg.categoryName == languageCategory.categoryName))
                return false;
            languageCategories.Add(languageCategory);
            return true;
        }

        public bool AddCategory(string categoryName)
        {
            if (languageCategories.Exists(ctg => ctg.categoryName == categoryName))
                return false;
            languageCategories.Add(new LanguageCategory()
            {
                categoryName = categoryName,
            });

            return true;
        }
        
        public LanguageItem GetLanguageItem(string category, string key)
        {
            return languageCategories.First(cat => cat.categoryName == category)
                .languageItems.First(ctg => ctg.key == key);
        }

        public LanguageItem GetLanguageItem(string path)
        {
            var splitedPath = path.Split('/');
            if (splitedPath.Length < 2)
            {
                throw new ArgumentException("Invalid path: " + path);
            }
            var category = splitedPath.First();
            var key = splitedPath.Last();
            return languageCategories.First(cat => cat.categoryName == category)
                .languageItems.First(ctg => ctg.key == key);
        }

        public LanguageItem GetLanguageItem(int categoryId, int keyId)
        {
            return languageCategories[categoryId].languageItems[keyId];
        }

        public LanguageItem GetLanguageItem(LanguageVariable languageVariable)
        {
            return languageCategories[languageVariable.Category].languageItems[languageVariable.Key];
        }
    }
}