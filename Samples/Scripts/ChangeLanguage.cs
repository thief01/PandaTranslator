using UnityEngine;

namespace PandaTranslator.Samples.Scripts
{
    public class ChangeLanguage : MonoBehaviour
    {
        public void SwapLanguage(SystemLanguage systemLanguage)
        {
            LanguageManagerInstance.LanguageManager.SetLanguage(systemLanguage);
        }
    }
}
