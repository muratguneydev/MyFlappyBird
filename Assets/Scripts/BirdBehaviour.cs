using FlappyBird.Events;
using UnityEngine;
using Zenject;

namespace FlappyBird
{
	[RequireComponent(typeof(Rigidbody2D))]
	public class BirdBehaviour : MonoBehaviour
	{
		[SerializeField] private GameObject _gameOverScreen;
		private Jumper _jumper;
		private Rigidbody2D _rigidBody;
		private KeyInput _keyInput;
		private IEventBus _eventBus;

		[Inject]
        public virtual void Construct(IEventBus eventBus, Jumper jumper, KeyInput keyInput)
        {
            _eventBus = eventBus;
			_jumper = jumper;
			_rigidBody = GetComponent<Rigidbody2D>();
			_keyInput = keyInput;
        }

		void Update()
		{
			if (_keyInput.GetKeyDown(KeyCode.Space))
				_jumper.Move(_rigidBody);
		}

		private void OnCollisionEnter2D(Collision2D collision)
		{
			//if (collision.gameObject.GetComponent<PipeBehaviour>())
			_eventBus.Fire(new BirdHitThePipeSignal(_gameOverScreen));
		}
	}
}
