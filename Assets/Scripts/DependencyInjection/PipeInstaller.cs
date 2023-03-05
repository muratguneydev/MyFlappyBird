using FlappyBird;
using UnityEngine;
using Zenject;

public class PipeInstaller : Installer<GameObject, float, PipeInstaller>
{
	private readonly GameObject _pipePrefab;
	private readonly float _deadZoneX;

	public PipeInstaller(GameObject pipePrefab, float deadZoneX)
	{
		_pipePrefab = pipePrefab;
		_deadZoneX = deadZoneX;
	}
	public override void InstallBindings()
	{
		Container.Bind<ObjectDestroyer>().AsSingle();
		Container.Bind<Destroyer>()
			//.FromInstance(new Destroyer(-23))
			.AsSingle();
		Container.BindInstance(_deadZoneX).WhenInjectedInto<Destroyer>();

		Container.BindFactory<Pipe, Pipe.Factory>()
				// This means that any time Pipe.Factory.Create is called, it will instantiate
				// this prefab and then search it for the Pipe component
				.FromComponentInNewPrefab(_pipePrefab)
				// We can also tell Zenject what to name the new gameobject here
				.WithGameObjectName("Pipe")
				// GameObjectGroup's are just game objects used for organization
				// This is nice so that it doesn't clutter up our scene hierarchy
				.UnderTransformGroup("Pipes");
		Container.BindInterfacesAndSelfTo<PipeSpawner>().AsSingle();
		
	}
}