using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "SettingsInstaller", menuName = "Installers/SettingsInstaller")]
public class SettingsInstaller : ScriptableObjectInstaller<SettingsInstaller>
{
	public MainSceneDependencyRegistrar.Settings GameInstaller;

    public override void InstallBindings()
    {
            Container.BindInstance(GameInstaller);

    }
}