using System;
using FlappyBird;
using FlappyBird.Events;
using UnityEngine;
using Zenject;

public class MainSceneDependencyRegistrar : MonoInstaller
{
	[Inject]
	Settings _settings = null;

	public override void InstallBindings()
	{
		Container.Bind<Jumper>().AsSingle().NonLazy();


		Container.BindInterfacesAndSelfTo<PipeSpawner>().AsSingle();
		Container.BindFactory<PipeMove, PipeMove.Factory>()
				// This means that any time Asteroid.Factory.Create is called, it will instantiate
				// this prefab and then search it for the Asteroid component
				.FromComponentInNewPrefab(_settings.PipePrefab)
				// We can also tell Zenject what to name the new gameobject here
				.WithGameObjectName("Pipe")
				// GameObjectGroup's are just game objects used for organization
				// This is nice so that it doesn't clutter up our scene hierarchy
				.UnderTransformGroup("Pipes");


		SignalBusInstaller.Install(Container);

		Container.DeclareSignal<GoneThroughPipesSignal>();

		// Container.BindSignal<GoneThroughPipesSignal>()
		// 	.ToMethod<Score>(x => x.Increment).FromResolve();

	}

	[Serializable]
	public class Settings
	{
		public GameObject PipePrefab;

	}
}