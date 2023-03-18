using FlappyBird;
using FlappyBird.Events;
using Zenject;
public class CoreInstaller : Installer
{
    public override void InstallBindings()
    {
		SignalBusInstaller.Install(Container);
		Container.Bind<IEventBus>().To<EventBus>().AsSingle();
		
		Container.DeclareSignal<OnResetButtonClickedUISignal>();
		Container.BindSignal<OnResetButtonClickedUISignal>()
            .ToMethod<GameController>(x => x.OnResetButtonClicked)
			.FromResolve();

		Container.DeclareSignal<GameResetSignal>();
		// Container.BindSignal<GameResetSignal>()
        //     .ToMethod<BirdBehaviour>(x => x.OnGameReset)
		// 	.FromResolve();

		Container.DeclareSignal<GameOverSignal>();
		// Container.BindSignal<GameOverSignal>()
        //     .ToMethod<BirdBehaviour>(x => x.OnGameOver)
		// 	.FromResolve();

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