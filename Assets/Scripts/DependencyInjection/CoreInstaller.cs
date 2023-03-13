using FlappyBird;
using FlappyBird.Events;
using Zenject;
public class CoreInstaller : Installer
{
    public override void InstallBindings()
    {
		SignalBusInstaller.Install(Container);
		Container.Bind<IEventBus>().To<EventBus>().AsSingle();
		
		Container.DeclareSignal<GameResetSignal>();
		Container.BindSignal<GameResetSignal>()
            .ToMethod<GameController>(x => x.OnReset)
			.FromResolve();

		Container.BindInterfacesTo<GameInitializer>().AsSingle();
		Container.Bind<GameController>().AsSingle();
		Container.Bind<DeltaTime>().AsSingle();
		Container.Bind<KeyInput>().AsSingle();

		Container.Bind<ScoreManager>().AsSingle();
		Container.BindSignal<GoneThroughPipesSignal>()
            .ToMethod<ScoreManager>(x => x.Increment)
			.FromResolve();
    }
}