using UnityEngine;
using Zenject;

namespace FlappyBird
{
	public class PipeSpawner : MonoBehaviour
	{
		[SerializeField] private float heightOffset = 10;
		[SerializeField] private float spawnFrequencySeconds = 4;
		private GameTimer _timer;
		private YPositionRandomizer _yPositionRandomizer;
		private Pipe.Factory _factory;

		[Inject]
        public void Construct(Pipe.Factory factory)
        {
            _factory = factory;
        }

		void Start()
		{
			// _timer = new GameTimer(spawnFrequencySeconds, SpawnNext);
			// _yPositionRandomizer = new YPositionRandomizer(heightOffset);
			// SpawnNext();
		}

		void Update()
		{
			//_timer.Tick(Time.deltaTime);
		}

		private void SpawnNext()
		{
			var pipe = _factory.Create();
			var randomY = _yPositionRandomizer.Get(transform.position.y);
			pipe.transform.position = new Vector3(transform.position.x, randomY, 0);
		}
	}
}
