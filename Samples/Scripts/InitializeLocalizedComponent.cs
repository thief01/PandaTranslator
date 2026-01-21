using System;
using PandaTranslator.Runtime.Components;
using PandaTranslator.Runtime.Core.Interfaces;
using UnityEngine;

namespace PandaTranslator.Samples.Scripts
{
    [RequireComponent(typeof(LocalizedComponent))]
    public class InitializeLocalizedComponent : MonoBehaviour
    {
        private void Awake()
        {
            var localizedComponent = GetComponent<ILanguageComponent>();
            var language = LanguageManagerInstance.LanguageManager.GetLanguage();
            language.SetUpLanguageComponent(localizedComponent);
        }
    }
}
