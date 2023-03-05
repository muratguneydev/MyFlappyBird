using FlappyBird;
using Zenject;

public class BirdInstaller : Installer<BirdSettings, BirdInstaller>
{
	private readonly BirdSettings _birdSettings;

	public BirdInstaller(BirdSettings birdSettings)
	{
		_birdSettings = birdSettings;
	}
	public override void InstallBindings()
	{
		Container.Bind<Jumper>().AsSingle().WithArguments(_birdSettings.JumpUpVelocity).NonLazy();
	}
}