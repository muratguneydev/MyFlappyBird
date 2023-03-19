using FlappyBird;
using FlappyBird.Events;
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
		Container.Bind<NoOpJumper>().AsSingle();
		Container.Bind<JumperFactory>()
			.FromMethod(ctx => new JumperFactory(ctx.Container.Resolve<KeyInput>(), ctx.Container.Resolve<Jumper>(), ctx.Container.Resolve<NoOpJumper>()))
			.AsSingle();

		Container.DeclareSignal<BirdHitThePipeUISignal>();
		Container.BindSignal<BirdHitThePipeUISignal>()
            .ToMethod<GameController>(x => x.OnBirdHitThePipe)
			.FromResolve();
	}
}
