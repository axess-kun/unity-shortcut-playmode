using UnityEditor;
using UnityEngine;

namespace Axess.EditorApp.EnterPlayMode
{
    [CreateAssetMenu(fileName = nameof(EnterPlayModeSettings), menuName = "Editor Extend/Enter Play Mode Settings")]
    internal class EnterPlayModeSettings : ScriptableObject
    {
        public const string ExpectedFilePath = "Assets/Editor/EnterPlayModeSettings.asset";

        [SerializeField] private SceneAsset scene;
        public SceneAsset Scene => scene;
    }

    [CustomEditor(typeof(EnterPlayModeSettings))]
    internal class EnterPlayModeSettingsEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            // Check path
            var path = AssetDatabase.GetAssetPath(target);
            if (path != EnterPlayModeSettings.ExpectedFilePath)
            {
                EditorGUILayout.HelpBox($"This asset MUST located at {EnterPlayModeSettings.ExpectedFilePath}",
                    MessageType.Error);
            }

            base.OnInspectorGUI();
        }
    }
}
