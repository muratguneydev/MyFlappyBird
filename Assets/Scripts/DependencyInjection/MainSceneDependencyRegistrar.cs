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
		PipeInstaller.Install(Container, _settings.PipePrefab, _settings.PipeDeadZoneX);
		//Container.Bind<Foo>().AsSingle().WithArguments(_value);
	}

	[Serializable]
	public class Settings
	{
		public Settings(GameObject pipe)
		{
			PipePrefab = pipe;
		}
		public GameObject PipePrefab;
		public float PipeDeadZoneX;
	}
}
