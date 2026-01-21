using PandaTranslator.Runtime.Core.Interfaces;
using PandaTranslator.Runtime.Data;
using UnityEngine;

namespace PandaTranslator.Runtime.Components
{
    public abstract class LocalizedComponent : MonoBehaviour, ILanguageComponent
    {
        [SerializeField] private LanguageVariable languageVariable;

        protected LanguageData languageItem;
        
        private void OnDestroy()
        {
            UnRegisterEvents();
        }

        public LanguageVariable GetLanguageVariable()
        {
            return languageVariable;
        }

        public void SetLanguageData(LanguageData languageData)
        {
            UnRegisterEvents();
            if (languageData == null)
            {
                Debug.LogWarning("LanguageData is null");
                return;
            }
            languageItem = languageData;
            UpdateLang();
            RegisterEvents();
        }

        protected abstract void UpdateLang();
        
        private void RegisterEvents()
        {
            if (languageItem == null)
            {
                Debug.LogWarning("LanguageData is null");
                return;
            }
            languageItem.OnLanguageDataChanged.AddListener(UpdateLang);
        }

        private void UnRegisterEvents()
        {
            if (languageItem == null)
            {
                Debug.LogWarning("LanguageData is null");
                return;
            }
            languageItem.OnLanguageDataChanged.RemoveListener(UpdateLang);
        }
    }
}