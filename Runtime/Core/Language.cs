using System;
using System.Collections.Generic;
using System.Linq;
using PandaTranslator.Runtime.Components;
using PandaTranslator.Runtime.Core.Interfaces;
using PandaTranslator.Runtime.Data;
using UnityEngine;

namespace PandaTranslator.Runtime.Core
{
    public class Language : ScriptableObject
    {
        public SystemLanguage language;
        public List<LanguageCategory> languageCategories = new List<LanguageCategory>();
        
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