using FlappyBird;
using Zenject;

public class PipeInstaller : Installer<PipeSettings, PipeSpawnerSettings, PipeInstaller>
{
	private readonly PipeSettings _pipeSettings;
	private readonly PipeSpawnerSettings _pipeSpawnerSettings;

	public PipeInstaller(PipeSettings pipeSettings, PipeSpawnerSettings pipeSpawnerSettings)
	{
		_pipeSettings = pipeSettings;
		_pipeSpawnerSettings = pipeSpawnerSettings;
	}
	public override void InstallBindings()
	{
		Container.Bind<ObjectDestroyer>().AsSingle();
		Container.Bind<Destroyer>()
			//.FromInstance(new Destroyer(-23))
			.AsSingle();
		Container.BindInstance(_pipeSettings.PipeDeadZoneX).WhenInjectedInto<Destroyer>();

		Container.BindFactory<Pipe, Pipe.Factory>()
				// This means that any time Pipe.Factory.Create is called, it will instantiate
				// this prefab and then search it for the Pipe component
				.FromComponentInNewPrefab(_pipeSettings.PipePrefab)
				// We can also tell Zenject what to name the new gameobject here
				.WithGameObjectName("Pipe")
				// GameObjectGroup's are just game objects used for organization
				// This is nice so that it doesn't clutter up our scene hierarchy
				.UnderTransformGroup("Pipes");
		Container.BindInterfacesAndSelfTo<PipeSpawner>().AsSingle();
		
	}
}
