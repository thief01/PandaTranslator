using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace Ultimate_Translation.Items
{
    public class LanguageDefinitionData
    {
        public Dictionary<string, LanguageCategory> Categories = new Dictionary<string, LanguageCategory>();
    }

    public class LanguageCategoryData
    {
        public string Name;
        public List<string> Keys;
    }
}