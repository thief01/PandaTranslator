using PandaTranslator.Runtime.Data;
using UnityEngine;

namespace PandaTranslator.Runtime.Components
{
    public abstract class LocalizedComponent : MonoBehaviour
    {
        public LanguageVariable LanguageVariable => languageVariable;

        [SerializeField] private LanguageVariable languageVariable;

        protected LanguageData languageItem;

        protected virtual void Awake()
        {
            RegisterEvents();
            UpdateLang();
        }

        private void OnDestroy()
        {
            UnRegisterEvents();
        }

        public void SetLanguageData(LanguageData languageData)
        {
            languageItem = languageData;
            UpdateLang();
        }

        public void SetLanguageVariable(LanguageVariable variable)
        {
            languageVariable = variable;
            UpdateLang();
        }

        protected abstract void UpdateLang();

        protected abstract LanguageTranslationType GetTranslationType();

        private void RegisterEvents()
        {
            // LanguageManager.LanguageChanged.AddListener(UpdateLanguageItem);
        }

        private void UnRegisterEvents()
        {
            // LanguageManager.LanguageChanged.RemoveListener(UpdateLanguageItem);
        }
    }
}