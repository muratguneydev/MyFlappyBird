using UnityEngine;

namespace FlappyBird
{
	public class PipeMiddle : MonoBehaviour
	{
		// Start is called before the first frame update
		private Score _score;

		void Start()
		{
			_score = GameObject.FindGameObjectWithTag("ScoreTag").GetComponent<Score>();
		}

		// Update is called once per frame
		void Update()
		{

		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
			_score.Increment();
		}
	}
}