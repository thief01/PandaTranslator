using PandaTranslator.Runtime.Components;
using PandaTranslator.Runtime.Data;

namespace PandaTranslator.Runtime.Core.Interfaces
{
    public interface ILanguageComponent
    {
         LanguageVariable GetLanguageVariable();

         void SetLanguageData(LanguageData languageData);
    }
}