using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] private Scene _scene;
    [SerializeField] private GameplayUI _gamplayUI;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<ScenesController>().AsSingle().WithArguments(_scene);

        Container.BindInterfacesAndSelfTo<SceneGameplayUIMediator>().AsSingle().WithArguments(_gamplayUI);
    }
}
