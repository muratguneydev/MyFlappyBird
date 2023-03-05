using FlappyBird;
using FlappyBird.Events;
using UnityEngine;
using Zenject;
public class CoreInstaller : Installer//<GameObject, CoreInstaller>
{
    public override void InstallBindings()
    {
		Container.Bind<Jumper>().AsSingle().NonLazy();



		SignalBusInstaller.Install(Container);
		Container.Bind<IEventBus>().To<EventBus>().AsSingle();

		Container.DeclareSignal<GoneThroughPipesSignal>();
		Container.DeclareSignal<ObjectMovedSignal>();
		//.CopyIntoAllSubContainers();

		Debug.Log("ObjectMovedSignal subscribe start");
		Container.BindSignal<ObjectMovedSignal>()
            .ToMethod<Destroyer>(x => x.OnObjectMoved)
			.FromResolve();
		Debug.Log("ObjectMovedSignal subscribed");

		// Container.BindSignal<GoneThroughPipesSignal>()
		// 	.ToMethod<Score>(x => x.Increment).FromResolve();
		Container.BindInterfacesTo<GameInitializer>().AsSingle();

    }
}