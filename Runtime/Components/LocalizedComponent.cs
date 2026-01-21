using PandaTranslator.Runtime.Data;
using UnityEngine;

namespace PandaTranslator.Runtime.Components
{
    public abstract class LocalizedComponent : MonoBehaviour
    {
        public LanguageVariable LanguageVariable => languageVariable;

        [SerializeField] private LanguageVariable languageVariable;

        protected LanguageData languageItem;
        
        private void OnDestroy()
        {
            UnRegisterEvents();
        }

        public void SetLanguageData(LanguageData languageData)
        {
            languageItem = languageData;
            UpdateLang();
            RegisterEvents();
        }

        protected abstract void UpdateLang();
        
        private void RegisterEvents()
        {
            languageItem.OnLanguageDataChanged.AddListener(UpdateLang);
        }

        private void UnRegisterEvents()
        {
            languageItem.OnLanguageDataChanged.RemoveListener(UpdateLang);
        }
    }
}