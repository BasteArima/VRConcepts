using UnityEngine;

namespace VRConcepts.Runtime.Utilities
{
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
        
        [Header("Platform")]
        public BuildPlatforms Platform = BuildPlatforms.PC;

        [Header("Common")]
        public bool PlayerSittingMode; // [TODO] Перенести в настройки, если будут
        public bool IsBuildWithCheats = true;
    }
}