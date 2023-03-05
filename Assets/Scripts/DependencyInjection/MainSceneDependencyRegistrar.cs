using FlappyBird;
using Zenject;

public class MainSceneDependencyRegistrar : MonoInstaller
{
	[Inject] PipeSettings _pipeSettings;
	[Inject] PipeSpawnerSettings _pipeSpawnerSettings;
	[Inject] BirdSettings _birdSettings;

	//https://github.com/modesttree/Zenject/blob/master/Documentation/CheatSheet.md
	public override void InstallBindings()
	{
		Container.Install<CoreInstaller>();
		PipeInstaller.Install(Container, _pipeSettings, _pipeSpawnerSettings);
		//Container.Bind<Foo>().AsSingle().WithArguments(_value);
		BirdInstaller.Install(Container, _birdSettings);
	}
}
