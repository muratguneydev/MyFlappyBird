using FlappyBird;
using Zenject;

public class MainSceneDependencyRegistrar : MonoInstaller
{
    public override void InstallBindings()
    {
		Container.Bind<Jumper>().AsSingle().NonLazy();
    }
}