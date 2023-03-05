using UnityEngine;
using Zenject;

namespace FlappyBird
{
	public class PipeSpawner2 : ITickable, IInitializable
	{
		private GameTimer _timer;
		private YPositionRandomizer _yPositionRandomizer;
		private Pipe.Factory _pipeFactory;
		private readonly PipeSpawnerSettings _pipeSpawnerSettings;

		public PipeSpawner2(Pipe.Factory pipeFactory, PipeSpawnerSettings pipeSpawnerSettings)
        {
            _pipeFactory = pipeFactory;
			_pipeSpawnerSettings = pipeSpawnerSettings;
			Debug.Log($"Height offset:{pipeSpawnerSettings.HeightOffset}");
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
