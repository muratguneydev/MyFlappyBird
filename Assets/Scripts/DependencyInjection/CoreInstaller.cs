using FlappyBird;
using FlappyBird.Events;
using Zenject;
public class CoreInstaller : Installer
{
    public override void InstallBindings()
    {
		SignalBusInstaller.Install(Container);
		Container.Bind<IEventBus>().To<EventBus>().AsSingle();

		Container.BindInterfacesTo<GameInitializer>().AsSingle();
		Container.Bind<DeltaTime>().AsSingle();

		Container.Bind<ScoreManager>().AsSingle();
		Container.BindSignal<GoneThroughPipesSignal>()
            .ToMethod<ScoreManager>(x => x.Increment)
			.FromResolve();
    }
}