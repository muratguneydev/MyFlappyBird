using FlappyBird;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "SettingsInstaller", menuName = "Installers/SettingsInstaller")]
public class SettingsInstaller : ScriptableObjectInstaller<SettingsInstaller>
{
	public PipeSettings PipeSettings;
	public PipeSpawnerSettings PipeSpawnerSettings;
	public BirdSettings BirdSettings;

    public override void InstallBindings()
    {
            Container.BindInstance(PipeSettings);
            Container.BindInstance(PipeSpawnerSettings);
            Container.BindInstance(BirdSettings);
    }
}