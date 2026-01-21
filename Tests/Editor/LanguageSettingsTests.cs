using NUnit.Framework;
using PandaTranslator.Runtime.Core;
using PandaTranslator.Runtime.Data;
using UnityEngine;

namespace PandaTranslator.Tests.Editor
{
    public class LanguageSettingsTests
    {
        [Test]
        public void ExistLanguageSettingsTest()
        {
            var languageSettings = Resources.Load<LanguageSettings>("Language Settings");
            Assert.IsNotNull(languageSettings);
        }
        
        [Test]
        public void HasLanguagesTest()
        {
            var languageManager = new LanguageManager();
            var languageSettings = LanguageSettings.LoadLanguageSettings();
            Assert.IsNotNull(languageSettings);
            
            Assert.IsNotNull(languageSettings.languages);
            Assert.IsNotEmpty(languageSettings.languages);
        }
    }
}
