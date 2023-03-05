using FlappyBird;
using FlappyBird.Events;
using UnityEngine;
using Zenject;
public class CoreInstaller : Installer
{
    public override void InstallBindings()
    {
		Container.Bind<Jumper>().AsSingle().NonLazy();
		Container.Bind<Destroyer>()
			//.FromInstance(new Destroyer(-23))
			.AsSingle();
		Container.BindInstance(-23f).WhenInjectedInto<Destroyer>();

		Container.BindInterfacesAndSelfTo<PipeSpawner>().AsSingle();
		// Container.BindFactory<Pipe, Pipe.Factory>()
		// 		// This means that any time Asteroid.Factory.Create is called, it will instantiate
		// 		// this prefab and then search it for the Asteroid component
		// 		.FromComponentInNewPrefab(_settings.PipePrefab)
		// 		// We can also tell Zenject what to name the new gameobject here
		// 		.WithGameObjectName("Pipe")
		// 		// GameObjectGroup's are just game objects used for organization
		// 		// This is nice so that it doesn't clutter up our scene hierarchy
		// 		.UnderTransformGroup("Pipes");


		SignalBusInstaller.Install(Container);

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