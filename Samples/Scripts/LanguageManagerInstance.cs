using PandaTranslator.Runtime.Core;
using UnityEngine;

namespace PandaTranslator.Samples.Scripts
{
    public static class LanguageManagerInstance
    {
        public static LanguageManager LanguageManager
        {
            get
            {
                if (languageManager == null)
                {
                    languageManager = new LanguageManager();
                }
                return languageManager;
            }
        }

        private static LanguageManager languageManager;
    }
}
