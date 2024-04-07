using VRConcepts.Runtime.Utilities;
using Zenject;

public class BootstrapSceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<OrientationHelper>().AsSingle().NonLazy();
    }
}
