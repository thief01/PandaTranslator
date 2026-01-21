using UnityEngine;

namespace PandaTranslator.Samples.Scripts
{
    public class ChangeLanguage : MonoBehaviour
    {
        [SerializeField] private SystemLanguage language;
        public void SwapLanguage()
        {
            LanguageManagerInstance.LanguageManager.SetLanguage(language);
        }
    }
}
