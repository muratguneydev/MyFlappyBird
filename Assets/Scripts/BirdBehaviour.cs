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
		private bool _canJump = true;

		[Inject]
        public virtual void Construct(IEventBus eventBus, Jumper jumper, KeyInput keyInput)
        {
            _eventBus = eventBus;
			_eventBus.Subscribe<GameResetSignal>(OnGameReset);
			_eventBus.Subscribe<GameOverSignal>(OnGameOver);

			_jumper = jumper;
			_keyInput = keyInput;
        }

		void Start()
		{
			_rigidBody = GetComponent<Rigidbody2D>();
		}

		void Update()
		{
			if (_canJump && _keyInput.GetKeyDown(KeyCode.Space))
				_jumper.Move(_rigidBody);
		}

		void OnCollisionEnter2D(Collision2D collision)
		{
			//if (collision.gameObject.GetComponent<PipeBehaviour>())
			_eventBus.Fire(new BirdHitThePipeUISignal(_gameOverScreen));//Remove parameter. Let the receiver collect what they need.
		}

		public void OnGameOver(GameOverSignal gameOverSignal)
		{
			_canJump = false;
		}

		public void OnGameReset(GameResetSignal gameResetSignal)
		{
			_canJump = true;
		}
	}
}
