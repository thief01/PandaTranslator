using PandaTranslator.Runtime.Data;
using UnityEngine;

namespace PandaTranslator.Runtime.Components
{
    public class LocalizedAudio : LocalizedComponent
    {
        private AudioSource audioSource;

        protected void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        protected override void UpdateLang()
        {
            if (audioSource == null)
                audioSource = GetComponent<AudioSource>();
            audioSource.clip = languageItem.audioClip;
        }
    }
}