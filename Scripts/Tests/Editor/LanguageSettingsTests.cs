using System.Collections;
using NUnit.Framework;
using Ultimate_Translation.Items;
using Unity_Translate.Core;
using UnityEngine;
using UnityEngine.TestTools;

namespace Unity_Translate.Scripts.Tests.Editor
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
            var languageSettings = LanguageManager.GetLanguageSettings();
            Assert.IsNotNull(languageSettings);
            
            Assert.IsNotNull(languageSettings.languages);
            Assert.IsNotEmpty(languageSettings.languages);
        }
    }
}
