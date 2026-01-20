using UnityEngine;

namespace PandaTranslator.Runtime.Utils
{
    public class LanguageChanger : MonoBehaviour
    {
        [SerializeField] private SystemLanguage language;
        // private LanguageManager languageManager;
        private void Awake()
        {
            // languageManager = LanguageManager.Instance;
        }

        public void UseLanguage()
        {
            // languageManager.SetLanguage(language);
        }
    }
}
