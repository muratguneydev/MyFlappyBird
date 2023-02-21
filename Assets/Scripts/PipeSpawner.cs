using UnityEngine;

namespace FlappyBird
{
	public class PipeSpawner : MonoBehaviour
	{
		[SerializeField] private GameObject _pipe;
		[SerializeField] private float heightOffset = 10;
		private GameTimer _timer;
		private YPositionRandomizer _yPositionRandomizer;

		// Start is called before the first frame update
		void Start()
		{
			_timer = new GameTimer(4, SpawnPipe);
			_yPositionRandomizer = new YPositionRandomizer(heightOffset);
			SpawnPipe();
		}

		// Update is called once per frame
		void Update()
		{
			_timer.Tick(Time.deltaTime);
		}

		private void SpawnPipe()
		{
			var randomY = _yPositionRandomizer.Get(transform.position.y);
			Instantiate(_pipe, new Vector3(transform.position.x, randomY, 0), transform.rotation);
		}
	}
}
