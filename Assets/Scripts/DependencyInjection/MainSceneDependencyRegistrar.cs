using System;
using FlappyBird;
using UnityEngine;
using Zenject;

public class MainSceneDependencyRegistrar : MonoInstaller
{
	[Inject]
	Settings _settings = null;

	//https://github.com/modesttree/Zenject/blob/master/Documentation/CheatSheet.md
	public override void InstallBindings()
	{
		Container.Install<CoreInstaller>();
		Container.BindFactory<Pipe, Pipe.Factory>()
				// This means that any time Asteroid.Factory.Create is called, it will instantiate
				// this prefab and then search it for the Asteroid component
				.FromComponentInNewPrefab(_settings.PipePrefab)
				// We can also tell Zenject what to name the new gameobject here
				.WithGameObjectName("Pipe")
				// GameObjectGroup's are just game objects used for organization
				// This is nice so that it doesn't clutter up our scene hierarchy
				.UnderTransformGroup("Pipes");
	}

	[Serializable]
	public class Settings
	{
		public Settings(GameObject pipe)
		{
			PipePrefab = pipe;
		}
		public GameObject PipePrefab;

	}
}