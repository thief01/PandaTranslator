using UnityEngine;

namespace PandaTranslator.Runtime.Components
{
    [System.Serializable]
    public class LanguageVariable
    {
        public SystemLanguage PreviewLanguage;
        public int Category;
        public int Key;
        public string CategoryName;
        public string KeyName;
    }
}
