using PandaTranslator.Runtime.Data;
using UnityEngine;
using UnityEngine.UI;

namespace PandaTranslator.Runtime.Components
{
    [RequireComponent(typeof(Image))]
    public class LocalizedImage : LocalizedComponent
    {
        [SerializeField] private bool setNativeSize = true;
        private Image image;

        protected override void Awake()
        {
            image = GetComponent<Image>();
            base.Awake();
        }

        protected override void UpdateLang()
        {
            if (image == null)
                image = GetComponent<Image>();
            image.sprite = languageItem.sprite;
            if (setNativeSize)
                image.SetNativeSize();
        }
    }
}
