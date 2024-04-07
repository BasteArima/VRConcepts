using UnityEngine;
using Zenject;

namespace VRConcepts.Runtime.Installers
{
    [CreateAssetMenu(fileName = "ScriptableObjectInstaller", menuName = "Installers/ScriptableObjectInstaller")]
    public class ScriptableObjectInstaller : ScriptableObjectInstaller<ScriptableObjectInstaller>
    {
        public override void InstallBindings()
        {
        }
    }
}