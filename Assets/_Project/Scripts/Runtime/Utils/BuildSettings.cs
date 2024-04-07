#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

[CreateAssetMenu(fileName = "BuildSettings", menuName = "Data/BuildSettings")]
public class BuildSettings : ScriptableObject
{
    public enum BuildPlatforms
    {
        None,
        PC,
        Meta,
        Steam
    }

    [Header("Platform")]
    public BuildPlatforms Platform = BuildPlatforms.PC;

    [Header("Common")] 
    public bool PlayerSittingMode; // [TODO] Перенести в настройки, если будут
    public bool IsBuildWithCheats = true;

    private static BuildSettings _instance;

    public static BuildSettings Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = Resources.Load<BuildSettings>("BuildSettings");
            }

            return _instance;
        }
    }

#if UNITY_EDITOR
    [MenuItem("Build Tools/Build Settings")]
    public static void OpenBuildSettings()
    {
        BuildSettings settingsConfig = Resources.LoadAll<BuildSettings>("")[0];
        if (null == settingsConfig)
        {
            Debug.LogError($"Scene config {settingsConfig.name} can't be found!");
            return;
        }

        EditorUtility.OpenPropertyEditor(settingsConfig);
    }
#endif
}