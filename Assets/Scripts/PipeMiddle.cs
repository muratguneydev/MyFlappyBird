using FlappyBird.Events;
using UnityEngine;
using Zenject;

namespace FlappyBird
{
	public class PipeMiddle : MonoBehaviour
	{
		private IEventBus _eventBus;

		[Inject]
        public void Construct(IEventBus eventBus)
        {
			Debug.Log("Constructed PipeMiddle.");
            _eventBus = eventBus;
        }

		private void OnTriggerEnter2D(Collider2D collision)
		{
			_eventBus.Fire(new GoneThroughPipesSignal());
		}
	}
}