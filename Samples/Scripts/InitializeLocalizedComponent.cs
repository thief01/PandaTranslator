using System;
using PandaTranslator.Runtime.Components;
using UnityEngine;

namespace PandaTranslator.Samples.Scripts
{
    [RequireComponent(typeof(LocalizedComponent))]
    public class InitializeLocalizedComponent : MonoBehaviour
    {
        private void Awake()
        {
            var localizedComponent = GetComponent<LocalizedComponent>();
            var languageVariable = localizedComponent.LanguageVariable;
            var languageItem = LanguageManagerInstance.LanguageManager.GetLanguageItem(languageVariable);
            localizedComponent.SetLanguageData(languageItem);
        }
    }
}
