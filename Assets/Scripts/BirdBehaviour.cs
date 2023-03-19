using FlappyBird.Events;
using UnityEngine;
using Zenject;

namespace FlappyBird
{
	[RequireComponent(typeof(Rigidbody2D))]
	public class BirdBehaviour : MonoBehaviour
	{
		[SerializeField] private GameObject _gameOverScreen;
		
		private Rigidbody2D _rigidBody;
		private KeyInput _keyInput;
		private IEventBus _eventBus;
		private bool _isGameOver;

		private JumperFactory _jumperFactory;

		[Inject]
        public virtual void Construct(IEventBus eventBus, JumperFactory jumperFactory)
        {
            _eventBus = eventBus;
			_eventBus.Subscribe<GameResetSignal>(OnGameReset);
			_eventBus.Subscribe<GameOverSignal>(OnGameOver);

			_jumperFactory = jumperFactory;//Note: JumperFactory is used here to take out the logic from MonoBehaviour and leave it as humble object.
        }

		void Start()
		{
			_rigidBody = GetComponent<Rigidbody2D>();
		}

		void Update()
		{
			_jumperFactory
				.Get(_isGameOver)
				.Move(_rigidBody);
		}

		void OnCollisionEnter2D(Collision2D collision)
		{
			//if (collision.gameObject.GetComponent<PipeBehaviour>())
			_eventBus.Fire(new BirdHitThePipeUISignal(_gameOverScreen));//Remove parameter. Let the receiver collect what they need.
		}

		public void OnGameOver(GameOverSignal gameOverSignal)
		{
			_isGameOver = true;
		}

		public void OnGameReset(GameResetSignal gameResetSignal)
		{
			_isGameOver = false;
		}
	}
}
