using UnityEngine;
using Zenject;

namespace FlappyBird
{
	//To avoid dependency on the play mode and creating MonoBehavour objects, we use Zenject's interfaces. Tick() is the same as MonoBevour's Update and Initialize as Start.
	public class PipeSpawner : ITickable, IInitializable
	{
		private GameTimer _timer;
		private YPositionRandomizer _yPositionRandomizer;
		private Pipe.Factory _pipeFactory;
		private readonly PipeSpawnerSettings _pipeSpawnerSettings;

		public PipeSpawner(Pipe.Factory pipeFactory, PipeSpawnerSettings pipeSpawnerSettings)
        {
            _pipeFactory = pipeFactory;
			_pipeSpawnerSettings = pipeSpawnerSettings;
		}

		public void Initialize()
		{
			_timer = new GameTimer(_pipeSpawnerSettings.SpawnFrequencySeconds, SpawnNext);
			_yPositionRandomizer = new YPositionRandomizer(_pipeSpawnerSettings.HeightOffset);
			SpawnNext();
		}

		public void Tick()
		{
			_timer.Tick(Time.deltaTime);
		}

		private void SpawnNext()
		{
			var pipe = _pipeFactory.Create();
			var randomY = _yPositionRandomizer.Get(_pipeSpawnerSettings.StartPositionY);
			pipe.transform.position = new Vector3(_pipeSpawnerSettings.StartPositionX, randomY, 0);
		}
	}
}
