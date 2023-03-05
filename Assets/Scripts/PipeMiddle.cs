using FlappyBird.Events;
using UnityEngine;
using Zenject;

namespace FlappyBird
{
	public class PipeMiddle : MonoBehaviour
	{
		private SignalBus _signalBus;

		[Inject]
        public void Construct(SignalBus signalBus)
        {
			Debug.Log("Constructed PipeMiddle.");
            _signalBus = signalBus;
        }

		private void OnTriggerEnter2D(Collider2D collision)
		{
			_signalBus.Fire(new GoneThroughPipesSignal());
		}
	}
}