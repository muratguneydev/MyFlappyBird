using UnityEngine;
using Zenject;

namespace FlappyBird
{
	public class PipeSpawner : IInitializable, IInvokable
	{
		private YPositionRandomizer _yPositionRandomizer;
		private PipeBehaviour.Factory _pipeFactory;
		private readonly PipeSpawnerSettings _pipeSpawnerSettings;

		public PipeSpawner(PipeBehaviour.Factory pipeFactory, PipeSpawnerSettings pipeSpawnerSettings,
			YPositionRandomizer yPositionRandomizer)
        {
            _pipeFactory = pipeFactory;
			_pipeSpawnerSettings = pipeSpawnerSettings;
			_yPositionRandomizer = yPositionRandomizer;
		}

		public void Initialize()
		{
			SpawnNext();
		}

		public void Invoke()
		{
			SpawnNext();
		}

		private void SpawnNext()
		{
			var pipe = _pipeFactory.Create();
			var randomY = _yPositionRandomizer.Get(_pipeSpawnerSettings.StartPositionY);
			pipe.transform.position = new Vector3(_pipeSpawnerSettings.StartPositionX, randomY, 0);
		}

		
	}
}
