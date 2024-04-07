using UnityEngine.SceneManagement;

namespace VRConcepts.Runtime
{
    public static class RuntimeConstants
    {
        public static class PhysicLayers
        {
            public const string Grabbing = "Grabbing";
            public const string Grabbable = "Grabbable";
            public const string Hand = "Hand";
            public const string HandPlayer = "HandPlayer";
            public const string FaceMask = "FaceMask";
        }
        
        public static class Configs
        {
            public const string ConfigFileName = "Config";
            public const string PHOTO_PHOLDERS_NAME = "photos";
        }
    
        public static class Scenes
        {
            public static readonly int Bootstrap = SceneUtility.GetBuildIndexByScenePath("0.Bootstrap");
            public static readonly int Loading = SceneUtility.GetBuildIndexByScenePath("1.Loading");
            public static readonly int Core = SceneUtility.GetBuildIndexByScenePath("2.Core");
            public static readonly int Empty = SceneUtility.GetBuildIndexByScenePath("3.Empty");
        }
    }
}
