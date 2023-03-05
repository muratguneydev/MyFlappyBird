using FlappyBird;
using FlappyBird.Events;
using Zenject;
public class CoreInstaller : Installer
{
    public override void InstallBindings()
    {
		Container.Bind<Jumper>().AsSingle().NonLazy();

		SignalBusInstaller.Install(Container);
		Container.Bind<IEventBus>().To<EventBus>().AsSingle();

		Container.DeclareSignal<GoneThroughPipesSignal>();
		Container.DeclareSignal<ObjectMovedSignal>();

		Container.BindSignal<ObjectMovedSignal>()
            .ToMethod<Destroyer>(x => x.OnObjectMoved)
			.FromResolve();

		Container.BindInterfacesTo<GameInitializer>().AsSingle();

		Container.Bind<ScoreManager>().AsSingle();
		Container.BindSignal<GoneThroughPipesSignal>()
            .ToMethod<ScoreManager>(x => x.Increment)
			.FromResolve();
    }
}