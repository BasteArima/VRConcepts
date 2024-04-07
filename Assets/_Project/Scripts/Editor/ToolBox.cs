using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using VRConcepts.Runtime.Utilities;

namespace VRConcepts.Editor
{
    public class ToolBox
    {
        [MenuItem("Build Tools/Build Settings", priority = 200)]
        public static void OpenBuildSettings()
        {
            var settingsConfig = Resources.LoadAll<BuildSettings>("")[0];
            if (null == settingsConfig)
            {
                Debug.LogError($"{settingsConfig.name} can't be found!");
                return;
            }

            EditorUtility.OpenPropertyEditor(settingsConfig);
        }
        
        [MenuItem("Build Tools/Scenes/Bootstrap &1", priority = 201)]
        public static void OpenBootstrapScene()
        {
            EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
            EditorSceneManager.OpenScene("Assets/_Project/Scenes/0.Bootstrap.unity");
        }

        [MenuItem("Build Tools/Scenes/Loading &2", priority = 202)]
        public static void OpenLoadingScene()
        {
            EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
            EditorSceneManager.OpenScene("Assets/_Project/Scenes/1.Loading.unity");
        }
        
        [MenuItem("Build Tools/Scenes/Core &3", priority = 203)]
        public static void OpenCoreScene()
        {
            EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
            EditorSceneManager.OpenScene("Assets/_Project/Scenes/2.Core.unity");
        }
    }
}