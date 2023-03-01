using FlappyBird;
using FlappyBird.Events;
using Zenject;

public class MainSceneDependencyRegistrar : MonoInstaller
{
    public override void InstallBindings()
    {
		Container.Bind<Jumper>().AsSingle().NonLazy();



		SignalBusInstaller.Install(Container);

        Container.DeclareSignal<GoneThroughPipesSignal>();

        Container.Bind<Score>().AsSingle();
        //Container.Bind<PipeMiddle>().AsSingle();

        Container.BindSignal<GoneThroughPipesSignal>()
            .ToMethod<Score>(x => x.Increment).FromResolve();

        //Container.BindInterfacesTo<PipeMiddle>().AsSingle();
    }
}