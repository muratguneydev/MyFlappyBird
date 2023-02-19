using UnityEngine;

namespace FlappyBird
{
	public class PipeSpawnerScript : MonoBehaviour
	{
		public GameObject pipe;
		public float spawnRate = 2;
		private float timer = 0;
		public float heightOffset = 10;

		// Start is called before the first frame update
		void Start()
		{
			SpawnPipe();
		}

		// Update is called once per frame
		void Update()
		{
			if (timer < spawnRate)
				timer += Time.deltaTime;
			else
			{
				SpawnPipe();
				timer = 0;
			}
		}

		private void SpawnPipe()
		{
			// var lowestPoint = transform.position.y - heightOffset;
			// var highestPoint = transform.position.y + heightOffset;
			// var randomY = Random.Range(lowestPoint, highestPoint);
			// var position = 

			Instantiate(pipe, transform.position, transform.rotation);
		}
	}
}