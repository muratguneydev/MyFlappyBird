using UnityEngine;
using Zenject;

namespace FlappyBird
{
	public class PipeSpawner : MonoBehaviour
	{
		[SerializeField] private GameObject _pipe;
		[SerializeField] private float heightOffset = 10;
		private GameTimer _timer;
		private YPositionRandomizer _yPositionRandomizer;
		private Pipe.Factory _factory;

		[Inject]
        public void Construct(Pipe.Factory factory)
        {
			Debug.Log("Constructed Spawner.");

            _factory = factory;
        }

		// Start is called before the first frame update
		void Start()
		{
			_timer = new GameTimer(4, SpawnNext);
			_yPositionRandomizer = new YPositionRandomizer(heightOffset);
			SpawnNext();
		}

		// Update is called once per frame
		void Update()
		{
			_timer.Tick(Time.deltaTime);
		}

		private void SpawnNext()
		{
			var pipe = _factory.Create();
			var randomY = _yPositionRandomizer.Get(transform.position.y);
			pipe.transform.position = new Vector3(transform.position.x, randomY, 0);
		}
	}
}
