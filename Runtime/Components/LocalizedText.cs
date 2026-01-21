using System;
using PandaTranslator.Runtime.Data;
using TMPro;
using UnityEngine;

namespace PandaTranslator.Runtime.Components
{
    [RequireComponent(typeof(TMP_Text))]
    public class LocalizedText : LocalizedComponent
    {
        private TMP_Text tmpText;
        private string[] formatingTexts;

        protected void Awake()
        {
            tmpText = GetComponent<TMP_Text>();
        }

        public void SetTextsToFormat(params string[] texts)
        {
            formatingTexts = texts;
            UpdateLang();
        }

        protected override void UpdateLang()
        {
            if (tmpText == null)
                tmpText = GetComponent<TMP_Text>();
            if (formatingTexts != null && formatingTexts.Length > 0)
            {
                tmpText.text = FormatText();
                return;
            }

            tmpText.text = languageItem.translation;
        }
        
        private string FormatText()
        {
            var text = "";
            try
            {
                text = string.Format(languageItem.translation, formatingTexts);
                return text;
            }
            catch (Exception e)
            {
                Debug.LogError("Error in formatting text: " + e.Message + " with text: " + languageItem.translation +
                               " and formating texts count: " + formatingTexts.Length);
            }

            return languageItem.translation;
        }
    }
}