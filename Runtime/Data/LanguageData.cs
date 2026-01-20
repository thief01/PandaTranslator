using UnityEngine;
using UnityEngine.Events;

namespace PandaTranslator.Runtime.Data
{
    public class LanguageData
    {
        public UnityEvent OnLanguageDataChanged;
        public string translation;
        public Sprite sprite;
        public AudioClip audioClip;

        public void UpdateFromLanguageData(LanguageData languageData)
        {
            translation = languageData.translation;
            sprite = languageData.sprite;
            audioClip = languageData.audioClip;
            OnLanguageDataChanged.Invoke();
        }

        public bool CheckType(LanguageTranslationType type)
        {
            switch (type)
            {
                case LanguageTranslationType.Text:
                    return !string.IsNullOrEmpty(translation);
                case LanguageTranslationType.Image:
                    return sprite != null;
                case LanguageTranslationType.Audio:
                    return audioClip != null;
                default:
                    return false;
            }
        }
    }
}