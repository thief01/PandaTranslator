using PandaTranslator.Editor.Tools;
using PandaTranslator.Runtime.Core;
using PandaTranslator.Runtime.Data;
using UnityEditor;
using UnityEngine;

namespace PandaTranslator.Editor.Inspectors
{
    [CustomEditor(typeof(LanguageSettings))]
    public class LanguageSettingsEditor : UnityEditor.Editor
    {
        protected override void OnHeaderGUI()
        {
            base.OnHeaderGUI();
            if (GUILayout.Button("Open Language Editor"))
            {
                LanguageEditor window = (LanguageEditor)EditorWindow.GetWindow(typeof(LanguageEditor));
            }
        }
    }
}
