using FlappyBird.Events;
using UnityEngine;
using Zenject;

namespace FlappyBird
{
	public class PipeMiddle : MonoBehaviour
	{
		// Start is called before the first frame update
		//private Score _score;
		private SignalBus _signalBus;

		[Inject]
        public void Construct(SignalBus signalBus)
        {
			Debug.Log("Constructed PipeMiddle.");
            _signalBus = signalBus;
        }

		void Start()
		{
			//_score = GameObject.FindGameObjectWithTag("ScoreTag").GetComponent<Score>();
		}

		// Update is called once per frame
		void Update()
		{

		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
			//_score.Increment();
			_signalBus.Fire(new GoneThroughPipesSignal());
		}
	}
}