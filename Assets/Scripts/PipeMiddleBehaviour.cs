using FlappyBird.Events;
using UnityEngine;
using Zenject;

namespace FlappyBird
{
	public class PipeMiddleBehaviour : MonoBehaviour
	{
		private IEventBus _eventBus;

		[Inject]
        public void Construct(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

		private void OnTriggerEnter2D(Collider2D collision)
		{
			//Add a layer to the bird and use that layer number here.
			if (collision.gameObject.layer == 3)
				_eventBus.Fire(new GoneThroughPipesSignal());
		}
	}
}