using PandaTranslator.Runtime.Components;
using PandaTranslator.Runtime.Data;

namespace PandaTranslator.Runtime.Core.Interfaces
{
    public interface ILanguage
    {
        void SetLanguageSettings(LanguageSettings languageSettings);
        public void SetLanguage(Language language);

        void SetUpLanguageComponent(ILanguageComponent languageComponent);
        public LanguageItem GetLanguageItem(string category, string key);

        public LanguageItem GetLanguageItem(string path);

        public LanguageItem GetLanguageItem(int categoryId, int keyId);
        public LanguageItem GetLanguageItem(LanguageVariable languageVariable);
    }
}
