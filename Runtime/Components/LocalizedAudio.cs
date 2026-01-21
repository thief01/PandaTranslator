using PandaTranslator.Runtime.Data;
using UnityEngine;

namespace PandaTranslator.Runtime.Components
{
    public class LocalizedAudio : LocalizedComponent
    {
        private AudioSource audioSource;

        protected override void Awake()
        {
            audioSource = GetComponent<AudioSource>();
            base.Awake();
        }

        protected override void UpdateLang()
        {
            if (audioSource == null)
                audioSource = GetComponent<AudioSource>();
            audioSource.clip = languageItem.audioClip;
        }
    }
}