using UnityEditor;
using UnityEditor.SceneManagement;

namespace Axess.EditorApp.EnterPlayMode
{
    internal static class EnterPlayModeExecutor
    {
        [InitializeOnLoadMethod]
        private static void Initialize()
        {
            EditorApplication.playModeStateChanged -= OnPlayModeStateChanged;
            EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
        }

        private static void OnPlayModeStateChanged(PlayModeStateChange mode)
        {
            if (mode == PlayModeStateChange.EnteredPlayMode)
            {
                EditorSceneManager.playModeStartScene = null;
                EditorApplication.playModeStateChanged -= OnPlayModeStateChanged;
            }
        }

        // NOTE: Unity default "Edit/Play" priority is around 180
        [MenuItem("Edit/Play (Custom) _F5", priority = 179)]
        private static void EnterPlayMode()
        {
            if (EditorApplication.isPlayingOrWillChangePlaymode)
            {
                return;
            }

            SceneAsset sceneAsset = null;

            // Search settings file
            // NOTE: AssetDatabase.FindAssets() take too much time when using in very very very large project
            var settings = AssetDatabase.LoadAssetAtPath<EnterPlayModeSettings>(EnterPlayModeSettings.ExpectedFilePath);
            if (settings != null)
            {
                sceneAsset = settings.Scene;
            }

            // Not set / no settings, try load SampleScene
            if (sceneAsset == null)
            {
                sceneAsset = AssetDatabase.LoadAssetAtPath<SceneAsset>("Assets/Scenes/SampleScene.unity");
            }

            // Still nothing found
            if (sceneAsset == null)
            {
                return;
            }

            // Enter play mode
            // NOTE: Play `sceneAsset`, then back to current (editing) scene when back to Edit Mode
            EditorSceneManager.playModeStartScene = sceneAsset;
            EditorApplication.EnterPlaymode();
        }
    }
}
