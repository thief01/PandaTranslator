using PandaTranslator.Runtime.Data;
using PandaTranslator.Runtime.Translations;

namespace PandaTranslator.Runtime
{
    public static class LanguageManagerExtensions
    {
        public static void SetLanguageVariable(this LanguageVariable localizedComponent, LanguageTranslationType type)
        {
            LanguageManager.Instance.GetTranslation(localizedComponent, type);
        }
    }
}