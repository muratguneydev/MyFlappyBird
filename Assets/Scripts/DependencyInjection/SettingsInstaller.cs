using FlappyBird;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "SettingsInstaller", menuName = "Installers/SettingsInstaller")]
public class SettingsInstaller : ScriptableObjectInstaller<SettingsInstaller>
{
	public PipeSettings GameInstaller;
	public PipeSpawnerSettings PipeSpawnerSettings;

    public override void InstallBindings()
    {
            Container.BindInstance(GameInstaller);
            Container.BindInstance(PipeSpawnerSettings);
    }
}