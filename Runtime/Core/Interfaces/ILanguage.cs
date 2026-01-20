using PandaTranslator.Runtime.Components;
using PandaTranslator.Runtime.Data;

namespace PandaTranslator.Runtime.Core.Interfaces
{
    public interface ILanguage
    {
        public LanguageItem GetLanguageItem(string category, string key);

        public LanguageItem GetLanguageItem(string path);

        public LanguageItem GetLanguageItem(int categoryId, int keyId);
        public LanguageItem GetLanguageItem(LanguageVariable languageVariable);
    }
}
